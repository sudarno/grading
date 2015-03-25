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
    public partial class frmMeasurementStyle : Form
    {
        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        private bool insertMeStyle(string STYLEID,string BUYERID, string MEID,int? CEK)
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
                Command.CommandText = "INSERT INTO measurementstyle(STYLEID,BUYERID,MEID,CEK) VALUES(@STYLEID,@BUYERID,@MEID,@CEK)";
                //item insert
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                Command.Parameters.AddWithValue("@MEID", MEID);
                Command.Parameters.AddWithValue("@BUYERID", BUYERID);
                Command.Parameters.AddWithValue("@CEK", CEK);
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

        private bool deleteStyle(string STYLEID, string BUYERID)
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
                Command.CommandText = "DELETE FROM measurementstyle WHERE STYLEID=@STYLEID AND BUYERID=@BUYERID";
                //item update
                Command.Parameters.AddWithValue("@STYLEID", STYLEID);
                //Command.Parameters.AddWithValue("@MEID", MEID);
                Command.Parameters.AddWithValue("@BUYERID", BUYERID);
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

        public frmMeasurementStyle()
        {
            InitializeComponent();
        }
        private void SetStyleCallBack(string Style, string Desc)
        {
            txtStyleID.Text = Style;
            txtStyleName.Text = Desc;
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

                //dataTableBuyer.Rows.Add(new object() {"0", ""});

                DataRow newCustomersRow = dataTableBuyer.NewRow();

                newCustomersRow["BUYERID"] = "";
                newCustomersRow["BUYERNAME"] = "";

                dataTableBuyer.Rows.Add(newCustomersRow);

                //combo binding

                cbBuyer.DataSource = bindingSourceBuyer;
                cbBuyer.ValueMember = "BUYERID";
                cbBuyer.DisplayMember = "BUYERNAME";
                cbBuyer.Text = "";
               // cbBuyer.SelectedIndex=-1;
                //masterDataGridView.Rows.Clear();
                //cbBuyer.Items.Insert(0, new ListItem("Select", string.Empty));
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void cmdStyleID_Click(object sender, EventArgs e)
        {
            //txtStyleID.Text = "";
            findStyle f = new findStyle();
            f.AddItemCallback = new findStyle.AddCategoryDelegate(this.SetStyleCallBack);
            f.ShowDialog();

            if (txtStyleID.Text != "")
            {
                // detailsDataGridView.DataSource = masterBindingSource;
                // detailsDataGridView.DataSource = detailsBindingSource;
               // getData(txtStyleID.Text);

                getBuyer();

            }
        }

        private void getMeasurementBuyer(string buyer,string style)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                //list combo
                string selectQueryStringBuyer = "SELECT * FROM "+
                    "(SELECT * FROM measurementstyle WHERE styleid='" + style + "' ORDER BY CEK)DATA " +
                    " RIGHT JOIN measurement on measurement.MEID = DATA.MEID AND measurement.BUYERID=DATA.buyerid " +
                    " WHERE measurement.BUYERID='"+buyer+"'";

                MySqlDataAdapter sqlDataAdapterBuyer = new MySqlDataAdapter(selectQueryStringBuyer, connection);
                MySqlCommandBuilder sqlCommandBuilderBuyer = new MySqlCommandBuilder(sqlDataAdapterBuyer);

                DataTable dataTableBuyer = new DataTable();
                sqlDataAdapterBuyer.Fill(dataTableBuyer);
                BindingSource bindingSourceBuyer = new BindingSource();
                bindingSourceBuyer.DataSource = dataTableBuyer;

                masterDataGridView.DataSource = bindingSourceBuyer;
                //isi grid

                masterDataGridView.Columns.Clear();

                //DataGridViewCheckBoxColumn ColumnmCEK = new DataGridViewCheckBoxColumn();
                DataGridViewTextBoxColumn ColumnmCEK = new DataGridViewTextBoxColumn();
                ColumnmCEK.HeaderText = "NO";
                ColumnmCEK.Width = 80;
                ColumnmCEK.DataPropertyName = "CEK";
                ColumnmCEK.Name = "CEK";
                ColumnmCEK.Visible = true;
                masterDataGridView.Columns.Add(ColumnmCEK);
                masterDataGridView.Columns["CEK"].Visible = true;


                DataGridViewTextBoxColumn ColumnmSTYLE = new DataGridViewTextBoxColumn();
                ColumnmSTYLE.HeaderText = "STYLEID";
                ColumnmSTYLE.Width = 80;
                ColumnmSTYLE.DataPropertyName = "STYLEID";
                ColumnmSTYLE.Name = "STYLEID";
                ColumnmSTYLE.Visible = true;
                masterDataGridView.Columns.Add(ColumnmSTYLE);
                masterDataGridView.Columns["STYLEID"].Visible = false;

                DataGridViewTextBoxColumn ColumnmBUYERID = new DataGridViewTextBoxColumn();
                ColumnmBUYERID.HeaderText = "BUYERID";
                ColumnmBUYERID.Width = 80;
                ColumnmBUYERID.DataPropertyName = "BUYERID";
                ColumnmBUYERID.Name = "BUYERID";
                masterDataGridView.Columns.Add(ColumnmBUYERID);
                masterDataGridView.Columns["BUYERID"].Visible = false;
                


                DataGridViewTextBoxColumn ColumnmMEID = new DataGridViewTextBoxColumn();
                ColumnmMEID.HeaderText = "CODE";
                ColumnmMEID.Width = 80;
                ColumnmMEID.DataPropertyName = "MEID";
                ColumnmMEID.Name = "MEID";
                ColumnmMEID.Visible = true;
                masterDataGridView.Columns.Add(ColumnmMEID);
               
                masterDataGridView.Columns["MEID"].Visible = false;

                DataGridViewTextBoxColumn ColumnmBUYERID1 = new DataGridViewTextBoxColumn();
                ColumnmBUYERID1.HeaderText = "BUYERID1";
                ColumnmBUYERID1.Width = 80;
                ColumnmBUYERID1.DataPropertyName = "BUYERID1";
                ColumnmBUYERID1.Name = "BUYERID1";
                masterDataGridView.Columns.Add(ColumnmBUYERID1);
                masterDataGridView.Columns["BUYERID1"].Visible = false;
                

                DataGridViewTextBoxColumn ColumnmMEID1 = new DataGridViewTextBoxColumn();
                ColumnmMEID1.HeaderText = "MEID1";
                ColumnmMEID1.Width = 80;
                ColumnmMEID1.DataPropertyName = "MEID1";
                ColumnmMEID1.Name = "MEID1";
                ColumnmMEID1.Visible = true;
                masterDataGridView.Columns.Add(ColumnmMEID1);

                DataGridViewTextBoxColumn ColumnmMEASUREMENT = new DataGridViewTextBoxColumn();
                ColumnmMEASUREMENT.HeaderText = "MEASUREMENT";
                ColumnmMEASUREMENT.Width = 350;
                ColumnmMEASUREMENT.DataPropertyName = "MEASUREMENT";
                ColumnmMEASUREMENT.Name = "MEASUREMENT";
                ColumnmMEASUREMENT.Visible = false;
                masterDataGridView.Columns.Add(ColumnmMEASUREMENT);
                masterDataGridView.Columns["MEASUREMENT"].Visible = true;




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
                masterDataAdapter = new MySqlDataAdapter("select * from measurement Where BUYERID='" + cbBuyer.SelectedValue.ToString() + "'", connection);
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
        private void cbBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string buyer = cbBuyer.SelectedValue.ToString();
            getMeasurementBuyer(buyer, txtStyleID.Text);

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string STYLEID;
            string MEID;
            string BUYERID;
            int? CEK;

            //delet dulu semua by style
            BUYERID = cbBuyer.SelectedValue.ToString();
            STYLEID = txtStyleID.Text;
            deleteStyle(STYLEID, BUYERID);

            foreach (DataGridViewRow row in masterDataGridView.Rows)
            {
            

                //if (row.Cells["CEK"].Value != DBNull.Value )
                if (row.Cells["CEK"].Value != null)
                {
                    //if (Convert.ToBoolean(row.Cells["CEK"].Value) == true)
                    //if (Convert.ToBoolean(row.Cells["CEK"].Value) == true)
                    //{
                    try
                    {
                        CEK = Convert.ToInt16(row.Cells["CEK"].Value);
                        STYLEID = txtStyleID.Text;
                        BUYERID = Convert.ToString(masterDataGridView.Rows[row.Index].Cells["BUYERID1"].Value);
                        MEID = Convert.ToString(masterDataGridView.Rows[row.Index].Cells["MEID1"].Value);
                        //delete
                        //MessageBox.Show("insert");
                        insertMeStyle(STYLEID, BUYERID, MEID, CEK);
                    }
                    catch
                    {
                    }
                    //}
               }
            }
            MessageBox.Show("the data has been saved");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMeasurementStyle_Load(object sender, EventArgs e)
        {

        }
    }
}
