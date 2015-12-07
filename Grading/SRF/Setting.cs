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
    public partial class Setting : Form
    {
        private string GStrCode = "";
        private DataSet data = null;
        private BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlCommandBuilder sqlCommandBuilder = null;

        public delegate void SetParameterValueDelegate(string date1, string date2, string status);
        public SetParameterValueDelegate SetParameterValueCallback;

        public Setting()
        {
            InitializeComponent();
        }
        private void SetItemsCallBack(string ItemsID)
        {
            GStrCode = ItemsID;
        }
        private void getData()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from srfsetting", connection);
                masterDataAdapter.Fill(data, "srfsetting");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "srfsetting";

                //list buyer
                string selectQueryStringLW = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                DataTable dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;
                
                masterDataGridView.Columns.Clear();

                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "styleid";
                ColumnStyle.Name = "styleid";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                masterDataGridView.Columns.Add(ColumnStyle);

                DataGridViewComboBoxColumn ColumnBuyer = new DataGridViewComboBoxColumn();
                ColumnBuyer.HeaderText = "BUYERID";
                ColumnBuyer.Width = 150;
                ColumnBuyer.DataPropertyName = "BUYERID";
                ColumnBuyer.Name = "BUYERID";
                ColumnBuyer.ReadOnly = false;
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "BUYERID";
                ColumnBuyer.DisplayMember = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnBuyer);

                /*
                

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
                */
                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void getData(string style)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from srfsetting where styleid LIKE @style", connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@style","%"+ style+"%");
                masterDataAdapter.Fill(data, "srfsetting");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "srfsetting";

                //list buyer
                string selectQueryStringLW = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                DataTable dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;

                masterDataGridView.Columns.Clear();

                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "styleid";
                ColumnStyle.Name = "styleid";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                masterDataGridView.Columns.Add(ColumnStyle);

                DataGridViewComboBoxColumn ColumnBuyer = new DataGridViewComboBoxColumn();
                ColumnBuyer.HeaderText = "BUYERID";
                ColumnBuyer.Width = 150;
                ColumnBuyer.DataPropertyName = "BUYERID";
                ColumnBuyer.Name = "BUYERID";
                ColumnBuyer.ReadOnly = false;
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "BUYERID";
                ColumnBuyer.DisplayMember = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnBuyer);
                //
                DataGridViewTextBoxColumn ColumnCostingStart = new DataGridViewTextBoxColumn();
                ColumnCostingStart.HeaderText = "Costing Start";
                ColumnCostingStart.Width = 80;
                ColumnCostingStart.DataPropertyName = "costingstart";
                ColumnCostingStart.Name = "costingstart";
                masterDataGridView.Columns.Add(ColumnCostingStart);

                DataGridViewTextBoxColumn ColumnCostingEnd = new DataGridViewTextBoxColumn();
                ColumnCostingEnd.HeaderText = "Costing End";
                ColumnCostingEnd.Width = 80;
                ColumnCostingEnd.DataPropertyName = "costingend";
                ColumnCostingEnd.Name = "costingend";
                masterDataGridView.Columns.Add(ColumnCostingEnd);

                DataGridViewTextBoxColumn ColumnBookingStart = new DataGridViewTextBoxColumn();
                ColumnBookingStart.HeaderText = "Booking Start";
                ColumnBookingStart.Width = 80;
                ColumnBookingStart.DataPropertyName = "bookingstart";
                ColumnBookingStart.Name = "bookingstart";
                masterDataGridView.Columns.Add(ColumnBookingStart);

                DataGridViewTextBoxColumn ColumnBookingEnd = new DataGridViewTextBoxColumn();
                ColumnBookingEnd.HeaderText = "Booking End";
                ColumnBookingEnd.Width = 80;
                ColumnBookingEnd.DataPropertyName = "bookingend";
                ColumnBookingEnd.Name = "bookingend";
                masterDataGridView.Columns.Add(ColumnBookingEnd);

                DataGridViewTextBoxColumn ColumnPatternStart = new DataGridViewTextBoxColumn();
                ColumnPatternStart.HeaderText = "Pattern Start";
                ColumnPatternStart.Width = 80;
                ColumnPatternStart.DataPropertyName = "patternstart";
                ColumnPatternStart.Name = "patternstart";
                masterDataGridView.Columns.Add(ColumnPatternStart);

                DataGridViewTextBoxColumn ColumnPatternEnd = new DataGridViewTextBoxColumn();
                ColumnPatternEnd.HeaderText = "Pattern End";
                ColumnPatternEnd.Width = 80;
                ColumnPatternEnd.DataPropertyName = "patternend";
                ColumnPatternEnd.Name = "patternend";
                masterDataGridView.Columns.Add(ColumnPatternEnd);


                DataGridViewTextBoxColumn ColumnProductionStart = new DataGridViewTextBoxColumn();
                ColumnProductionStart.HeaderText = "Production Start";
                ColumnProductionStart.Width = 80;
                ColumnProductionStart.DataPropertyName = "productionstart";
                ColumnProductionStart.Name = "productionstart";
                masterDataGridView.Columns.Add(ColumnProductionStart);

                DataGridViewTextBoxColumn ColumnProductionEnd = new DataGridViewTextBoxColumn();
                ColumnProductionEnd.HeaderText = "Production End";
                ColumnProductionEnd.Width = 80;
                ColumnProductionEnd.DataPropertyName = "productionend";
                ColumnProductionEnd.Name = "productionend";
                masterDataGridView.Columns.Add(ColumnProductionEnd);


                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            getData("");
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "srfsetting");
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
                masterDataAdapter.Update(data, "srfsetting");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtStyle.Text);
        }

        private void masterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //untuk costing
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] == masterDataGridView.Columns["STYLEID"])
            {
                GStrCode = "";
                findStyle f = new findStyle();
                f.AddItemCallback = new findStyle.AddCategoryDelegate(this.SetItemsCallBack);
                f.ShowDialog();
                if (GStrCode != "")
                {

                    masterDataGridView.Rows[e.RowIndex].Cells["STYLEID"].Value = GStrCode;

                }

            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            getData("");
        }
    }
}
