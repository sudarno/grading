using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Grading.SRF
{
    public partial class findSetting : Form
    {
        public delegate void AddCategoryDelegate(string itemID);
        public AddCategoryDelegate AddItemCallback;

        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;
        public findSetting()
        {
            InitializeComponent();
        }
        private void getData(string style, string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT style.STYLEID,style.STYLENAME FROM srfsetting " +
                        "INNER JOIN style ON srfsetting.styleid=style.STYLEID WHERE style.STYLEID LIKE @styleid AND style.STYLENAME LIKE @stylename";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@styleid", "%" + txtStyleID.Text + "%");
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@stylename", "%" + txtDescription.Text + "%");
                // masterDataAdapter = new MySqlDataAdapter("select * from style where STYLEID LIKE '%" + txtStyleID.Text + "%' AND STYLENAME LIKE '%" + txtDescription.Text + "%'", connection);
                masterDataAdapter.Fill(data, "style");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "style";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnstyleID = new DataGridViewTextBoxColumn();
                ColumnstyleID.HeaderText = "styleID";
                ColumnstyleID.Width = 180;
                ColumnstyleID.DataPropertyName = "styleID";
                ColumnstyleID.Name = "styleID";
                masterDataGridView.Columns.Add(ColumnstyleID);


                DataGridViewTextBoxColumn ColumnstyleName = new DataGridViewTextBoxColumn();
                ColumnstyleName.HeaderText = "Description";
                ColumnstyleName.Width = 180;
                ColumnstyleName.DataPropertyName = "styleNAME";
                ColumnstyleName.Name = "styleNAME";
                masterDataGridView.Columns.Add(ColumnstyleName);

                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void findSetting_Load(object sender, EventArgs e)
        {
            getData(txtStyleID.Text, txtDescription.Text);
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtStyleID.Text, txtDescription.Text);
        }

        private void masterDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.masterDataGridView.Rows[e.RowIndex];
                AddItemCallback(row.Cells[0].Value.ToString());
                this.Close();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void masterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
