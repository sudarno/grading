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
    public partial class frmSize : Form
    {
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        public frmSize()
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
                masterDataAdapter = new MySqlDataAdapter("select * from size", connection);
                masterDataAdapter.Fill(data, "size");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "size";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnsizeID = new DataGridViewTextBoxColumn();
                ColumnsizeID.HeaderText = "sizeID";
                ColumnsizeID.Width = 80;
                ColumnsizeID.DataPropertyName = "sizeID";
                ColumnsizeID.Name = "sizeID";
                masterDataGridView.Columns.Add(ColumnsizeID);


                DataGridViewTextBoxColumn ColumnsizeName = new DataGridViewTextBoxColumn();
                ColumnsizeName.HeaderText = "sizeNAME";
                ColumnsizeName.Width = 180;
                ColumnsizeName.DataPropertyName = "sizeNAME";
                ColumnsizeName.Name = "sizeNAME";
                masterDataGridView.Columns.Add(ColumnsizeName);

                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from size", connection);
                masterDataAdapter.Fill(data, "size");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "size";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnsizeID = new DataGridViewTextBoxColumn();
                ColumnsizeID.HeaderText = "sizeID";
                ColumnsizeID.Width = 80;
                ColumnsizeID.DataPropertyName = "sizeID";
                ColumnsizeID.Name = "sizeID";
                masterDataGridView.Columns.Add(ColumnsizeID);


                DataGridViewTextBoxColumn ColumnsizeName = new DataGridViewTextBoxColumn();
                ColumnsizeName.HeaderText = "sizeNAME";
                ColumnsizeName.Width = 180;
                ColumnsizeName.DataPropertyName = "sizeNAME";
                ColumnsizeName.Name = "sizeNAME";
                masterDataGridView.Columns.Add(ColumnsizeName);

                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "size");
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
                    masterBindingSource.RemoveAt(item.Index);
                }

                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "size");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmSize_Load(object sender, EventArgs e)
        {
            getData();
        }
    }
}
