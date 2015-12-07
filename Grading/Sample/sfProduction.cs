using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Grading.Sample
{
    public partial class sfProduction : Form
    {

        private string GDocNo = "";
        private string GStyleID = "";
        private string GSizeID = "";
        private string GBuyerID = "";

        public delegate void SetParameterValueDelegate(string date1,string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
        //private string GDocNo = "";

        //private string GBuyerID = "";
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlCommandBuilder sqlCommandBuilder = null;

        public sfProduction()
        {
            InitializeComponent();
        }
        private void getData(DateTime date1, DateTime date2)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM sfproduction WHERE isnull(datesend) OR DATE(datercvd) BETWEEN DATE(@date1) AND DATE(@date2)";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));
                masterDataAdapter.Fill(data, "sfproduction");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sfproduction";

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

                DataGridViewButtonColumn ColumnNo = new DataGridViewButtonColumn();
                ColumnNo.HeaderText = "Document No";
                ColumnNo.Width = 100;
                ColumnNo.DataPropertyName = "no";
                ColumnNo.Name = "no";
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
                ColumnSize.DataPropertyName = "SIZEID";
                ColumnSize.Name = "SIZEID";
                ColumnSize.ReadOnly = false;
                //binding
                ColumnSize.DataSource = bindingSourceSize;
                ColumnSize.ValueMember = "SIZEID";
                ColumnSize.DisplayMember = "SIZENAME";
                masterDataGridView.Columns.Add(ColumnSize);
                //

                DataGridViewComboBoxColumn ColumnBuyer = new DataGridViewComboBoxColumn();
                ColumnBuyer.HeaderText = "BUYER";
                ColumnBuyer.Width = 150;
                ColumnBuyer.DataPropertyName = "BUYERID";
                ColumnBuyer.Name = "BUYERID";
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "BUYERID";
                ColumnBuyer.DisplayMember = "BUYERNAME";
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


                masterDataGridView.DataSource = masterBindingSource;


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
                string strAdapter = "SELECT * FROM sfproduction WHERE no LIKE @DocNo AND styleid LIKE @styleid";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@styleid", "%" + txtStyle.Text + "%");
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DocNo", "%" + txtDocNo.Text + "%");
                masterDataAdapter.Fill(data, "sfproduction");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sfproduction";

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

                DataGridViewButtonColumn ColumnNo = new DataGridViewButtonColumn();
                ColumnNo.HeaderText = "Document No";
                ColumnNo.Width = 100;
                ColumnNo.DataPropertyName = "no";
                ColumnNo.Name = "no";
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
                ColumnSize.DataPropertyName = "SIZEID";
                ColumnSize.Name = "SIZEID";
                ColumnSize.ReadOnly = false;
                //binding
                ColumnSize.DataSource = bindingSourceSize;
                ColumnSize.ValueMember = "SIZEID";
                ColumnSize.DisplayMember = "SIZENAME";
                masterDataGridView.Columns.Add(ColumnSize);
                //

                DataGridViewComboBoxColumn ColumnBuyer = new DataGridViewComboBoxColumn();
                ColumnBuyer.HeaderText = "BUYER";
                ColumnBuyer.Width = 150;
                ColumnBuyer.DataPropertyName = "BUYERID";
                ColumnBuyer.Name = "BUYERID";
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "BUYERID";
                ColumnBuyer.DisplayMember = "BUYERNAME";
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


                masterDataGridView.DataSource = masterBindingSource;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void SetItemsCallBack(string LNo, string LStyleID, string LSizeID, string LBuyerID)
        {
            GDocNo = LNo;
            GStyleID = LStyleID;
            GSizeID = LSizeID;
            GBuyerID = LBuyerID;
        }
        private void masterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //untuk costing
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] == masterDataGridView.Columns["no"])
            {
                GDocNo = "";
                findDocNo f = new findDocNo();
                f.AddItemCallback = new findDocNo.AddCategoryDelegate(this.SetItemsCallBack);
                f.ShowDialog();
                if (GDocNo != "")
                {

                    masterDataGridView.Rows[e.RowIndex].Cells["no"].Value = GDocNo;
                    masterDataGridView.Rows[e.RowIndex].Cells["styleid"].Value = GStyleID;
                    masterDataGridView.Rows[e.RowIndex].Cells["SIZEID"].Value = GSizeID;
                    masterDataGridView.Rows[e.RowIndex].Cells["buyerid"].Value = GBuyerID;
                }

            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "sfproduction");
                MessageBox.Show("the data has been saved");
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
                masterDataAdapter.Update(data, "sfproduction");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
                getData(date1.Value.Date, date2.Value.Date);
            }
        }

        private void sfProduction_Load(object sender, EventArgs e)
        {
            date1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            getData(date1.Value.Date, date2.Value.Date);
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            getData(date1.Value.Date, date2.Value.Date);
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

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getDataFind();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            rptProduction f = new rptProduction();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }
    }
}
