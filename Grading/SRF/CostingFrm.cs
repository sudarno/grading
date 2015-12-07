using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Grading.SRF
{
    public partial class CostingFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1;
        public CostingFrm()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1)
        {
            date1 = param1;
        }
        private void CostingFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dsReject = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                //string strQuery = "SELECT * FROM sample WHERE date(srfpola) BETWEEN date(@DATE1) AND date(@DATE2) AND status LIKE @STATUS";
                string strQuery = "SELECT " +
                "srfsetting.styleid styleid1,srfcosting.sizeid sizeid1,srfsetting.styleid,srfsetting.buyerid,status,srfcosting.sizeid " +
                ",srfcosting.crffrom,srfcosting.datercvd,srfcosting.datesend " +
                ",srfcosting.fabric " +
                ",if(date(srfcosting.datercvd) < date(@tgl) AND date(srfcosting.datercvd) <> date('0000-00-00') , 1, 0) as rcvdprev " +
                ",if(date(srfcosting.datesend) < date(@tgl) AND date(srfcosting.datesend) <> date('0000-00-00'), 1, 0) as finishprev " +
                ",if(date(srfcosting.datercvd) = date(@tgl) AND date(srfcosting.datercvd) <> date('0000-00-00') , 1, 0) as rcvdtoday " +
                ",if(date(srfcosting.datesend) = date(@tgl) AND date(srfcosting.datesend) <> date('0000-00-00'), 1, 0) as finishtoday " +
                ",srfcosting.doneby,srfcosting.Remark " +
                "FROM srfcosting " +
                "INNER JOIN srfsetting on srfsetting.styleid=srfcosting.styleid " +
                "WHERE (DATE(srfsetting.costingend)> DATE(@tgl) or ISNULL(srfsetting.costingend)) AND DATE(srfsetting.costingstart)<= DATE(@tgl) ";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@tgl", date1);
                masterDataAdapter.Fill(dsReject, "srfcostingxsd");

                CostingCr objRpt = new CostingCr();
                objRpt.SetDataSource(dsReject);
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
