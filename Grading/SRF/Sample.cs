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
    public partial class frmSample : Form
    {
        private string GStrCode="";
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        public delegate void SetParameterValueDelegate(string date1, string date2,string status);
        public SetParameterValueDelegate SetParameterValueCallback;

        public frmSample()
        {
            InitializeComponent();
        }
        private void SetItemsCallBack(string ItemsID)
        {
            GStrCode = ItemsID;
        }

        private void getStatus()
        {
           

            cbStatus.Items.Add("");
            cbStatus.Items.Add("SENT");
            cbStatus.Items.Add("NONE");

           // cbStatus.SelectedText = "";

        }

        private void getData(DateTime from,DateTime to,string status,string styleid)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM sample WHERE date(srfpola) BETWEEN date(@from) AND date(@to) AND status LIKE @status AND styleid LIKE @styleid";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@from",dateFrom.Value);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@to", dateTo.Value);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@status","%"+ cbStatus.Text +"%");
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@styleid", "%" + txtStyle.Text + "%");


                masterDataAdapter.Fill(data, "sample");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sample";

                
             
                masterDataGridView.DataSource = masterBindingSource;
                //list color
                string selectQueryStringCOLOR = "SELECT * FROM color";

                MySqlDataAdapter sqlDataAdapterCOLOR = new MySqlDataAdapter(selectQueryStringCOLOR, connection);
                MySqlCommandBuilder sqlCommandBuilderCOLOR = new MySqlCommandBuilder(sqlDataAdapterCOLOR);

                DataTable dataTableCOLOR = new DataTable();
                sqlDataAdapterCOLOR.Fill(dataTableCOLOR);
                BindingSource bindingSourceCOLOR = new BindingSource();
                bindingSourceCOLOR.DataSource = dataTableCOLOR;

                //list size 

                string selectQueryStringSIZEID = "SELECT SIZEID FROM size";

                MySqlDataAdapter sqlDataAdapterSIZEID = new MySqlDataAdapter(selectQueryStringSIZEID, connection);
                MySqlCommandBuilder sqlCommandBuilderSIZEID = new MySqlCommandBuilder(sqlDataAdapterSIZEID);

                DataTable dataTableSIZEID = new DataTable();
                sqlDataAdapterSIZEID.Fill(dataTableSIZEID);
                BindingSource bindingSourceSIZEID = new BindingSource();
                bindingSourceSIZEID.DataSource = dataTableSIZEID;

                //list status sent none
                string selectQueryStringStatus = "SELECT sample FROM active";

                MySqlDataAdapter sqlDataAdapterStatus = new MySqlDataAdapter(selectQueryStringStatus, connection);
                MySqlCommandBuilder sqlCommandBuilderStatus = new MySqlCommandBuilder(sqlDataAdapterStatus);

                DataTable dataTableStatus = new DataTable();
                sqlDataAdapterStatus.Fill(dataTableStatus);
                BindingSource bindingSourceStatus = new BindingSource();
                bindingSourceStatus.DataSource = dataTableStatus;

                masterDataGridView.Columns.Clear();

                //DataGridViewComboBoxColumn ColumnStyle = new DataGridViewComboBoxColumn();
                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "STYLEID";
                ColumnStyle.Name = "STYLEID";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                masterDataGridView.Columns.Add(ColumnStyle);
          
                DataGridViewComboBoxColumn ColumnColor = new DataGridViewComboBoxColumn();
                ColumnColor.HeaderText = "COLOR";
                ColumnColor.Width = 100;
                ColumnColor.DataPropertyName = "colorid";
                ColumnColor.Name = "colorid";
                ColumnColor.ReadOnly = false;
                //binding
                ColumnColor.DataSource = bindingSourceCOLOR;
                ColumnColor.ValueMember = "COLORID";
                ColumnColor.DisplayMember = "COLORNAME";

                masterDataGridView.Columns.Add(ColumnColor);

                DataGridViewComboBoxColumn SizeColumn = new DataGridViewComboBoxColumn();
                SizeColumn.HeaderText = "SIZEID";
                SizeColumn.Width = 80;
                SizeColumn.DataPropertyName = "SIZEID";
                SizeColumn.Name = "SIZEID";

                SizeColumn.DataSource = bindingSourceSIZEID;
                SizeColumn.ValueMember = "SIZEID";
                SizeColumn.DisplayMember = "SIZEID";
                masterDataGridView.Columns.Add(SizeColumn);

                DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
                statusColumn.HeaderText = "STATUS";
                statusColumn.Width = 80;
                statusColumn.DataPropertyName = "status";
                
                statusColumn.Name = "status";
                statusColumn.DataSource = bindingSourceStatus;
                statusColumn.ValueMember = "sample";
                statusColumn.DisplayMember = "sample";

                
                masterDataGridView.Columns.Add(statusColumn);


                DataGridViewTextBoxColumn QtyColumn = new DataGridViewTextBoxColumn();
                QtyColumn.HeaderText = "QTY";
                QtyColumn.Width = 80;
                QtyColumn.DataPropertyName = "qty";
                QtyColumn.Name = "qty";
                masterDataGridView.Columns.Add(QtyColumn);

                DataGridViewTextBoxColumn qtysmsColumn = new DataGridViewTextBoxColumn();
                qtysmsColumn.HeaderText = "QTY SMS";
                qtysmsColumn.Width = 80;
                qtysmsColumn.DataPropertyName = "qtysms";
                qtysmsColumn.Name = "qtysms";
                masterDataGridView.Columns.Add(qtysmsColumn);

                DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn();
                typeColumn.HeaderText = "TYPE";
                typeColumn.Width = 80;
                typeColumn.DataPropertyName = "type";
                typeColumn.Name = "type";
                masterDataGridView.Columns.Add(typeColumn);

                DataGridViewTextBoxColumn srfpolaColumn = new DataGridViewTextBoxColumn();
                srfpolaColumn.HeaderText = "SRF POLA";
                srfpolaColumn.Width = 80;
                srfpolaColumn.DataPropertyName = "srfpola";
                srfpolaColumn.Name = "srfpola";
                masterDataGridView.Columns.Add(srfpolaColumn);


                DataGridViewTextBoxColumn srfsampleColumn = new DataGridViewTextBoxColumn();
                srfsampleColumn.HeaderText = "SRF SAMPLE";
                srfsampleColumn.Width = 80;
                srfsampleColumn.DataPropertyName = "srfsample";
                srfsampleColumn.Name = "srfsample";
                masterDataGridView.Columns.Add(srfsampleColumn);

                DataGridViewTextBoxColumn receivedColumn = new DataGridViewTextBoxColumn();
                receivedColumn.HeaderText = "RCVD POLA";
                receivedColumn.Width = 80;
                receivedColumn.DataPropertyName = "received";
                receivedColumn.Name = "received";
                masterDataGridView.Columns.Add(receivedColumn);

                DataGridViewTextBoxColumn cuttingColumn = new DataGridViewTextBoxColumn();
                cuttingColumn.HeaderText = "CUT";
                cuttingColumn.Width = 80;
                cuttingColumn.DataPropertyName = "cutting";
                cuttingColumn.Name = "cutting";
                masterDataGridView.Columns.Add(cuttingColumn);

                DataGridViewTextBoxColumn washsendColumn = new DataGridViewTextBoxColumn();
                washsendColumn.HeaderText = "SEND";
                washsendColumn.Width = 80;
                washsendColumn.DataPropertyName = "washsend";
                washsendColumn.Name = "washsend";
                masterDataGridView.Columns.Add(washsendColumn);

                DataGridViewTextBoxColumn washrcvdColumn = new DataGridViewTextBoxColumn();
                washrcvdColumn.HeaderText = "RCVD";
                washrcvdColumn.Width = 80;
                washrcvdColumn.DataPropertyName = "washrcvd";
                washrcvdColumn.Name = "washrcvd";
                masterDataGridView.Columns.Add(washrcvdColumn);

                DataGridViewTextBoxColumn reqetaColumn = new DataGridViewTextBoxColumn();
                reqetaColumn.HeaderText = "REQ ETA";
                reqetaColumn.Width = 80;
                reqetaColumn.DataPropertyName = "reqeta";
                reqetaColumn.Name = "reqeta";
                masterDataGridView.Columns.Add(reqetaColumn);


                DataGridViewTextBoxColumn plansendColumn = new DataGridViewTextBoxColumn();
                plansendColumn.HeaderText = "PLAN SEND";
                plansendColumn.Width = 80;
                plansendColumn.DataPropertyName = "plansend";
                plansendColumn.Name = "plansend";
                masterDataGridView.Columns.Add(plansendColumn);

                DataGridViewTextBoxColumn actualsendColumn = new DataGridViewTextBoxColumn();
                actualsendColumn.HeaderText = "ACTUAL SEND";
                actualsendColumn.Width = 80;
                actualsendColumn.DataPropertyName = "actualsend";
                actualsendColumn.Name = "actualsend";
                masterDataGridView.Columns.Add(actualsendColumn);

           
                DataGridViewTextBoxColumn remarksColumn = new DataGridViewTextBoxColumn();
                remarksColumn.HeaderText = "REMARKS";
                remarksColumn.Width = 150;
                remarksColumn.DataPropertyName = "remarks";
                remarksColumn.Name = "remarks";
                masterDataGridView.Columns.Add(remarksColumn);


                connection.Close();


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
                string strAdapter = "SELECT * FROM sample";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.Fill(data, "sample");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sample";

                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;

                //masterDataGridView.Columns.Clear();


                DataGridViewTextBoxColumn ColumnID = new DataGridViewTextBoxColumn();
                ColumnID.HeaderText = "styleid";
                ColumnID.Width = 90;
                ColumnID.DataPropertyName = "styleid";
                ColumnID.Name = "styleid";
                masterDataGridView.Columns.Add(ColumnID);
                
                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Sample_Load(object sender, EventArgs e)
        {
            getStatus();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "sample");
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
                masterDataAdapter.Update(data, "sample");
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

        private void cmdView_Click(object sender, EventArgs e)
        {
            getData(dateFrom.Value, dateTo.Value, cbStatus.SelectedText, txtStyle.Text);
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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(cbStatus.Text);
        }

        private void masterDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //MessageBox.Show("test");
        }

        private void masterDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (masterDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                masterDataGridView.Rows[e.RowIndex].Cells["srfpola"].Value=DateTime.Now;
            }
        }

        private void cmdXSD_Click(object sender, EventArgs e)
        {
            DataSet dsReject = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strQuery = "SELECT * FROM sample WHERE date(srfpola) BETWEEN date(@DATE1) AND date(@DATE2) AND status LIKE @STATUS";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", dateFrom.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", dateTo.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@STATUS", "%"+cbStatus.SelectedValue+"%");
            masterDataAdapter.Fill(dsReject, "samplexsd");
            Application.DoEvents();
            dsReject.WriteXmlSchema("C:\\MyGarmentReport\\samplexsd.xsd");
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            SampleFrm f = new SampleFrm();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(dateFrom.Value.ToString("yyyy-MM-dd"), dateTo.Value.ToString("yyyy-MM-dd"),cbStatus.SelectedText);
            f.Show();
        }
    }
}
