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
    public partial class sfCostingPrint : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string No;
        public sfCostingPrint()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1)
        {
            No = param1;
            
        }
        private void sfCostingPrint_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dsReject = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                //string strQuery = "SELECT * FROM sample WHERE date(srfpola) BETWEEN date(@DATE1) AND date(@DATE2) AND status LIKE @STATUS";
                string strAdapter = "SELECT * FROM sfcosting " +
                                 "INNER JOIN sfcostingdetail ON sfcosting.`no`=sfcostingdetail.`no` WHERE sfcosting.`no`=@no";
                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@no", No);
                masterDataAdapter.Fill(dsReject, "sfcostingboxxsd");

                // test
                MySqlDataAdapter SubDataAdapter;
                DataSet dsSub = new DataSet();
                string strAdapter1 = "SELECT * FROM sfcosting " +
                                "INNER JOIN sfcostingmatch ON sfcosting.`no`=sfcostingmatch.`no` WHERE sfcosting.`no`=@no";
                SubDataAdapter = new MySqlDataAdapter(strAdapter1, connection);
                SubDataAdapter.SelectCommand.Parameters.AddWithValue("@no", No);
                SubDataAdapter.Fill(dsSub, "sfcostingboxsubxsd");
                //sfCostingPrintCrSub objRpt1 = new sfCostingPrintCrSub();
                //end test

                sfCostingPrintCr objRpt = new sfCostingPrintCr();
                objRpt.SetDataSource(dsReject);
                objRpt.OpenSubreport("sfCostingPrintCrSub.rpt").SetDataSource(dsSub);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
