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
    public partial class ProductionFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1;
        public ProductionFrm()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1)
        {
            date1 = param1;
        }
        private void ProductionFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dsReject = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                //string strQuery = "SELECT * FROM sample WHERE date(srfpola) BETWEEN date(@DATE1) AND date(@DATE2) AND status LIKE @STATUS";
                string strQuery = "SELECT " +
                     "srfsetting.styleid styleid1,srfproduction.sizeid sizeid1,srfsetting.styleid,srfsetting.buyerid,status,srfproduction.sizeid " +
                    ",srfproduction.crffrom,srfproduction.datercvd,srfproduction.datesend " +
                    ",srfproduction.fabric " +
                    ",if(date(srfproduction.datercvd) < date(@tgl) AND date(srfproduction.datercvd) <> date('0000-00-00') , 1, 0) as rcvdprev " +
                    ",if(date(srfproduction.datesend) < date(@tgl) AND date(srfproduction.datesend) <> date('0000-00-00'), 1, 0) as finishprev " +
                    ",if(date(srfproduction.datercvd) = date(@tgl) AND date(srfproduction.datercvd) <> date('0000-00-00') , 1, 0) as rcvdtoday " +
                    ",if(date(srfproduction.datesend) = date(@tgl) AND date(srfproduction.datesend) <> date('0000-00-00'), 1, 0) as finishtoday " +
                    ",srfproduction.doneby,srfproduction.Remark " +
                    "FROM srfproduction " +
                    "INNER JOIN srfsetting on srfsetting.styleid=srfproduction.styleid " +
                    "WHERE (DATE(srfsetting.productionend)> DATE(@tgl) or ISNULL(srfsetting.productionend)) AND DATE(srfsetting.productionstart)<= DATE(@tgl) ";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@tgl", date1);
                masterDataAdapter.Fill(dsReject, "srfproductionxsd");

                ProductionCr objRpt = new ProductionCr();
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
