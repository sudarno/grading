using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Grading
{
    public partial class findStyle : Form
    {

        public delegate void AddCategoryDelegate(string itemID, string itemDesc);
        public AddCategoryDelegate AddItemCallback;

        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        private void getData(string style, string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from style where STYLEID LIKE '%" + txtStyleID.Text + "%' AND STYLENAME LIKE '%"+txtDescription.Text+"%'", connection);
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
        private void getData()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from style", connection);
                masterDataAdapter.Fill(data, "style");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "style";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnstyleID = new DataGridViewTextBoxColumn();
                ColumnstyleID.HeaderText = "STYLE ID";
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
        public findStyle()
        {
            InitializeComponent();
        }

        private void findStyle_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void masterDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.masterDataGridView.Rows[e.RowIndex];
                AddItemCallback(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtStyleID.Text, txtDescription.Text);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
