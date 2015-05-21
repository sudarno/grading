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
    public partial class qrSewingFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1, date2;

        public qrSewingFrm()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1, string param2)
        {

            date1 = param1;
            date2 = param2;

        }
        private void qrSewingFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dataPrint = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                /*
                string strQuery = "SELECT qccheck.DATE,date('" + date1 + "') date1,date('" + date2 + "') date2,line.NAME,buyer.BUYERNAME,style.STYLEID,qcstyle.QTYORDER,qcstyle.QTYCUTT,qccheck.QTYCHECK,qccheck.QTYPASS,(qccheck.QTYCHECK-qccheck.QTYPASS)QTYREPAIR" +
                        " FROM qccheck" +
                        " INNER JOIN qcstyle ON qcstyle.STYLEID=qccheck.STYLEID  AND qcstyle.COLORID=qccheck.COLORID" +
                        " INNER JOIN line ON line.LINEID=qccheck.LINEID" +
                        " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID" +
                        " INNER JOIN style ON style.STYLEID=qccheck.STYLEID" +
                        " WHERE date(qccheck.DATE) BETWEEN date('" + date1 + "') AND date('" + date2 + "')";
                */
                string strQuery = "SELECT DATE,date1,date2,DT1.COLORID,DT1.LINEID,DT1.NAME,DT1.BUYERID,DT1.BUYERNAME,DT1.STYLEID,DT1.STYLENAME,QTYORDER,QTYCUTT,QTYPASS,QTYCHECK,TotQtyPass,TotQtyCheck FROM " +
               "(SELECT qccheck.DATE,date(@DATE1) date1,date(@DATE2) date2,qccheck.COLORID, qccheck.LINEID,line.NAME,qccheck.BUYERID,buyer.BUYERNAME,style.STYLEID,style.STYLENAME,qcstyle.QTYORDER,qccheck.QTYCHECK,qccheck.QTYPASS " +
               ",(SELECT SUM(a.QTYPASS) from qccheck a where a.DATE <= qccheck.DATE ) TotQtyPass,(select SUM(a.QTYCHECK) from qccheck a where a.DATE <= qccheck.DATE ) TotQtyCheck " +
               " FROM qccheck " +
               " INNER JOIN qcstyle ON qcstyle.STYLEID=qccheck.STYLEID  AND qcstyle.COLORID=qccheck.COLORID " +
               " INNER JOIN line ON line.LINEID=qccheck.LINEID " +
               " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID " +
               " INNER JOIN style ON style.STYLEID=qccheck.STYLEID " +
               " WHERE date(qccheck.DATE) BETWEEN date(@DATE1) AND date(@DATE2) " +
               " )DT1 " +
               " LEFT JOIN " +
                "( " +
               "  SELECT LINEID,STYLEID,COLORID,BUYERID,SUM(QTYCUTT) QTYCUTT FROM qccutting " +
               " WHERE qccutting.DATE <= date(@DATE2) " +
               " GROUP BY LINEID,STYLEID,COLORID,BUYERID " +
               " ) DT2 " +
               " ON DT1.STYLEID=DT2.STYLEID AND DT1.LINEID=DT2.LINEID AND DT1.COLORID=DT2.COLORID ";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2);

                masterDataAdapter.Fill(dataPrint, "qrsewingday");
                qrSewingCR objRpt = new qrSewingCR();
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
