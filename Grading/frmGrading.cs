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
    public partial class frmGrading : Form
    {
        private DataSet data = null;
        BindingSource masterBindingSource = new BindingSource();
        BindingSource detailsBindingSource = new BindingSource();


        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlDataAdapter detailsDataAdapter = null;


        private MySqlCommandBuilder sqlCommandBuilder = null;
        public frmGrading()
        {
            InitializeComponent();
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

                detailsDataAdapter = new MySqlDataAdapter("select * from gradingdetail where STYLEID='" + Style + "'", connection);
                detailsDataAdapter.Fill(data, "gradingdetail");
                sqlCommandBuilder = new MySqlCommandBuilder(detailsDataAdapter);

                //combo buyer
                
                /*
                string selectQueryStringMonth = "SELECT * FROM buyer";

                MySqlDataAdapter buyerDataAdapter = new MySqlDataAdapter(selectQueryStringMonth, connection);
                MySqlCommandBuilder buyerCommandBuilder = new MySqlCommandBuilder(buyerDataAdapter);

                DataTable dataTableBuyer = new DataTable();
                buyerDataAdapter.Fill(dataTableBuyer);
                BindingSource bindingSourceBuyer = new BindingSource();
                bindingSourceBuyer.DataSource = dataTableBuyer;
                cbBuyer.DataSource = bindingSourceBuyer;
                cbBuyer.ValueMember = "BUYERID";
                cbBuyer.DisplayMember = "BUYERID";
                */
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
                //end combo buyer

                DataRelation Relation = new DataRelation("rGrading", data.Tables["grading"].Columns["STYLEID"], data.Tables["gradingdetail"].Columns["STYLEID"]);
                data.Relations.Add(Relation);

             

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "grading";

                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "rGrading";

           

                 //grading header 
                 txtStyleID.DataBindings.Clear();
                 cbBuyer.DataBindings.Clear();
                 txtColorID.DataBindings.Clear();
                 dateGrading.DataBindings.Clear();

                 txtStyleID.Text = Style;

                 // txtOrderID.DataBindings.Add(new Binding("Text", data, "Orders.OrderID", true));
                 //txtRemarks.DataBindings.Add(new Binding("Text", data, "Orders.Remarks", true));

                 txtStyleID.DataBindings.Add(new Binding("Text", masterBindingSource, "STYLEID", true, DataSourceUpdateMode.OnPropertyChanged));
                 cbBuyer.DataBindings.Add(new Binding("Text", masterBindingSource, "BUYERID", true, DataSourceUpdateMode.OnPropertyChanged));
                

                 txtColorID.DataBindings.Add(new Binding("Text", masterBindingSource, "COLOR", true, DataSourceUpdateMode.OnPropertyChanged));
                 dateGrading.DataBindings.Add(new Binding("Text", masterBindingSource, "DATE", true, DataSourceUpdateMode.OnPropertyChanged));

                    //
                    // cbBuyer.SelectedValue = data.Tables["grading"].Rows[0]["BUYERID"].ToString();
                    //buyer

                

                //grid detail

                detailsDataGridView.DataSource = detailsBindingSource;

                if (data.Tables["grading"].Rows.Count < 1)
                {
                    masterBindingSource.AddNew(); //inisial untuk insert new
                    txtStyleID.Text = Style;
                    detailsDataGridView.Enabled = false;
                }
                else { detailsDataGridView.Enabled = true; }

                //list size 

                string selectQueryStringSIZEID = "SELECT SIZEID FROM sizeorder where STYLEID='" + Style + "'";

                MySqlDataAdapter sqlDataAdapterSIZEID = new MySqlDataAdapter(selectQueryStringSIZEID, connection);
                MySqlCommandBuilder sqlCommandBuilderSIZEID = new MySqlCommandBuilder(sqlDataAdapterSIZEID);

                DataTable dataTableSIZEID = new DataTable();
                sqlDataAdapterSIZEID.Fill(dataTableSIZEID);
                BindingSource bindingSourceSIZEID = new BindingSource();
                bindingSourceSIZEID.DataSource = dataTableSIZEID;

                //list MEID
                string selectQueryStringMEID = "SELECT * FROM measurement";

                MySqlDataAdapter sqlDataAdapterMEID = new MySqlDataAdapter(selectQueryStringMEID, connection);
                MySqlCommandBuilder sqlCommandBuilderMEID = new MySqlCommandBuilder(sqlDataAdapterMEID);

                DataTable dataTableMEID = new DataTable();
                sqlDataAdapterMEID.Fill(dataTableMEID);
                BindingSource bindingSourceMEID = new BindingSource();
                bindingSourceMEID.DataSource = dataTableMEID;

                //list direct
                string selectQueryStringLW= "SELECT * FROM direction WHERE STYLEID='"+Style+"'";

                MySqlDataAdapter sqlDataAdapterLW = new MySqlDataAdapter(selectQueryStringLW, connection);
                MySqlCommandBuilder sqlCommandBuilderLW = new MySqlCommandBuilder(sqlDataAdapterLW);

                DataTable dataTableLW = new DataTable();
                sqlDataAdapterLW.Fill(dataTableLW);
                BindingSource bindingSourceLW = new BindingSource();
                bindingSourceLW.DataSource = dataTableLW;

                //end list

                //isi colum grid
                detailsDataGridView.Columns.Clear();
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

                //DataGridViewTextBoxColumn MEIDColumn = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn MEIDColumn = new DataGridViewComboBoxColumn();
                MEIDColumn.HeaderText = "MEASUREMENT";
                MEIDColumn.Width = 300;
                MEIDColumn.DataPropertyName = "MEID";
                MEIDColumn.Name = "MEID";

                //binding
                MEIDColumn.DataSource = bindingSourceMEID;
                MEIDColumn.ValueMember = "MEID";
                MEIDColumn.DisplayMember = "MEASUREMENT";

                detailsDataGridView.Columns.Add(MEIDColumn);




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

                //DataGridViewTextBoxColumn SizeColumn = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn SizeColumn = new DataGridViewComboBoxColumn();
                SizeColumn.HeaderText = "SIZEID";
                SizeColumn.Width = 80;
                SizeColumn.DataPropertyName = "SIZEID";
                SizeColumn.Name = "SIZEID";

                SizeColumn.DataSource = bindingSourceSIZEID;
                SizeColumn.ValueMember = "SIZEID";
                SizeColumn.DisplayMember = "SIZEID";


                detailsDataGridView.Columns.Add(SizeColumn);

                DataGridViewTextBoxColumn BasicColumn = new DataGridViewTextBoxColumn();
                BasicColumn.HeaderText = "BASIC";
                BasicColumn.Width = 80;
                BasicColumn.DataPropertyName = "BASIC";
                BasicColumn.Name = "BASIC";
                detailsDataGridView.Columns.Add(BasicColumn);


                //close koneksi
                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void SetStyleCallBack(string Style, string Desc)
        {
            txtStyleID.Text = Style;
            txtStyleName.Text = Desc;
        }

        private void cmdCustomer_Click(object sender, EventArgs e)
        {
            //txtStyleID.Text = "";
            findStyle f = new findStyle();
            f.AddItemCallback = new findStyle.AddCategoryDelegate(this.SetStyleCallBack);
            f.ShowDialog();
            
            if (txtStyleID.Text != "")
            {
                // detailsDataGridView.DataSource = masterBindingSource;
                // detailsDataGridView.DataSource = detailsBindingSource;
                getData(txtStyleID.Text);

            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "grading");
                detailsBindingSource.EndEdit();
                detailsDataAdapter.Update(data, "gradingdetail");
                detailsDataGridView.Enabled = true;
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
                    detailsBindingSource.RemoveAt(item.Index);
                }
                detailsBindingSource.EndEdit();
                detailsDataAdapter.Update(data, "gradingdetail");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
                getData(txtStyleID.Text);
            }
        }

        private void cmdPrintSpec_Click(object sender, EventArgs e)
        {
            DataSet dataPrint= new DataSet();
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

            string strQuery = "select buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE "+
                   " ,direction.LW,measurement.MEID,measurement.MEASUREMENT"+
                   " ,MAX(case when sizeorder.SIZEBASIC=1 then sizeorder.SIZEID end ) SIZEBASIC" +
                   ",MAX(case when sizeorder.SIZEBASIC=1 then sizeorder.ORDERNO end ) ORDERNOBASIC"+
                   ",MAX(case when sizeorder.ORDERNO=1 then sizeorder.ORDERNO end ) ORDERNO1"+
                   ",MAX(case when sizeorder.ORDERNO=2 then sizeorder.ORDERNO end ) ORDERNO2"+
                   ",MAX(case when sizeorder.ORDERNO=3 then sizeorder.ORDERNO end ) ORDERNO3"+
                   ",MAX(case when sizeorder.ORDERNO=4 then sizeorder.ORDERNO end ) ORDERNO4"+
                   ",MAX(case when sizeorder.ORDERNO=5 then sizeorder.ORDERNO end ) ORDERNO5"+
                   ",MAX(case when sizeorder.ORDERNO=6 then sizeorder.ORDERNO end ) ORDERNO6"+
                   ",MAX(case when sizeorder.ORDERNO=7 then sizeorder.ORDERNO end ) ORDERNO7"+
                   ",MAX(case when sizeorder.ORDERNO=8 then sizeorder.ORDERNO end ) ORDERNO8"+
                   ",MAX(case when sizeorder.ORDERNO=9 then sizeorder.ORDERNO end ) ORDERNO9"+
                   ",MAX(case when sizeorder.ORDERNO=10 then sizeorder.ORDERNO end ) ORDERNO10"+
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
                    " from grading "+
                    " inner join gradingdetail on grading.STYLEID=gradingdetail.STYLEID"+
                    " inner join measurement on measurement.MEID=gradingdetail.MEID"+
                    " inner join size on size.SIZEID=gradingdetail.SIZEID"+
                    " inner join style on style.STYLEID=grading.STYLEID"+
                    " inner join buyer on buyer.BUYERID =grading.BUYERID"+
                    " inner join direction on direction.STYLEID=gradingdetail.STYLEID AND direction.LW=gradingdetail.DIRECTION"+
                    " inner join sizeorder on sizeorder.SIZEID=gradingdetail.SIZEID AND sizeorder.STYLEID=gradingdetail.STYLEID"+
                    " where grading.STYLEID='" + txtStyleID.Text + "'" +
                    " GROUP BY buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE,direction.LW,measurement.MEID,measurement.MEASUREMENT "+
                    " ORDER BY sizeorder.ORDERNO,measurement.MEID";
            masterDataAdapter = new MySqlDataAdapter(strQuery,connection);
            masterDataAdapter.Fill(dataPrint, "gradingPrint");


            //DataSet data = new joborderCRUD().prJobOrder(txtCostingNo.Text);


            Application.DoEvents();
            dataPrint.WriteXml("C:\\MyGarmentReport\\qcspec.xml", XmlWriteMode.WriteSchema);
            Form f = new printSpec();
            f.Show();
        
        }

        private void cmdPrintGrading_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);

            string strQuery = "select buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE " +
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
                  " from grading " +
                  " inner join gradingdetail on grading.STYLEID=gradingdetail.STYLEID" +
                  " inner join measurement on measurement.MEID=gradingdetail.MEID" +
                  " inner join size on size.SIZEID=gradingdetail.SIZEID" +
                  " inner join style on style.STYLEID=grading.STYLEID" +
                  " inner join buyer on buyer.BUYERID =grading.BUYERID" +
                  " inner join direction on direction.STYLEID=gradingdetail.STYLEID AND direction.LW=gradingdetail.DIRECTION" +
                  " inner join sizeorder on sizeorder.SIZEID=gradingdetail.SIZEID AND sizeorder.STYLEID=gradingdetail.STYLEID" +
                  " where grading.STYLEID='" + txtStyleID.Text + "'" +
                  " GROUP BY buyer.BUYERNAME,style.STYLENAME,grading.COLOR,grading.DATE,direction.LW,measurement.MEID,measurement.MEASUREMENT " +
                  " ORDER BY sizeorder.ORDERNO,measurement.MEID";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            masterDataAdapter.Fill(dataPrint, "gradingPrint");

            Application.DoEvents();
            dataPrint.WriteXml("C:\\MyGarmentReport\\qcspec.xml", XmlWriteMode.WriteSchema);
            Form f = new printGrading();
           f.Show();


        }

        private void cbBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*

                    MySqlConnection connection = new MySqlConnection(Global.strCon);

                    DataSet data1 = new DataSet();
                    string sqlQuery = "select * from buyer where BUYERID='" + cbBuyer.Text + "'";
                    masterDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
                    masterDataAdapter.Fill(data1, "buyer");

                    txtBuyerName.Text = Convert.ToString(data1.Tables[0].Rows[0]["BUYERNAME"]);
                
            */
        }

        private void cbBuyer_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
