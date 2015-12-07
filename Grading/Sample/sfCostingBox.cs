using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Grading.Sample
{
    public partial class sfCostingBox : Form
    {
        //
        public delegate void SetParameterValueDelegate(string No);
        public SetParameterValueDelegate SetParameterValueCallback;
        //
        private DataSet data = null;

        BindingSource masterBindingSource = new BindingSource();
        BindingSource detailsBindingSource = new BindingSource();
        BindingSource matchBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlDataAdapter detailsDataAdapter = null;
        private MySqlDataAdapter matchDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;
        //DataGridViewComboBoxColumn MEColumn = new DataGridViewComboBoxColumn();
        public sfCostingBox()
        {
            InitializeComponent();
        }

        private void getData()
        {
            data = new DataSet();
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                string strQuery = "select * from sfcosting where no=" + txtNo.Text;
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.Fill(data, "sfcosting");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                string strQuery1 = "select * from sfcostingdetail where no=" + txtNo.Text + " ORDER BY NoUrut ASC";
                detailsDataAdapter = new MySqlDataAdapter(strQuery1, connection);
                detailsDataAdapter.Fill(data, "sfcostingdetail");
                sqlCommandBuilder = new MySqlCommandBuilder(detailsDataAdapter);

                string strQuery2 = "select * from sfcostingmatch where no=" + txtNo.Text + " ORDER BY NoUrut ASC ";
                matchDataAdapter = new MySqlDataAdapter(strQuery2, connection);
                matchDataAdapter.Fill(data, "sfcostingmatch");
                sqlCommandBuilder = new MySqlCommandBuilder(matchDataAdapter);


                DataRelation Relation = new DataRelation("rsfcosting", data.Tables["sfcosting"].Columns["no"], data.Tables["sfcostingdetail"].Columns["no"]);
                DataRelation Relation1 = new DataRelation("rsfcostingmatch", data.Tables["sfcosting"].Columns["no"], data.Tables["sfcostingmatch"].Columns["no"]);

                data.Relations.Add(Relation);
                data.Relations.Add(Relation1);



                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sfcosting";

                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "rsfcosting";

                matchBindingSource.DataSource = masterBindingSource;
                matchBindingSource.DataMember = "rsfcostingmatch";
                //matchBindingSource

                //grading header 
                txtNo.DataBindings.Clear();

                txtWidth.DataBindings.Clear();
                txtConsp.DataBindings.Clear();
                txtDesc.DataBindings.Clear();
                txtColor.DataBindings.Clear();
                picSketch.DataBindings.Clear();
                picMarker.DataBindings.Clear();
                //size
                //txtSize1. picMarker.DataBindings.Clear();
                txtSize1.DataBindings.Clear();
                txtSize2.DataBindings.Clear();
                txtSize3.DataBindings.Clear();
                txtSize4.DataBindings.Clear();
                txtSize5.DataBindings.Clear();
                txtSize6.DataBindings.Clear();
                txtSize7.DataBindings.Clear();
                txtSize8.DataBindings.Clear();
                txtSize9.DataBindings.Clear();
                txtSize10.DataBindings.Clear();
                txtSize11.DataBindings.Clear();
                txtSize12.DataBindings.Clear();
                //qty 1- 12
                txtQty1.DataBindings.Clear();
                txtQty2.DataBindings.Clear();
                txtQty3.DataBindings.Clear();
                txtQty4.DataBindings.Clear();
                txtQty5.DataBindings.Clear();
                txtQty6.DataBindings.Clear();
                txtQty7.DataBindings.Clear();

                txtQty8.DataBindings.Clear();
                txtQty9.DataBindings.Clear();
                txtQty10.DataBindings.Clear();
                txtQty11.DataBindings.Clear();
                txtQty12.DataBindings.Clear();
                //tembahan
                txtStatusCons.DataBindings.Clear();
                txtReviseDue.DataBindings.Clear();
                txtCount.DataBindings.Clear();
                txtTotMarker.DataBindings.Clear();
                cekList1.DataBindings.Clear();
                cekList2.DataBindings.Clear();
                cekList3.DataBindings.Clear();
                cekList4.DataBindings.Clear();
                //srinkage
                txtSLength.DataBindings.Clear();
                txtSWidth.DataBindings.Clear();




                txtNo.DataBindings.Add(new Binding("Text", masterBindingSource, "no", true, DataSourceUpdateMode.OnPropertyChanged));
                txtWidth.DataBindings.Add(new Binding("Text", masterBindingSource, "width", true, DataSourceUpdateMode.OnPropertyChanged));
                txtConsp.DataBindings.Add(new Binding("Text", masterBindingSource, "consp", true, DataSourceUpdateMode.OnPropertyChanged));
                txtDesc.DataBindings.Add(new Binding("Text", masterBindingSource, "desc", true, DataSourceUpdateMode.OnPropertyChanged));
                txtColor.DataBindings.Add(new Binding("Text", masterBindingSource, "color", true, DataSourceUpdateMode.OnPropertyChanged));
                picSketch.DataBindings.Add(new Binding("Image", masterBindingSource, "picSketch", true, DataSourceUpdateMode.OnPropertyChanged));
                picMarker.DataBindings.Add(new Binding("Image", masterBindingSource, "picMarker", true, DataSourceUpdateMode.OnPropertyChanged));


                //size
                txtSize1.DataBindings.Add(new Binding("Text", masterBindingSource, "size1", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize2.DataBindings.Add(new Binding("Text", masterBindingSource, "size2", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize3.DataBindings.Add(new Binding("Text", masterBindingSource, "size3", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize4.DataBindings.Add(new Binding("Text", masterBindingSource, "size4", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize5.DataBindings.Add(new Binding("Text", masterBindingSource, "size5", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize6.DataBindings.Add(new Binding("Text", masterBindingSource, "size6", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize7.DataBindings.Add(new Binding("Text", masterBindingSource, "size7", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize8.DataBindings.Add(new Binding("Text", masterBindingSource, "size8", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize9.DataBindings.Add(new Binding("Text", masterBindingSource, "size9", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize10.DataBindings.Add(new Binding("Text", masterBindingSource, "size10", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize11.DataBindings.Add(new Binding("Text", masterBindingSource, "size11", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSize12.DataBindings.Add(new Binding("Text", masterBindingSource, "size12", true, DataSourceUpdateMode.OnPropertyChanged));

                // qty

                txtQty1.DataBindings.Add(new Binding("Text", masterBindingSource, "qty1", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty2.DataBindings.Add(new Binding("Text", masterBindingSource, "qty2", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty3.DataBindings.Add(new Binding("Text", masterBindingSource, "qty3", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty4.DataBindings.Add(new Binding("Text", masterBindingSource, "qty4", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty5.DataBindings.Add(new Binding("Text", masterBindingSource, "qty5", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty6.DataBindings.Add(new Binding("Text", masterBindingSource, "qty6", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty7.DataBindings.Add(new Binding("Text", masterBindingSource, "qty7", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty8.DataBindings.Add(new Binding("Text", masterBindingSource, "qty8", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty9.DataBindings.Add(new Binding("Text", masterBindingSource, "qty9", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty10.DataBindings.Add(new Binding("Text", masterBindingSource, "qty10", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty11.DataBindings.Add(new Binding("Text", masterBindingSource, "qty11", true, DataSourceUpdateMode.OnPropertyChanged));
                txtQty12.DataBindings.Add(new Binding("Text", masterBindingSource, "qty12", true, DataSourceUpdateMode.OnPropertyChanged));
                //tambahan
                txtStatusCons.DataBindings.Add(new Binding("Text", masterBindingSource, "StatusCons", true, DataSourceUpdateMode.OnPropertyChanged));
                txtReviseDue.DataBindings.Add(new Binding("Text", masterBindingSource, "ReviseDue", true, DataSourceUpdateMode.OnPropertyChanged));
                txtCount.DataBindings.Add(new Binding("Text", masterBindingSource, "Count", true, DataSourceUpdateMode.OnPropertyChanged));
                txtTotMarker.DataBindings.Add(new Binding("Text", masterBindingSource, "TotMarker", true, DataSourceUpdateMode.OnPropertyChanged));
                cekList1.DataBindings.Add(new Binding("Checked", masterBindingSource, "cekList1", true, DataSourceUpdateMode.OnPropertyChanged));
                cekList2.DataBindings.Add(new Binding("Checked", masterBindingSource, "cekList2", true, DataSourceUpdateMode.OnPropertyChanged));
                cekList3.DataBindings.Add(new Binding("Checked", masterBindingSource, "cekList3", true, DataSourceUpdateMode.OnPropertyChanged));
                cekList4.DataBindings.Add(new Binding("Checked", masterBindingSource, "cekList4", true, DataSourceUpdateMode.OnPropertyChanged));

                txtSLength.DataBindings.Add(new Binding("Text", masterBindingSource, "Slength", true, DataSourceUpdateMode.OnPropertyChanged));
                txtSWidth.DataBindings.Add(new Binding("Text", masterBindingSource, "SWidth", true, DataSourceUpdateMode.OnPropertyChanged));

                
                //detail input
                detailsDataGridView.Columns.Clear();
                //detailsDataGridView.ColumnHeadersHeight = 100;
                //detailsDataGridView.AdjustColumnHeaderBorderStyle = 10;



                DataGridViewTextBoxColumn NoUrutColumn = new DataGridViewTextBoxColumn();
                NoUrutColumn.HeaderText = "NoUrut";
                NoUrutColumn.Width = 40;
                NoUrutColumn.DataPropertyName = "NoUrut";
                NoUrutColumn.Name = "NoUrut";

                detailsDataGridView.Columns.Add(NoUrutColumn);

                DataGridViewTextBoxColumn NoColumn = new DataGridViewTextBoxColumn();
                NoColumn.HeaderText = "No";
                NoColumn.Width = 40;
                NoColumn.DataPropertyName = "no";
                NoColumn.Name = "no";
                NoColumn.Visible = false;
                detailsDataGridView.Columns.Add(NoColumn);



                DataGridViewTextBoxColumn MatColumn = new DataGridViewTextBoxColumn();
                MatColumn.HeaderText = "Material";

                MatColumn.Width = 100;
                MatColumn.DataPropertyName = "Material";
                MatColumn.Name = "Material";
                detailsDataGridView.Columns.Add(MatColumn);
                
      
                
                DataGridViewTextBoxColumn FabridColumn = new DataGridViewTextBoxColumn();
                FabridColumn.HeaderText = "Fabric Type";
                FabridColumn.Width = 100;
                FabridColumn.DataPropertyName = "FabricType";
                FabridColumn.Name = "FabricType";
                detailsDataGridView.Columns.Add(FabridColumn);

               
                DataGridViewTextBoxColumn MarkerOriColumn = new DataGridViewTextBoxColumn();
                MarkerOriColumn.HeaderText = "Marker Orientation";
                MarkerOriColumn.Width = 100;
                MarkerOriColumn.DataPropertyName = "MarkerOri";
                MarkerOriColumn.Name = "MarkerOri";
                detailsDataGridView.Columns.Add(MarkerOriColumn);
               
                DataGridViewTextBoxColumn PCS1Column = new DataGridViewTextBoxColumn();
                PCS1Column.HeaderText = "PCS";
                PCS1Column.Width = 40;
                PCS1Column.DataPropertyName = "PCS1";
                PCS1Column.Name = "PCS1";
                PCS1Column.DefaultCellStyle.BackColor = Color.Fuchsia;
                detailsDataGridView.Columns.Add(PCS1Column);

                DataGridViewTextBoxColumn Inch1Column = new DataGridViewTextBoxColumn();
                Inch1Column.HeaderText = "Inch";
                Inch1Column.Width = 40;
                Inch1Column.DataPropertyName = "Inch1";
                Inch1Column.Name = "inch1";
                Inch1Column.DefaultCellStyle.BackColor = Color.LightBlue;
                detailsDataGridView.Columns.Add(Inch1Column);

                DataGridViewTextBoxColumn Yard1Column = new DataGridViewTextBoxColumn();
                Yard1Column.HeaderText = "Yard";
                Yard1Column.Width = 40;
                Yard1Column.DataPropertyName = "Yard1";
                Yard1Column.Name = "Yard1";
                Yard1Column.DefaultCellStyle.BackColor = Color.GreenYellow;
                detailsDataGridView.Columns.Add(Yard1Column);

                DataGridViewTextBoxColumn PCS2Column = new DataGridViewTextBoxColumn();
                PCS2Column.HeaderText = "PCS";
                PCS2Column.Width = 40;
                PCS2Column.DataPropertyName = "PCS2";
                PCS2Column.Name = "PCS2";
                PCS2Column.DefaultCellStyle.BackColor = Color.Fuchsia;
                detailsDataGridView.Columns.Add(PCS2Column);

                DataGridViewTextBoxColumn Inch2Column = new DataGridViewTextBoxColumn();
                Inch2Column.HeaderText = "Inch";
                Inch2Column.Width = 40;
                Inch2Column.DataPropertyName = "Inch2";
                Inch2Column.Name = "inch2";
                Inch2Column.DefaultCellStyle.BackColor = Color.LightBlue;
                detailsDataGridView.Columns.Add(Inch2Column);

                DataGridViewTextBoxColumn Yard2Column = new DataGridViewTextBoxColumn();
                Yard2Column.HeaderText = "Yard";
                Yard2Column.Width = 40;
                Yard2Column.DataPropertyName = "Yard2";
                Yard2Column.Name = "Yard2";
                Yard2Column.DefaultCellStyle.BackColor = Color.GreenYellow;
                detailsDataGridView.Columns.Add(Yard2Column);

                DataGridViewTextBoxColumn Option1Column = new DataGridViewTextBoxColumn();
                Option1Column.HeaderText = "Option1";
                Option1Column.Width = 50;
                Option1Column.DataPropertyName = "Option1";
                Option1Column.Name = "Option1";
                Option1Column.DefaultCellStyle.BackColor = Color.Aqua;
                detailsDataGridView.Columns.Add(Option1Column);

                DataGridViewTextBoxColumn Option2Column = new DataGridViewTextBoxColumn();
                Option2Column.HeaderText = "Option2";
                Option2Column.Width = 50;
                Option2Column.DataPropertyName = "Option2";
                Option2Column.Name = "Option2";
                Option2Column.DefaultCellStyle.BackColor = Color.AliceBlue;
                detailsDataGridView.Columns.Add(Option2Column);

                DataGridViewTextBoxColumn CutColumn = new DataGridViewTextBoxColumn();
                CutColumn.HeaderText = "Cut Width";
                CutColumn.Width = 40;
                CutColumn.DataPropertyName = "CutWidth";
                CutColumn.Name = "CutWidth";
                detailsDataGridView.Columns.Add(CutColumn);

                DataGridViewTextBoxColumn ContenColumn = new DataGridViewTextBoxColumn();
                ContenColumn.HeaderText = "Fabric Content";
                ContenColumn.Width = 100;
                ContenColumn.DataPropertyName = "FabricContent";
                ContenColumn.Name = "FabricContent";
                detailsDataGridView.Columns.Add(ContenColumn);
                //end
                 
                detailsDataGridView.DataSource = detailsBindingSource;

                //match column
                /*
                DataGridViewCheckBoxColumn CekColumn = new DataGridViewCheckBoxColumn();
                CekColumn.HeaderText = "cek";
                CekColumn.Width = 100;
                CekColumn.DataPropertyName = "cek";
                CekColumn.Name = "cek";
                gridMatch.Columns.Add(CekColumn);
                */
                gridMatch.Columns.Clear();

                DataGridViewTextBoxColumn MatNoColumn = new DataGridViewTextBoxColumn();
                MatNoColumn.HeaderText = "no";
                MatNoColumn.Width = 50;
                MatNoColumn.DataPropertyName = "no";
                MatNoColumn.Name = "no";
                MatNoColumn.Visible = false;
                gridMatch.Columns.Add(MatNoColumn);

                DataGridViewTextBoxColumn MatUrutColumn = new DataGridViewTextBoxColumn();
                MatUrutColumn.HeaderText = "No Urut";
                MatUrutColumn.Width = 50;
                MatUrutColumn.DataPropertyName = "NoUrut";
                MatUrutColumn.Name = "NoUrut";
                gridMatch.Columns.Add(MatUrutColumn);

                DataGridViewTextBoxColumn matGroupColumn = new DataGridViewTextBoxColumn();
                matGroupColumn.HeaderText = "Group";
                matGroupColumn.Width = 100;
                matGroupColumn.DataPropertyName = "group";
                matGroupColumn.Name = "group";
                gridMatch.Columns.Add(matGroupColumn);

                DataGridViewTextBoxColumn MatDetailColumn = new DataGridViewTextBoxColumn();
                MatDetailColumn.HeaderText = "Detail";
                MatDetailColumn.Width = 200;
                MatDetailColumn.DataPropertyName = "detail";
                MatDetailColumn.Name = "detail";
                gridMatch.Columns.Add(MatDetailColumn);

                DataGridViewCheckBoxColumn CekColumn = new DataGridViewCheckBoxColumn();
                CekColumn.HeaderText = "cek";
                CekColumn.Width = 40;
                CekColumn.DataPropertyName = "cek";
                CekColumn.Name = "cek";
                gridMatch.Columns.Add(CekColumn);

                gridMatch.DataSource = matchBindingSource;

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void getData(string id)
        {
            data = new DataSet();
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                string strQuery = "select * from sfcosting where no=" + txtNo.Text;
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.Fill(data, "sfcosting");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);


                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "sfcosting";


                //grading header 
                txtNo.DataBindings.Clear();

                txtWidth.DataBindings.Clear();
                txtConsp.DataBindings.Clear();
                txtDesc.DataBindings.Clear();
                txtColor.DataBindings.Clear();


                txtNo.DataBindings.Add(new Binding("Text", masterBindingSource, "no", true, DataSourceUpdateMode.OnPropertyChanged));
                txtWidth.DataBindings.Add(new Binding("Text", masterBindingSource, "width", true, DataSourceUpdateMode.OnPropertyChanged));
                txtConsp.DataBindings.Add(new Binding("Text", masterBindingSource, "consp", true, DataSourceUpdateMode.OnPropertyChanged));
                txtDesc.DataBindings.Add(new Binding("Text", masterBindingSource, "desc", true, DataSourceUpdateMode.OnPropertyChanged));
                txtColor.DataBindings.Add(new Binding("Text", masterBindingSource, "color", true, DataSourceUpdateMode.OnPropertyChanged));

                //

                //end
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void sfCostingBox_Load(object sender, EventArgs e)
        {   //header inisial
            this.detailsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.detailsDataGridView.ColumnHeadersHeight = this.detailsDataGridView.ColumnHeadersHeight * 2;
            this.detailsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;


            txtNo.Text = Global.GlobalCode;

            getData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {

                //this.Validate();
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "sfcosting");

                detailsBindingSource.EndEdit();
                detailsDataAdapter.Update(data, "sfcostingdetail");

                matchBindingSource.EndEdit();
                matchDataAdapter.Update(data, "sfcostingmatch");

                MessageBox.Show("the data has been saved");
                getData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                getData();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void detailsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // DataGridViewRow row = this.detailsDataGridView.Rows[e.RowIndex];
                if ((detailsDataGridView.Rows[e.RowIndex].Cells["PCS1"].Value is DBNull) || detailsDataGridView.Rows[e.RowIndex].Cells["Yard1"].Value is DBNull || detailsDataGridView.Rows[e.RowIndex].Cells["Inch1"].Value is DBNull)
                {
                    //detailsDataGridView.Rows[e.RowIndex].Cells["Option1"].Value = null;
                }
                else
                {
                    if (Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["PCS1"].Value) > 0)
                    {
                        
                        detailsDataGridView.Rows[e.RowIndex].Cells["Option1"].Value = Math.Round((Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["Yard1"].Value) + (Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["Inch1"].Value) / 36)) / (Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["PCS1"].Value)),2);
                        
                    }
                }

                if (detailsDataGridView.Rows[e.RowIndex].Cells["PCS2"].Value is DBNull || detailsDataGridView.Rows[e.RowIndex].Cells["Yard2"].Value is DBNull || detailsDataGridView.Rows[e.RowIndex].Cells["Inch2"].Value is DBNull)
                {
                    //detailsDataGridView.Rows[e.RowIndex].Cells["Option2"].Value = null;
                }
                else
                {
                    if (Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["PCS2"].Value) > 0)
                    {

                        detailsDataGridView.Rows[e.RowIndex].Cells["Option2"].Value = Math.Round((Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["Yard2"].Value) + ((Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["Inch2"].Value) / 36))) / (Convert.ToDouble(detailsDataGridView.Rows[e.RowIndex].Cells["PCS2"].Value)),2);
                    }
                }

            }

        }

        private void detailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void detailsDataGridView_RowCreated(object sender, PaintEventArgs e)
        {


        }

        private void detailsDataGridView_Paint(object sender, PaintEventArgs e)
        {
            //merger column
            
            string[] monthes = { "OPTION 1", "OPTION 2", "MARKER" };
            for (int j = 5; j < 13; )
            {
                Rectangle r1 = this.detailsDataGridView.GetCellDisplayRectangle(j, -1, true);
                int w2 = this.detailsDataGridView.GetCellDisplayRectangle(j + 1, -1, true).Width;
                int w3 = this.detailsDataGridView.GetCellDisplayRectangle(j + 2, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                if (j < 9)
                {
                    r1.Width = r1.Width + w2 + w3 - 1;

                }
                else
                {
                    r1.Width = r1.Width + w2 - 1;
                }

                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.detailsDataGridView.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                if (j < 9)
                { //option1 & option 2
                    e.Graphics.DrawString(monthes[j / 6], this.detailsDataGridView.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(this.detailsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                }
                else
                {//marker
                    e.Graphics.DrawString(monthes[j / 5], this.detailsDataGridView.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(this.detailsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                }

                j += 3;
            }

            // paint marker
             
            

        }

        private void cmdSketch_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //txtPath.Text = openFileDialog1.FileName;
                    picSketch.Image = Image.FromFile(openFileDialog1.FileName);
                    // detailsDataGridView.Rows[e.RowIndex].Cells["IMAGE"].Value = Image.FromFile(openFileDialog1.FileName);



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdMarker_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog2 = new OpenFileDialog();
                openFileDialog2.Filter = "Image files | *.jpg";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    //txtPath.Text = openFileDialog1.FileName;
                    picMarker.Image = Image.FromFile(openFileDialog2.FileName);
                    // detailsDataGridView.Rows[e.RowIndex].Cells["IMAGE"].Value = Image.FromFile(openFileDialog1.FileName);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            sfCostingPrint f = new sfCostingPrint();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(txtNo.Text);
            f.Show();
        }

        private void cmdXSD_Click(object sender, EventArgs e)
        {
            DataSet dsReject = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strAdapter = "SELECT * FROM sfcosting " +
                            "INNER JOIN sfcostingdetail ON sfcosting.`no`=sfcostingdetail.`no` WHERE sfcosting.`no`=@no";
            masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@no", txtNo.Text);
            masterDataAdapter.Fill(dsReject, "sfcostingboxxsd");
            Application.DoEvents();
            dsReject.WriteXmlSchema("C:\\MyGarmentReport\\sfcostingboxxsd.xsd");
        }

        private void cmdXSD2_Click(object sender, EventArgs e)
        {
            DataSet dsReject = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strAdapter = "SELECT * FROM sfcosting " +
                            "INNER JOIN sfcostingmatch ON sfcosting.`no`=sfcostingmatch.`no` WHERE sfcosting.`no`=@no";
            masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@no", txtNo.Text);
            masterDataAdapter.Fill(dsReject, "sfcostingboxsubxsd");
            Application.DoEvents();
            dsReject.WriteXmlSchema("C:\\MyGarmentReport\\sfcostingboxsubxsd.xsd");
        }
    }
    }