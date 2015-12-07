﻿using System;
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
    public partial class Booking : Form
    {
        //field table
        //item grading detail
        private string styleid1 { get; set; }
        private string sizeid1 { get; set; }
        private int? no1 { get; set; }

        private string styleid { get; set; }
        private string sizeid { get; set; }
        private int? no { get; set; }

        private DateTime? datercvd { get; set; }
        private DateTime? datesend { get; set; }
       // private string? datercvd { get; set; }
       // private string? datesend { get; set; }

        private string status { get; set; }
        private string crffrom { get; set; }
        private string fabric { get; set; }
        private string doneby { get; set; }
        private string Remark { get; set; }
        //
        private string GStrCode = "";
        public delegate void SetParameterValueDelegate(string date1);
        public SetParameterValueDelegate SetParameterValueCallback;
        //private string GStrCode = "";
        //private string GitemsDesc = "";
        //private string GBuyerID = "";
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlCommandBuilder sqlCommandBuilder = null;
  

        public Booking()
        {
            InitializeComponent();
        }
        private void getData(DateTime tgl)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                //string strAdapter = "SELECT * FROM srfbooking WHERE DATE(datercvd)=DATE('" + tgl.ToString("yyyy-MM-dd") + "')";
                string strAdapter = "SELECT " +
                    "srfsetting.styleid styleid1,srfbooking.sizeid sizeid1,srfbooking.no no1,srfbooking.no,srfsetting.styleid,srfsetting.buyerid,status,srfbooking.sizeid " +
                    ",srfbooking.crffrom,srfbooking.datercvd,srfbooking.datesend " +
                    ",srfbooking.fabric " +
                    // ",if(date(srfbooking.datercvd) < date('2015-07-08') AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdprev "+
                    // ",if(date(srfbooking.datesend) < date('2015-07-08') AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishprev "+
                    // ",if(date(srfbooking.datercvd) = date('2015-07-08') AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdtoday "+
                    //",if(date(srfbooking.datesend) = date('2015-07-08') AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishtoday "+
                    ",srfbooking.doneby,srfbooking.Remark " +
                    "FROM srfbooking " +
                    "INNER JOIN srfsetting on srfsetting.styleid=srfbooking.styleid " +
                    "WHERE (DATE(srfsetting.bookingend)> DATE(@tgl) or ISNULL(srfsetting.bookingend)) AND DATE(srfsetting.bookingstart)<= DATE(@tgl) ";

                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@tgl", tgl.ToString("yyyy-MM-dd"));
                masterDataAdapter.Fill(data, "srfbooking");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "srfbooking";

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


                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "styleid";
                ColumnStyle.Name = "styleid";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                masterDataGridView.Columns.Add(ColumnStyle);


                DataGridViewComboBoxColumn ColumnBuyer = new DataGridViewComboBoxColumn();
                ColumnBuyer.HeaderText = "BUYER";
                ColumnBuyer.Width = 150;
                ColumnBuyer.DataPropertyName = "BUYERID";
                ColumnBuyer.Name = "BUYERID";
                ColumnBuyer.ReadOnly = false;
                ColumnBuyer.Visible = false;
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "BUYERID";
                ColumnBuyer.DisplayMember = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnBuyer);

                // binding
                DataGridViewComboBoxColumn ColumnSize = new DataGridViewComboBoxColumn();
                ColumnSize.HeaderText = "SIZE";
                ColumnSize.Width = 150;
                ColumnSize.DataPropertyName = "SIZEID";
                ColumnSize.Name = "SIZEID";
                ColumnSize.ReadOnly = false;
                //binding
                ColumnSize.DataSource = bindingSourceSize;
                ColumnSize.ValueMember = "SIZEID";
                ColumnSize.DisplayMember = "SIZENAME";
                masterDataGridView.Columns.Add(ColumnSize);
                //                

                DataGridViewTextBoxColumn ColumnNO = new DataGridViewTextBoxColumn();
                ColumnNO.HeaderText = "No";
                ColumnNO.Width = 40;
                ColumnNO.DataPropertyName = "no";
                ColumnNO.Name = "no";
                ColumnNO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                masterDataGridView.Columns.Add(ColumnNO);

                DataGridViewTextBoxColumn Columnstyleid1 = new DataGridViewTextBoxColumn();
                Columnstyleid1.HeaderText = "styleid1";
                Columnstyleid1.Width = 80;
                Columnstyleid1.DataPropertyName = "styleid1";
                Columnstyleid1.Name = "styleid1";
                Columnstyleid1.ReadOnly = true;
                Columnstyleid1.Visible = false;
                masterDataGridView.Columns.Add(Columnstyleid1);

                DataGridViewTextBoxColumn Columnsizeid1 = new DataGridViewTextBoxColumn();
                Columnsizeid1.HeaderText = "sizeid1";
                Columnsizeid1.Width = 80;
                Columnsizeid1.DataPropertyName = "sizeid1";
                Columnsizeid1.Name = "sizeid1";
                Columnsizeid1.ReadOnly = true;
                Columnsizeid1.Visible = false;
                masterDataGridView.Columns.Add(Columnsizeid1);

                DataGridViewTextBoxColumn ColumnNo1 = new DataGridViewTextBoxColumn();
                ColumnNo1.HeaderText = "no1";
                ColumnNo1.Width = 80;
                ColumnNo1.DataPropertyName = "no1";
                ColumnNo1.Name = "no1";
                ColumnNo1.ReadOnly = true;
                ColumnNo1.Visible = false;
                masterDataGridView.Columns.Add(ColumnNo1);
                

                
                //status
                DataGridViewTextBoxColumn ColumnStatus = new DataGridViewTextBoxColumn();
                ColumnStatus.HeaderText = "STATUS";
                ColumnStatus.Width = 80;
                ColumnStatus.DataPropertyName = "status";
                ColumnStatus.Name = "status";
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
        private void getData(string tgl)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                //string strAdapter = "SELECT * FROM srfbooking WHERE DATE(datercvd)=DATE('" + tgl.ToString("yyyy-MM-dd") + "')";
                string strAdapter = "SELECT " +
                    "srfsetting.styleid styleid1,srfbooking.sizeid sizeid1,srfsetting.styleid,srfsetting.buyerid,status,srfbooking.sizeid " +
                    ",srfbooking.crffrom,srfbooking.datercvd,srfbooking.datesend " +
                    ",srfbooking.fabric " +
                    // ",if(date(srfbooking.datercvd) < date('2015-07-08') AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdprev "+
                    // ",if(date(srfbooking.datesend) < date('2015-07-08') AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishprev "+
                    // ",if(date(srfbooking.datercvd) = date('2015-07-08') AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdtoday "+
                    //",if(date(srfbooking.datesend) = date('2015-07-08') AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishtoday "+
                    ",srfbooking.doneby,srfbooking.Remark " +
                    "FROM srfbooking " +
                    "INNER JOIN srfsetting on srfsetting.styleid=srfbooking.styleid " +
                    "WHERE srfsetting.styleid LIKE @tgl ";

                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@tgl", "%" + tgl + "%");
                masterDataAdapter.Fill(data, "srfbooking");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "srfbooking";

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
                ColumnBuyer.Visible = false;
                //binding
                ColumnBuyer.DataSource = bindingSourceLW;
                ColumnBuyer.ValueMember = "BUYERID";
                ColumnBuyer.DisplayMember = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnBuyer);

                DataGridViewTextBoxColumn Columnstyleid1 = new DataGridViewTextBoxColumn();
                Columnstyleid1.HeaderText = "styleid1";
                Columnstyleid1.Width = 80;
                Columnstyleid1.DataPropertyName = "styleid1";
                Columnstyleid1.Name = "styleid1";
                Columnstyleid1.ReadOnly = true;
                Columnstyleid1.Visible = false;
                masterDataGridView.Columns.Add(Columnstyleid1);

                DataGridViewTextBoxColumn Columnsizeid1 = new DataGridViewTextBoxColumn();
                Columnsizeid1.HeaderText = "sizeid1";
                Columnsizeid1.Width = 80;
                Columnsizeid1.DataPropertyName = "sizeid1";
                Columnsizeid1.Name = "sizeid1";
                Columnsizeid1.ReadOnly = true;
                Columnsizeid1.Visible = false;
                masterDataGridView.Columns.Add(Columnsizeid1);

                //status
                DataGridViewTextBoxColumn ColumnStatus = new DataGridViewTextBoxColumn();
                ColumnStatus.HeaderText = "Status";
                ColumnStatus.Width = 80;
                ColumnStatus.DataPropertyName = "status";
                ColumnStatus.Name = "status";
                masterDataGridView.Columns.Add(ColumnStatus);

                // binding
                DataGridViewComboBoxColumn ColumnSize = new DataGridViewComboBoxColumn();
                ColumnSize.HeaderText = "SIZEID";
                ColumnSize.Width = 150;
                ColumnSize.DataPropertyName = "SIZEID";
                ColumnSize.Name = "SIZEID";
                ColumnSize.ReadOnly = false;
                //binding
                ColumnSize.DataSource = bindingSourceSize;
                ColumnSize.ValueMember = "SIZEID";
                ColumnSize.DisplayMember = "SIZENAME";
                masterDataGridView.Columns.Add(ColumnSize);
                //

                DataGridViewTextBoxColumn ColumnCrfFrom = new DataGridViewTextBoxColumn();
                ColumnCrfFrom.HeaderText = "crffrom";
                ColumnCrfFrom.Width = 80;
                ColumnCrfFrom.DataPropertyName = "crffrom";
                ColumnCrfFrom.Name = "crffrom";
                masterDataGridView.Columns.Add(ColumnCrfFrom);

                DataGridViewTextBoxColumn ColumnDateReceive = new DataGridViewTextBoxColumn();
                ColumnDateReceive.HeaderText = "Receive";
                ColumnDateReceive.Width = 80;
                ColumnDateReceive.DataPropertyName = "datercvd";
                ColumnDateReceive.Name = "datercvd";
                masterDataGridView.Columns.Add(ColumnDateReceive);

                DataGridViewTextBoxColumn ColumnDateSend = new DataGridViewTextBoxColumn();
                ColumnDateSend.HeaderText = "Send";
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
                ColumnDoneBy.HeaderText = "doneby";
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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            getData(dateQC.Value.Date);
            cmdSave.Enabled = true;
        }

        private bool insertBooking(string styleid, string sizeid, int? no,DateTime? datercvd, DateTime? datesend, string status, string crffrom, string fabric, string doneby, string remark)
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
                //Command.CommandText = "INSERT INTO srfbooking(styleid,sizeid,datercvd,datesend,status,crffrim,fabric,doneby,remark) VALUES(@STYLEID,@MEID,@SIZEID,@DIRECTION,@BASIC)";
                Command.CommandText = "INSERT INTO srfbooking (styleid, sizeid, no,datercvd, datesend, status, crffrom, fabric, doneby, Remark) VALUES (@styleid, @sizeid, @no,@datercvd, @datesend, @status, @crffrom, @fabric, @doneby, @Remark)";
                //item insert
                Command.Parameters.AddWithValue("@styleid", styleid);
                Command.Parameters.AddWithValue("@sizeid", sizeid);
                Command.Parameters.AddWithValue("@no", no);
                Command.Parameters.AddWithValue("@datercvd", datercvd);
                Command.Parameters.AddWithValue("@datesend", datesend);
                Command.Parameters.AddWithValue("@status", status);
                Command.Parameters.AddWithValue("@crffrom", crffrom);
                Command.Parameters.AddWithValue("@fabric", fabric);
                Command.Parameters.AddWithValue("@doneby", doneby);
                Command.Parameters.AddWithValue("@Remark", remark);
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

        private bool updateBooking(string styleid1, string sizeid1, int? no1,string styleid, string sizeid,int? no, DateTime? datercvd, DateTime? datesend, string status, string crffrom, string fabric, string doneby, string remark)
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
                //Command.CommandText = "INSERT INTO srfbooking(styleid,sizeid,datercvd,datesend,status,crffrim,fabric,doneby,remark) VALUES(@STYLEID,@MEID,@SIZEID,@DIRECTION,@BASIC)";
                Command.CommandText = "UPDATE srfbooking SET styleid=@styleid, sizeid=@sizeid, no=@no,datercvd=@datercvd, datesend=@datesend, status=@status, crffrom=@crffrom, fabric=@fabric, doneby=@doneby, Remark=@Remark WHERE styleid=@styleid1 AND sizeid=@sizeid1 AND no=@no1";
                //key
                Command.Parameters.AddWithValue("@styleid1", styleid1);
                Command.Parameters.AddWithValue("@sizeid1", sizeid1);
                Command.Parameters.AddWithValue("@no1", no1);
                Command.Parameters.AddWithValue("@no", no);
                Command.Parameters.AddWithValue("@styleid", styleid);
                Command.Parameters.AddWithValue("@sizeid", sizeid);
                Command.Parameters.AddWithValue("@datercvd", datercvd);
                Command.Parameters.AddWithValue("@datesend", datesend);
                Command.Parameters.AddWithValue("@status", status);
                Command.Parameters.AddWithValue("@crffrom", crffrom);
                Command.Parameters.AddWithValue("@fabric", fabric);
                Command.Parameters.AddWithValue("@doneby", doneby);
                Command.Parameters.AddWithValue("@Remark", remark);


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

        private bool deleteBooking(string styleid, string sizeid,int no)
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
                //Command.CommandText = "INSERT INTO srfbooking(styleid,sizeid,datercvd,datesend,status,crffrim,fabric,doneby,remark) VALUES(@STYLEID,@MEID,@SIZEID,@DIRECTION,@BASIC)";
                Command.CommandText = "DELETE FROM srfbooking WHERE styleid=@styleid AND sizeid=@sizeid AND no=@no";
                //item insert
                Command.Parameters.AddWithValue("@styleid", styleid);
                Command.Parameters.AddWithValue("@sizeid", sizeid);
                Command.Parameters.AddWithValue("@no", no);
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
        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterDataGridView.EndEdit();
                for (int i = 0; i < masterDataGridView.Rows.Count-1; i++)
                {
                    //simpan
                    styleid1 = Convert.ToString(masterDataGridView.Rows[i].Cells["styleid1"].Value);
                    sizeid1 = Convert.ToString(masterDataGridView.Rows[i].Cells["sizeid1"].Value);
                    if (masterDataGridView.Rows[i].Cells["no1"].Value != DBNull.Value)
                    {
                        no1 = Convert.ToInt32(masterDataGridView.Rows[i].Cells["no1"].Value);
                    }
                    styleid = Convert.ToString(masterDataGridView.Rows[i].Cells["styleid"].Value);
                    sizeid = Convert.ToString(masterDataGridView.Rows[i].Cells["sizeid"].Value);
                    if (masterDataGridView.Rows[i].Cells["no"].Value!=DBNull.Value)
                    {
                    no = Convert.ToInt32(masterDataGridView.Rows[i].Cells["no"].Value);
                    }

                    //datercvd = masterDataGridView.Rows[i].Cells["datercvd"].Value.ToString("dd-MM-yy");
                    if (masterDataGridView.Rows[i].Cells["datercvd"].Value.ToString() != "")
                    {
                        datercvd = Convert.ToDateTime(masterDataGridView.Rows[i].Cells["datercvd"].Value);
                    }
                    else
                    {
                        datercvd= null;
                    }

                    if (masterDataGridView.Rows[i].Cells["datesend"].Value.ToString() != "")
                    {
                        datesend = Convert.ToDateTime(masterDataGridView.Rows[i].Cells["datesend"].Value);
                    }
                    else
                    {
                        datesend = null;
                    }
                    //datercvd = Convert.ToDateTime(masterDataGridView.Rows[i].Cells["datercvd"].Value);
                    //datesend = Convert.ToDateTime(masterDataGridView.Rows[i].Cells["datesend"].Value);
                    status = Convert.ToString(masterDataGridView.Rows[i].Cells["status"].Value);
                    crffrom = Convert.ToString(masterDataGridView.Rows[i].Cells["crffrom"].Value);
                    fabric = Convert.ToString(masterDataGridView.Rows[i].Cells["fabric"].Value);
                    doneby = Convert.ToString(masterDataGridView.Rows[i].Cells["doneby"].Value);
                    Remark = Convert.ToString(masterDataGridView.Rows[i].Cells["Remark"].Value);

                    if (masterDataGridView.Rows[i].Cells["styleid1"].Value.ToString()=="")
                    {
                        //insert
                        insertBooking(styleid, sizeid, no, datercvd, datesend, status, crffrom, fabric, doneby, Remark);
                        masterDataGridView.Rows[i].Cells["styleid1"].Value = styleid;
                        masterDataGridView.Rows[i].Cells["sizeid1"].Value = sizeid;
                        masterDataGridView.Rows[i].Cells["no1"].Value = no;

                    }
                    else //update
                    {
                        updateBooking(styleid1, sizeid1,no1,styleid, sizeid,no, datercvd, datesend, status, crffrom, fabric, doneby, Remark);
                        masterDataGridView.Rows[i].Cells["styleid1"].Value = styleid;
                        masterDataGridView.Rows[i].Cells["sizeid1"].Value = sizeid;
                        masterDataGridView.Rows[i].Cells["no1"].Value = no;

                    }
                    //if e

                    //update
                }

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
                    if (item.Cells["styleid1"].Value.ToString() == "")
                    {
                        masterDataGridView.Rows.RemoveAt(item.Index);
                        //deleteBooking(item.Cells["styleid1"].Value.ToString(), item.Cells["sizeid1"].Value.ToString());
                        //masterBindingSource.RemoveAt(item.Index);
                    }else{

                        deleteBooking(item.Cells["styleid1"].Value.ToString(), item.Cells["sizeid1"].Value.ToString(), Convert.ToInt32(item.Cells["no1"].Value));
                        masterDataGridView.Rows.RemoveAt(item.Index);

                    }
                }
                //masterBindingSource.EndEdit();
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }
        private void SetItemsCallBack(string ItemsID)
        {
            GStrCode = ItemsID;
        }
        private void masterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //untuk costing
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] == masterDataGridView.Columns["STYLEID"])
            {
                GStrCode = "";
                findSetting f = new findSetting();
                f.AddItemCallback = new findSetting.AddCategoryDelegate(this.SetItemsCallBack);
                f.ShowDialog();
                if (GStrCode != "")
                {

                    masterDataGridView.Rows[e.RowIndex].Cells["STYLEID"].Value = GStrCode;

                }

            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtStyle.Text);
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            getData(dateQC.Value.Date);
        }

        private void cmdXSD_Click(object sender, EventArgs e)
        {
            DataSet dsReject = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strAdapter = "SELECT " +
                "srfsetting.styleid styleid1,srfbooking.sizeid sizeid1,srfsetting.styleid,srfsetting.buyerid,status,srfbooking.sizeid " +
                ",srfbooking.crffrom,srfbooking.datercvd,srfbooking.datesend " +
                ",srfbooking.fabric " +
                ",if(date(srfbooking.datercvd) < date('2015-07-08') AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdprev "+
                ",if(date(srfbooking.datesend) < date('2015-07-08') AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishprev "+
                ",if(date(srfbooking.datercvd) = date('2015-07-08') AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdtoday "+
                ",if(date(srfbooking.datesend) = date('2015-07-08') AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishtoday "+
                ",srfbooking.doneby,srfbooking.Remark " +
                "FROM srfbooking " +
                "INNER JOIN srfsetting on srfsetting.styleid=srfbooking.styleid " +
                "WHERE (DATE(srfsetting.bookingend)> DATE(@tgl) or ISNULL(srfsetting.bookingend)) AND DATE(srfsetting.bookingstart)<= DATE(@tgl) ";

            masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@tgl", dateQC.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.Fill(dsReject, "srfbookingxsd");
            Application.DoEvents();
            dsReject.WriteXmlSchema("C:\\MyGarmentReport\\srfbookingxsd.xsd");
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            BookingFrm f = new BookingFrm();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(dateQC.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }
    }
}
