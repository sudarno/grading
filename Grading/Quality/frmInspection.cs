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
    public partial class frmInspection : Form
    {
        public delegate void SetParameterValueDelegate(string date1, string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
        //field table
        //item reject detail
        string style = null;
        string color = null;
        
        private string STYLEID { get; set; } //1
        private string COLORID { get; set; } //2
        private int ID { get; set; } //3 CODE
        private int ID1 { get; set; }
        private int MAJOR { get; set; } //3 CODE
        private int MINOR { get; set; } //4
        private string NAME { get; set; }
        
        private double QTY { get; set; }

        private string GStrCode = "";
        private string GitemsDesc = "";
        private string GBuyerID = "";


        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();
        
        private MySqlDataAdapter masterDataAdapter = null;
        
        private MySqlCommandBuilder sqlCommandBuilder = null;

        private DataTable dataTableLW = null;

        public frmInspection()
        {
            InitializeComponent();
        }

        //CRUD detail
        private bool insertDetail(string STYLEID, string COLORID, int ID, int MAJOR, int MINOR,string NAME)
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
                Command.CommandText = "INSERT INTO qcinspectiondetail(STYLEID,COLORID,ID,MAJOR,MINOR,NAME) VALUES(@STYLEID,@COLORID,@ID,@MAJOR,@MINOR,@NAME)";
                //item insert
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@COLORID", COLORID);
                Command.Parameters.AddWithValue("@ID", ID);
                Command.Parameters.AddWithValue("@MAJOR", MAJOR);
                Command.Parameters.AddWithValue("@MINOR", MINOR);
                Command.Parameters.AddWithValue("@NAME", NAME);

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

        private bool updateDetail(string STYLEID, string COLORID, int ID1,int ID, int MAJOR, int MINOR, string NAME)
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
                Command.CommandText = "UPDATE qcinspectiondetail SET ID=@ID,MAJOR=@MAJOR,MINOR=@MINOR,NAME=@NAME WHERE STYLEID=@STYLEID AND COLORID=@COLORID AND ID=@ID1";
                //item insert
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@COLORID", COLORID);
                Command.Parameters.AddWithValue("@ID1", ID1);
                Command.Parameters.AddWithValue("@ID", ID);
                Command.Parameters.AddWithValue("@MAJOR", MAJOR);
                Command.Parameters.AddWithValue("@MINOR", MINOR);
                Command.Parameters.AddWithValue("@NAME", NAME);

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

        private bool updateDetail(string STYLEID, string COLORID, int ID)
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
                Command.CommandText = "DELETE FROM qcinspectiondetail WHERE STYLEID=@STYLEID AND COLORID=@COLORID AND ID=@ID";
                //item insert
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@COLORID", COLORID);
                Command.Parameters.AddWithValue("@ID", ID);

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

        //END CRUD

        private void saveItem()
        {
            detailsDataGridView.EndEdit();

            for (int i = 0; i < detailsDataGridView.Rows.Count - 1; i++)
            {
                STYLEID = Convert.ToString(detailsDataGridView.Rows[i].Cells["hSTYLEID"].Value);
                COLORID = Convert.ToString(detailsDataGridView.Rows[i].Cells["hCOLORID"].Value);

                ID = Convert.ToInt32(detailsDataGridView.Rows[i].Cells["hID"].Value);
                ID1 = Convert.ToInt32(detailsDataGridView.Rows[i].Cells["hID1"].Value);
                MAJOR = Convert.ToInt32(detailsDataGridView.Rows[i].Cells["hMAJOR"].Value);
                MINOR = Convert.ToInt32(detailsDataGridView.Rows[i].Cells["hMINOR"].Value);
                NAME = Convert.ToString(detailsDataGridView.Rows[i].Cells["hNAME"].Value);
                if (STYLEID=="") //untuk insert
                {
                    if (insertDetail(style, color, ID, MAJOR, MINOR, NAME))
                    {
                        detailsDataGridView.Rows[i].Cells["hSTYLEID"].Value = style;
                        detailsDataGridView.Rows[i].Cells["hCOLORID"].Value = color;
                        detailsDataGridView.Rows[i].Cells["hID1"].Value = ID;
                    }
                }else //untuk update
                {
                    if (updateDetail(style, color, ID1,ID, MAJOR, MINOR, NAME))
                    {
                        detailsDataGridView.Rows[i].Cells["hID1"].Value = ID;
                    }
                }
            }
        }
        private void getData(DateTime date)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM qcinspection WHERE DATE(DATE)=DATE('" + date.ToString("yyyy-MM-dd") + "')";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.Fill(data, "qcinspection");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "qcinspection";
                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;
                //detailsDataGridView.DataSource = detailsBindingSource;
                //list direct
                string selectQueryStringLW = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;
                //binding COLOR
                string selectQueryStringCOLOR = "SELECT * FROM color";

                MySqlDataAdapter sqlDataAdapterCOLOR = new MySqlDataAdapter(selectQueryStringCOLOR, connection);
                MySqlCommandBuilder sqlCommandBuilderCOLOR = new MySqlCommandBuilder(sqlDataAdapterCOLOR);

                DataTable dataTableCOLOR = new DataTable();
                sqlDataAdapterCOLOR.Fill(dataTableCOLOR);
                BindingSource bindingSourceCOLOR = new BindingSource();
                bindingSourceCOLOR.DataSource = dataTableCOLOR;
                //end line
                //binding Category
                string selectQueryStringCATEGORY = "SELECT * FROM category";

                MySqlDataAdapter sqlDataAdapterCATEGORY = new MySqlDataAdapter(selectQueryStringCATEGORY, connection);
                MySqlCommandBuilder sqlCommandBuilderCATEGORY = new MySqlCommandBuilder(sqlDataAdapterCATEGORY);

                DataTable dataTableCATEGORY = new DataTable();
                sqlDataAdapterCATEGORY.Fill(dataTableCATEGORY);
                BindingSource bindingSourceCATEGORY = new BindingSource();
                bindingSourceCATEGORY.DataSource = dataTableCATEGORY;
                //end line

                masterDataGridView.Columns.Clear();

                //DataGridViewComboBoxColumn ColumnStyle = new DataGridViewComboBoxColumn();
                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "STYLEID";
                ColumnStyle.Name = "STYLEID";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                //binding

                //  ColumnStyle.DataSource = bindingSourceLW;
                //  ColumnStyle.ValueMember = "STYLEID";
                //  ColumnStyle.DisplayMember = "STYLEID";

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


                DataGridViewComboBoxColumn ColumnColor = new DataGridViewComboBoxColumn();
                ColumnColor.HeaderText = "COLOR";
                ColumnColor.Width = 100;
                ColumnColor.DataPropertyName = "COLORID";
                ColumnColor.Name = "COLORID";
                ColumnColor.ReadOnly = false;
                //binding
                ColumnColor.DataSource = bindingSourceCOLOR;
                ColumnColor.ValueMember = "COLORID";
                ColumnColor.DisplayMember = "COLORNAME";

                masterDataGridView.Columns.Add(ColumnColor);
                
                DataGridViewTextBoxColumn ColumnDate = new DataGridViewTextBoxColumn();
                ColumnDate.HeaderText = "DATE";
                ColumnDate.Width = 100;
                ColumnDate.DataPropertyName = "DATE";
                ColumnDate.Name = "DATE";
                ColumnDate.Visible = true;
                masterDataGridView.Columns.Add(ColumnDate);

                DataGridViewComboBoxColumn ColumnCATEGORYID = new DataGridViewComboBoxColumn();
                ColumnCATEGORYID.HeaderText = "CATEGORY";
                ColumnCATEGORYID.Width = 70;
                ColumnCATEGORYID.DataPropertyName = "categoryid";
                ColumnCATEGORYID.Name = "categoryname";
                //binding

                ColumnCATEGORYID.DataSource = bindingSourceCATEGORY;
                ColumnCATEGORYID.ValueMember = "categoryid";
                ColumnCATEGORYID.DisplayMember = "categoryname";
                masterDataGridView.Columns.Add(ColumnCATEGORYID);

                DataGridViewTextBoxColumn ColumnQtyCheck = new DataGridViewTextBoxColumn();
                ColumnQtyCheck.HeaderText = "INSPECTOR";
                ColumnQtyCheck.Width = 80;
                ColumnQtyCheck.DataPropertyName = "INSPECTOR";
                ColumnQtyCheck.Name = "INSPECTOR";
                masterDataGridView.Columns.Add(ColumnQtyCheck);

    

                DataGridViewComboBoxColumn ColumnQtyStatus = new DataGridViewComboBoxColumn();
                ColumnQtyStatus.HeaderText = "STATUS";
                ColumnQtyStatus.Width = 80;
                ColumnQtyStatus.DataPropertyName = "RESULT";
                ColumnQtyStatus.Name = "RESULT";
               
                // binding

                ComboBox CB = new ComboBox();
                CB.Items.Add("FAIL");
                CB.Items.Add("PASS");

                ColumnQtyStatus.DataSource = CB.Items;

                masterDataGridView.Columns.Add(ColumnQtyStatus);

                DataGridViewTextBoxColumn ColumnQTY = new DataGridViewTextBoxColumn();
                ColumnQTY.HeaderText = "QTY INSP";
                ColumnQTY.Width = 50;
                ColumnQTY.DataPropertyName = "QTY";
                ColumnQTY.Name = "QTY";
                masterDataGridView.Columns.Add(ColumnQTY);


                DataGridViewTextBoxColumn ColumnREMARKS = new DataGridViewTextBoxColumn();
                ColumnREMARKS.HeaderText = "REMARKS";
                ColumnREMARKS.Width = 160;
                ColumnREMARKS.DataPropertyName = "REMARKS";
                ColumnREMARKS.Name = "REMARKS";
                masterDataGridView.Columns.Add(ColumnREMARKS);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void getData(DateTime date1,DateTime date2)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM qcinspection WHERE DATE(DATE) BETWEEN DATE(@date1) AND DATE(@date2)";

                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));
                masterDataAdapter.Fill(data, "qcinspection");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "qcinspection";
                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;
                //detailsDataGridView.DataSource = detailsBindingSource;
                //list direct
                string selectQueryStringLW = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;
                //binding COLOR
                string selectQueryStringCOLOR = "SELECT * FROM color";

                MySqlDataAdapter sqlDataAdapterCOLOR = new MySqlDataAdapter(selectQueryStringCOLOR, connection);
                MySqlCommandBuilder sqlCommandBuilderCOLOR = new MySqlCommandBuilder(sqlDataAdapterCOLOR);

                DataTable dataTableCOLOR = new DataTable();
                sqlDataAdapterCOLOR.Fill(dataTableCOLOR);
                BindingSource bindingSourceCOLOR = new BindingSource();
                bindingSourceCOLOR.DataSource = dataTableCOLOR;
                //end line
                //binding Category
                string selectQueryStringCATEGORY = "SELECT * FROM category";

                MySqlDataAdapter sqlDataAdapterCATEGORY = new MySqlDataAdapter(selectQueryStringCATEGORY, connection);
                MySqlCommandBuilder sqlCommandBuilderCATEGORY = new MySqlCommandBuilder(sqlDataAdapterCATEGORY);

                DataTable dataTableCATEGORY = new DataTable();
                sqlDataAdapterCATEGORY.Fill(dataTableCATEGORY);
                BindingSource bindingSourceCATEGORY = new BindingSource();
                bindingSourceCATEGORY.DataSource = dataTableCATEGORY;
                //end line

                masterDataGridView.Columns.Clear();

                //DataGridViewComboBoxColumn ColumnStyle = new DataGridViewComboBoxColumn();
                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "STYLEID";
                ColumnStyle.Name = "STYLEID";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                //binding

                //  ColumnStyle.DataSource = bindingSourceLW;
                //  ColumnStyle.ValueMember = "STYLEID";
                //  ColumnStyle.DisplayMember = "STYLEID";

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


                DataGridViewComboBoxColumn ColumnColor = new DataGridViewComboBoxColumn();
                ColumnColor.HeaderText = "COLOR";
                ColumnColor.Width = 100;
                ColumnColor.DataPropertyName = "COLORID";
                ColumnColor.Name = "COLORID";
                ColumnColor.ReadOnly = false;
                //binding
                ColumnColor.DataSource = bindingSourceCOLOR;
                ColumnColor.ValueMember = "COLORID";
                ColumnColor.DisplayMember = "COLORNAME";

                masterDataGridView.Columns.Add(ColumnColor);

                DataGridViewTextBoxColumn ColumnDate = new DataGridViewTextBoxColumn();
                ColumnDate.HeaderText = "DATE";
                ColumnDate.Width = 100;
                ColumnDate.DataPropertyName = "DATE";
                ColumnDate.Name = "DATE";
                ColumnDate.Visible = true;
                masterDataGridView.Columns.Add(ColumnDate);

                DataGridViewComboBoxColumn ColumnCATEGORYID = new DataGridViewComboBoxColumn();
                ColumnCATEGORYID.HeaderText = "CATEGORY";
                ColumnCATEGORYID.Width = 70;
                ColumnCATEGORYID.DataPropertyName = "categoryid";
                ColumnCATEGORYID.Name = "categoryname";
                //binding

                ColumnCATEGORYID.DataSource = bindingSourceCATEGORY;
                ColumnCATEGORYID.ValueMember = "categoryid";
                ColumnCATEGORYID.DisplayMember = "categoryname";
                masterDataGridView.Columns.Add(ColumnCATEGORYID);

                DataGridViewTextBoxColumn ColumnQtyCheck = new DataGridViewTextBoxColumn();
                ColumnQtyCheck.HeaderText = "INSPECTOR";
                ColumnQtyCheck.Width = 80;
                ColumnQtyCheck.DataPropertyName = "INSPECTOR";
                ColumnQtyCheck.Name = "INSPECTOR";
                masterDataGridView.Columns.Add(ColumnQtyCheck);



                DataGridViewComboBoxColumn ColumnQtyStatus = new DataGridViewComboBoxColumn();
                ColumnQtyStatus.HeaderText = "STATUS";
                ColumnQtyStatus.Width = 80;
                ColumnQtyStatus.DataPropertyName = "RESULT";
                ColumnQtyStatus.Name = "RESULT";

                // binding

                ComboBox CB = new ComboBox();
                CB.Items.Add("FAIL");
                CB.Items.Add("PASS");

                ColumnQtyStatus.DataSource = CB.Items;

                masterDataGridView.Columns.Add(ColumnQtyStatus);

                DataGridViewTextBoxColumn ColumnQTY = new DataGridViewTextBoxColumn();
                ColumnQTY.HeaderText = "QTY INSP";
                ColumnQTY.Width = 50;
                ColumnQTY.DataPropertyName = "QTY";
                ColumnQTY.Name = "QTY";
                masterDataGridView.Columns.Add(ColumnQTY);


                DataGridViewTextBoxColumn ColumnREMARKS = new DataGridViewTextBoxColumn();
                ColumnREMARKS.HeaderText = "REMARKS";
                ColumnREMARKS.Width = 160;
                ColumnREMARKS.DataPropertyName = "REMARKS";
                ColumnREMARKS.Name = "REMARKS";
                masterDataGridView.Columns.Add(ColumnREMARKS);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void getData(string styleid)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM qcinspection WHERE STYLEID LIKE @STYLEID";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@STYLEID", "%"+styleid+"%");
                masterDataAdapter.Fill(data, "qcinspection");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "qcinspection";
                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;
                //detailsDataGridView.DataSource = detailsBindingSource;
                //list direct
                string selectQueryStringLW = "SELECT * FROM buyer";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;
                //binding COLOR
                string selectQueryStringCOLOR = "SELECT * FROM color";

                MySqlDataAdapter sqlDataAdapterCOLOR = new MySqlDataAdapter(selectQueryStringCOLOR, connection);
                MySqlCommandBuilder sqlCommandBuilderCOLOR = new MySqlCommandBuilder(sqlDataAdapterCOLOR);

                DataTable dataTableCOLOR = new DataTable();
                sqlDataAdapterCOLOR.Fill(dataTableCOLOR);
                BindingSource bindingSourceCOLOR = new BindingSource();
                bindingSourceCOLOR.DataSource = dataTableCOLOR;
                //end line
                //binding Category
                string selectQueryStringCATEGORY = "SELECT * FROM category";

                MySqlDataAdapter sqlDataAdapterCATEGORY = new MySqlDataAdapter(selectQueryStringCATEGORY, connection);
                MySqlCommandBuilder sqlCommandBuilderCATEGORY = new MySqlCommandBuilder(sqlDataAdapterCATEGORY);

                DataTable dataTableCATEGORY = new DataTable();
                sqlDataAdapterCATEGORY.Fill(dataTableCATEGORY);
                BindingSource bindingSourceCATEGORY = new BindingSource();
                bindingSourceCATEGORY.DataSource = dataTableCATEGORY;
                //end line

                masterDataGridView.Columns.Clear();

                //DataGridViewComboBoxColumn ColumnStyle = new DataGridViewComboBoxColumn();
                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "STYLEID";
                ColumnStyle.Name = "STYLEID";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                //binding

                //  ColumnStyle.DataSource = bindingSourceLW;
                //  ColumnStyle.ValueMember = "STYLEID";
                //  ColumnStyle.DisplayMember = "STYLEID";

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


                DataGridViewComboBoxColumn ColumnColor = new DataGridViewComboBoxColumn();
                ColumnColor.HeaderText = "COLOR";
                ColumnColor.Width = 100;
                ColumnColor.DataPropertyName = "COLORID";
                ColumnColor.Name = "COLORID";
                ColumnColor.ReadOnly = false;
                //binding
                ColumnColor.DataSource = bindingSourceCOLOR;
                ColumnColor.ValueMember = "COLORID";
                ColumnColor.DisplayMember = "COLORNAME";

                masterDataGridView.Columns.Add(ColumnColor);

                DataGridViewTextBoxColumn ColumnDate = new DataGridViewTextBoxColumn();
                ColumnDate.HeaderText = "DATE";
                ColumnDate.Width = 100;
                ColumnDate.DataPropertyName = "DATE";
                ColumnDate.Name = "DATE";
                ColumnDate.Visible = true;
                masterDataGridView.Columns.Add(ColumnDate);

                DataGridViewComboBoxColumn ColumnCATEGORYID = new DataGridViewComboBoxColumn();
                ColumnCATEGORYID.HeaderText = "CATEGORY";
                ColumnCATEGORYID.Width = 70;
                ColumnCATEGORYID.DataPropertyName = "categoryid";
                ColumnCATEGORYID.Name = "categoryname";
                //binding

                ColumnCATEGORYID.DataSource = bindingSourceCATEGORY;
                ColumnCATEGORYID.ValueMember = "categoryid";
                ColumnCATEGORYID.DisplayMember = "categoryname";
                masterDataGridView.Columns.Add(ColumnCATEGORYID);

                DataGridViewTextBoxColumn ColumnQtyCheck = new DataGridViewTextBoxColumn();
                ColumnQtyCheck.HeaderText = "INSPECTOR";
                ColumnQtyCheck.Width = 80;
                ColumnQtyCheck.DataPropertyName = "INSPECTOR";
                ColumnQtyCheck.Name = "INSPECTOR";
                masterDataGridView.Columns.Add(ColumnQtyCheck);



                DataGridViewComboBoxColumn ColumnQtyStatus = new DataGridViewComboBoxColumn();
                ColumnQtyStatus.HeaderText = "STATUS";
                ColumnQtyStatus.Width = 80;
                ColumnQtyStatus.DataPropertyName = "RESULT";
                ColumnQtyStatus.Name = "RESULT";

                // binding

                ComboBox CB = new ComboBox();
                CB.Items.Add("FAIL");
                CB.Items.Add("PASS");

                ColumnQtyStatus.DataSource = CB.Items;

                masterDataGridView.Columns.Add(ColumnQtyStatus);

                DataGridViewTextBoxColumn ColumnQTY = new DataGridViewTextBoxColumn();
                ColumnQTY.HeaderText = "QTY INSP";
                ColumnQTY.Width = 50;
                ColumnQTY.DataPropertyName = "QTY";
                ColumnQTY.Name = "QTY";
                masterDataGridView.Columns.Add(ColumnQTY);


                DataGridViewTextBoxColumn ColumnREMARKS = new DataGridViewTextBoxColumn();
                ColumnREMARKS.HeaderText = "REMARKS";
                ColumnREMARKS.Width = 160;
                ColumnREMARKS.DataPropertyName = "REMARKS";
                ColumnREMARKS.Name = "REMARKS";
                masterDataGridView.Columns.Add(ColumnREMARKS);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void frmInspection_Load(object sender, EventArgs e)
        {
            getData(dateQC.Value.Date);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "qcinspection");
                saveItem();
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
                if (this.masterDataGridView.SelectedRows.Count > 0)
                {

                    foreach (DataGridViewRow item in this.masterDataGridView.SelectedRows)
                    {
                        masterBindingSource.RemoveAt(item.Index);
                    }

                    masterBindingSource.EndEdit();
                    masterDataAdapter.Update(data, "qcinspection");
                    MessageBox.Show("the data has been deleted");
                }
                else
                {
                    MessageBox.Show("Not rows selected");
                }
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
            getData(dateQC.Value.Date,dateQC2.Value.Date);
        }
        private void SetItemsCallBack(string ItemsID, string ItemsDesc, string ItemBuyer)
        {
            GStrCode = ItemsID;
            GitemsDesc = ItemsDesc;
            GBuyerID = ItemBuyer;
        }
        private void masterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            GStrCode = "";
            GitemsDesc = "";
            GBuyerID = "";
            //untuk costing
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] == masterDataGridView.Columns["STYLEID"])
            {
                GStrCode = "";
                findStyleSetting f = new findStyleSetting();
                f.AddItemCallback = new findStyleSetting.AddCategoryDelegate(this.SetItemsCallBack);
                f.ShowDialog();
                if (GStrCode != "")
                {

                    masterDataGridView.Rows[e.RowIndex].Cells["STYLEID"].Value = GStrCode;
                    masterDataGridView.Rows[e.RowIndex].Cells["COLORID"].Value = GitemsDesc;
                    masterDataGridView.Rows[e.RowIndex].Cells["BUYERID"].Value = GBuyerID;
                }

            }
        }

        private void masterDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //masterDataGridView.Rows[e.RowIndex].Cells["DATE"].Value = dateQC.Value;
        }

        private void masterDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
    
                style = masterDataGridView.Rows[e.RowIndex].Cells["STYLEID"].Value.ToString();
                color = masterDataGridView.Rows[e.RowIndex].Cells["COLORID"].Value.ToString();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                DataSet dsDetail = new DataSet();
                string strQuery = "SELECT * FROM qcinspectiondetail WHERE STYLEID=@STYLEID AND COLORID=@COLORID";
                MySqlDataAdapter DetailsAdapter = new MySqlDataAdapter(strQuery, connection);
                DetailsAdapter.SelectCommand.Parameters.AddWithValue("@STYLEID", style);
                DetailsAdapter.SelectCommand.Parameters.AddWithValue("@COLORID", color);
                DetailsAdapter.Fill(dsDetail, "inspectiondetail");

                detailsDataGridView.Rows.Clear();
                for (int i = 0; i < dsDetail.Tables[0].Rows.Count; i++)
                {
                    detailsDataGridView.Rows.Add();
                    detailsDataGridView.Rows[i].Cells["hSTYLEID"].Value = dsDetail.Tables[0].Rows[i]["STYLEID"];
                    detailsDataGridView.Rows[i].Cells["hCOLORID"].Value = dsDetail.Tables[0].Rows[i]["COLORID"];
                    detailsDataGridView.Rows[i].Cells["hID"].Value = dsDetail.Tables[0].Rows[i]["ID"];
                    detailsDataGridView.Rows[i].Cells["hID1"].Value = dsDetail.Tables[0].Rows[i]["ID"];
                    detailsDataGridView.Rows[i].Cells["hMAJOR"].Value = dsDetail.Tables[0].Rows[i]["MAJOR"];
                    detailsDataGridView.Rows[i].Cells["hMINOR"].Value = dsDetail.Tables[0].Rows[i]["MINOR"];
                    detailsDataGridView.Rows[i].Cells["hNAME"].Value = dsDetail.Tables[0].Rows[i]["NAME"];

                }
            }
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtStyle.Text);
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            qcreportinspection f = new qcreportinspection();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(dateQC.Value.ToString("yyyy-MM-dd"), dateQC2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void cmdPrintDetail_Click(object sender, EventArgs e)
        {
            InspectionRpt f = new InspectionRpt();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(dateQC.Value.ToString("yyyy-MM-dd"), dateQC2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }
    }
}
