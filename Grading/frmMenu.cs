using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            crystal();
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
    }
}
