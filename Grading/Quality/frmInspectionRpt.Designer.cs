namespace Grading.Quality
{
    partial class frmInspectionRpt
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
            this.cmdXsd = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.cmdPrintDetail = new System.Windows.Forms.Button();
            this.cmdXsdDetail = new System.Windows.Forms.Button();
            this.cmdPrindetail1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdXsd
            // 
            this.cmdXsd.Location = new System.Drawing.Point(85, 164);
            this.cmdXsd.Name = "cmdXsd";
            this.cmdXsd.Size = new System.Drawing.Size(75, 23);
            this.cmdXsd.TabIndex = 22;
            this.cmdXsd.Text = "xsd";
            this.cmdXsd.UseVisualStyleBackColor = true;
            this.cmdXsd.Click += new System.EventHandler(this.cmdXsd_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(71, 95);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(89, 23);
            this.cmdPrint.TabIndex = 21;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "From";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(71, 55);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(200, 20);
            this.date2.TabIndex = 18;
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(71, 26);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(200, 20);
            this.date1.TabIndex = 17;
            // 
            // cmdPrintDetail
            // 
            this.cmdPrintDetail.Location = new System.Drawing.Point(62, 124);
            this.cmdPrintDetail.Name = "cmdPrintDetail";
            this.cmdPrintDetail.Size = new System.Drawing.Size(75, 23);
            this.cmdPrintDetail.TabIndex = 23;
            this.cmdPrintDetail.Text = "Print Detail";
            this.cmdPrintDetail.UseVisualStyleBackColor = true;
            this.cmdPrintDetail.Visible = false;
            this.cmdPrintDetail.Click += new System.EventHandler(this.cmdPrintDetail_Click);
            // 
            // cmdXsdDetail
            // 
            this.cmdXsdDetail.Location = new System.Drawing.Point(177, 164);
            this.cmdXsdDetail.Name = "cmdXsdDetail";
            this.cmdXsdDetail.Size = new System.Drawing.Size(75, 23);
            this.cmdXsdDetail.TabIndex = 24;
            this.cmdXsdDetail.Text = "xsd detail";
            this.cmdXsdDetail.UseVisualStyleBackColor = true;
            this.cmdXsdDetail.Click += new System.EventHandler(this.cmdXsdDetail_Click);
            // 
            // cmdPrindetail1
            // 
            this.cmdPrindetail1.Location = new System.Drawing.Point(166, 95);
            this.cmdPrindetail1.Name = "cmdPrindetail1";
            this.cmdPrindetail1.Size = new System.Drawing.Size(75, 23);
            this.cmdPrindetail1.TabIndex = 25;
            this.cmdPrindetail1.Text = "Print Detail";
            this.cmdPrindetail1.UseVisualStyleBackColor = true;
            this.cmdPrindetail1.Click += new System.EventHandler(this.cmdPrindetail1_Click);
            // 
            // frmInspectionRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 147);
            this.Controls.Add(this.cmdPrindetail1);
            this.Controls.Add(this.cmdXsdDetail);
            this.Controls.Add(this.cmdPrintDetail);
            this.Controls.Add(this.cmdXsd);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Name = "frmInspectionRpt";
            this.Text = "frmReportInspections";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdXsd;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Button cmdPrintDetail;
        private System.Windows.Forms.Button cmdXsdDetail;
        private System.Windows.Forms.Button cmdPrindetail1;
    }
}