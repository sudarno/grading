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
    public partial class PatternFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1;

        public PatternFrm()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1)
        {
            date1 = param1;
        }
        private void PatternFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dsReject = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                //string strQuery = "SELECT * FROM sample WHERE date(srfpola) BETWEEN date(@DATE1) AND date(@DATE2) AND status LIKE @STATUS";
                string strQuery = "SELECT " +
                    "srfsetting.styleid styleid1,srfpattern.sizeid sizeid1,srfsetting.styleid,srfsetting.buyerid,status,srfpattern.sizeid " +
                    ",srfpattern.crffrom,srfpattern.datercvd,srfpattern.datesend " +
                    ",srfpattern.fabric " +
                     ",if(date(srfpattern.datercvd) < date(@tgl) AND date(srfpattern.datercvd) <> date('0000-00-00') , 1, 0) as rcvdprev " +
                     ",if(date(srfpattern.datesend) < date(@tgl) AND date(srfpattern.datesend) <> date('0000-00-00'), 1, 0) as finishprev " +
                     ",if(date(srfpattern.datercvd) = date(@tgl) AND date(srfpattern.datercvd) <> date('0000-00-00') , 1, 0) as rcvdtoday " +
                    ",if(date(srfpattern.datesend) = date(@tgl) AND date(srfpattern.datesend) <> date('0000-00-00'), 1, 0) as finishtoday " +
                    ",srfpattern.doneby,srfpattern.Remark " +
                    "FROM srfpattern " +
                    "INNER JOIN srfsetting on srfsetting.styleid=srfpattern.styleid " +
                    "WHERE (DATE(srfsetting.patternend)> DATE(@tgl) or ISNULL(srfsetting.patternend)) AND DATE(srfsetting.patternstart)<= DATE(@tgl) ";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@tgl", date1);
                masterDataAdapter.Fill(dsReject, "srfpatternxsd");

                PatternCr objRpt = new PatternCr();
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
