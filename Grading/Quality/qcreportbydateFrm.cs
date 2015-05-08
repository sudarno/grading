using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;


namespace Grading.Quality
{
    public partial class qcreportbydateFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1, date2;

        public void SetParamValueCallbackFn(string param1,string param2 )
        {

            date1 = param1;
            date2 = param2;

        }
        public qcreportbydateFrm()
        {
            InitializeComponent();
        }

        private void qcreportbydateFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dataPrint = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                string strQuery = "SELECT qccheck.DATE,date('" + date1 + "') date1,date('" + date2 + "') date2,line.NAME,buyer.BUYERNAME,style.STYLEID,qcstyle.QTYORDER,qcstyle.QTYCUTT,qccheck.QTYCHECK,qccheck.QTYPASS,(qccheck.QTYCHECK-qccheck.QTYPASS)QTYREPAIR" +
                        " FROM qccheck" +
                        " INNER JOIN qcstyle ON qcstyle.STYLEID=qccheck.STYLEID  AND qcstyle.COLORID=qccheck.COLORID" +
                        " INNER JOIN line ON line.LINEID=qccheck.LINEID" +
                        " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID" +
                        " INNER JOIN style ON style.STYLEID=qccheck.STYLEID" +
                        " WHERE date(qccheck.DATE) BETWEEN date('" + date1 + "') AND date('" + date2 + "')";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.Fill(dataPrint, "qcreportbydate");

                qcreportbydateCR objRpt = new qcreportbydateCR();
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
