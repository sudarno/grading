using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Grading.Quality;
//using CrystalDecisions.CrystalReports.Engine;

namespace Grading
{
   
    public partial class frmReportbyDate : Form
    {
        public delegate void SetParameterValueDelegate(string date1, string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
       // private DataSet data = null;
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
       
        public frmReportbyDate()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strQuery = "SELECT date('" + date1.Value.ToString("yyyy-MM-dd") + "') date1,date('" + date2.Value.ToString("yyyy-MM-dd") + "') date2,line.NAME,buyer.BUYERNAME,style.STYLEID,style.QTYORDER,style.QTYCUTT,qccheck.QTYCHECK,qccheck.QTYPASS,(qccheck.QTYCHECK-qccheck.QTYPASS)QTYREPAIR" +
                    " FROM qccheck" +
                    " INNER JOIN line ON line.LINEID=qccheck.LINEID" +
                    " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID" +
                    " INNER JOIN style ON style.STYLEID=qccheck.STYLEID" +
                    " WHERE date(qccheck.DATE) BETWEEN date('" + date1.Value.ToString("yyyy-MM-dd") + "') AND date('" + date2.Value.ToString("yyyy-MM-dd") + "')";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            masterDataAdapter.Fill(dataPrint, "qcreportbydate");

            /*
            qcreportbydateCR objRpt = new qcreportbydateCR();

            objRpt.SetDataSource(dataPrint);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            */
            //DataSet data = new joborderCRUD().prJobOrder(txtCostingNo.Text);
            Application.DoEvents();
           //  dataPrint.WriteXml("C:\\MyGarmentReport\\qcreportbydate.xml", XmlWriteMode.WriteSchema);
            //dataPrint.WriteXmlSchema("C:\\MyGarmentReport\\qcreportbydate.xsd");
            // rptQCdate f = new rptQCdate();
           // f.Show();
        }

        private void frmReportbyDate_Load(object sender, EventArgs e)
        {

        }

        private void cmdPrint_Click_1(object sender, EventArgs e)
        {
            //this.SetParameterValueCallback= new SetParameterValueDelegate("date1","date2");
            qcreportbydateFrm f = new qcreportbydateFrm();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void cmdXsd_Click(object sender, EventArgs e)
        {
            DataSet dataPrint = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
            string strQuery = "SELECT date('" + date1.Value.ToString("yyyy-MM-dd") + "') date1,date('" + date2.Value.ToString("yyyy-MM-dd") + "') date2,line.NAME,buyer.BUYERNAME,style.STYLEID,style.QTYORDER,style.QTYCUTT,qccheck.QTYCHECK,qccheck.QTYPASS,(qccheck.QTYCHECK-qccheck.QTYPASS)QTYREPAIR" +
                    " FROM qccheck" +
                    " INNER JOIN line ON line.LINEID=qccheck.LINEID" +
                    " INNER JOIN buyer ON buyer.BUYERID=qccheck.BUYERID" +
                    " INNER JOIN style ON style.STYLEID=qccheck.STYLEID" +
                    " WHERE date(qccheck.DATE) BETWEEN date('" + date1.Value.ToString("yyyy-MM-dd") + "') AND date('" + date2.Value.ToString("yyyy-MM-dd") + "')";
            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
            //masterDataAdapter.SelectCommand.Parameters.AddWithValue("@", "");
            masterDataAdapter.Fill(dataPrint, "qcreportbydate");
            Application.DoEvents();
            dataPrint.WriteXmlSchema("C:\\MyGarmentReport\\qcreportbydate.xsd");

        }

        private void cmdSummary_Click(object sender, EventArgs e)
        {
            qcreportbysumFRM f = new qcreportbysumFRM();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();

        }

        private void cmdPerLine_Click(object sender, EventArgs e)
        {
            qcreportperline f = new qcreportperline();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();

        }

        private void cmdPerStyle_Click(object sender, EventArgs e)
        {
            qcreportperstyle f = new qcreportperstyle();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();

        }

        private void cmdSumPerStyle_Click(object sender, EventArgs e)
        {
            qcreportperstylesum f = new qcreportperstylesum();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }
    }
}
