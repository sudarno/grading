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
    public partial class qrSewing : Form
    {
        public delegate void SetParameterValueDelegate(string date1, string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
        
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        public qrSewing()
        {
            InitializeComponent();
        }

        private void qrSewing_Load(object sender, EventArgs e)
        {

        }

        private void cmdPerLine_Click(object sender, EventArgs e)
        {
            qrSewingFrm f = new qrSewingFrm();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void cmdXsd_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            /*
            string strQuery = "SELECT date('" + date1.Value.ToString("yyyy-MM-dd") + "') date1,date('" + date2.Value.ToString("yyyy-MM-dd") + "') date2,line.NAME,buyer.BUYERNAME,style.STYLEID,style.QTYORDER,style.QTYCUTT,qccheck.QTYCHECK,qccheck.QTYPASS,(qccheck.QTYCHECK-qccheck.QTYPASS)QTYREPAIR" +
                    " FROM qccheck" +
                    " INNER JOIN line ON line.LINEID=qccheck.LINEID" +
                    " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID" +
                    " INNER JOIN style ON style.STYLEID=qccheck.STYLEID" +
                    " WHERE date(qccheck.DATE) BETWEEN date('" + date1.Value.ToString("yyyy-MM-dd") + "') AND date('" + date2.Value.ToString("yyyy-MM-dd") + "')";
             */
            string strQuery = "SELECT DATE,date1,date2,DT1.COLORID,DT1.COLORNAME,DT1.LINEID,DT1.NAME,DT1.BUYERID,DT1.BUYERNAME,DT1.STYLEID,DT1.STYLENAME,QTYORDER,QTYCUTT,QTYPASS,QTYCHECK,TotQtyPass,TotQtyCheck FROM " +
                "(SELECT qccheck.DATE,date(@DATE1) date1,date(@DATE2) date2,qccheck.COLORID, qccheck.LINEID,line.NAME,qccheck.BUYERID,buyer.BUYERNAME,style.STYLEID,style.STYLENAME,qcstyle.QTYORDER,qccheck.QTYCHECK,qccheck.QTYPASS " +
                ",(SELECT SUM(a.QTYPASS) from qccheck a where a.DATE <= qccheck.DATE ) TotQtyPass,(select SUM(a.QTYCHECK) from qccheck a where a.DATE <= qccheck.DATE ) TotQtyCheck "+
                " FROM qccheck "+
                " INNER JOIN qcstyle ON qcstyle.STYLEID=qccheck.STYLEID  AND qcstyle.COLORID=qccheck.COLORID "+
                " INNER JOIN line ON line.LINEID=qccheck.LINEID "+
                " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID "+
                " INNER JOIN style ON style.STYLEID=qccheck.STYLEID "+
                " INNER JOIN color ON color.COLORID=qccheck.COLORID "+
                " WHERE date(qccheck.DATE) BETWEEN date(@DATE1) AND date(@DATE2) " +
                " )DT1 "+
                " LEFT JOIN "+
                 "( "+
                "  SELECT LINEID,STYLEID,COLORID,BUYERID,SUM(QTYCUTT) QTYCUTT FROM qccutting "+
                " WHERE qccutting.DATE <= date(@DATE2) "+
                " GROUP BY LINEID,STYLEID,COLORID,BUYERID "+
                " ) DT2 "+
                " ON DT1.STYLEID=DT2.STYLEID AND DT1.LINEID=DT2.LINEID AND DT1.COLORID=DT2.COLORID ";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.Fill(dataPrint, "qrsewingday");
            Application.DoEvents();
            dataPrint.WriteXmlSchema("C:\\MyGarmentReport\\qrsewingday.xsd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);

            string strQuery = "SELECT DATE,date1,date2,DT1.LINEID,DT1.NAME,DT1.BUYERID,DT1.BUYERNAME,DT1.STYLEID,DT1.STYLENAME,DT1.COLORID,DT1.COLORNAME,QTYORDER,QTYCUTT,QTYPASS,QTYCHECK FROM " +
                "(SELECT qccheck.DATE,date(@DATE1) date1,date(@DATE2) date2,qccheck.COLORID,color.COLORNAME, qccheck.LINEID,line.NAME,qccheck.BUYERID,buyer.BUYERNAME,style.STYLEID,style.STYLENAME,qcstyle.QTYORDER,qccheck.QTYCHECK,qccheck.QTYPASS " +
                " FROM qccheck " +
                " INNER JOIN qcstyle ON qcstyle.STYLEID=qccheck.STYLEID  AND qcstyle.COLORID=qccheck.COLORID " +
                " INNER JOIN line ON line.LINEID=qccheck.LINEID " +
                " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID " +
                " INNER JOIN style ON style.STYLEID=qccheck.STYLEID " +
                " INNER JOIN color ON color.COLORID=qccheck.COLORID " +
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
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2.Value.ToString("yyyy-MM-dd"));
            masterDataAdapter.Fill(dataPrint, "qrsewingstyle");
            Application.DoEvents();
            dataPrint.WriteXmlSchema("C:\\MyGarmentReport\\qrsewingstyle.xsd");
        }

        private void cmdPerStyle_Click(object sender, EventArgs e)
        {
            qrSewingStyleFRM f = new qrSewingStyleFRM();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void cmdSumPerStyle_Click(object sender, EventArgs e)
        {
            qrSewingStyleSumFRM f = new qrSewingStyleSumFRM();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }
    }
}
