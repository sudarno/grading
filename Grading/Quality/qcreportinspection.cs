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
    public partial class qcreportinspection : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1, date2;
        public qcreportinspection()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1, string param2)
        {

            date1 = param1;
            date2 = param2;

        }
        private void qcreportinspection_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dataPrint = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                string strQuery = "SELECT date('" + date1 + "') date1,date('" + date2 + "') date2,buyer.BUYERNAME,style.STYLENAME,qcinspection.POCUSTOMER,qcstyle.QTYORDER,qcinspection.QTYCUTT,qcinspection.QTYSHIP,qcinspection.CATEGORYID CATEGORY, color.COLORNAME,qcinspection.DATE,qcinspection.INSPECTOR,qcinspection.RESULT,qcinspection.REMARKS " +
                        "FROM qcinspection " +
                        "INNER JOIN qcstyle ON qcstyle.STYLEID=qcinspection.STYLEID AND qcstyle.COLORID=qcinspection.COLORID " +
                        "INNER JOIN buyer ON qcinspection.BUYERID=buyer.BUYERID " +
                        "INNER JOIN style ON style.STYLEID=qcinspection.STYLEID " +
                        "INNER JOIN color ON color.COLORID=qcinspection.COLORID " +
                        " WHERE date(qcinspection.DATE) BETWEEN date('" + date1 + "') AND date('" + date2 + "')";

                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.Fill(dataPrint, "qcreportinspection");

                qcreportinspectionCR objRpt = new qcreportinspectionCR();
                objRpt.SetDataSource(dataPrint);
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
