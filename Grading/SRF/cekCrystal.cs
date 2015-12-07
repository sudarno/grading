using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
namespace Grading.SRF
{
    public partial class cekCrystal : Form
    {
        public cekCrystal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            System.DateTime startTime, endTime;
            System.TimeSpan diffTime;
            if (sampleCr1 != null)
            {
                sampleCr1.Close();
                sampleCr1.Dispose();
                sampleCr1 = null;
                }
            // reseting the display text back to zeros
            this.textBox_Start.Text = "0";
            this.textBox_End.Text = "0";
            this.textBox_Diff.Text = "0";
            // instantiate a new ReportDocument object
            ReportDocument crReport = new ReportDocument();
            // mark the time before we Load the report from disk
            startTime = System.DateTime.Now;
            this.textBox_Start.Text = startTime.TimeOfDay.ToString();
        
            if (this.textBox_Filename.Text.Length<1)
            return;
            crReport.Load(@"C:\MyGarmentReport\test.rpt");

            // mark the time after the report was successfully loaded
            endTime = System.DateTime.Now;
            this.textBox_End.Text = endTime.TimeOfDay.ToString();
                // calculate the time difference, and display the time in TotalMilliseconds
            diffTime = endTime.Subtract(startTime);
            this.textBox_Diff.Text = diffTime.TotalMilliseconds.ToString(); 
        }

        private void cekCrystal_Load(object sender, EventArgs e)
        {

           // this.reportViewer1.RefreshReport();
        }
    }
}
