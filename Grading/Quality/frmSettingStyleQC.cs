using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Grading.Quality
{
    public partial class frmSettingStyleQC : Form
    {
        private DataSet data = null;
        BindingSource masterBindingSource = new BindingSource();
        BindingSource detailsBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlDataAdapter detailsDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;

        public frmSettingStyleQC()
        {
            InitializeComponent();
        }
        private void SetCostingCallBack(string Style, string Desc)
        {
            txtStyleID.Text = Style;
            txtDesc.Text = Desc;
        }
        private void getData(string Style)
        {
            data = new DataSet();
                try
                {
                    MySqlConnection connection = new MySqlConnection(Global.strCon);

                    masterDataAdapter = new MySqlDataAdapter("select * from style where STYLEID='" + Style + "'", connection);
                    masterDataAdapter.Fill(data, "grading");
                    sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                    detailsDataAdapter = new MySqlDataAdapter("select * from qcstyle where STYLEID='" + Style + "'", connection);
                    detailsDataAdapter.Fill(data, "gradingdetail");
                    sqlCommandBuilder = new MySqlCommandBuilder(detailsDataAdapter);
                    DataRelation Relation = new DataRelation("rGrading", data.Tables["grading"].Columns["STYLEID"], data.Tables["gradingdetail"].Columns["STYLEID"]);
                    data.Relations.Add(Relation);
                    masterBindingSource.DataSource = data;
                    masterBindingSource.DataMember = "grading";

                    detailsBindingSource.DataSource = masterBindingSource;
                    detailsBindingSource.DataMember = "rGrading";

                    //grading header 
                    txtStyleID.DataBindings.Clear();
                    txtStyleID.Text = Style;
                    txtStyleID.DataBindings.Add(new Binding("Text", masterBindingSource, "STYLEID", true, DataSourceUpdateMode.OnPropertyChanged));
                    //grid detail
                    //detailsDataGridView.Rows.Clear();
                    detailsDataGridView.DataSource = detailsBindingSource;
                    //detail column

                    //list COLOR
                    string selectQueryStringCOLOR = "SELECT * FROM color";

                    MySqlDataAdapter sqlDataAdapterCOLOR = new MySqlDataAdapter(selectQueryStringCOLOR, connection);
                    MySqlCommandBuilder sqlCommandBuilderCOLOR = new MySqlCommandBuilder(sqlDataAdapterCOLOR);

                    DataTable dataTableCOLOR = new DataTable();
                    sqlDataAdapterCOLOR.Fill(dataTableCOLOR);
                    BindingSource bindingSourceCOLOR = new BindingSource();
                    bindingSourceCOLOR.DataSource = dataTableCOLOR;

                    //list BUYER
                    string selectQueryStringBUYER = "SELECT * FROM BUYER";

                    MySqlDataAdapter sqlDataAdapterBUYER = new MySqlDataAdapter(selectQueryStringBUYER, connection);
                    MySqlCommandBuilder sqlCommandBuilderBUYER = new MySqlCommandBuilder(sqlDataAdapterBUYER);

                    DataTable dataTableBUYER = new DataTable();
                    sqlDataAdapterBUYER.Fill(dataTableBUYER);
                    BindingSource bindingSourceBUYER = new BindingSource();
                    bindingSourceBUYER.DataSource = dataTableBUYER;

                    //isi colum grid
                    detailsDataGridView.Columns.Clear();


                    DataGridViewComboBoxColumn BUYERColumn = new DataGridViewComboBoxColumn();
                    BUYERColumn.HeaderText = "BUYER";
                    BUYERColumn.Width = 100;
                    BUYERColumn.DataPropertyName = "BUYERID";
                    BUYERColumn.Name = "BUYERID";
                    
                    //binding
                    BUYERColumn.DataSource = bindingSourceBUYER;
                    BUYERColumn.ValueMember = "BUYERID";
                    BUYERColumn.DisplayMember = "BUYERNAME";

                    detailsDataGridView.Columns.Add(BUYERColumn);

                    DataGridViewComboBoxColumn COLORColumn = new DataGridViewComboBoxColumn();
                    COLORColumn.HeaderText = "COLORID";
                    COLORColumn.Width = 80;
                    COLORColumn.DataPropertyName = "COLORID";
                    COLORColumn.Name = "COLORID";

                    //binding
                    COLORColumn.DataSource = bindingSourceCOLOR;
                    COLORColumn.ValueMember = "COLORID";
                    COLORColumn.DisplayMember = "COLORNAME";

                    detailsDataGridView.Columns.Add(COLORColumn);

                    DataGridViewTextBoxColumn QTYORDERColumn = new DataGridViewTextBoxColumn();
                    QTYORDERColumn.HeaderText = "QTY ORDER";
                    QTYORDERColumn.Width = 100;
                    QTYORDERColumn.DataPropertyName = "QTYORDER";
                    QTYORDERColumn.Name = "QTYORDER";
                    detailsDataGridView.Columns.Add(QTYORDERColumn);


                    DataGridViewTextBoxColumn QTYCUTTColumn = new DataGridViewTextBoxColumn();
                    QTYCUTTColumn.HeaderText = "QTY CUTT";
                    QTYCUTTColumn.Width = 100;
                    QTYCUTTColumn.DataPropertyName = "QTYCUTT";
                    QTYCUTTColumn.Name = "QTYCUTT";
                    detailsDataGridView.Columns.Add(QTYCUTTColumn);

                    DataGridViewTextBoxColumn QTYSHIPColumn = new DataGridViewTextBoxColumn();
                    QTYSHIPColumn.HeaderText = "QTY SHIP";
                    QTYSHIPColumn.Width = 100;
                    QTYSHIPColumn.DataPropertyName = "QTYSHIP";
                    QTYSHIPColumn.Name = "QTYSHIP";
                    detailsDataGridView.Columns.Add(QTYSHIPColumn);

                    DataGridViewTextBoxColumn QTYPOColumn = new DataGridViewTextBoxColumn();
                    QTYPOColumn.HeaderText = "PO CUSTOMER";
                    QTYPOColumn.Width = 100;
                    QTYPOColumn.DataPropertyName = "POCUSTOMER";
                    QTYPOColumn.Name = "POCUSTOMER";
                    detailsDataGridView.Columns.Add(QTYPOColumn);

                    DataGridViewImageColumn IMAGEColumn = new DataGridViewImageColumn();
                    IMAGEColumn.HeaderText = "IMAGE";
                    IMAGEColumn.Width = 100;
                    IMAGEColumn.DataPropertyName = "IMAGE";
                    IMAGEColumn.Name = "IMAGE";
                    detailsDataGridView.Columns.Add(IMAGEColumn);


               
                    connection.Close();


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

        private void frmSettingStyleQC_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {

                detailsBindingSource.EndEdit();
                detailsDataAdapter.Update(data, "gradingdetail");
                //detailsDataGridView.Enabled = true;
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

        private void detailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
       
               if (detailsDataGridView.Rows[e.RowIndex].Cells["IMAGE"].Value.ToString() != string.Empty)
               {
                   var data = (Byte[])(detailsDataGridView.Rows[e.RowIndex].Cells["IMAGE"].Value);
                   var stream = new MemoryStream(data);
                   picItems.Image = Image.FromStream(stream);
               }
               else
               {
                   picItems.Image = null;
               }
       
        }

        private void detailsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

           
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] == detailsDataGridView.Columns["IMAGE"])
            {
                try
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "Image files | *.jpg";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = openFileDialog1.FileName;
                        picItems.Image = Image.FromFile(openFileDialog1.FileName);
                        detailsDataGridView.Rows[e.RowIndex].Cells["IMAGE"].Value = Image.FromFile(openFileDialog1.FileName);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
