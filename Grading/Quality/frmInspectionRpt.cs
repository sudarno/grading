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
    public partial class frmInspectionRpt : Form
    {
        public delegate void SetParameterValueDelegate(string date1, string date2);
        public SetParameterValueDelegate SetParameterValueCallback;
        // private DataSet data = null;
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
       

        public frmInspectionRpt()
        {
            InitializeComponent();
        }

        private void cmdXsd_Click(object sender, EventArgs e)
        {
            DataSet qcreportinspectiondetail = new DataSet();
            MySqlConnection connection = new MySqlConnection(Global.strCon);
/*
            string strQuery = "SELECT date('" + date1.Value.ToString("yyyy-MM-dd") + "') date1,date('" + date2.Value.ToString("yyyy-MM-dd") + "') date2,buyer.BUYERNAME,style.STYLENAME,qcstyle.POCUSTOMER,qcstyle.QTYORDER,qcstyle.QTYCUTT,qcstyle.QTYSHIP,qcstyle.CATEGORY , color.COLORNAME,qcinspection.DATE,qcinspection.INSPECTOR,qcinspection.RESULT,qcinspection.REMARKS " +
                "FROM qcinspection "+
                "INNER JOIN qcstyle ON qcstyle.STYLEID=qcinspection.STYLEID AND qcstyle.COLORID=qcinspection.COLORID "+
                "INNER JOIN buyer ON qcinspection.BUYERID=buyer.BUYERID "+
                "INNER JOIN style ON style.STYLEID=qcinspection.STYLEID "+
                "INNER JOIN color ON color.COLORID=qcinspection.COLORID";
 */
            string strQuery = "SELECT date('" + date1.Value.ToString("yyyy-MM-dd") + "') date1,date('" + date2.Value.ToString("yyyy-MM-dd") + "') date2,buyer.BUYERNAME,style.STYLENAME,qcstyle.POCUSTOMER,qcstyle.QTYORDER,qcstyle.QTYCUTT,qcstyle.QTYSHIP,qcstyle.CATEGORY , color.COLORNAME,qcinspection.DATE,qcinspection.INSPECTOR,qcinspection.RESULT,qcinspection.REMARKS, " +
                "qcinspection.QTY,qcinspectiondetail.MAJOR,qcinspectiondetail.MINOR,qcinspectiondetail.NAME,qcinspectiondetail.ID " +
                "FROM qcinspection " +
                "INNER JOIN qcstyle ON qcstyle.STYLEID=qcinspection.STYLEID AND qcstyle.COLORID=qcinspection.COLORID " +
                "INNER JOIN buyer ON qcinspection.BUYERID=buyer.BUYERID " +
                "INNER JOIN style ON style.STYLEID=qcinspection.STYLEID " +
                "INNER JOIN color ON color.COLORID=qcinspection.COLORID "+
                "INNER JOIN qcinspectiondetail ON qcinspectiondetail.STYLEID =qcinspection.STYLEID AND qcinspectiondetail.COLORID=qcinspection.COLORID";

            masterDataAdapter = new MySqlDataAdapter(strQuery, connection);

            masterDataAdapter.Fill(qcreportinspectiondetail, "qcreportinspectiondetail");
            Application.DoEvents();
            qcreportinspectiondetail.WriteXmlSchema("C:\\MyGarmentReport\\qcreportinspectiondetail.xsd");
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            qcreportinspection f = new qcreportinspection();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();
        }

        private void cmdPrintDetail_Click(object sender, EventArgs e)
        {
            InspectionRpt f = new InspectionRpt();
            this.SetParameterValueCallback += new SetParameterValueDelegate(f.SetParamValueCallbackFn);
            SetParameterValueCallback(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
            f.Show();

        }

   
    }
}
