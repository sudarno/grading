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
    public partial class rejectRptFrm : Form
    {
        BindingSource masterBindingSource = new BindingSource();
        private MySqlDataAdapter masterDataAdapter = null;
        string date1, date2;

        public rejectRptFrm()
        {
            InitializeComponent();
        }
        public void SetParamValueCallbackFn(string param1, string param2)
        {

            date1 = param1;
            date2 = param2;


        }
        private void rejectRptFrm_Load(object sender, EventArgs e)
        {
            try
            {

                DataSet dsReject = new DataSet();
                MySqlConnection connection = new MySqlConnection(Global.strCon);
                string strQuery = "SELECT @DATE1 date1,@DATE2 date2, " +
                               "reject.DATE ,buyer.BUYERNAME,style.STYLENAME,color.COLORNAME,rejectlist.CODE,rejectlist.NAME, qcstyle.IMAGE, " +
                               "MAX(case when sizeorder.ORDERNO=1 then rejectdetail.SIZEID end ) SIZE1, " +
                               "MAX(case when sizeorder.ORDERNO=2 then rejectdetail.SIZEID end ) SIZE2, " +
                               "MAX(case when sizeorder.ORDERNO=3 then rejectdetail.SIZEID end ) SIZE3, " +
                               "MAX(case when sizeorder.ORDERNO=4 then rejectdetail.SIZEID end ) SIZE4, " +
                               "MAX(case when sizeorder.ORDERNO=5 then rejectdetail.SIZEID end ) SIZE5, " +
                               "MAX(case when sizeorder.ORDERNO=6 then rejectdetail.SIZEID end ) SIZE6, " +
                               "MAX(case when sizeorder.ORDERNO=7 then rejectdetail.SIZEID end ) SIZE7, " +
                               "MAX(case when sizeorder.ORDERNO=8 then rejectdetail.SIZEID end ) SIZE8, " +
                               "MAX(case when sizeorder.ORDERNO=9 then rejectdetail.SIZEID end ) SIZE9, " +
                               "MAX(case when sizeorder.ORDERNO=10 then rejectdetail.SIZEID end ) SIZE10, " +
                               "MAX(case when sizeorder.ORDERNO=11 then rejectdetail.SIZEID end ) SIZE11, " +
                               "MAX(case when sizeorder.ORDERNO=12 then rejectdetail.SIZEID end ) SIZE12, " +
                               "MAX(case when sizeorder.ORDERNO=1 then rejectdetail.QTY end ) QTY1, " +
                               "MAX(case when sizeorder.ORDERNO=2 then rejectdetail.QTY end ) QTY2, " +
                               "MAX(case when sizeorder.ORDERNO=3 then rejectdetail.QTY end ) QTY3, " +
                               "MAX(case when sizeorder.ORDERNO=4 then rejectdetail.QTY end ) QTY4, " +
                               "MAX(case when sizeorder.ORDERNO=5 then rejectdetail.QTY end ) QTY5, " +
                               "MAX(case when sizeorder.ORDERNO=6 then rejectdetail.QTY end ) QTY6, " +
                               "MAX(case when sizeorder.ORDERNO=7 then rejectdetail.QTY end ) QTY7, " +
                               "MAX(case when sizeorder.ORDERNO=8 then rejectdetail.QTY end ) QTY8, " +
                               "MAX(case when sizeorder.ORDERNO=9 then rejectdetail.QTY end ) QTY9, " +
                               "MAX(case when sizeorder.ORDERNO=10 then rejectdetail.QTY end ) QTY10, " +
                               "MAX(case when sizeorder.ORDERNO=11 then rejectdetail.QTY end ) QTY11, " +
                               "MAX(case when sizeorder.ORDERNO=12 then rejectdetail.QTY end ) QTY12 " +
                               "FROM reject " +
                               "inner join rejectdetail on reject.STYLEID=rejectdetail.STYLEID AND reject.COLORID=rejectdetail.COLORID " +
                               "inner join style on style.STYLEID=reject.STYLEID " +
                               "inner join color on color.COLORID=reject.COLORID " +
                               "inner join rejectlist on rejectlist.CODE =rejectdetail.CODE " +
                               "inner join sizeorder on sizeorder.STYLEID=rejectdetail.STYLEID AND sizeorder.SIZEID=rejectdetail.SIZEID " +
                               "inner join qcstyle on qcstyle.STYLEID=reject.STYLEID AND qcstyle.COLORID=reject.COLORID " +
                                "inner join buyer on buyer.BUYERID=reject.BUYERID " +
                               " WHERE reject.DATE BETWEEN @DATE1 AND @DATE2 " +
                               "GROUP BY reject.DATE,style.STYLENAME,color.COLORNAME,rejectlist.CODE";
                masterDataAdapter = new MySqlDataAdapter(strQuery, connection);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE1", date1);
                masterDataAdapter.SelectCommand.Parameters.AddWithValue("@DATE2", date2);

                masterDataAdapter.Fill(dsReject, "rejectxsd");

                rejectCr objRpt = new rejectCr();
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
