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
    public partial class frmMeasurement : Form
    {
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        public frmMeasurement()
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
                masterDataAdapter = new MySqlDataAdapter("select * from measurement", connection);
                masterDataAdapter.Fill(data, "measurement");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "measurement";

                //list buyer

                //list combo
                string selectQueryStringBuyer = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterBuyer = new MySqlDataAdapter(selectQueryStringBuyer, connection);
                MySqlCommandBuilder sqlCommandBuilderBuyer = new MySqlCommandBuilder(sqlDataAdapterBuyer);

                DataTable dataTableBuyer = new DataTable();
                sqlDataAdapterBuyer.Fill(dataTableBuyer);
                BindingSource bindingSourceBuyer = new BindingSource();
                bindingSourceBuyer.DataSource = dataTableBuyer;
                cbBuyer.DataSource = bindingSourceBuyer;
                cbBuyer.ValueMember = "BUYERID";
                cbBuyer.DisplayMember = "BUYERID";
                //add kolom grid

                masterDataGridView.DataSource = masterBindingSource;
                masterDataGridView.Columns.Clear();
                /*
                DataGridViewTextBoxColumn ColumnmMEID = new DataGridViewTextBoxColumn();
                ColumnmMEID.HeaderText = "MEID";
                ColumnmMEID.Width = 80;
                ColumnmMEID.DataPropertyName = "MEID";
                ColumnmMEID.Name = "MEID";
                masterDataGridView.Columns.Add(ColumnmMEID);


                DataGridViewTextBoxColumn ColumnMEASUREMENT = new DataGridViewTextBoxColumn();
                ColumnMEASUREMENT.HeaderText = "MEASUREMENT";
                ColumnMEASUREMENT.Width = 180;
                ColumnMEASUREMENT.DataPropertyName = "MEASUREMENT";
                ColumnMEASUREMENT.Name = "MEASUREMENT";
                masterDataGridView.Columns.Add(ColumnMEASUREMENT);
                */
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void getBuyer()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                //list combo
                string selectQueryStringBuyer = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterBuyer = new MySqlDataAdapter(selectQueryStringBuyer, connection);
                MySqlCommandBuilder sqlCommandBuilderBuyer = new MySqlCommandBuilder(sqlDataAdapterBuyer);

                DataTable dataTableBuyer = new DataTable();
                sqlDataAdapterBuyer.Fill(dataTableBuyer);
                BindingSource bindingSourceBuyer = new BindingSource();
                bindingSourceBuyer.DataSource = dataTableBuyer;

                //combo binding

                cbBuyer.DataSource = bindingSourceBuyer;
                cbBuyer.ValueMember = "BUYERID";
                cbBuyer.DisplayMember = "BUYERNAME";
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void getData(string BuyerID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from measurement Where BUYERID='"+cbBuyer.SelectedValue.ToString()+"'", connection);
                masterDataAdapter.Fill(data, "measurement");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "measurement";

                //list buyer

          
                //add kolom grid

                
                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnmBUYERID = new DataGridViewTextBoxColumn();
                ColumnmBUYERID.HeaderText = "BUYERID";
                ColumnmBUYERID.Width = 80;
                ColumnmBUYERID.DataPropertyName = "BUYERID";
                ColumnmBUYERID.Name = "BUYERID";
                ColumnmBUYERID.Visible = false;
                masterDataGridView.Columns.Add(ColumnmBUYERID);
                masterDataGridView.Columns["BUYERID"].Visible = false;
                

                
                DataGridViewTextBoxColumn ColumnmMEID = new DataGridViewTextBoxColumn();
                ColumnmMEID.HeaderText = "MEID";
                ColumnmMEID.Width = 80;
                ColumnmMEID.DataPropertyName = "MEID";
                ColumnmMEID.Name = "MEID";
                ColumnmMEID.Visible = true;
                masterDataGridView.Columns.Add(ColumnmMEID);


                DataGridViewTextBoxColumn ColumnMEASUREMENT = new DataGridViewTextBoxColumn();
                ColumnMEASUREMENT.HeaderText = "MEASUREMENT";
                ColumnMEASUREMENT.Width = 350;
                ColumnMEASUREMENT.DataPropertyName = "MEASUREMENT";
                ColumnMEASUREMENT.Name = "MEASUREMENT";
                ColumnMEASUREMENT.Visible = true;
                masterDataGridView.Columns.Add(ColumnMEASUREMENT);

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
                masterDataAdapter = new MySqlDataAdapter("select * from measurement", connection);
                masterDataAdapter.Fill(data, "measurement");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "measurement";



                //list combo
                string selectQueryStringBuyer = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterBuyer = new MySqlDataAdapter(selectQueryStringBuyer, connection);
                MySqlCommandBuilder sqlCommandBuilderBuyer = new MySqlCommandBuilder(sqlDataAdapterBuyer);

                DataTable dataTableBuyer = new DataTable();
                sqlDataAdapterBuyer.Fill(dataTableBuyer);
                BindingSource bindingSourceBuyer = new BindingSource();
                bindingSourceBuyer.DataSource = dataTableBuyer;

                //combo binding

                cbBuyer.DataSource = bindingSourceBuyer;
                cbBuyer.ValueMember = "BUYERID";
                cbBuyer.DisplayMember = "BUYERNAME";
                
                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnmBUYERID = new DataGridViewTextBoxColumn();
                ColumnmBUYERID.HeaderText = "BUYERID";
                ColumnmBUYERID.Width = 80;
                ColumnmBUYERID.DataPropertyName = "BUYERID";
                ColumnmBUYERID.Name = "BUYERID";
                masterDataGridView.Columns.Add(ColumnmBUYERID);


                DataGridViewTextBoxColumn ColumnmMEID = new DataGridViewTextBoxColumn();
                ColumnmMEID.HeaderText = "CODE";
                ColumnmMEID.Width = 80;
                ColumnmMEID.DataPropertyName = "MEID";
                ColumnmMEID.Name = "MEID";
                masterDataGridView.Columns.Add(ColumnmMEID);


                DataGridViewTextBoxColumn ColumnMEASUREMENT = new DataGridViewTextBoxColumn();
                ColumnMEASUREMENT.HeaderText = "MEASUREMENT";
                ColumnMEASUREMENT.Width = 180;
                ColumnMEASUREMENT.DataPropertyName = "MEASUREMENT";
                ColumnMEASUREMENT.Name = "MEASUREMENT";
                masterDataGridView.Columns.Add(ColumnMEASUREMENT);

                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmMeasurement_Load(object sender, EventArgs e)
        {
           getBuyer();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "measurement");
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
                masterDataAdapter.Update(data, "measurement");
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

        private void cbBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData(cbBuyer.SelectedValue.ToString());
        }

        private void masterDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //masterDataGridView.Rows[].
            if (masterDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                masterDataGridView.Rows[e.RowIndex].Cells["BUYERID"].Value = Convert.ToString(cbBuyer.SelectedValue);
            }
        }

        private void cmdStyleID_Click(object sender, EventArgs e)
        {
            
        }
    }
}
