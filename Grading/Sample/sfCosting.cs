using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Grading.Measurement;

namespace Grading.Sample
{
    public partial class sfCosting : Form
    {
        //
       private string GStrCode = "";

        public delegate void SetParameterValueDelegate(string date1,string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
        //private string GStrCode = "";
        private string GitemsDesc = "";
        //private string GBuyerID = "";
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlCommandBuilder sqlCommandBuilder = null;

        public sfCosting()
        {
            InitializeComponent();
        }

        private void getData(DateTime date1,DateTime date2)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM sfcosting WHERE isnull(datesend)  OR DATE(datercvd) BETWEEN DATE(@date1) AND DATE(@date2)";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));
                masterDataAdapter.Fill(data, "sfcosting");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sfcosting";

                //list size

                string selectQueryStringSize = "SELECT * FROM size";

                MySqlDataAdapter sqlDataAdapterSize = new MySqlDataAdapter(selectQueryStringSize, connection);
                MySqlCommandBuilder sqlCommandBuilderSize = new MySqlCommandBuilder(sqlDataAdapterSize);

                DataTable dataTableSize = new DataTable();
                sqlDataAdapterSize.Fill(dataTableSize);
                BindingSource bindingSourceSize = new BindingSource();
                bindingSourceSize.DataSource = dataTableSize;

                //list buyer
                string selectQueryStringLW = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                DataTable dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;



                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnNo = new DataGridViewTextBoxColumn();
                ColumnNo.HeaderText = "AutoNo";
                ColumnNo.Width = 70;
                ColumnNo.DataPropertyName = "no";
                ColumnNo.Name = "no";
                ColumnNo.ReadOnly = true;
                masterDataGridView.Columns.Add(ColumnNo);

                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "styleid";
                ColumnStyle.Name = "styleid";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                masterDataGridView.Columns.Add(ColumnStyle);

                // binding
                DataGridViewComboBoxColumn ColumnSize = new DataGridViewComboBoxColumn();
                ColumnSize.HeaderText = "SIZE";
                ColumnSize.Width = 80;
                ColumnSize.DataPropertyName = "sizeid";
                ColumnSize.Name = "sizeid";
               // ColumnSize.ReadOnly = false;
                //binding
                ColumnSize.DataSource = bindingSourceSize;
                ColumnSize.ValueMember = "sizeid";
                ColumnSize.DisplayMember = "sizename";
                
                masterDataGridView.Columns.Add(ColumnSize);
                //

                DataGridViewComboBoxColumn ColumnBuyer = new DataGridViewComboBoxColumn();
                ColumnBuyer.HeaderText = "BUYER";
                ColumnBuyer.Width = 150;
                ColumnBuyer.DataPropertyName = "buyerid";
                ColumnBuyer.Name = "buyerid";
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "buyerid";
                ColumnBuyer.DisplayMember = "buyername";
                masterDataGridView.Columns.Add(ColumnBuyer);

                
                //status
                DataGridViewTextBoxColumn ColumnStatus = new DataGridViewTextBoxColumn();
                ColumnStatus.HeaderText = "Status";
                ColumnStatus.Width = 80;
                ColumnStatus.DataPropertyName = "status";
                ColumnStatus.Name = "status";
                ColumnStatus.Visible = false;
                masterDataGridView.Columns.Add(ColumnStatus);
                

                DataGridViewTextBoxColumn ColumnCrfFrom = new DataGridViewTextBoxColumn();
                ColumnCrfFrom.HeaderText = "CRF From";
                ColumnCrfFrom.Width = 80;
                ColumnCrfFrom.DataPropertyName = "crffrom";
                ColumnCrfFrom.Name = "crffrom";
                masterDataGridView.Columns.Add(ColumnCrfFrom);

                DataGridViewTextBoxColumn ColumnDateReceive = new DataGridViewTextBoxColumn();
                ColumnDateReceive.HeaderText = "Receive Date";
                ColumnDateReceive.Width = 80;
                ColumnDateReceive.DataPropertyName = "datercvd";
                ColumnDateReceive.Name = "datercvd";
                masterDataGridView.Columns.Add(ColumnDateReceive);

                DataGridViewTextBoxColumn ColumnDateSend = new DataGridViewTextBoxColumn();
                ColumnDateSend.HeaderText = "Send Date";
                ColumnDateSend.Width = 80;
                ColumnDateSend.DataPropertyName = "datesend";
                ColumnDateSend.Name = "datesend";
                masterDataGridView.Columns.Add(ColumnDateSend);

                DataGridViewButtonColumn ColumnKotak = new DataGridViewButtonColumn();
                ColumnKotak.HeaderText = "Box";
                ColumnKotak.Width = 40;
                ColumnKotak.DataPropertyName = "box";
                ColumnKotak.Name = "box";
                masterDataGridView.Columns.Add(ColumnKotak);
                
                
                DataGridViewTextBoxColumn ColumnConsp = new DataGridViewTextBoxColumn();
                ColumnConsp.HeaderText = "Consumption";
                ColumnConsp.Width = 80;
                ColumnConsp.DataPropertyName = "consp";
                ColumnConsp.Name = "consp";
                ColumnConsp.Visible=false;
                masterDataGridView.Columns.Add(ColumnConsp);

                DataGridViewTextBoxColumn ColumnWidth = new DataGridViewTextBoxColumn();
                ColumnWidth.HeaderText = "Width";
                ColumnWidth.Width = 80;
                ColumnWidth.DataPropertyName = "width";
                ColumnWidth.Name = "width";
                ColumnWidth.Visible=false;
                masterDataGridView.Columns.Add(ColumnWidth);
                 

                DataGridViewTextBoxColumn ColumnFabric = new DataGridViewTextBoxColumn();
                ColumnFabric.HeaderText = "Fabric";
                ColumnFabric.Width = 80;
                ColumnFabric.DataPropertyName = "fabric";
                ColumnFabric.Name = "fabric";
                masterDataGridView.Columns.Add(ColumnFabric);


                DataGridViewTextBoxColumn ColumnDoneBy = new DataGridViewTextBoxColumn();
                ColumnDoneBy.HeaderText = "Done By";
                ColumnDoneBy.Width = 80;
                ColumnDoneBy.DataPropertyName = "doneby";
                ColumnDoneBy.Name = "doneby";
                masterDataGridView.Columns.Add(ColumnDoneBy);

                DataGridViewTextBoxColumn ColumnRemark = new DataGridViewTextBoxColumn();
                ColumnRemark.HeaderText = "Remark";
                ColumnRemark.Width = 80;
                ColumnRemark.DataPropertyName = "remark";
                ColumnRemark.Name = "remark";
                masterDataGridView.Columns.Add(ColumnRemark);

                DataGridViewTextBoxColumn ColumnDesc = new DataGridViewTextBoxColumn();
                ColumnDesc.HeaderText = "Desc";
                ColumnDesc.Width = 80;
                ColumnDesc.DataPropertyName = "desc";
                ColumnDesc.Name = "desc";
                ColumnDesc.Visible = false;
                masterDataGridView.Columns.Add(ColumnDesc);

                DataGridViewTextBoxColumn ColumnColor = new DataGridViewTextBoxColumn();
                ColumnColor.HeaderText = "Color";
                ColumnColor.Width = 80;
                ColumnColor.DataPropertyName = "color";
                ColumnColor.Name = "color";
                ColumnColor.Visible = false;
                masterDataGridView.Columns.Add(ColumnColor);

             

                masterDataGridView.DataSource = masterBindingSource;

                //display index
                /*
               // masterDataGridView.Columns["no"].DisplayIndex = 0;
               // masterDataGridView.Columns["styleid"].DisplayIndex =1 ;
                masterDataGridView.Columns["sizeid"].DisplayIndex = 2;
                masterDataGridView.Columns["buyerid"].DisplayIndex = 3;
                masterDataGridView.Columns["status"].DisplayIndex = 4;
                masterDataGridView.Columns["crffrom"].DisplayIndex = 5;
                masterDataGridView.Columns["datercvd"].DisplayIndex = 6;
                masterDataGridView.Columns["datesend"].DisplayIndex = 7;
                masterDataGridView.Columns["box"].DisplayIndex = 8;
                 */
            



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void getDataFind()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM sfcosting WHERE no LIKE @DocNo AND styleid LIKE @styleid";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@styleid", "%" + txtStyle.Text + "%");
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DocNo", "%" + txtDocNo.Text + "%");
                masterDataAdapter.Fill(data, "sfcosting");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sfcosting";

                //list buyer
                string selectQueryStringLW = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                DataTable dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;

                //list size

                string selectQueryStringSize = "SELECT * FROM size";

                MySqlDataAdapter sqlDataAdapterSize = new MySqlDataAdapter(selectQueryStringSize, connection);
                MySqlCommandBuilder sqlCommandBuilderSize = new MySqlCommandBuilder(sqlDataAdapterSize);

                DataTable dataTableSize = new DataTable();
                sqlDataAdapterSize.Fill(dataTableSize);
                BindingSource bindingSourceSize = new BindingSource();
                bindingSourceSize.DataSource = dataTableSize;


                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnNo = new DataGridViewTextBoxColumn();
                ColumnNo.HeaderText = "AutoNo";
                ColumnNo.Width = 70;
                ColumnNo.DataPropertyName = "no";
                ColumnNo.Name = "no";
                ColumnNo.ReadOnly = true;
                masterDataGridView.Columns.Add(ColumnNo);

                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "styleid";
                ColumnStyle.Name = "styleid";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                masterDataGridView.Columns.Add(ColumnStyle);

                // binding
                DataGridViewComboBoxColumn ColumnSize = new DataGridViewComboBoxColumn();
                ColumnSize.HeaderText = "SIZE";
                ColumnSize.Width = 80;
                ColumnSize.DataPropertyName = "sizeid";
                ColumnSize.Name = "sizeid";
                // ColumnSize.ReadOnly = false;
                //binding
                ColumnSize.DataSource = bindingSourceSize;
                ColumnSize.ValueMember = "sizeid";
                ColumnSize.DisplayMember = "sizename";

                masterDataGridView.Columns.Add(ColumnSize);
                //

                DataGridViewComboBoxColumn ColumnBuyer = new DataGridViewComboBoxColumn();
                ColumnBuyer.HeaderText = "BUYER";
                ColumnBuyer.Width = 150;
                ColumnBuyer.DataPropertyName = "buyerid";
                ColumnBuyer.Name = "buyerid";
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "buyerid";
                ColumnBuyer.DisplayMember = "buyername";
                masterDataGridView.Columns.Add(ColumnBuyer);


                //status
                DataGridViewTextBoxColumn ColumnStatus = new DataGridViewTextBoxColumn();
                ColumnStatus.HeaderText = "Status";
                ColumnStatus.Width = 80;
                ColumnStatus.DataPropertyName = "status";
                ColumnStatus.Name = "status";
                ColumnStatus.Visible = false;
                masterDataGridView.Columns.Add(ColumnStatus);


                DataGridViewTextBoxColumn ColumnCrfFrom = new DataGridViewTextBoxColumn();
                ColumnCrfFrom.HeaderText = "CRF From";
                ColumnCrfFrom.Width = 80;
                ColumnCrfFrom.DataPropertyName = "crffrom";
                ColumnCrfFrom.Name = "crffrom";
                masterDataGridView.Columns.Add(ColumnCrfFrom);

                DataGridViewTextBoxColumn ColumnDateReceive = new DataGridViewTextBoxColumn();
                ColumnDateReceive.HeaderText = "Receive Date";
                ColumnDateReceive.Width = 80;
                ColumnDateReceive.DataPropertyName = "datercvd";
                ColumnDateReceive.Name = "datercvd";
                masterDataGridView.Columns.Add(ColumnDateReceive);

                DataGridViewTextBoxColumn ColumnDateSend = new DataGridViewTextBoxColumn();
                ColumnDateSend.HeaderText = "Send Date";
                ColumnDateSend.Width = 80;
                ColumnDateSend.DataPropertyName = "datesend";
                ColumnDateSend.Name = "datesend";
                masterDataGridView.Columns.Add(ColumnDateSend);

                DataGridViewButtonColumn ColumnKotak = new DataGridViewButtonColumn();
                ColumnKotak.HeaderText = "Box";
                ColumnKotak.Width = 40;
                ColumnKotak.DataPropertyName = "box";
                ColumnKotak.Name = "box";
                masterDataGridView.Columns.Add(ColumnKotak);

                
                DataGridViewTextBoxColumn ColumnConsp = new DataGridViewTextBoxColumn();
                ColumnConsp.HeaderText = "Consumption";
                ColumnConsp.Width = 80;
                ColumnConsp.DataPropertyName = "consp";
                ColumnConsp.Name = "consp";
                ColumnConsp.Visible = false;
                masterDataGridView.Columns.Add(ColumnConsp);

                DataGridViewTextBoxColumn ColumnWidth = new DataGridViewTextBoxColumn();
                ColumnWidth.HeaderText = "Width";
                ColumnWidth.Width = 80;
                ColumnWidth.DataPropertyName = "width";
                ColumnWidth.Name = "width";
                ColumnWidth.Visible = false;
                masterDataGridView.Columns.Add(ColumnWidth);
                

                DataGridViewTextBoxColumn ColumnFabric = new DataGridViewTextBoxColumn();
                ColumnFabric.HeaderText = "Fabric";
                ColumnFabric.Width = 80;
                ColumnFabric.DataPropertyName = "fabric";
                ColumnFabric.Name = "fabric";
                masterDataGridView.Columns.Add(ColumnFabric);


                DataGridViewTextBoxColumn ColumnDoneBy = new DataGridViewTextBoxColumn();
                ColumnDoneBy.HeaderText = "Done By";
                ColumnDoneBy.Width = 80;
                ColumnDoneBy.DataPropertyName = "doneby";
                ColumnDoneBy.Name = "doneby";
                masterDataGridView.Columns.Add(ColumnDoneBy);

                DataGridViewTextBoxColumn ColumnRemark = new DataGridViewTextBoxColumn();
                ColumnRemark.HeaderText = "Remark";
                ColumnRemark.Width = 80;
                ColumnRemark.DataPropertyName = "remark";
                ColumnRemark.Name = "remark";
                masterDataGridView.Columns.Add(ColumnRemark);

                DataGridViewTextBoxColumn ColumnDesc = new DataGridViewTextBoxColumn();
                ColumnDesc.HeaderText = "Desc";
                ColumnDesc.Width = 80;
                ColumnDesc.DataPropertyName = "desc";
                ColumnDesc.Name = "desc";
                ColumnDesc.Visible = false;
                masterDataGridView.Columns.Add(ColumnDesc);

                DataGridViewTextBoxColumn ColumnColor = new DataGridViewTextBoxColumn();
                ColumnColor.HeaderText = "Color";
                ColumnColor.Width = 80;
                ColumnColor.DataPropertyName = "color";
                ColumnColor.Name = "color";
                ColumnColor.Visible = false;
                masterDataGridView.Columns.Add(ColumnColor);


                masterDataGridView.DataSource = masterBindingSource;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void sfCosting_Load(object sender, EventArgs e)
        {
            date1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //cmdView.PerformClick();
            getData(date1.Value.Date, date2.Value.Date);
            
            //masterDataGridView.Refresh();
            //cmdView.PerformClick();
           // cmdView_Click.
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
           getData(date1.Value.Date,date2.Value.Date);
        }

        private void SetItemsCallBack(string ItemsID,string Description)
        {
            GStrCode = ItemsID;
            GitemsDesc = Description;
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
            //box
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                 e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] == masterDataGridView.Columns["box"])
            {
               // MessageBox.Show("test bro");
                sfCostingBox f = new sfCostingBox();
                Global.GlobalCode = Convert.ToString(masterDataGridView.Rows[e.RowIndex].Cells["no"].Value);
                //GlobalCode = Convert.ToInt32(masterDataGridView.Rows[e.RowIndex].Cells["STYLEID"].Value);
                //f.AddItemCallback = new findStyle.AddCategoryDelegate(this.SetItemsCallBack);
                
                f.ShowDialog();
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "sfcosting");
                MessageBox.Show("the data has been saved");
                getData(date1.Value.Date, date2.Value.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                getData(date1.Value.Date, date2.Value.Date);
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
                masterDataAdapter.Update(data, "sfcosting");
                MessageBox.Show("the data has been deleted");
                getData(date1.Value.Date, date2.Value.Date);

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
                getData(date1.Value.Date, date2.Value.Date);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void masterDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (masterDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                masterDataGridView.Rows[e.RowIndex].Cells["datercvd"].Value = DateTime.Now.Date;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDocNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getDataFind();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            rptCosting f = new rptCosting();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void masterDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            masterDataGridView.Columns["no"].DisplayIndex = 0;
            masterDataGridView.Columns["styleid"].DisplayIndex =1 ;
            masterDataGridView.Columns["sizeid"].DisplayIndex = 2;
            masterDataGridView.Columns["buyerid"].DisplayIndex = 3;
            masterDataGridView.Columns["status"].DisplayIndex = 4;
            masterDataGridView.Columns["crffrom"].DisplayIndex = 5;
            masterDataGridView.Columns["datercvd"].DisplayIndex = 6;
            masterDataGridView.Columns["datesend"].DisplayIndex = 7;
            masterDataGridView.Columns["box"].DisplayIndex = 8;
            //masterDataGridView.Columns["desc"].Visible = false;
            //masterDataGridView.Columns["color"].Visible = false;
        }
    }
}
