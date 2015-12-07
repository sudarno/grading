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
    
    public partial class rptCosting : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1, date2;
        public rptCosting()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1, string param2)
        {
            date1 = param1;
            date2 = param2;
        }
        private void rptCosting_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dsReject = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                string strAdapter = "SELECT date(@date1) date1,date(@date2) date2, " +
                        "styleid,buyername buyerid,status,sizeid, " +
                        "crffrom,datercvd,datesend " +
                        ",fabric " +
                        ",if(date(datercvd) < date(@date2), 1, 0) as rcvdprev " +
                        ",if(date(datesend) < date(@date2), 1, 0) as finishprev " +
                        ",if(date(datercvd) = date(@date2), 1, 0) as rcvdtoday " +
                        ",if(date(datesend) = date(@date2), 1, 0) as finishtoday " +
                        ",doneby,Remark " +
                        "FROM sfcosting " +
                        "INNER JOIN buyer ON buyer.BUYERID=sfcosting.buyerid " +
                        "WHERE isnull(datesend)  OR date(datercvd) BETWEEN date(@date1) AND date(@date2) ";

                masterDataAdapter = new MySqlDataAdapter(strAdapter, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date1", date1);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@date2", date2);
                masterDataAdapter.Fill(dsReject, "sfbookingxsd");

                rptCostingCr objRpt = new rptCostingCr();
                objRpt.SetDataSource(dsReject);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
