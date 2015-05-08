using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Grading.Quality
{
    public partial class frmreject : Form
    {
        public delegate void SetParameterValueDelegate(string date1, string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
        string style;
        string color;
        
        //item reject detail
        private string STYLEID { get; set; } //1
        private string COLORID { get; set; } //2
        private string CODE { get; set; } //3 CODE
        private string CODE1 { get; set; } //3 CODE
        private string SIZEID { get; set; } //4
        
        private double QTY { get; set; }

        private DataSet data = null;
        private DataSet data1 = null;
        BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;


        public frmreject()
        {
            InitializeComponent();
        }

        private void SetStyleCallBack(string SetStyleID, string SetstyleDesc, string SetcolorID, string SetcolorName, string SetbuyerID, string SetBuyerName)
        {
            txtStyleID.Text = SetStyleID;
            txtColorID.Text = SetcolorID;
            txtStyleName.Text = SetstyleDesc;
            txtColorName.Text = SetcolorName;
            txtBuyerID.Text = SetbuyerID;
            txtBuyerName.Text = SetBuyerName;
            style = SetStyleID;
            color = SetcolorID;
        }
        private bool insertRejectDetail(string STYLEID, string COLORID, string CODE, string SIZEID, double QTY)
        {
            bool stat = false;
            try
            {
                DataSet ds = new DataSet();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                //command
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                // Command.CommandText = "Select * from Orders ";
                Command.CommandText = "INSERT INTO rejectdetail(STYLEID,COLORID,CODE,SIZEID,QTY) VALUES(@STYLEID,@COLORID,@CODE,@SIZEID,@QTY)";
                //item insert
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@COLORID", COLORID);
                Command.Parameters.AddWithValue("@CODE", CODE);
                Command.Parameters.AddWithValue("@SIZEID", SIZEID);
                Command.Parameters.AddWithValue("@QTY", QTY);

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
        private bool updateRejectDetail(string STYLEID, string COLORID, string CODE,string CODE1, string SIZEID, double QTY)
        {
            bool stat = false;
            try
            {
                DataSet ds = new DataSet();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                //command
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                // Command.CommandText = "Select * from Orders ";
                Command.CommandText = "UPDATE rejectdetail SET CODE=@CODE,QTY=@QTY  WHERE STYLEID=@STYLEID AND COLORID=@COLORID AND SIZEID=@SIZEID AND CODE=@CODE1 ";
                Command.Parameters.AddWithValue("@CODE1", CODE);
                //item insert
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@COLORID", COLORID);
                Command.Parameters.AddWithValue("@CODE", CODE);
                Command.Parameters.AddWithValue("@SIZEID", SIZEID);
                Command.Parameters.AddWithValue("@QTY", QTY);

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

        private bool cekRejectDetail(string STYLEID, string COLORID,string CODE, string SIZEID)
        {
            bool stat = false;
            try
            {
                DataSet ds = new DataSet();
                MySqlConnection Connection = new MySqlConnection();
                //konek ke database
                Connection.ConnectionString = Global.strCon;
                Connection.Open(); //mulai konneksi
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                Command.CommandText = "SELECT * FROM rejectdetail  WHERE STYLEID=@STYLEID AND COLORID=@COLORID AND CODE=@CODE AND SIZEID=@SIZEID";
                //key
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@COLORID", COLORID);
                Command.Parameters.AddWithValue("@CODE", CODE);
                Command.Parameters.AddWithValue("@SIZEID", SIZEID);

                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
                DataAdapter.Fill(ds, "rejectdetail");
                MySqlCommandBuilder CommandBuilder = new MySqlCommandBuilder(DataAdapter);
                //--end masukan ke dataset
                Connection.Close();//akhiri koneksi
                if (ds.Tables["rejectdetail"].Rows.Count == 0)
                {
                    stat = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stat;
        }


        private void getData(string Style,string Color)
        {
            data = new DataSet();
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);

                //string strQuery = "SELECT * FROM reject where STYLEID=@StyleID AND COLORID=@ColorID";
                masterDataAdapter = new MySqlDataAdapter("select * from reject where STYLEID='" + Style + "' and COLORID ='" + Color + "'", connection);
               // masterDataAdapter.SelectCommand.Parameters.AddWithValue("@StyleID", txtStyleID.Text);
               // masterDataAdapter.SelectCommand.Parameters.AddWithValue("@ColorID", txtColorID.Text);
                masterDataAdapter.Fill(data, "reject");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "reject";

                txtStyleID.DataBindings.Clear();
                txtColorID.DataBindings.Clear();

                //txtStyleID.DataBindings.Add(new Binding("Text", masterBindingSource, "STYLEID", true, DataSourceUpdateMode.OnPropertyChanged));
                //txtColorID.DataBindings.Add(new Binding("Text", masterBindingSource, "COLORID", true, DataSourceUpdateMode.OnPropertyChanged));
                txtStyleID.DataBindings.Add(new Binding("Text", masterBindingSource, "STYLEID", true, DataSourceUpdateMode.OnPropertyChanged));
                txtColorID.DataBindings.Add(new Binding("Text", masterBindingSource, "COLORID", true, DataSourceUpdateMode.OnPropertyChanged));


                if (data.Tables["reject"].Rows.Count < 1)
                {
                    masterBindingSource.AddNew(); //inisial untuk insert new
                    txtStyleID.Text = style;
                    txtColorID.Text = color;
                    dateGrading.Value = DateTime.Now;
                }
                else
                {
                    txtStyleID.DataBindings.Clear();
                    txtColorID.DataBindings.Clear();
                    dateGrading.DataBindings.Clear();

                    txtStyleID.DataBindings.Add(new Binding("Text", masterBindingSource, "STYLEID", true, DataSourceUpdateMode.OnPropertyChanged));
                    txtColorID.DataBindings.Add(new Binding("Text", masterBindingSource, "COLORID", true, DataSourceUpdateMode.OnPropertyChanged));
                    dateGrading.DataBindings.Add(new Binding("Text", masterBindingSource, "DATE", true, DataSourceUpdateMode.OnPropertyChanged));

                }

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void AddItemDetails(string style,string color)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                data1 = new DataSet();
                string strQuery = "SELECT "+
                    "style.STYLEID,color.COLORID,rejectlist.CODE CODE1,rejectlist.CODE, " +
                    "MAX(case when sizeorder.ORDERNO=1 then rejectdetail.QTY end ) QTY1, "+
                    "MAX(case when sizeorder.ORDERNO=2 then rejectdetail.QTY end ) QTY2, "+
                    "MAX(case when sizeorder.ORDERNO=3 then rejectdetail.QTY end ) QTY3, "+
                    "MAX(case when sizeorder.ORDERNO=4 then rejectdetail.QTY end ) QTY4, "+
                    "MAX(case when sizeorder.ORDERNO=5 then rejectdetail.QTY end ) QTY5, "+
                    "MAX(case when sizeorder.ORDERNO=6 then rejectdetail.QTY end ) QTY6, "+ 
                    "MAX(case when sizeorder.ORDERNO=7 then rejectdetail.QTY end ) QTY7, "+
                    "MAX(case when sizeorder.ORDERNO=8 then rejectdetail.QTY end ) QTY8, "+
                    "MAX(case when sizeorder.ORDERNO=9 then rejectdetail.QTY end ) QTY9, "+
                    "MAX(case when sizeorder.ORDERNO=10 then rejectdetail.QTY end ) QTY10, "+
                    "MAX(case when sizeorder.ORDERNO=11 then rejectdetail.QTY end ) QTY11, "+
                    "MAX(case when sizeorder.ORDERNO=12 then rejectdetail.QTY end ) QTY12 "+
                    "FROM reject "+
                    "inner join rejectdetail on reject.STYLEID=rejectdetail.STYLEID AND reject.COLORID=rejectdetail.COLORID "+
                    "inner join style on style.STYLEID=reject.STYLEID "+
                    "inner join color on color.COLORID=reject.COLORID "+
                    "inner join rejectlist on rejectlist.CODE =rejectdetail.CODE "+
                    "inner join sizeorder on sizeorder.STYLEID=rejectdetail.STYLEID AND sizeorder.SIZEID=rejectdetail.SIZEID "+
                    "WHERE reject.STYLEID=@STYLEID AND reject.COLORID=@COLORID " +
                    "GROUP BY reject.DATE,style.STYLENAME,color.COLORNAME,rejectlist.CODE";
                MySqlDataAdapter ItemDataAdapter = new MySqlDataAdapter(strQuery, connection);
                ItemDataAdapter.SelectCommand.Parameters.AddWithValue("@STYLEID", style);
                ItemDataAdapter.SelectCommand.Parameters.AddWithValue("@COLORID", color);
                ItemDataAdapter.Fill(data1, "rejectsize");


                for (int i = 0; i < data1.Tables[0].Rows.Count; i++)
                {
                    //isi add colom
                    detailsDataGridView.Rows.Add();
                    for (int j = 0; j < detailsDataGridView.Columns.Count; j++)
                    {
                        detailsDataGridView.Rows[i].Cells[j].Value = data1.Tables[0].Rows[i][j];

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddColumnDetail(string style)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data1 = new DataSet();
                string sqlQuery = "select * from sizeorder where styleid='" + style + "' order by ORDERNO";
                MySqlDataAdapter ColumDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
                ColumDataAdapter.Fill(data1, "style");

            
                //list size 

                string selectQueryStringSIZEID = "SELECT SIZEID FROM sizeorder where STYLEID='" + style + "'";

                MySqlDataAdapter sqlDataAdapterSIZEID = new MySqlDataAdapter(selectQueryStringSIZEID, connection);
                MySqlCommandBuilder sqlCommandBuilderSIZEID = new MySqlCommandBuilder(sqlDataAdapterSIZEID);

                DataTable dataTableSIZEID = new DataTable();
                sqlDataAdapterSIZEID.Fill(dataTableSIZEID);
                BindingSource bindingSourceSIZEID = new BindingSource();
                bindingSourceSIZEID.DataSource = dataTableSIZEID;

                //list MEID
                string selectQueryStringMEID = "SELECT * FROM rejectlist";

                MySqlDataAdapter sqlDataAdapterMEID = new MySqlDataAdapter(selectQueryStringMEID, connection);
                MySqlCommandBuilder sqlCommandBuilderMEID = new MySqlCommandBuilder(sqlDataAdapterMEID);

                DataTable dataTableMEID = new DataTable();
                sqlDataAdapterMEID.Fill(dataTableMEID);
                BindingSource bindingSourceMEID = new BindingSource();
                bindingSourceMEID.DataSource = dataTableMEID;
           
                //add colom detail
                detailsDataGridView.Columns.Clear();

                detailsDataGridView.Columns.Add("STYLEID", "STYLEID");
                detailsDataGridView.Columns["STYLEID"].Visible = true;
                detailsDataGridView.Columns.Add("COLORID", "COLORID");
                detailsDataGridView.Columns["COLORID"].Visible = true;
                detailsDataGridView.Columns.Add("CODE1", "CODE1"); //CODE
                detailsDataGridView.Columns["CODE1"].Visible = true;
         

                DataGridViewComboBoxColumn MEColumn = new DataGridViewComboBoxColumn();
                MEColumn.HeaderText = "CODE";
                MEColumn.Width = 250;
                MEColumn.DataPropertyName = "CODE";
                MEColumn.Name = "CODE";

                //binding
                MEColumn.DataSource = bindingSourceMEID;
                MEColumn.ValueMember = "CODE";
                MEColumn.DisplayMember = "NAME";

                detailsDataGridView.Columns.Add(MEColumn);

     

      

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
        private void cmdStyleID_Click(object sender, EventArgs e)
        {

            findStyleColor f = new findStyleColor();
            f.AddItemCallback = new findStyleColor.AddCategoryDelegate(this.SetStyleCallBack);
            f.ShowDialog();

            if (txtStyleID.Text != "")
            {
                getData(txtStyleID.Text,txtColorID.Text);
                AddColumnDetail(txtStyleID.Text);// cukup
                AddItemDetails(txtStyleID.Text,txtColorID.Text);

            }
        }

        private void saveItem()
        {
            detailsDataGridView.EndEdit();
            for (int i = 0; i < detailsDataGridView.Rows.Count - 1; i++)
            {
                STYLEID = txtStyleID.Text;
                COLORID = txtColorID.Text;
                CODE = Convert.ToString(detailsDataGridView.Rows[i].Cells["CODE"].Value);
                CODE1 = Convert.ToString(detailsDataGridView.Rows[i].Cells["CODE1"].Value);

                for (int j = 4; j < detailsDataGridView.Columns.Count; j++)
                    {
                        
                        SIZEID = detailsDataGridView.Columns[j].HeaderText;
                        try
                        {
                            QTY = Convert.ToDouble(detailsDataGridView.Rows[i].Cells[SIZEID].Value);
                        }
                        catch
                        {
                            QTY = 0.0;
                        }

                        if (cekRejectDetail(STYLEID,COLORID, CODE, SIZEID))
                        {


                            if (insertRejectDetail(STYLEID, COLORID,CODE, SIZEID, QTY))
                            {
                                detailsDataGridView.Rows[i].Cells["STYLEID"].Value = STYLEID;
                                detailsDataGridView.Rows[i].Cells["COLORID"].Value = COLORID;
                                detailsDataGridView.Rows[i].Cells["CODE1"].Value = CODE;

                            }
                            //insert

                        }

                        else
                        {

                            if (updateRejectDetail(STYLEID,COLORID, CODE, CODE1 , SIZEID, QTY))
                            {
                                detailsDataGridView.Rows[i].Cells["CODE1"].Value = CODE;
                            }

                        }
                     
                    }
               

            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "reject");
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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            rejectRptFrm f = new rejectRptFrm();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }
    }
}
