using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Grading.Quality;
using Grading.Master;
using Grading.Measurement;
using Grading.SRF;
using Grading.Sample;

namespace Grading
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuyer f = new frmBuyer();
            f.MdiParent = this;
            f.Show();
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStyle f = new frmStyle();
            f.MdiParent = this;
            f.Show();
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSize f = new frmSize();
            f.MdiParent = this;
            f.Show();

        }

        private void initialSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetting f = new frmSetting();
            f.MdiParent = this;
            f.Show();
        }

        private void stylePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void measurementChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrading f = new frmGrading();
            f.MdiParent = this;
            f.Show();
        }

        private void measurementToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmMeasurement f = new frmMeasurement();
            f.MdiParent = this;
            f.Show();
        }

        private void settingPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void measurementGradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradingSet f = new frmGradingSet();
            f.MdiParent = this;
            f.Show();
        }

        private void crystal()
        {
            test1.Refresh();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            string pathString = @"C:\MyGarmentReport";
            crystal();
            // cek folder
            if (!System.IO.File.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }
        }

        private void sizeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettingProp f = new frmSettingProp();
            f.MdiParent = this;
            f.Show();
        }

        private void measurementStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMeasurementStyle f = new frmMeasurementStyle();
            f.MdiParent = this;
            f.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest f = new frmTest();
            f.MdiParent = this;
            f.Show();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLine f = new frmLine();
            f.MdiParent = this;
            f.Show();

        }

        private void inputQCCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQCCheck f = new frmQCCheck();
            f.MdiParent = this;
            f.Show();

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportbyDate f = new frmReportbyDate();
            f.MdiParent = this;
            f.Show();
            
        }

        private void settingQtyStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettingStyleQC f = new frmSettingStyleQC();
            f.MdiParent = this;
            f.Show();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
            frmColor f = new frmColor();
            f.MdiParent = this;
            f.Show();
        }

        private void inputFinalInspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInspection f = new frmInspection();
            f.MdiParent = this;
            f.Show();

        }

        private void reportFinalInspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInspectionRpt f = new frmInspectionRpt();
            f.MdiParent = this;
            f.Show();
        }

        private void inputFinalPermakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermak f = new frmPermak();
            f.MdiParent = this;
            f.Show();

        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory f = new frmCategory();
            f.MdiParent = this;
            f.Show();

        }

        private void inputRejectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreject f = new frmreject();
            f.MdiParent = this;
            f.Show();
        }

        private void reportRejectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rejectRpt f = new rejectRpt();
            f.MdiParent = this;
            f.Show();

        }

        private void inputQCCuttingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qCutting f = new qCutting();
            f.MdiParent = this;
            f.Show();

        }

        private void inputQCFinishingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qFinishing f = new qFinishing();
            f.MdiParent = this;
            f.Show();

        }

        private void inputRepairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qRepair f = new qRepair();
            f.MdiParent = this;
            f.Show();
        }

        private void reportQCSewingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qrSewing f = new qrSewing();
            f.MdiParent = this;
            f.Show();

        }

        private void reportQCFinishingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qrFinishing f = new qrFinishing();
            f.MdiParent = this;
            f.Show();
        }

        private void rejectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRejectList f = new frmRejectList();
            f.MdiParent = this;
            f.Show();
        }

        private void statusSampleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSample f = new frmSample();
            f.MdiParent = this;
            f.Show();
        }

        private void statusSampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Costing f = new Costing();
            f.MdiParent = this;
            f.Show();
        }

        private void patternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pattern f = new Pattern();
            f.MdiParent = this;
            f.Show();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booking f = new Booking();
            f.MdiParent = this;
            f.Show();
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production f = new Production();
            f.MdiParent = this;
            f.Show();
        }

        private void settingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setting f = new Setting();
            f.MdiParent = this;
            f.Show();
        }

        private void cekCrystalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cekCrystal f = new cekCrystal();
            f.MdiParent = this;
            f.Show();
        }

        private void costingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfCosting f = new sfCosting();
            f.MdiParent = this;
            f.Show();
        }

        private void bookingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sfBooking f = new sfBooking();
            f.MdiParent = this;
            f.Show();
        }

        private void patternToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sfPattern f = new sfPattern();
            f.MdiParent = this;
            f.Show();
        }

        private void productionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sfProduction f = new sfProduction();
            f.MdiParent = this;
            f.Show();
        }

        private void costingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfCostingBox f = new sfCostingBox();
            f.MdiParent = this;
            f.Show();
        }
    }
}
