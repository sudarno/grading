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
    public partial class qrFinishingSumFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1, date2;
        public qrFinishingSumFrm()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1, string param2)
        {

            date1 = param1;
            date2 = param2;

        }
        private void qrFinishingSumFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dataPrint = new DataSet();
                DataSet dataSub = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                string strQuery = "SELECT DT1.DATE,date1,date2,DT1.COLORID,DT1.COLORNAME,DT1.BUYERID,DT1.BUYERNAME,DT1.STYLEID,DT1.STYLENAME,DT1.QTYORDER,DT1.QTYFINISH,DT7.QTYREPAIR,QTYCUTT,QTYSEWING FROM " +
                      " (SELECT qcfinishing.DATE,date(@DATE1) date1,date(@DATE2) date2,qcfinishing.COLORID,color.COLORNAME,qcfinishing.BUYERID,buyer.BUYERNAME,style.STYLEID,style.STYLENAME,qcstyle.QTYORDER,qcfinishing.QTYFINISH " +
                       " FROM qcfinishing " +
                       "INNER JOIN qcstyle ON qcstyle.STYLEID=qcfinishing.STYLEID  AND qcstyle.COLORID=qcfinishing.COLORID " +
                       "INNER JOIN buyer ON buyer.BUYERID=qcfinishing.BUYERID " +
                       "INNER JOIN style ON style.STYLEID=qcfinishing.STYLEID " +
                       "INNER JOIN color ON color.COLORID=qcfinishing.COLORID " +
                       "WHERE date(qcfinishing.DATE) BETWEEN date(@DATE1) AND date(@DATE2) " +
                       ") DT1 " +
                       "LEFT JOIN " +
                       "(SELECT DATE,STYLEID,COLORID,BUYERID,SUM(QTYREPAIR) QTYREPAIR FROM qcrepair " +
                       " WHERE qcrepair.DATE <= date(@DATE2) " +
                       " GROUP BY STYLEID,COLORID,BUYERID,DATE " +
                       " ) DT7 ON DT1.STYLEID=DT7.STYLEID AND DT1.COLORID=DT7.COLORID AND DT1.DATE=DT7.DATE " +
                       " LEFT JOIN " +
                       " (SELECT STYLEID,COLORID,BUYERID,SUM(QTYCUTT) QTYCUTT FROM qccutting " +
                       "WHERE qccutting.DATE <= date(@DATE2) " +
                       "GROUP BY STYLEID,COLORID,BUYERID)DT2 " +
                       "ON DT1.STYLEID=DT2.STYLEID AND  DT1.COLORID=DT2.COLORID " +
                       " LEFT JOIN " +
                       " (SELECT STYLEID,COLORID,BUYERID,SUM(QTYCHECK+QTYPASS) QTYSEWING FROM qccheck " +
                       " WHERE qccheck.DATE <= date(@DATE2) " +
                       " GROUP BY STYLEID,COLORID,BUYERID) DT3 " +
                       " ON DT1.STYLEID=DT3.STYLEID AND  DT1.COLORID=DT3.COLORID ";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2);
                masterDataAdapter.Fill(dataPrint, "qrfinishingtbl");
                //sub report
                string strQuerySub = "SELECT BUYERID,STYLEID,COLORID,LINEID,sum(QTYREPAIR) QTYREPAIR FROM qcrepair " +
                "WHERE  DATE BETWEEN date(@DATE1) AND date(@DATE2) " +
                "GROUP BY BUYERID,STYLEID,COLORID,LINEID";
                MySqlDataAdapter DataAdapterSub = new MySqlDataAdapter(strQuerySub, connection);
                DataAdapterSub.SelectCommand.Parameters.AddWithValue("@DATE1", date1);
                DataAdapterSub.SelectCommand.Parameters.AddWithValue("@DATE2", date2);
                DataAdapterSub.Fill(dataSub, "qrrepairsumtbl");

                qrFinishingSumCr objRpt = new qrFinishingSumCr();
                objRpt.SetDataSource(dataPrint);
                objRpt.Subreports[0].SetDataSource(dataSub);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
                //untuk sub


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
