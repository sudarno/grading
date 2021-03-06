﻿using System;
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
    public partial class findStyleColor : Form
    {
        public delegate void AddCategoryDelegate(string styleID, string styleDesc,string colorID,string colorDesc,string buyerID,string buyerDesc);
        public AddCategoryDelegate AddItemCallback;

        private DataSet data = null;
        private BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        private MySqlCommandBuilder sqlCommandBuilder = null;

        public findStyleColor()
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
                /*
                string strQueryBuyer = "SELECT buyer.BUYERNAME,qcstyle.* FROM qcstyle " +
                    "INNER JOIN buyer ON buyer.BUYERID=qcstyle.BUYERID where qcstyle.STYLEID LIKE '%" + txtStyleID.Text + "%' AND BUYERNAME LIKE '%" + txtBuyerName.Text + "%'";
                 */
                string strQueryBuyer = "SELECT  style.STYLEID,style.STYLENAME,color.COLORID,color.COLORNAME,buyer.BUYERID,buyer.BUYERNAME " +
                    "FROM qcstyle " +
                    "INNER JOIN buyer ON buyer.BUYERID=qcstyle.BUYERID " +
                    "INNER JOIN color ON color.COLORID=qcstyle.COLORID " +
                    "INNER JOIN style ON style.STYLEID=qcstyle.STYLEID " +
                    "WHERE qcstyle.STYLEID LIKE '%" + txtStyleID.Text + "%' AND BUYERNAME LIKE '%" + txtBuyerName.Text + "%'";

                masterDataAdapter = new MySqlDataAdapter(strQueryBuyer, connection);
                masterDataAdapter.Fill(data, "style");
                sqlCommandBuilder = new MySqlCommandBuilder(masterDataAdapter);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "style";

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
        private void findStyleColor_Load(object sender, EventArgs e)
        {
            getData(txtStyleID.Text, txtBuyerName.Text);
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            getData(txtStyleID.Text.ToString(), txtBuyerName.Text.ToString());
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void masterDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void masterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void masterDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.masterDataGridView.Rows[e.RowIndex];
                AddItemCallback(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
                this.Close();
            }
        }
    }
}
