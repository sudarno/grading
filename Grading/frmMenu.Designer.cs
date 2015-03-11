namespace Grading
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measurementStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measurementChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measurementGradingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test1 = new Grading.test();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.qCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buyerToolStripMenuItem,
            this.styleToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.measurementToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // buyerToolStripMenuItem
            // 
            this.buyerToolStripMenuItem.Name = "buyerToolStripMenuItem";
            this.buyerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.buyerToolStripMenuItem.Text = "Buyer";
            this.buyerToolStripMenuItem.Click += new System.EventHandler(this.buyerToolStripMenuItem_Click);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.styleToolStripMenuItem.Text = "Style";
            this.styleToolStripMenuItem.Click += new System.EventHandler(this.styleToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // measurementToolStripMenuItem
            // 
            this.measurementToolStripMenuItem.Name = "measurementToolStripMenuItem";
            this.measurementToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.measurementToolStripMenuItem.Text = "Measurement";
            this.measurementToolStripMenuItem.Click += new System.EventHandler(this.measurementToolStripMenuItem_Click);
            // 
            // qCToolStripMenuItem
            // 
            this.qCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingPropertiesToolStripMenuItem,
            this.measurementChartToolStripMenuItem,
            this.measurementGradingToolStripMenuItem,
            this.testToolStripMenuItem});
            this.qCToolStripMenuItem.Name = "qCToolStripMenuItem";
            this.qCToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.qCToolStripMenuItem.Text = "Measurement";
            // 
            // settingPropertiesToolStripMenuItem
            // 
            this.settingPropertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeOrderToolStripMenuItem,
            this.measurementStyleToolStripMenuItem});
            this.settingPropertiesToolStripMenuItem.Name = "settingPropertiesToolStripMenuItem";
            this.settingPropertiesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.settingPropertiesToolStripMenuItem.Text = "Setting Properties";
            this.settingPropertiesToolStripMenuItem.Click += new System.EventHandler(this.settingPropertiesToolStripMenuItem_Click);
            // 
            // sizeOrderToolStripMenuItem
            // 
            this.sizeOrderToolStripMenuItem.Name = "sizeOrderToolStripMenuItem";
            this.sizeOrderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.sizeOrderToolStripMenuItem.Text = "Size Order";
            this.sizeOrderToolStripMenuItem.Click += new System.EventHandler(this.sizeOrderToolStripMenuItem_Click);
            // 
            // measurementStyleToolStripMenuItem
            // 
            this.measurementStyleToolStripMenuItem.Name = "measurementStyleToolStripMenuItem";
            this.measurementStyleToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.measurementStyleToolStripMenuItem.Text = "Measurement Style";
            this.measurementStyleToolStripMenuItem.Click += new System.EventHandler(this.measurementStyleToolStripMenuItem_Click);
            // 
            // measurementChartToolStripMenuItem
            // 
            this.measurementChartToolStripMenuItem.Name = "measurementChartToolStripMenuItem";
            this.measurementChartToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.measurementChartToolStripMenuItem.Text = "Measurement Chart";
            this.measurementChartToolStripMenuItem.Visible = false;
            this.measurementChartToolStripMenuItem.Click += new System.EventHandler(this.measurementChartToolStripMenuItem_Click);
            // 
            // measurementGradingToolStripMenuItem
            // 
            this.measurementGradingToolStripMenuItem.Name = "measurementGradingToolStripMenuItem";
            this.measurementGradingToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.measurementGradingToolStripMenuItem.Text = "Measurement Grading";
            this.measurementGradingToolStripMenuItem.Click += new System.EventHandler(this.measurementGradingToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 432);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Measurement Size Spec";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measurementChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measurementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measurementGradingToolStripMenuItem;
        private test test1;
        private System.Windows.Forms.ToolStripMenuItem sizeOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measurementStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}

