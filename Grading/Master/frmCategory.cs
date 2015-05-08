using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Grading.Master
{
    public partial class frmCategory : Form
    {
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        public frmCategory()
        {
            InitializeComponent();
        }
        private void getData()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM category";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.Fill(data, "category");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "category";

                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnID = new DataGridViewTextBoxColumn();
                ColumnID.HeaderText = "category id";
                ColumnID.Width = 90;
                ColumnID.DataPropertyName = "categoryid";
                ColumnID.Name = "categoryid";
                masterDataGridView.Columns.Add(ColumnID);

                DataGridViewTextBoxColumn ColumnName = new DataGridViewTextBoxColumn();
                ColumnName.HeaderText = "name";
                ColumnName.Width = 90;
                ColumnName.DataPropertyName = "categoryname";
                ColumnName.Name = "categoryname";
                masterDataGridView.Columns.Add(ColumnName);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "category");
                MessageBox.Show("the data has been saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow item in this.masterDataGridView.SelectedRows)
                {
                    //masterDataGridView.Rows.RemoveAt(item.Index);
                    masterBindingSource.RemoveAt(item.Index);
                }

                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "category");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
