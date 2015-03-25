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
    public partial class frmSettingProp : Form
    {
        // private DataGridView masterDataGridView = new DataGridView();
        private BindingSource masterBindingSource = new BindingSource();
        private BindingSource dirBindingSource = new BindingSource();
        private BindingSource sizeBindingSource = new BindingSource();
        // private DataGridView detailsDataGridView = new DataGridView();
        
        private DataSet data = null;

        //tambahan
        //private SqlDataAdapter sqlDataAdapter = null;
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlDataAdapter dirDataAdapter = null;
        private MySqlDataAdapter sizeDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        public frmSettingProp()
        {
            InitializeComponent();
        }
        private void SetCostingCallBack(string Style, string Desc)
        {
           txtStyleID.Text = Style;
           txtDesc.Text = Desc;
        }

        private void getData(string style)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from style where styleid='"+style+"'", connection);
                masterDataAdapter.Fill(data, "style");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                dirDataAdapter=new MySqlDataAdapter("select * from direction where styleID='"+style+"'", connection);
                dirDataAdapter.Fill(data, "direction");
                sqlCommandBuilder = new MySqlCommandBuilder(dirDataAdapter);

                //tambahan size order

                sizeDataAdapter = new MySqlDataAdapter("select * from sizeorder where styleID='" + style + "' Order By ORDERNO", connection);
                sizeDataAdapter.Fill(data, "sizeorder");
                sqlCommandBuilder = new MySqlCommandBuilder(sizeDataAdapter);
          

                DataRelation Relation = new DataRelation("rDirection", data.Tables["style"].Columns["STYLEID"], data.Tables["direction"].Columns["STYLEID"]);
                data.Relations.Add(Relation);

                DataRelation Relation1 = new DataRelation("rSize", data.Tables["style"].Columns["STYLEID"], data.Tables["sizeorder"].Columns["STYLEID"]);
                data.Relations.Add(Relation1);


                //list size 

                string selectQueryStringItem = "SELECT * FROM size";

                MySqlDataAdapter sqlDataAdapterItem = new MySqlDataAdapter(selectQueryStringItem, connection);
                MySqlCommandBuilder sqlCommandBuilderItem = new MySqlCommandBuilder(sqlDataAdapterItem);

                DataTable dataTableItem = new DataTable();
                sqlDataAdapterItem.Fill(dataTableItem);
                BindingSource bindingSourceItem = new BindingSource();
                bindingSourceItem.DataSource = dataTableItem;


                //dataGridViewComboTrial.ClearSelection();


                //binding
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "style";

                dirBindingSource.DataSource = masterBindingSource;
                dirBindingSource.DataMember = "rDirection";

                sizeBindingSource.DataSource = masterBindingSource;
                sizeBindingSource.DataMember = "rSize";


                dirDataGridView.DataSource = dirBindingSource;
                sizeDataGridView.DataSource = sizeBindingSource;

                //grid size order
                sizeDataGridView.Columns.Clear();
                /*
                DataGridViewTextBoxColumn sizeStyleID = new DataGridViewTextBoxColumn();
                sizeStyleID.HeaderText = "STYLEID";
                sizeStyleID.Width = 80;
                sizeStyleID.DataPropertyName = "STYLEID";
                sizeStyleID.Name = "STYLEID";
                sizeDataGridView.Columns.Add(sizeStyleID);
                */
                //DataGridViewTextBoxColumn sizeSizeID = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn sizeSizeID = new DataGridViewComboBoxColumn();
                sizeSizeID.HeaderText = "SIZEID";
                sizeSizeID.Width = 80;
                sizeSizeID.DataPropertyName = "SIZEID";
                sizeSizeID.Name = "SIZEID";

                //binding
                sizeSizeID.DataSource = bindingSourceItem;
                sizeSizeID.ValueMember = "SIZEID";
                sizeSizeID.DisplayMember = "SIZENAME";

                //add column
                sizeDataGridView.Columns.Add(sizeSizeID);

                List<int> myNo = new List<int>
                {
                1,2,3,4,5,6,7,8,9,10,11,12
                };
               // DataGridViewTextBoxColumn sizeOrdrNo = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn sizeOrdrNo = new DataGridViewComboBoxColumn();
                sizeOrdrNo.HeaderText = "ORDERNO";
                sizeOrdrNo.Width = 80;
                sizeOrdrNo.DataPropertyName = "ORDERNO";
                sizeOrdrNo.Name = "ORDERNO";
                sizeDataGridView.Columns.Add(sizeOrdrNo);

                sizeOrdrNo.DataSource = myNo;
                //sizeOrdrNo.ValueMember = "SIZEID";
               // sizeOrdrNo.DisplayMember = "SIZENAME";


                //DataGridViewTextBoxColumn sizeBasic = new DataGridViewTextBoxColumn();
                DataGridViewCheckBoxColumn sizeBasic = new DataGridViewCheckBoxColumn();
                sizeBasic.HeaderText = "SIZEBASIC";
                sizeBasic.Width = 80;
                sizeBasic.DataPropertyName = "SIZEBASIC";
                sizeBasic.Name = "SIZEBASIC";
                sizeDataGridView.Columns.Add(sizeBasic);


                //end size order
                


                //add kolom untuk direction
                dirDataGridView.Columns.Clear();

                /*
                DataGridViewTextBoxColumn ColumnStyleID = new DataGridViewTextBoxColumn();
                ColumnStyleID.HeaderText = "STYLEID";
                ColumnStyleID.Width = 100;
                ColumnStyleID.DataPropertyName = "STYLEID";
                ColumnStyleID.Name = "STYLEID";
                dirDataGridView.Columns.Add(ColumnStyleID);
                */
                //end direction

                //DataGridViewTextBoxColumn ColumnLW = new DataGridViewTextBoxColumn();
                List<string> myLW = new List<string>
                {
                "L","W"
                };
                DataGridViewComboBoxColumn ColumnLW = new DataGridViewComboBoxColumn();
                ColumnLW.HeaderText = "LW";
                ColumnLW.Width = 80;
                ColumnLW.DataPropertyName = "LW";
                ColumnLW.Name = "LW";
                dirDataGridView.Columns.Add(ColumnLW);
                ColumnLW.DataSource = myLW;




                DataGridViewTextBoxColumn ColumnLWValue = new DataGridViewTextBoxColumn();
                ColumnLWValue.HeaderText = "LWVALUE";
                ColumnLWValue.Width = 80;
                ColumnLWValue.DataPropertyName = "LWVALUE";
                ColumnLWValue.Name = "LWVALUE";
                dirDataGridView.Columns.Add(ColumnLWValue);

               

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        private void cmdCustomer_Click(object sender, EventArgs e)
        {
            findStyle f = new findStyle();
            f.AddItemCallback = new findStyle.AddCategoryDelegate(this.SetCostingCallBack);
            f.ShowDialog();

            if (txtStyleID.Text != "")
            {
               // detailsDataGridView.DataSource = masterBindingSource;
               // detailsDataGridView.DataSource = detailsBindingSource;
                getData(txtStyleID.Text);

            }
        }

        private void frmSettingProp_Load(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                dirBindingSource.EndEdit();
                dirDataAdapter.Update(data, "direction");
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

                foreach (DataGridViewRow item in this.dirDataGridView.SelectedRows)
                {
                    dirBindingSource.RemoveAt(item.Index);
                }

                dirBindingSource.EndEdit();
                dirDataAdapter.Update(data, "direction");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
                getData(txtStyleID.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sizeBindingSource.EndEdit();
                sizeDataAdapter.Update(data, "sizeorder");
                MessageBox.Show("the data has been saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow item in this.sizeDataGridView.SelectedRows)
                {
                    sizeBindingSource.RemoveAt(item.Index);
                }

                sizeBindingSource.EndEdit();
                sizeDataAdapter.Update(data, "sizeorder");
                MessageBox.Show("the data has been deleted");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
                getData(txtStyleID.Text);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
