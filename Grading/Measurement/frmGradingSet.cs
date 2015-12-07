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

namespace Grading
{
    public partial class frmGradingSet : Form
    {
        //item grading detail
        private string STYLEID { get; set; }
        private string STYLEID1 { get; set; }
        private string MEID { get; set; }
        private string MEID1 { get; set; }
        private string SIZEID { get; set; }
        private string SIZEID1 { get; set; }
        private string DIRECTION { get; set; }
        private double BASIC { get; set; }

        private DataSet data = null;
        private DataSet data1 = null;
        BindingSource masterBindingSource = new BindingSource();
        //BindingSource detailsBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;
        //private MySqlDataAdapter detailsDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;
        //DataGridViewComboBoxColumn MEColumn = new DataGridViewComboBoxColumn();

        public frmGradingSet()
        {
            InitializeComponent();
        }

        private void SetStyleCallBack(string Style, string Desc)
        {
            txtStyleID.Text = Style;
            txtStyleName.Text = Desc;
        }
        private void getData1(string Style)
        {
            data = new DataSet();
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);

                masterDataAdapter = new MySqlDataAdapter("select * from grading where STYLEID='" + Style + "'", connection);
                masterDataAdapter.Fill(data, "grading");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "grading";
                //grading header 
                txtStyleID.DataBindings.Clear();
                cbBuyer.DataBindings.Clear();
                txtColorID.DataBindings.Clear();
                dateGrading.DataBindings.Clear();
                
                //txtStyleID.Text = Style;

                // txtOrderID.DataBindings.Add(new Binding("Text", data, "Orders.OrderID", true));
                //txtRemarks.DataBindings.Add(new Binding("Text", data, "Orders.Remarks", true));

                txtStyleID.DataBindings.Add(new Binding("Text", masterBindingSource, "STYLEID", true, DataSourceUpdateMode.OnPropertyChanged));
                cbBuyer.DataBindings.Add(new Binding("Text", masterBindingSource, "BUYERID", true, DataSourceUpdateMode.OnPropertyChanged));
               txtColorID.DataBindings.Add(new Binding("Text", masterBindingSource, "COLOR", true, DataSourceUpdateMode.OnPropertyChanged));
                dateGrading.DataBindings.Add(new Binding("Text", masterBindingSource, "DATE", true, DataSourceUpdateMode.OnPropertyChanged));

         

                //close koneksi
               connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void getData(string Style)
        {
            data = new DataSet();
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);

                masterDataAdapter = new MySqlDataAdapter("select * from grading where STYLEID='" + Style + "'", connection);
                masterDataAdapter.Fill(data, "grading");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                string selectQueryStringMonth = "SELECT * FROM buyer";

                MySqlDataAdapter buyerDataAdapter = new MySqlDataAdapter(selectQueryStringMonth, connection);
                MySqlCommandBuilder buyerCommandBuilder = new MySqlCommandBuilder(buyerDataAdapter);

                DataTable dataTableBuyer = new DataTable();
                buyerDataAdapter.Fill(dataTableBuyer);
                BindingSource bindingSourceBuyer = new BindingSource();
                bindingSourceBuyer.DataSource = dataTableBuyer;
                cbBuyer.DataSource = bindingSourceBuyer;
                cbBuyer.ValueMember = "BUYERID";
                cbBuyer.DisplayMember = "BUYERNAME";


                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "grading";


                //grading header 
                txtStyleID.DataBindings.Clear();
                //cbBuyer.DataBindings.Clear();
                txtColorID.DataBindings.Clear();
                dateGrading.DataBindings.Clear();
                txtBuyer.DataBindings.Clear();



                // txtOrderID.DataBindings.Add(new Binding("Text", data, "Orders.OrderID", true));
                //txtRemarks.DataBindings.Add(new Binding("Text", data, "Orders.Remarks", true));

                txtStyleID.DataBindings.Add(new Binding("Text", masterBindingSource, "STYLEID", true, DataSourceUpdateMode.OnPropertyChanged));
                txtBuyer.DataBindings.Add(new Binding("Text", masterBindingSource, "BUYERID", true, DataSourceUpdateMode.OnPropertyChanged));
                if (txtBuyer.Text != "")
                {
                    cbBuyer.SelectedValue = txtBuyer.Text;

                }
                else
                {
                    cbBuyer.Text = "";
                }
                //cbBuyer.DataBindings.Add(new Binding("Text", masterBindingSource, "BUYERID", true, DataSourceUpdateMode.OnPropertyChanged));
                //cbBuyer.ValueMember=masterBindingSource.
                txtColorID.DataBindings.Add(new Binding("Text", masterBindingSource, "COLOR", true, DataSourceUpdateMode.OnPropertyChanged));
                dateGrading.DataBindings.Add(new Binding("Text", masterBindingSource, "DATE", true, DataSourceUpdateMode.OnPropertyChanged));

                //
                // cbBuyer.SelectedValue = data.Tables["grading"].Rows[0]["BUYERID"].ToString();
                //buyer

                if (data.Tables["grading"].Rows.Count < 1)
                {
                    masterBindingSource.AddNew(); //inisial untuk insert new
                    txtStyleID.Text = Style;
                    dateGrading.Value = DateTime.Now;
                }

                //grid detail

            //    detailsDataGridView.DataSource = detailsBindingSource;

   

                //end

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        
        private void frmGradingSet_Load(object sender, EventArgs e)
        {
            cbPrint.Text = "NORMAL";
            dateGrading.Value = DateTime.Now;
        }

        private void cmdStyleID_Click(object sender, EventArgs e)
        {

            findStyle f = new findStyle();
            f.AddItemCallback = new findStyle.AddCategoryDelegate(this.SetStyleCallBack);
            f.ShowDialog();

            if (txtStyleID.Text != "")
            {
               getData(txtStyleID.Text);
               AddColumnDetail(txtStyleID.Text);
               AddItemDetails(txtStyleID.Text);


            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                //this.Validate();
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data,"grading");
                saveItem();
                MessageBox.Show("the data has been saved");

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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow item in this.detailsDataGridView.SelectedRows)
                {
                   STYLEID1 = Convert.ToString(detailsDataGridView.Rows[item.Index].Cells["STYLEID1"].Value);
                   STYLEID = Convert.ToString(detailsDataGridView.Rows[item.Index].Cells["STYLEID"].Value);
                   MEID1 = Convert.ToString(detailsDataGridView.Rows[item.Index].Cells["MEID1"].Value);
                   MEID = Convert.ToString(detailsDataGridView.Rows[item.Index].Cells["MEID"].Value);
                   DIRECTION = Convert.ToString(detailsDataGridView.Rows[item.Index].Cells["DIRECTION"].Value);

                    if (STYLEID1 == "")
                    {
                        detailsDataGridView.Rows.RemoveAt(item.Index);
                    }
                    else
                    {
                        if (deleteGradingDetail(STYLEID, MEID))
                        {
                            detailsDataGridView.Rows.RemoveAt(item.Index);
                        }

                    }
                   // dirBindingSource.RemoveAt(item.Index);
                }

                //dirBindingSource.EndEdit();
                //dirDataAdapter.Update(data, "direction");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
                getData(txtStyleID.Text);
            }
        }

        private void AddColumnDetail(string style)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                 data1 = new DataSet();
                string sqlQuery = "select * from sizeorder where styleid='"+style+"' order by ORDERNO";
                MySqlDataAdapter ColumDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
                ColumDataAdapter.Fill(data1, "style");

                //tambah lis
                //list
                //list size 

                string selectQueryStringSIZEID = "SELECT SIZEID FROM sizeorder where STYLEID='" + style + "'";

                MySqlDataAdapter sqlDataAdapterSIZEID = new MySqlDataAdapter(selectQueryStringSIZEID, connection);
                MySqlCommandBuilder sqlCommandBuilderSIZEID = new MySqlCommandBuilder(sqlDataAdapterSIZEID);

                DataTable dataTableSIZEID = new DataTable();
                sqlDataAdapterSIZEID.Fill(dataTableSIZEID);
                BindingSource bindingSourceSIZEID = new BindingSource();
                bindingSourceSIZEID.DataSource = dataTableSIZEID;

                //list MEID
                string selectQueryStringMEID = "SELECT * FROM measurementstyle WHERE STYLEID='" + style + "' ORDER BY CEK";

                MySqlDataAdapter sqlDataAdapterMEID = new MySqlDataAdapter(selectQueryStringMEID, connection);
                MySqlCommandBuilder sqlCommandBuilderMEID = new MySqlCommandBuilder(sqlDataAdapterMEID);

                DataTable dataTableMEID = new DataTable();
                sqlDataAdapterMEID.Fill(dataTableMEID);
                BindingSource bindingSourceMEID = new BindingSource();
                bindingSourceMEID.DataSource = dataTableMEID;
                //list direct
                string selectQueryStringLW = "SELECT * FROM direction WHERE STYLEID='" + style + "'";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                DataTable dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;

                //end list
                //add colom detail
                detailsDataGridView.Columns.Clear();

                detailsDataGridView.Columns.Add("STYLEID1", "STYLEID1");
                detailsDataGridView.Columns["STYLEID1"].Visible = false;
                detailsDataGridView.Columns.Add("MEID1", "MEID1");
                detailsDataGridView.Columns["MEID1"].Visible = false;
                detailsDataGridView.Columns.Add("STYLEID", "STYLEID");
                detailsDataGridView.Columns["STYLEID"].Visible = false;
              //detailsDataGridView.Columns.Add("MEID", "MEID");
              //  detailsDataGridView.Columns.Add("MEASUREMENT", "MEASUREMENT");
               // detailsDataGridView.Columns.Add("DIRECTION", "DIRECTION");

                DataGridViewComboBoxColumn MEColumn = new DataGridViewComboBoxColumn();
                MEColumn.HeaderText = "CODE";
                MEColumn.Width = 80;
                MEColumn.DataPropertyName = "MEID";
                MEColumn.Name = "MEID";

                //binding
                MEColumn.DataSource = bindingSourceMEID;
                MEColumn.ValueMember = "MEID";
                MEColumn.DisplayMember = "MEID";

                detailsDataGridView.Columns.Add(MEColumn);

                detailsDataGridView.Columns.Add("MEASUREMENT", "MEASUREMENT");
                detailsDataGridView.Columns["MEASUREMENT"].Width = 350;

                //DataGridViewTextBoxColumn DIRECTColumn = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn DIRECTColumn = new DataGridViewComboBoxColumn();
                DIRECTColumn.HeaderText = "DIRECTION";
                DIRECTColumn.Width = 80;
                DIRECTColumn.DataPropertyName = "DIRECTION";
                DIRECTColumn.Name = "DIRECTION";

                //binding
                DIRECTColumn.DataSource = bindingSourceLW;
                DIRECTColumn.ValueMember = "LW";
                DIRECTColumn.DisplayMember = "LW";

                detailsDataGridView.Columns.Add(DIRECTColumn);


                for (int i = 0; i < data1.Tables[0].Rows.Count; i++)
                {
                    detailsDataGridView.Columns.Add(Convert.ToString(data1.Tables[0].Rows[i]["SIZEID"]), Convert.ToString(data1.Tables[0].Rows[i]["SIZEID"]));
                    detailsDataGridView.Columns[Convert.ToString(data1.Tables[0].Rows[i]["SIZEID"])].Width = 50;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void AddItemDetails(string style)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                data1 = new DataSet();
                string strQuery = "select style.STYLEID,measurement.MEID,style.STYLEID,measurement.MEID,measurement.MEASUREMENT " +
                 " ,direction.LW" +
                 " ,MAX(case when sizeorder.ORDERNO=1 then gradingdetail.BASIC end ) BASIC1" +
                 " ,MAX(case when sizeorder.ORDERNO=2 then gradingdetail.BASIC end ) BASIC2" +
                 " ,MAX(case when sizeorder.ORDERNO=3 then gradingdetail.BASIC end ) BASIC3" +
                 " ,MAX(case when sizeorder.ORDERNO=4 then gradingdetail.BASIC end ) BASIC4" +
                 ",MAX(case when sizeorder.ORDERNO=5 then gradingdetail.BASIC end ) BASIC5" +
                 " ,MAX(case when sizeorder.ORDERNO=6 then gradingdetail.BASIC end ) BASIC6" +
                 ",MAX(case when sizeorder.ORDERNO=7 then gradingdetail.BASIC end ) BASIC7" +
                 " ,MAX(case when sizeorder.ORDERNO=8 then gradingdetail.BASIC end ) BASIC8" +
                 " ,MAX(case when sizeorder.ORDERNO=9 then gradingdetail.BASIC end ) BASIC9" +
                 " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC end ) BASIC10" +
                 " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC end ) BASIC11" +
                 " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC end ) BASIC12" +
                  " from grading " +
                  " inner join gradingdetail on grading.STYLEID=gradingdetail.STYLEID" +
                  " inner join measurement on measurement.MEID=gradingdetail.MEID" +
                  " inner join size on size.SIZEID=gradingdetail.SIZEID" +
                  " inner join style on style.STYLEID=grading.STYLEID" +
                  " inner join buyer on buyer.BUYERID =grading.BUYERID" +
                  " inner join direction on direction.STYLEID=gradingdetail.STYLEID AND direction.LW=gradingdetail.DIRECTION" +
                  " inner join sizeorder on sizeorder.SIZEID=gradingdetail.SIZEID AND sizeorder.STYLEID=gradingdetail.STYLEID" +
                  " inner join measurementstyle on measurementstyle.STYLEID=style.STYLEID and measurementstyle.MEID=measurement.MEID  AND measurement.BUYERID=measurementstyle.buyerid " +
                    //" where grading.STYLEID='" + txtStyleID.Text + "'" +
                  " where grading.STYLEID='"+style+"'" +
                  " GROUP BY buyer.BUYERNAME,style.STYLEID,style.STYLENAME,grading.COLOR,grading.DATE,direction.LW,measurement.MEID,measurement.MEASUREMENT " +
                  " ORDER BY sizeorder.ORDERNO,measurementstyle.CEK";
                MySqlDataAdapter ItemDataAdapter = new MySqlDataAdapter(strQuery, connection);
                ItemDataAdapter.Fill(data1, "gradingPrint");

                for (int i = 0; i < data1.Tables[0].Rows.Count; i++)
                {
                    detailsDataGridView.Rows.Add();
                    for (int j = 0; j < detailsDataGridView.Columns.Count; j++)
                    {
                        detailsDataGridView.Rows[i].Cells[j].Value = Convert.ToString(data1.Tables[0].Rows[i][j]);

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                /*
                string sqlQuery = "select * from gradingdetail where styleid='10.29285.00.70' order by MEID";
                masterDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
                masterDataAdapter.Fill(data, "style");
                 */
                string strQuery = "select style.STYLEID,measurement.MEID,style.STYLEID,measurement.MEID,measurement.MEASUREMENT " +
                 " ,direction.LW" +
                 " ,MAX(case when sizeorder.ORDERNO=1 then gradingdetail.BASIC end ) BASIC1" +
                 " ,MAX(case when sizeorder.ORDERNO=2 then gradingdetail.BASIC end ) BASIC2" +
                 " ,MAX(case when sizeorder.ORDERNO=3 then gradingdetail.BASIC end ) BASIC3" +
                 " ,MAX(case when sizeorder.ORDERNO=4 then gradingdetail.BASIC end ) BASIC4" +
                 ",MAX(case when sizeorder.ORDERNO=5 then gradingdetail.BASIC end ) BASIC5" +
                 " ,MAX(case when sizeorder.ORDERNO=6 then gradingdetail.BASIC end ) BASIC6" +
                 ",MAX(case when sizeorder.ORDERNO=7 then gradingdetail.BASIC end ) BASIC7" +
                 " ,MAX(case when sizeorder.ORDERNO=8 then gradingdetail.BASIC end ) BASIC8" +
                 " ,MAX(case when sizeorder.ORDERNO=9 then gradingdetail.BASIC end ) BASIC9" +
                 " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC end ) BASIC10" +
                  " from grading " +
                  " inner join gradingdetail on grading.STYLEID=gradingdetail.STYLEID" +
                  " inner join measurement on measurement.MEID=gradingdetail.MEID" +
                  " inner join size on size.SIZEID=gradingdetail.SIZEID" +
                  " inner join style on style.STYLEID=grading.STYLEID" +
                  " inner join buyer on buyer.BUYERID =grading.BUYERID" +
                  " inner join direction on direction.STYLEID=gradingdetail.STYLEID AND direction.LW=gradingdetail.DIRECTION" +
                  " inner join sizeorder on sizeorder.SIZEID=gradingdetail.SIZEID AND sizeorder.STYLEID=gradingdetail.STYLEID" +
                  //" where grading.STYLEID='" + txtStyleID.Text + "'" +
                  " where grading.STYLEID='10.29285.00.70'" +
                  " GROUP BY buyer.BUYERNAME,style.STYLEID,style.STYLENAME,grading.COLOR,grading.DATE,direction.LW,measurement.MEID,measurement.MEASUREMENT " +
                  " ORDER BY sizeorder.ORDERNO,measurement.MEID";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.Fill(data, "gradingPrint");

                detailsDataGridView.Rows.Clear();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    detailsDataGridView.Rows.Add();
                    //detailsDataGridView.Rows[i].Cells["STYLEID"].Value = Convert.ToString(data.Tables[0].Rows[i]["STYLEID"]);
                    //detailsDataGridView.Rows[i].Cells["MEID"].Value = Convert.ToString(data.Tables[0].Rows[i]["MEID"]);
                    //detailsDataGridView.Rows[i].Cells["MEASUREMENT"].Value = Convert.ToString(data.Tables[0].Rows[i]["MEASUREMENT"]);
                    //detailsDataGridView.Rows[i].Cells["DIRECTION"].Value = Convert.ToString(data.Tables[0].Rows[i]["LW"]);
                    for (int j = 0; j < detailsDataGridView.Columns.Count; j++)
                    {
                        detailsDataGridView.Rows[i].Cells[j].Value = Convert.ToString(data.Tables[0].Rows[i][j]);
                        
                    }
                    //detailsDataGridView.Rows[i].Cells[].Value = Convert.ToString(data.Tables[0].Rows[i]["LW"]);



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private bool insertGradingDetail(string STYLEID, string MEID, string SIZEID,string DIRECTION, double BASIC)
        {
            bool stat = false;
            try
            {
                DataSet ds = new DataSet();
                //Sqlserver SqlStr = new Sqlserver();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                //---masukan ke data adapter
                //command
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                // Command.CommandText = "Select * from Orders ";
                Command.CommandText = "INSERT INTO gradingdetail(STYLEID,MEID,SIZEID,DIRECTION,BASIC) VALUES(@STYLEID,@MEID,@SIZEID,@DIRECTION,@BASIC)";
                //item insert
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@MEID", MEID);
                Command.Parameters.AddWithValue("@SIZEID", SIZEID);
                Command.Parameters.AddWithValue("@DIRECTION", DIRECTION);
                Command.Parameters.AddWithValue("@BASIC", BASIC);

                Command.ExecuteNonQuery();
                // MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
                // DataAdapter.Fill(ds, "Orders");
                // MySqlCommandBuilder CommandBuilder = new MySqlCommandBuilder(DataAdapter);
                //--end masukan ke dataset
                Connection.Close();//akhiri koneksi
                stat = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stat;
        }

       // STYLEID1, MEID1, SIZEID1, MEID, SIZEID, DIRECTION, BASIC

        private bool updateGaradingDetail(string STYLEID1, string MEID1, string SIZEID1, string MEID,string SIZEID, string DIRECTION, double BASIC)
        {
            bool stat = false;
            try
            {
                DataSet ds = new DataSet();
                //Sqlserver SqlStr = new Sqlserver();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                //---masukan ke data adapter
                //command
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                Command.CommandText = "UPDATE gradingdetail SET MEID=@MEID,SIZEID=@SIZEID,DIRECTION=@DIRECTION,BASIC=@BASIC WHERE STYLEID=@STYLEID1 AND MEID=@MEID1 AND SIZEID=@SIZEID1 ";
                //item update key
                Command.Parameters.AddWithValue("@STYLEID1", STYLEID1);
                Command.Parameters.AddWithValue("@MEID1", MEID1);
                Command.Parameters.AddWithValue("@SIZEID1", SIZEID1);

                //update detail
                Command.Parameters.AddWithValue("@MEID", MEID);
                Command.Parameters.AddWithValue("@SIZEID", SIZEID);
                Command.Parameters.AddWithValue("@DIRECTION", DIRECTION);
                Command.Parameters.AddWithValue("@BASIC", BASIC);

                Command.ExecuteNonQuery();
                Connection.Close();//akhiri koneksi
                stat = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stat;
        }

        private bool deleteGradingDetail(string STYLEID1, string MEID1)
        {
            bool stat = false;
            try
            {
                DataSet ds = new DataSet();
                //Sqlserver SqlStr = new Sqlserver();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                //---masukan ke data adapter
                //command
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                // Command.CommandText = "Select * from Orders ";
                Command.CommandText = "DELETE FROM gradingdetail WHERE STYLEID=@STYLEID1 AND MEID=@MEID1";
                //key
                Command.Parameters.AddWithValue("@STYLEID1", STYLEID1);
                Command.Parameters.AddWithValue("@MEID1", MEID1);
                //Command.Parameters.AddWithValue("@SIZEID1", SIZEID1);
                //item update
                Command.ExecuteNonQuery();
                Connection.Close();//akhiri koneksi
                stat = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stat;
        }

        private bool cekGradingDetail(string STYLEID, string MEID, string SIZEID)
        {
            bool stat = false;
            try
            {
                DataSet ds = new DataSet();
                //Sqlserver SqlStr = new Sqlserver();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                //---masukan ke data adapter
                //command
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                // Command.CommandText = "Select * from Orders ";
                Command.CommandText = "SELECT * FROM gradingdetail  WHERE STYLEID=@STYLEID AND MEID=@MEID AND SIZEID=@SIZEID";
                //key
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@MEID", MEID);
                Command.Parameters.AddWithValue("@SIZEID", SIZEID);
        
               // Command.ExecuteNonQuery();
                 MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
                 DataAdapter.Fill(ds, "gradingdetail");
                 MySqlCommandBuilder CommandBuilder = new MySqlCommandBuilder(DataAdapter);
                //--end masukan ke dataset
                Connection.Close();//akhiri koneksi
                if (ds.Tables["gradingdetail"].Rows.Count == 0) {
                stat = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stat;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                //Sqlserver SqlStr = new Sqlserver();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                //---masukan ke data adapter
                //command
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                // Command.CommandText = "Select * from Orders ";
                Command.CommandText = "UPDATE gradingdetail SET WHERE STYLEID=@STYLEID AND MEID=@MEID AND SIZEID=@SIZEID ";
                Command.Parameters.AddWithValue("@STYLEID", txtStyleID.Text);

                Command.ExecuteNonQuery();
               // MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
               // DataAdapter.Fill(ds, "Orders");
               // MySqlCommandBuilder CommandBuilder = new MySqlCommandBuilder(DataAdapter);
                //--end masukan ke dataset
                Connection.Close();//akhiri koneksi

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void saveItem()
        {
            detailsDataGridView.EndEdit();
            for (int i = 0; i < detailsDataGridView.Rows.Count-1; i++)
            {
                STYLEID1 = Convert.ToString(detailsDataGridView.Rows[i].Cells["STYLEID1"].Value);
                STYLEID = txtStyleID.Text;
                MEID1 = Convert.ToString(detailsDataGridView.Rows[i].Cells["MEID1"].Value);
                MEID = Convert.ToString(detailsDataGridView.Rows[i].Cells["MEID"].Value);
                DIRECTION = Convert.ToString(detailsDataGridView.Rows[i].Cells["DIRECTION"].Value);
                if (DIRECTION == "" )
                {
                    MessageBox.Show("Direction Input is Empty, Please choice Direction ");
                }else
                {

                for (int j = 6; j < detailsDataGridView.Columns.Count; j++)
                {
                    //double number;
                    SIZEID1 = detailsDataGridView.Columns[j].HeaderText;
                    SIZEID = detailsDataGridView.Columns[j].HeaderText;
                    try
                    {
                        BASIC = Convert.ToDouble(detailsDataGridView.Rows[i].Cells[SIZEID1].Value);
                    }
                    catch
                    {
                        BASIC = 0.0;
                    }
                    /*
                    if (Double.TryParse(detailsDataGridView.Rows[i].Cells[SIZEID1].Value.ToString(), out number))
                        BASIC = number;
                    else
                        BASIC = 0;
                     */
                   // if (STYLEID1 == "" )
                    if (cekGradingDetail(STYLEID, MEID, SIZEID))
                    {
                        
                 
                            if (insertGradingDetail(STYLEID, MEID, SIZEID, DIRECTION, BASIC))
                            {
                                detailsDataGridView.Rows[i].Cells["STYLEID1"].Value = STYLEID;
                            }
                            //insert
                 
                    }

                    else{
       
                            if (updateGaradingDetail(STYLEID1, MEID1, SIZEID1, MEID, SIZEID, DIRECTION, BASIC))
                            {
                            }
       
                        }
                }
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            detailsDataGridView.EndEdit();
            for (int i = 0; i < detailsDataGridView.Rows.Count; i++)
            {
                STYLEID1=Convert.ToString(detailsDataGridView.Rows[i].Cells["STYLEID1"].Value);
                STYLEID = Convert.ToString(detailsDataGridView.Rows[i].Cells["STYLEID"].Value);
                MEID1 = Convert.ToString(detailsDataGridView.Rows[i].Cells["MEID1"].Value);
                MEID = Convert.ToString(detailsDataGridView.Rows[i].Cells["MEID"].Value);
                DIRECTION = Convert.ToString(detailsDataGridView.Rows[i].Cells["DIRECTION"].Value);

                for (int j = 6; j < detailsDataGridView.Columns.Count; j++)
                {
                    SIZEID1 = detailsDataGridView.Columns[j].HeaderText;
                    SIZEID = detailsDataGridView.Columns[j].HeaderText;
                    BASIC = Convert.ToDouble(detailsDataGridView.Rows[i].Cells[SIZEID1].Value);
                    if (updateGaradingDetail(STYLEID1, MEID1, SIZEID1, MEID, SIZEID, DIRECTION, BASIC))
                    {
                    }
                    else 
                    {
                    }
                    
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            detailsDataGridView.EndEdit();
            for (int i = 0; i < detailsDataGridView.Rows.Count; i++)
            {
               
                STYLEID = Convert.ToString(detailsDataGridView.Rows[i].Cells["STYLEID"].Value);
              
                MEID = Convert.ToString(detailsDataGridView.Rows[i].Cells["MEID"].Value);
                DIRECTION = Convert.ToString(detailsDataGridView.Rows[i].Cells["DIRECTION"].Value);

                for (int j = 6; j < detailsDataGridView.Columns.Count; j++)
                {
                   // SIZEID1 = detailsDataGridView.Columns[j].HeaderText;
                    SIZEID = detailsDataGridView.Columns[j].HeaderText;
                    BASIC = Convert.ToDouble(detailsDataGridView.Rows[i].Cells[SIZEID].Value);
                    if (insertGradingDetail(STYLEID, MEID, SIZEID, DIRECTION, BASIC))
                    {
                    }
                    else
                    {
                    }

                }

            }
        }

        private void txtStyleID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblStyle_Click(object sender, EventArgs e)
        {

        }

        private void txtStyleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuyer.Text = cbBuyer.SelectedValue.ToString();
        }

        private void cmdPrintSpec_Click(object sender, EventArgs e)
        {
            if (LW())
            {
                DataSet dataPrint = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                /*
                string strQuery = "select buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE "+
                        ",direction.LW,measurement.MEID,measurement.MEASUREMENT,direction.LW "+
                        ",sizeorder.SIZEID "+
                        ",gradingdetail.BASIC"+
                        ",gradingdetail.BASIC*(1-(direction.LWVALUE/100)) PATTERN "+
                        "from grading "+
                        "inner join gradingdetail on grading.STYLEID=gradingdetail.STYLEID "+
                        " inner join measurement on measurement.MEID=gradingdetail.MEID"+
                        " inner join size on size.SIZEID=gradingdetail.SIZEID "+
                        " inner join style on style.STYLEID=grading.STYLEID"+
                        " inner join buyer on buyer.BUYERID =grading.BUYERID"+
                        " inner join direction on direction.STYLEID=gradingdetail.STYLEID AND direction.LW=gradingdetail.DIRECTION" +
                        " inner join sizeorder on sizeorder.SIZEID=gradingdetail.SIZEID AND sizeorder.STYLEID=gradingdetail.STYLEID"+
                        " where grading.STYLEID='"+txtStyleID.Text+"'"+
                        " ORDER BY sizeorder.ORDERNO ";
                */

                string strQuery = "select style.STYLEID,buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE " +
                       " ,direction.LW,measurement.MEID,measurement.MEASUREMENT" +
                       " ,MAX(case when sizeorder.SIZEBASIC=1 then sizeorder.SIZEID end ) SIZEBASIC" +
                       ",MAX(case when sizeorder.SIZEBASIC=1 then sizeorder.ORDERNO end ) ORDERNOBASIC" +
                       ",MAX(case when sizeorder.ORDERNO=1 then sizeorder.ORDERNO end ) ORDERNO1" +
                       ",MAX(case when sizeorder.ORDERNO=2 then sizeorder.ORDERNO end ) ORDERNO2" +
                       ",MAX(case when sizeorder.ORDERNO=3 then sizeorder.ORDERNO end ) ORDERNO3" +
                       ",MAX(case when sizeorder.ORDERNO=4 then sizeorder.ORDERNO end ) ORDERNO4" +
                       ",MAX(case when sizeorder.ORDERNO=5 then sizeorder.ORDERNO end ) ORDERNO5" +
                       ",MAX(case when sizeorder.ORDERNO=6 then sizeorder.ORDERNO end ) ORDERNO6" +
                       ",MAX(case when sizeorder.ORDERNO=7 then sizeorder.ORDERNO end ) ORDERNO7" +
                       ",MAX(case when sizeorder.ORDERNO=8 then sizeorder.ORDERNO end ) ORDERNO8" +
                       ",MAX(case when sizeorder.ORDERNO=9 then sizeorder.ORDERNO end ) ORDERNO9" +
                       ",MAX(case when sizeorder.ORDERNO=10 then sizeorder.ORDERNO end ) ORDERNO10" +
                       ",MAX(case when sizeorder.ORDERNO=11 then sizeorder.ORDERNO end ) ORDERNO11" +
                       ",MAX(case when sizeorder.ORDERNO=12 then sizeorder.ORDERNO end ) ORDERNO12" +

                       " ,MAX(case when sizeorder.ORDERNO=1 then sizeorder.SIZEID end ) SIZE1 " +
                       " ,MAX(case when sizeorder.ORDERNO=2 then sizeorder.SizeID end ) SIZE2 " +
                       " ,MAX(case when sizeorder.ORDERNO=3 then sizeorder.SizeID end ) SIZE3" +
                       " ,MAX(case when sizeorder.ORDERNO=4 then sizeorder.SizeID end ) SIZE4" +
                       " ,MAX(case when sizeorder.ORDERNO=5 then sizeorder.SizeID end ) SIZE5" +
                       " ,MAX(case when sizeorder.ORDERNO=6 then sizeorder.SizeID end ) SIZE6" +
                       " ,MAX(case when sizeorder.ORDERNO=7 then sizeorder.SizeID end ) SIZE7" +
                       " ,MAX(case when sizeorder.ORDERNO=8 then sizeorder.SizeID end ) SIZE8" +
                       " ,MAX(case when sizeorder.ORDERNO=9 then sizeorder.SizeID end ) SIZE9" +
                       " ,MAX(case when sizeorder.ORDERNO=10 then sizeorder.SizeID end ) SIZE10" +
                       " ,MAX(case when sizeorder.ORDERNO=11 then sizeorder.SizeID end ) SIZE11" +
                       " ,MAX(case when sizeorder.ORDERNO=12 then sizeorder.SizeID end ) SIZE12" +

                       " ,MAX(case when sizeorder.ORDERNO=1 then gradingdetail.BASIC end ) BASIC1" +
                       " ,MAX(case when sizeorder.ORDERNO=2 then gradingdetail.BASIC end ) BASIC2" +
                       " ,MAX(case when sizeorder.ORDERNO=3 then gradingdetail.BASIC end ) BASIC3" +
                       " ,MAX(case when sizeorder.ORDERNO=4 then gradingdetail.BASIC end ) BASIC4" +
                       ",MAX(case when sizeorder.ORDERNO=5 then gradingdetail.BASIC end ) BASIC5" +
                       " ,MAX(case when sizeorder.ORDERNO=6 then gradingdetail.BASIC end ) BASIC6" +
                       ",MAX(case when sizeorder.ORDERNO=7 then gradingdetail.BASIC end ) BASIC7" +
                       " ,MAX(case when sizeorder.ORDERNO=8 then gradingdetail.BASIC end ) BASIC8" +
                       " ,MAX(case when sizeorder.ORDERNO=9 then gradingdetail.BASIC end ) BASIC9" +
                       " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC end ) BASIC10" +
                       " ,MAX(case when sizeorder.ORDERNO=11 then gradingdetail.BASIC end ) BASIC11" +
                       " ,MAX(case when sizeorder.ORDERNO=12 then gradingdetail.BASIC end ) BASIC12" +

                       " ,MAX(case when sizeorder.ORDERNO=1 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN1" +
                       " ,MAX(case when sizeorder.ORDERNO=2 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN2" +
                       " ,MAX(case when sizeorder.ORDERNO=3 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN3" +
                       " ,MAX(case when sizeorder.ORDERNO=4 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN4" +
                       " ,MAX(case when sizeorder.ORDERNO=5 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN5" +
                       " ,MAX(case when sizeorder.ORDERNO=6 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN6" +
                        " ,MAX(case when sizeorder.ORDERNO=7 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN7" +
                        " ,MAX(case when sizeorder.ORDERNO=8 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN8" +
                        " ,MAX(case when sizeorder.ORDERNO=9 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN9" +
                        " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN10" +
                        " ,MAX(case when sizeorder.ORDERNO=11 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN11" +
                        " ,MAX(case when sizeorder.ORDERNO=12 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN12" +

                        " from grading " +
                        " inner join gradingdetail on grading.STYLEID=gradingdetail.STYLEID" +
                        " inner join measurement on measurement.MEID=gradingdetail.MEID" +
                        " inner join size on size.SIZEID=gradingdetail.SIZEID" +
                        " inner join style on style.STYLEID=grading.STYLEID" +
                        " inner join buyer on buyer.BUYERID =grading.BUYERID" +
                        " inner join measurementstyle on measurementstyle.STYLEID=style.STYLEID and measurementstyle.MEID=measurement.MEID AND measurement.BUYERID=measurementstyle.BUYERID " +
                        " inner join direction on direction.STYLEID=gradingdetail.STYLEID AND direction.LW=gradingdetail.DIRECTION" +
                        " inner join sizeorder on sizeorder.SIZEID=gradingdetail.SIZEID AND sizeorder.STYLEID=gradingdetail.STYLEID" +
                        " where grading.STYLEID='" + txtStyleID.Text + "'" +
                        " GROUP BY buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE,direction.LW,measurement.MEID,measurement.MEASUREMENT " +
                        " ORDER BY sizeorder.ORDERNO,measurementstyle.CEK";
                MySqlDataAdapter printDataAdapter = new MySqlDataAdapter(strQuery, connection);
                printDataAdapter.Fill(dataPrint, "gradingPrint");


                //DataSet data = new joborderCRUD().prJobOrder(txtCostingNo.Text);


                Application.DoEvents();
                dataPrint.WriteXml("C:\\MyGarmentReport\\qcspec.xml", XmlWriteMode.WriteSchema);
                if (cbPrint.Text == "NORMAL")
                {
                    if (cbUOM.Text == "INCH")
                    {
                        Form f = new printSpec1();
                        f.Show();
                    }
                    else
                    {
                        Form f = new printSpec();
                        f.Show();
                    }
                }
                else if (cbPrint.Text == "BW")
                {
                                        if (cbUOM.Text == "INCH")
                    {
                        Form f = new printSpecBW1();
                        f.Show();
                    }
                    else
                    {

                    Form f = new printSpecBW();
                    f.Show();

                   }
                }
                else if (cbPrint.Text == "BW & AW")
                {
                   if (cbUOM.Text == "INCH")
                    {
                        Form f = new printSpecAW1();
                        f.Show();
                    }
                    else
                    {

                    Form f = new printSpecAW();
                    f.Show();
                                        }

                }
                else if (cbPrint.Text == "Test")
                {
                    Form f = new printSpecAW1();
                    f.Show();

                }

            }
            else
            {
                MessageBox.Show("Wrong Process");
            }

            
        }

        private void cmdPrintGrading_Click(object sender, EventArgs e)
        {
            if (LW())
            {
                DataSet dataPrint = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);

                string strQuery = "select style.STYLEID,buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE " +
                     " ,direction.LW,measurement.MEID,measurement.MEASUREMENT" +
                     " ,MAX(case when sizeorder.SIZEBASIC=1 then sizeorder.SIZEID end ) SIZEBASIC" +
                     ",MAX(case when sizeorder.SIZEBASIC=1 then sizeorder.ORDERNO end ) ORDERNOBASIC" +
                     ",MAX(case when sizeorder.ORDERNO=1 then sizeorder.ORDERNO end ) ORDERNO1" +
                     ",MAX(case when sizeorder.ORDERNO=2 then sizeorder.ORDERNO end ) ORDERNO2" +
                     ",MAX(case when sizeorder.ORDERNO=3 then sizeorder.ORDERNO end ) ORDERNO3" +
                     ",MAX(case when sizeorder.ORDERNO=4 then sizeorder.ORDERNO end ) ORDERNO4" +
                     ",MAX(case when sizeorder.ORDERNO=5 then sizeorder.ORDERNO end ) ORDERNO5" +
                     ",MAX(case when sizeorder.ORDERNO=6 then sizeorder.ORDERNO end ) ORDERNO6" +
                     ",MAX(case when sizeorder.ORDERNO=7 then sizeorder.ORDERNO end ) ORDERNO7" +
                     ",MAX(case when sizeorder.ORDERNO=8 then sizeorder.ORDERNO end ) ORDERNO8" +
                     ",MAX(case when sizeorder.ORDERNO=9 then sizeorder.ORDERNO end ) ORDERNO9" +
                     ",MAX(case when sizeorder.ORDERNO=10 then sizeorder.ORDERNO end ) ORDERNO10" +
                     ",MAX(case when sizeorder.ORDERNO=10 then sizeorder.ORDERNO end ) ORDERNO11" +
                     ",MAX(case when sizeorder.ORDERNO=10 then sizeorder.ORDERNO end ) ORDERNO12" +

                     " ,MAX(case when sizeorder.ORDERNO=1 then sizeorder.SIZEID end ) SIZE1 " +
                     " ,MAX(case when sizeorder.ORDERNO=2 then sizeorder.SizeID end ) SIZE2 " +
                     " ,MAX(case when sizeorder.ORDERNO=3 then sizeorder.SizeID end ) SIZE3" +
                     " ,MAX(case when sizeorder.ORDERNO=4 then sizeorder.SizeID end ) SIZE4" +
                     " ,MAX(case when sizeorder.ORDERNO=5 then sizeorder.SizeID end ) SIZE5" +
                     " ,MAX(case when sizeorder.ORDERNO=6 then sizeorder.SizeID end ) SIZE6" +
                     " ,MAX(case when sizeorder.ORDERNO=7 then sizeorder.SizeID end ) SIZE7" +
                     " ,MAX(case when sizeorder.ORDERNO=8 then sizeorder.SizeID end ) SIZE8" +
                     " ,MAX(case when sizeorder.ORDERNO=9 then sizeorder.SizeID end ) SIZE9" +
                     " ,MAX(case when sizeorder.ORDERNO=10 then sizeorder.SizeID end ) SIZE10" +
                     " ,MAX(case when sizeorder.ORDERNO=11 then sizeorder.SizeID end ) SIZE11" +
                     " ,MAX(case when sizeorder.ORDERNO=12 then sizeorder.SizeID end ) SIZE12" +

                     " ,MAX(case when sizeorder.ORDERNO=1 then gradingdetail.BASIC end ) BASIC1" +
                     " ,MAX(case when sizeorder.ORDERNO=2 then gradingdetail.BASIC end ) BASIC2" +
                     " ,MAX(case when sizeorder.ORDERNO=3 then gradingdetail.BASIC end ) BASIC3" +
                     " ,MAX(case when sizeorder.ORDERNO=4 then gradingdetail.BASIC end ) BASIC4" +
                     ",MAX(case when sizeorder.ORDERNO=5 then gradingdetail.BASIC end ) BASIC5" +
                     " ,MAX(case when sizeorder.ORDERNO=6 then gradingdetail.BASIC end ) BASIC6" +
                     ",MAX(case when sizeorder.ORDERNO=7 then gradingdetail.BASIC end ) BASIC7" +
                     " ,MAX(case when sizeorder.ORDERNO=8 then gradingdetail.BASIC end ) BASIC8" +
                     " ,MAX(case when sizeorder.ORDERNO=9 then gradingdetail.BASIC end ) BASIC9" +
                     " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC end ) BASIC10" +
                     " ,MAX(case when sizeorder.ORDERNO=11 then gradingdetail.BASIC end ) BASIC11" +
                     " ,MAX(case when sizeorder.ORDERNO=12 then gradingdetail.BASIC end ) BASIC12" +

                     " ,MAX(case when sizeorder.ORDERNO=1 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN1" +
                     " ,MAX(case when sizeorder.ORDERNO=2 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN2" +
                     " ,MAX(case when sizeorder.ORDERNO=3 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN3" +
                     " ,MAX(case when sizeorder.ORDERNO=4 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN4" +
                     " ,MAX(case when sizeorder.ORDERNO=5 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN5" +
                     " ,MAX(case when sizeorder.ORDERNO=6 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN6" +
                      " ,MAX(case when sizeorder.ORDERNO=7 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN7" +
                      " ,MAX(case when sizeorder.ORDERNO=8 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN8" +
                      " ,MAX(case when sizeorder.ORDERNO=9 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN9" +
                      " ,MAX(case when sizeorder.ORDERNO=10 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN10" +
                      " ,MAX(case when sizeorder.ORDERNO=11 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN11" +
                      " ,MAX(case when sizeorder.ORDERNO=12 then gradingdetail.BASIC*(1-(direction.LWVALUE/100)) end ) PATTERN12" +

                      " from grading " +
                      " inner join gradingdetail on grading.STYLEID=gradingdetail.STYLEID" +
                      " inner join measurement on measurement.MEID=gradingdetail.MEID" +
                      " inner join size on size.SIZEID=gradingdetail.SIZEID" +
                      " inner join style on style.STYLEID=grading.STYLEID" +
                      " inner join buyer on buyer.BUYERID =grading.BUYERID" +
                      " inner join measurementstyle on measurementstyle.STYLEID=style.STYLEID and measurementstyle.MEID=measurement.MEID AND measurement.BUYERID=measurementstyle.BUYERID  " +
                      " inner join direction on direction.STYLEID=gradingdetail.STYLEID AND direction.LW=gradingdetail.DIRECTION" +
                      " inner join sizeorder on sizeorder.SIZEID=gradingdetail.SIZEID AND sizeorder.STYLEID=gradingdetail.STYLEID" +
                      " where grading.STYLEID='" + txtStyleID.Text + "'" +
                      " GROUP BY buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE,direction.LW,measurement.MEID,measurement.MEASUREMENT " +
                      " ORDER BY sizeorder.ORDERNO,measurementstyle.CEK";
                MySqlDataAdapter printDataAdapter = new MySqlDataAdapter(strQuery, connection);
                printDataAdapter.Fill(dataPrint, "gradingPrint");
                Application.DoEvents();
                dataPrint.WriteXml("C:\\MyGarmentReport\\qcspec.xml", XmlWriteMode.WriteSchema);
                if (cbUOM.Text == "INCH")
                {
                    Form f = new printGrading1();
                    f.Show();
                }
                else
                {
                    Form f = new printGrading();
                    f.Show();
                }

               
            }
            else
            {
                MessageBox.Show("wrong proses");
            }

        }

        private void detailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //

        }

        private void detailsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // dgFactures.Rows(dgFactures.CurrentRow.Cells(0).RowIndex).Cells(2).Value = bindingpart.Current("Description").ToString
            //
   
        }

        private void detailsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void detailsDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (detailsDataGridView.CurrentCell.ColumnIndex == 3 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            if (detailsDataGridView.CurrentCell.ColumnIndex == 3 )
            {
                var currentcell = detailsDataGridView.CurrentCellAddress;
                var sendingCB = sender as DataGridViewComboBoxEditingControl;
                string MEID;
                DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)detailsDataGridView.Rows[currentcell.Y].Cells["MEASUREMENT"];
                MEID = sendingCB.EditingControlFormattedValue.ToString();
                //cel.Value = sendingCB.EditingControlFormattedValue.ToString();

                //cari di database
                DataSet ds = new DataSet();
                //MySqlConnection connection = new MySqlConnection(Global.strCon);
                string str = "select * from measurement where MEID='" + MEID + "'";//" + detailsDataGridView.Rows[detailsDataGridView.CurrentRow.Index].Cells["MEID"].Value + "'";
                MySqlConnection con = new MySqlConnection(Global.strCon);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(str, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "measurement");
                if (ds.Tables["measurement"].Rows.Count > 0)
                {
                    cel.Value = ds.Tables["measurement"].Rows[0]["MEASUREMENT"].ToString();
                    //detailsDataGridView.Rows[detailsDataGridView.CurrentRow.Index].Cells["MEASUREMENT"].Value = ds.Tables["measurement"].Rows[0]["MEASUREMENT"].ToString();
                    //detailsDataGridView.Rows[intRownum].Cells[4].Value = ds.Tables["Product_Details"].Rows[intRownum][1].ToString();
                    detailsDataGridView.Update();
                }
                con.Close();


            }

        }
        private void comboBox_SelecteIndexChanged(object sender, EventArgs e)
        {
            try
            {/*
                DataSet ds = new DataSet();
                string str = "select ProductCategory,ProductName from Product_Details where ProductID='" + dataGridView1.Rows[intRownum].Cells[2].Value + "'";
                MSqlConnection con = new SqlConnection(Class1.cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Product_Details");
                if (ds.Tables["Product_Details"].Rows.Count > 0)
                {
                    dataGridView1.Rows[intRownum].Cells[3].Value = ds.Tables["Product_Details"].Rows[intRownum][0].ToString();
                    dataGridView1.Rows[intRownum].Cells[4].Value = ds.Tables["Product_Details"].Rows[intRownum][1].ToString();
                    dataGridView1.Update();
                }
              */
                /*
                DataSet ds = new DataSet();
                //MySqlConnection connection = new MySqlConnection(Global.strCon);
                string str = "select * from measurement where MEID='0001'";//" + detailsDataGridView.Rows[detailsDataGridView.CurrentRow.Index].Cells["MEID"].Value + "'";
                MySqlConnection con = new MySqlConnection(Global.strCon);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(str, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "measurement");
                if (ds.Tables["measurement"].Rows.Count > 0)
                {
                    detailsDataGridView.Rows[detailsDataGridView.CurrentRow.Index].Cells["MEASUREMENT"].Value = ds.Tables["measurement"].Rows[0]["MEASUREMENT"].ToString();
                    //detailsDataGridView.Rows[intRownum].Cells[4].Value = ds.Tables["Product_Details"].Rows[intRownum][1].ToString();
                    detailsDataGridView.Update();
                }
                con.Close();
               // MessageBox.Show("jancuk");
                 */
                
                    //MessageBox.Show(detailsDataGridView.Rows[detailsDataGridView.CurrentRow.Index].Cells["MEID"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private bool LW()
        {
            bool stat = false;
            try
            {
                DataSet dataPrint = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);

                string strQuery = "SELECT * FROM direction WHERE styleid='" + txtStyleID.Text + "'";
                MySqlDataAdapter printDataAdapter = new MySqlDataAdapter(strQuery, connection);
                printDataAdapter.Fill(dataPrint, "gradingPrint");

                Application.DoEvents();
                dataPrint.WriteXml("C:\\MyGarmentReport\\qclw.xml", XmlWriteMode.WriteSchema);
                stat = true;
            }
            catch
            {
            }
            return stat;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);

            string strQuery = "SELECT * FROM direction WHERE styleid='"+txtStyleID.Text+"'";
            MySqlDataAdapter printDataAdapter = new MySqlDataAdapter(strQuery, connection);
            printDataAdapter.Fill(dataPrint, "gradingPrint");

            Application.DoEvents();
            dataPrint.WriteXml("C:\\MyGarmentReport\\qclw.xml", XmlWriteMode.WriteSchema);

            Form f = new printGrading();
            f.Show();
        }

        private void cbPrint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdListInch_Click(object sender, EventArgs e)
        {
            frmInch f = new frmInch();
            f.MdiParent = this.MdiParent;
            f.Show();
            
            /*
            fFormObj.TopLevel = false;
            this.Controls.Add(fFormObj);
            fFormObj.Parent = this;
            fFormObj.TopMost = true;
            */
        }
    }
}
