using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Grading.Master
{
    public partial class frmRejectList : Form
    {
        private DataSet data = null;
        private BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlCommandBuilder sqlCommandBuilder = null;
        public frmRejectList()
        {
            InitializeComponent();
        }
        private void getData()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                // Create a DataSet.
                data = new DataSet();
                masterDataAdapter = new MySqlDataAdapter("select * from rejectlist", connection);
                masterDataAdapter.Fill(data, "rejectlist");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "rejectlist";

                //add kolom grid

                masterDataGridView.Columns.Clear();

                DataGridViewTextBoxColumn ColumnBuyerID = new DataGridViewTextBoxColumn();
                ColumnBuyerID.HeaderText = "CODE";
                ColumnBuyerID.Width = 80;
                ColumnBuyerID.DataPropertyName = "CODE";
                ColumnBuyerID.Name = "CODE";
                masterDataGridView.Columns.Add(ColumnBuyerID);


                DataGridViewTextBoxColumn ColumnBuyerName = new DataGridViewTextBoxColumn();
                ColumnBuyerName.HeaderText = "NAME";
                ColumnBuyerName.Width = 180;
                ColumnBuyerName.DataPropertyName = "NAME";
                ColumnBuyerName.Name = "NAME";
                masterDataGridView.Columns.Add(ColumnBuyerName);

                masterDataGridView.DataSource = masterBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void frmRejectList_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "rejectlist");
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

                foreach (DataGridViewRow item in this.masterDataGridView.SelectedRows)
                {
                    //masterDataGridView.Rows.RemoveAt(item.Index);
                    masterBindingSource.RemoveAt(item.Index);
                }

                masterBindingSource.EndEdit();
                masterDataAdapter.Update(data, "rejectlist");
                MessageBox.Show("the data has been deleted");

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
    }
}
