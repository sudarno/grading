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
    public partial class findBuyer : Form
    {
        public delegate void AddCategoryDelegate(string itemID, string itemDesc);
        public AddCategoryDelegate AddItemCallback;

        private DataSet data = null;

        private BindingSource masterBindingSource = new BindingSource();

        private MySqlDataAdapter masterDataAdapter = null;

        private MySqlCommandBuilder sqlCommandBuilder = null;
        public findBuyer()
        {
            InitializeComponent();
        }
        private void getData(string buyer, string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from buyer where BUYERID LIKE '%"+txtBuyerID+"%' AND BUYERNAME LIKE '%"+txtBuyerName+"'" , connection);
                masterDataAdapter.Fill(data, "style");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "style";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnstyleID = new DataGridViewTextBoxColumn();
                ColumnstyleID.HeaderText = "BUYERID";
                ColumnstyleID.Width = 80;
                ColumnstyleID.DataPropertyName = "BUYERID";
                ColumnstyleID.Name = "BUYERID";
                masterDataGridView.Columns.Add(ColumnstyleID);


                DataGridViewTextBoxColumn ColumnstyleName = new DataGridViewTextBoxColumn();
                ColumnstyleName.HeaderText = "BUYERNAME";
                ColumnstyleName.Width = 180;
                ColumnstyleName.DataPropertyName = "BUYERNAME";
                ColumnstyleName.Name = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnstyleName);

                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void getData()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from buyer", connection);
                masterDataAdapter.Fill(data, "style");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "style";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnstyleID = new DataGridViewTextBoxColumn();
                ColumnstyleID.HeaderText = "BUYERID";
                ColumnstyleID.Width = 80;
                ColumnstyleID.DataPropertyName = "BUYERID";
                ColumnstyleID.Name = "BUYERID";
                masterDataGridView.Columns.Add(ColumnstyleID);


                DataGridViewTextBoxColumn ColumnstyleName = new DataGridViewTextBoxColumn();
                ColumnstyleName.HeaderText = "BUYERNAME";
                ColumnstyleName.Width = 180;
                ColumnstyleName.DataPropertyName = "BUYERNAME";
                ColumnstyleName.Name = "BUYERNAME";
                masterDataGridView.Columns.Add(ColumnstyleName);

                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void findBuyer_Load(object sender, EventArgs e)
        {

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtBuyerID.Text, txtBuyerName.Text);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
