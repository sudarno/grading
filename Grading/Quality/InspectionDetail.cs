using System;
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
    public partial class InspectionDetail : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1, date2;
        public InspectionDetail()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1, string param2)
        {

            date1 = param1;
            date2 = param2;

        }
        private void InspectionDetail_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet qcreportinspectiondetail = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                /*
                string strQuery = "SELECT date(@DATE1) date1,date(@DATE2) date2,buyer.BUYERNAME,style.STYLENAME,qcinspection.POCUSTOMER,qcstyle.QTYORDER,qcinspection.QTYCUTT,qcinspection.QTYSHIP,qcinspection.CATEGORYID CATEGORY, color.COLORNAME,qcinspection.DATE,qcinspection.INSPECTOR,qcinspection.RESULT,qcinspection.REMARKS, " +
               "qcinspection.QTY,qcinspectiondetail.MAJOR,qcinspectiondetail.MINOR,qcinspectiondetail.NAME,qcinspectiondetail.ID " +
               "FROM qcinspection " +
               "INNER JOIN qcstyle ON qcstyle.STYLEID=qcinspection.STYLEID AND qcstyle.COLORID=qcinspection.COLORID " +
               "INNER JOIN buyer ON qcinspection.BUYERID=buyer.BUYERID " +
               "INNER JOIN style ON style.STYLEID=qcinspection.STYLEID " +
               "INNER JOIN color ON color.COLORID=qcinspection.COLORID " +
               "INNER JOIN qcinspectiondetail ON qcinspectiondetail.STYLEID =qcinspection.STYLEID AND qcinspectiondetail.COLORID=qcinspection.COLORID" +
               " WHERE DATE BETWEEN @DATE1 AND @DATE2 ";
                 */
                string strQuery = "SELECT date(@DATE1) date1,date(@DATE2) date2,qcinspection.ID1,buyer.BUYERNAME,style.STYLENAME,qcinspection.POCUSTOMER,qcstyle.QTYORDER,qcinspection.QTYCUTT,qcinspection.QTYSHIP,qcinspection.CATEGORYID CATEGORY, color.COLORNAME,qcinspection.DATE,qcinspection.INSPECTOR,qcinspection.RESULT,qcinspection.REMARKS, qcinspection.QTY,qcinspectiondetail.MAJOR,qcinspectiondetail.MINOR,qcinspectiondetail.NAME,qcinspectiondetail.ID FROM qcinspection INNER JOIN qcstyle ON qcstyle.STYLEID=qcinspection.STYLEID AND qcstyle.COLORID=qcinspection.COLORID INNER JOIN buyer ON qcinspection.BUYERID=buyer.BUYERID INNER JOIN style ON style.STYLEID=qcinspection.STYLEID INNER JOIN color ON color.COLORID=qcinspection.COLORID INNER JOIN qcinspectiondetail ON qcinspectiondetail.ID1 =qcinspection.ID1  " +
                        "WHERE DATE BETWEEN @DATE1 AND @DATE2";

                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2);

                masterDataAdapter.Fill(qcreportinspectiondetail, "qcinspectiondetail");

                InspectionDetailCr objRpt = new InspectionDetailCr();
                objRpt.SetDataSource(qcreportinspectiondetail);
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
