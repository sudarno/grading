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
    public partial class qFinishing : Form
    {
        public delegate void SetParameterValueDelegate(string date1, string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
        private string GStrCode = "";
        private string GitemsDesc = "";
        private string GBuyerID = "";

        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        private DataTable dataTableLW = null;

        public qFinishing()
        {
            InitializeComponent();
        }
        private void SetCostingCallBack(string CostingNo)
        {
            GStrCode = CostingNo;
        }
        private void SetItemsCallBack(string ItemsID, string ItemsDesc, string ItemBuyer)
        {
            GStrCode = ItemsID;
            GitemsDesc = ItemsDesc;
            GBuyerID = ItemBuyer;
        }
        private void getData(string style)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM qcfinishing WHERE STYLEID LIKE @STYLEID ORDER BY LINEID ASC";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@STYLEID", "%" + style + "%");
                masterDataAdapter.Fill(data, "qcfinishing");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "qcfinishing";

                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;

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
                ColumnColor.HeaderText = "COLORID";
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

                DataGridViewTextBoxColumn ColumnQtyCheck = new DataGridViewTextBoxColumn();
                ColumnQtyCheck.HeaderText = "QTY FINISH";
                ColumnQtyCheck.Width = 60;
                ColumnQtyCheck.DataPropertyName = "QTYFINISH";
                ColumnQtyCheck.Name = "QTYFINISH";
                masterDataGridView.Columns.Add(ColumnQtyCheck);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void getData(DateTime date)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                string strAdapter = "SELECT * FROM qcfinishing WHERE DATE(DATE)=DATE('" + date.ToString("yyyy-MM-dd") + "')";


                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.Fill(data, "qcfinishing");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "qcfinishing";

                //add kolom grid
                // binding
                masterDataGridView.DataSource = masterBindingSource;


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

                masterDataGridView.Columns.Clear();
                
                DataGridViewButtonColumn ColumnStyle = new DataGridViewButtonColumn();
                ColumnStyle.HeaderText = "STYLEID";
                ColumnStyle.Width = 150;
                ColumnStyle.DataPropertyName = "STYLEID";
                ColumnStyle.Name = "STYLEID";
                ColumnStyle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


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
                ColumnColor.HeaderText = "COLORID";
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
                ColumnDate.Visible = false;
                masterDataGridView.Columns.Add(ColumnDate);

                DataGridViewTextBoxColumn ColumnQtyCheck = new DataGridViewTextBoxColumn();
                ColumnQtyCheck.HeaderText = "QTY FINISH";
                ColumnQtyCheck.Width = 60;
                ColumnQtyCheck.DataPropertyName = "QTYFINISH";
                ColumnQtyCheck.Name = "QTYFINISH";
                masterDataGridView.Columns.Add(ColumnQtyCheck);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void finishing_Load(object sender, EventArgs e)
        {
            getData(dateQC.Value.Date);
            cmdSave.Enabled = true;
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            getData(dateQC.Value.Date);
            cmdSave.Enabled = true;
        }

      

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "qcfinishing");
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
                        //masterDataGridView.Rows.RemoveAt(item.Index);
                        masterBindingSource.RemoveAt(item.Index);
                    }

                    masterBindingSource.EndEdit();
                    masterDataAdapter.Update(data, "qcfinishing");
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

        private void cmdFind_Click(object sender, EventArgs e)
        {

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
            masterDataGridView.Rows[e.RowIndex].Cells["DATE"].Value = dateQC.Value;
        }

        private void dateQC_ValueChanged(object sender, EventArgs e)
        {
            getData(dateQC.Value.Date);
            cmdSave.Enabled = true;
        }

        private void cmdRepair_Click(object sender, EventArgs e)
        {
            qRepair f = new qRepair();
            f.MdiParent = this.MdiParent;
            f.Show();
        }
    }
}
