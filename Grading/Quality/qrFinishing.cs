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
    public partial class qrFinishing : Form
    {
        public delegate void SetParameterValueDelegate(string date1, string date2);
        public SetParameterValueDelegate SetParameterValueCallback;

        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        public qrFinishing()
        {
            InitializeComponent();
        }

        private void cmdXsd_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet("qrfinishingds");
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            /*
            string strQuery = "SELECT DT1.DATE,date1,date2,DT1.LINEID,DT1.NAME,DT1.COLORID,DT1.COLORNAME,DT1.BUYERID,DT1.BUYERNAME,DT1.STYLEID,DT1.STYLENAME,DT1.QTYORDER,DT1.QTYFINISH,DT1.QTYREPAIR,QTYCUTT,QTYSEWING FROM " +
                "(SELECT qcrepair.DATE,date(@DATE1) date1,date(@DATE2) date2,qcrepair.LINEID,line.NAME,qcrepair.COLORID,color.COLORNAME,qcrepair.BUYERID,buyer.BUYERNAME,style.STYLEID,style.STYLENAME,qcstyle.QTYORDER,qcfinishing.QTYFINISH,qcrepair.QTYREPAIR " +
                "FROM qcrepair "+
                "INNER JOIN qcstyle ON qcstyle.STYLEID=qcrepair.STYLEID  AND qcstyle.COLORID=qcrepair.COLORID "+
                "INNER JOIN line ON line.LINEID=qcrepair.LINEID "+
                "INNER JOIN buyer ON buyer.BUYERID=qcrepair.BUYERID "+
                "INNER JOIN style ON style.STYLEID=qcrepair.STYLEID "+
                "INNER JOIN color ON color.COLORID=qcrepair.COLORID "+
                "LEFT JOIN qcfinishing ON qcfinishing.STYLEID=qcrepair.STYLEID AND qcfinishing.COLORID=qcrepair.COLORID "+
                "WHERE date(qcrepair.DATE) BETWEEN date(@DATE1) AND date(@DATE2)) DT1 " +
                "LEFT JOIN "+
                " (SELECT STYLEID,COLORID,BUYERID,LINEID,SUM(QTYCUTT) QTYCUTT FROM qccutting "+
                "WHERE qccutting.DATE <= date(@DATE2) " +
                "GROUP BY STYLEID,COLORID,BUYERID,LINEID)DT2 "+
                "ON DT1.STYLEID=DT2.STYLEID AND  DT1.COLORID=DT2.COLORID AND DT1.LINEID=DT2.LINEID "+
                " LEFT JOIN "+
                "(SELECT STYLEID,COLORID,BUYERID,LINEID,SUM(QTYCHECK+QTYPASS) QTYSEWING FROM qccheck "+
                " WHERE qccheck.DATE <= date(@DATE2) " +
                " GROUP BY STYLEID,COLORID,BUYERID,LINEID) DT3 "+
                " ON DT1.STYLEID=DT3.STYLEID AND  DT1.COLORID=DT3.COLORID AND DT1.LINEID=DT3.LINEID ";
             */
            string strQuery = "SELECT DT1.DATE,date1,date2,DT1.COLORID,DT1.COLORNAME,DT1.BUYERID,DT1.BUYERNAME,DT1.STYLEID,DT1.STYLENAME,DT1.QTYORDER,DT1.QTYFINISH,DT7.QTYREPAIR,QTYCUTT,QTYSEWING FROM " +
                       " (SELECT qcfinishing.DATE,date(@DATE1) date1,date(@DATE2) date2,qcfinishing.COLORID,color.COLORNAME,qcfinishing.BUYERID,buyer.BUYERNAME,style.STYLEID,style.STYLENAME,qcstyle.QTYORDER,qcfinishing.QTYFINISH " +
                        " FROM qcfinishing "+
                        "INNER JOIN qcstyle ON qcstyle.STYLEID=qcfinishing.STYLEID  AND qcstyle.COLORID=qcfinishing.COLORID "+
                        "INNER JOIN buyer ON buyer.BUYERID=qcfinishing.BUYERID "+
                        "INNER JOIN style ON style.STYLEID=qcfinishing.STYLEID "+
                        "INNER JOIN color ON color.COLORID=qcfinishing.COLORID "+
                        "WHERE date(qcfinishing.DATE) BETWEEN date(@DATE1) AND date(@DATE2) " +
                        ") DT1 "+
                        "LEFT JOIN "+
                        "(SELECT DATE,STYLEID,COLORID,BUYERID,SUM(QTYREPAIR) QTYREPAIR FROM qcrepair " +
                        " WHERE qcrepair.DATE <= date(@DATE2) " +
                        " GROUP BY STYLEID,COLORID,BUYERID,DATE " +
                        " ) DT7 ON DT1.STYLEID=DT7.STYLEID AND DT1.COLORID=DT7.COLORID AND DT1.DATE=DT7.DATE " +
                        " LEFT JOIN "+
                        " (SELECT STYLEID,COLORID,BUYERID,SUM(QTYCUTT) QTYCUTT FROM qccutting "+
                        "WHERE qccutting.DATE <= date(@DATE2) " +
                        "GROUP BY STYLEID,COLORID,BUYERID)DT2 "+
                        "ON DT1.STYLEID=DT2.STYLEID AND  DT1.COLORID=DT2.COLORID "+
                        " LEFT JOIN "+
                        " (SELECT STYLEID,COLORID,BUYERID,SUM(QTYCHECK+QTYPASS) QTYSEWING FROM qccheck "+
                        " WHERE qccheck.DATE <= date(@DATE2) " +
                        " GROUP BY STYLEID,COLORID,BUYERID) DT3 "+
                        " ON DT1.STYLEID=DT3.STYLEID AND  DT1.COLORID=DT3.COLORID ";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.Fill(dataPrint, "qrfinishingtbl");
            Application.DoEvents();
            dataPrint.WriteXmlSchema("C:\\MyGarmentReport\\qrfinishing.xsd");

        }

        private void cmdPerStyle_Click(object sender, EventArgs e)
        {
            qrFinishingFrm f = new qrFinishingFrm();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void cmdXSDsubRepair_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdSumPerStyle_Click(object sender, EventArgs e)
        {
            qrFinishingSumFrm f = new qrFinishingSumFrm();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet("qrrepairds");
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strQuery = "SELECT DATE,BUYERID,STYLEID,COLORID,LINEID,QTYREPAIR FROM qcrepair "+
                "WHERE DATE BETWEEN date(@DATE1) AND date(@DATE2)";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.Fill(dataPrint, "qrrepairtbl");
            Application.DoEvents();
            dataPrint.WriteXmlSchema("C:\\MyGarmentReport\\qrrepairdetail.xsd");
        }

        private void cmdSum_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet("qrrepairsumds");
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strQuery = "SELECT BUYERID,STYLEID,COLORID,LINEID,sum(QTYREPAIR) QTYREPAIR FROM qcrepair "+
                "WHERE  DATE BETWEEN date(@DATE1) AND date(@DATE2) " +
                "GROUP BY BUYERID,STYLEID,COLORID,LINEID";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.Fill(dataPrint, "qrrepairsumtbl");
            Application.DoEvents();
            dataPrint.WriteXmlSchema("C:\\MyGarmentReport\\qrrepairsum.xsd");
        }

      
    }
}
