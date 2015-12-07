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
    public partial class BookingFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1;
        public BookingFrm()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1)
        {
            date1 = param1;
        }
        private void BookingFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dsReject = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                //string strQuery = "SELECT * FROM sample WHERE date(srfpola) BETWEEN date(@DATE1) AND date(@DATE2) AND status LIKE @STATUS";
                string strQuery = "SELECT " +
                "srfsetting.styleid styleid1,srfbooking.sizeid sizeid1,srfsetting.styleid,srfsetting.buyerid,status,srfbooking.sizeid " +
                ",srfbooking.crffrom,srfbooking.datercvd,srfbooking.datesend " +
                ",srfbooking.fabric " +
                ",if(date(srfbooking.datercvd) < date(@tgl) AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdprev " +
                ",if(date(srfbooking.datesend) < date(@tgl) AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishprev " +
                ",if(date(srfbooking.datercvd) = date(@tgl) AND date(srfbooking.datercvd) <> date('0000-00-00') , 1, 0) as rcvdtoday " +
                ",if(date(srfbooking.datesend) = date(@tgl) AND date(srfbooking.datesend) <> date('0000-00-00'), 1, 0) as finishtoday " +
                ",srfbooking.doneby,srfbooking.Remark " +
                "FROM srfbooking " +
                "INNER JOIN srfsetting on srfsetting.styleid=srfbooking.styleid " +
                "WHERE (DATE(srfsetting.bookingend)> DATE(@tgl) or ISNULL(srfsetting.bookingend)) AND DATE(srfsetting.bookingstart)<= DATE(@tgl) ";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@tgl", date1);
                masterDataAdapter.Fill(dsReject, "srfbookingxsd");

                BookingCr objRpt = new BookingCr();
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
