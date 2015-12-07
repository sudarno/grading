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
    public partial class findDocNo : Form
    {
        public delegate void AddCategoryDelegate(string No, string StyleID,string SizeID,string BuyerID);
        public AddCategoryDelegate AddItemCallback;

        private DataSet data = null;
        private BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlCommandBuilder sqlCommandBuilder = null;

        public findDocNo()
        {
            InitializeComponent();
        }
        private void getData(string DocNo, string StyleID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                /*
                string strQueryBuyer = "SELECT buyer.BUYERNAME,qcstyle.* FROM qcstyle " +
                    "INNER JOIN buyer ON buyer.BUYERID=qcstyle.BUYERID where qcstyle.STYLEID LIKE '%" + txtStyleID.Text + "%' AND BUYERNAME LIKE '%" + txtBuyerName.Text + "%'";
                 */
                string strQueryBuyer = "SELECT no,styleid,sizeid,buyerid,datercvd FROM sfcosting WHERE sfcosting.no LIKE @DocNo AND sfcosting.styleid LIKE @styleid order by sfcosting.datercvd desc limit 1000";
                masterDataAdapter = new MySqlDataAdapter(strQueryBuyer, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DocNo", "%" + DocNo.ToString() + "%");
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@styleid", "%" + StyleID.ToString() + "%");
                
               
                masterDataAdapter.Fill(data, "findDocNo");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "findDocNo";

                //add kolom grid
                /*
                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnstyleID = new DataGridViewTextBoxColumn();
                ColumnstyleID.HeaderText = "STYLEID";
                ColumnstyleID.Width = 80;
                ColumnstyleID.DataPropertyName = "STYLEID";
                ColumnstyleID.Name = "STYLEID";
                masterDataGridView.Columns.Add(ColumnstyleID);


                DataGridViewTextBoxColumn ColumnstyleName = new DataGridViewTextBoxColumn();
                ColumnstyleName.HeaderText = "BUYERNAME";
                ColumnstyleName.Width = 180;
                ColumnstyleName.DataPropertyName = "BUYERNAME";
                ColumnstyleName.Name = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnstyleName);
                */


                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtDocNo.Text, txtStyleID.Text);
        }

        private void findDocNo_Load(object sender, EventArgs e)
        {
            getData(txtDocNo.Text, txtStyleID.Text);
        }

        private void masterDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.masterDataGridView.Rows[e.RowIndex];
                AddItemCallback(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());
                this.Close();
            }
        }

        private void masterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
