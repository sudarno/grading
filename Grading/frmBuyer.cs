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
    public partial class frmBuyer : Form
    {
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        
        public frmBuyer()
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
                masterDataAdapter = new MySqlDataAdapter("select * from buyer", connection);
                masterDataAdapter.Fill(data, "buyer");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "buyer";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnBuyerID = new DataGridViewTextBoxColumn();
                ColumnBuyerID.HeaderText = "BUYERID";
                ColumnBuyerID.Width = 80;
                ColumnBuyerID.DataPropertyName = "BUYERID";
                ColumnBuyerID.Name = "BUYERID";
                masterDataGridView.Columns.Add(ColumnBuyerID);


                DataGridViewTextBoxColumn ColumnBuyerName = new DataGridViewTextBoxColumn();
                ColumnBuyerName.HeaderText = "BUYERNAME";
                ColumnBuyerName.Width = 180;
                ColumnBuyerName.DataPropertyName = "BUYERNAME";
                ColumnBuyerName.Name = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnBuyerName);

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
                masterDataAdapter = new MySqlDataAdapter("select * from buyer", connection);
                masterDataAdapter.Fill(data, "buyer");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "buyer";
               
                //add kolom grid
                
                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnBuyerID = new DataGridViewTextBoxColumn();
                ColumnBuyerID.HeaderText = "BUYERID";
                ColumnBuyerID.Width = 80;
                ColumnBuyerID.DataPropertyName = "BUYERID";
                ColumnBuyerID.Name = "BUYERID";
                masterDataGridView.Columns.Add(ColumnBuyerID);


                DataGridViewTextBoxColumn ColumnBuyerName= new DataGridViewTextBoxColumn();
                ColumnBuyerName.HeaderText = "BUYERNAME";
                ColumnBuyerName.Width = 180;
                ColumnBuyerName.DataPropertyName = "BUYERNAME";
                ColumnBuyerName.Name = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnBuyerName);

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
                masterDataAdapter.Update(data, "buyer");
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
                masterDataAdapter.Update(data, "buyer");
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

        private void frmBuyer_Load(object sender, EventArgs e)
        {
            getData();
        }
    }
}
