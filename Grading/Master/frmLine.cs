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
    public partial class frmLine : Form
    {
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        public frmLine()
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
                string strAdapter = "SELECT * FROM line";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.Fill(data, "tblline");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "tblline";

                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnID = new DataGridViewTextBoxColumn();
                ColumnID.HeaderText = "LINEID";
                ColumnID.Width = 40;
                ColumnID.DataPropertyName = "LINEID";
                ColumnID.Name = "LINEID";
                masterDataGridView.Columns.Add(ColumnID);

                DataGridViewTextBoxColumn ColumnName = new DataGridViewTextBoxColumn();
                ColumnName.HeaderText = "NAME";
                ColumnName.Width = 180;
                ColumnName.DataPropertyName = "NAME";
                ColumnName.Name = "NAME";
                masterDataGridView.Columns.Add(ColumnName);

            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmLine_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "tblline");
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
                masterDataAdapter.Update(data, "tblline");
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
