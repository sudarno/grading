namespace Grading
{
    partial class frmReportbyDate
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
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.cmdXsd = new System.Windows.Forms.Button();
            this.cmdSummary = new System.Windows.Forms.Button();
            this.cmdPerLine = new System.Windows.Forms.Button();
            this.cmdPerStyle = new System.Windows.Forms.Button();
            this.cmdSumPerStyle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(497, 36);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(89, 23);
            this.cmdPrint.TabIndex = 14;
            this.cmdPrint.Text = "Print Detail";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "From";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(58, 41);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(200, 20);
            this.date2.TabIndex = 11;
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(58, 12);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(200, 20);
            this.date1.TabIndex = 10;
            // 
            // cmdXsd
            // 
            this.cmdXsd.Location = new System.Drawing.Point(55, 139);
            this.cmdXsd.Name = "cmdXsd";
            this.cmdXsd.Size = new System.Drawing.Size(75, 23);
            this.cmdXsd.TabIndex = 15;
            this.cmdXsd.Text = "xsd";
            this.cmdXsd.UseVisualStyleBackColor = true;
            this.cmdXsd.Visible = false;
            this.cmdXsd.Click += new System.EventHandler(this.cmdXsd_Click);
            // 
            // cmdSummary
            // 
            this.cmdSummary.Location = new System.Drawing.Point(25, 110);
            this.cmdSummary.Name = "cmdSummary";
            this.cmdSummary.Size = new System.Drawing.Size(105, 23);
            this.cmdSummary.TabIndex = 16;
            this.cmdSummary.Text = "Summary PerLine";
            this.cmdSummary.UseVisualStyleBackColor = true;
            this.cmdSummary.Click += new System.EventHandler(this.cmdSummary_Click);
            // 
            // cmdPerLine
            // 
            this.cmdPerLine.Location = new System.Drawing.Point(25, 81);
            this.cmdPerLine.Name = "cmdPerLine";
            this.cmdPerLine.Size = new System.Drawing.Size(105, 23);
            this.cmdPerLine.TabIndex = 17;
            this.cmdPerLine.Text = "Detail PerLine";
            this.cmdPerLine.UseVisualStyleBackColor = true;
            this.cmdPerLine.Click += new System.EventHandler(this.cmdPerLine_Click);
            // 
            // cmdPerStyle
            // 
            this.cmdPerStyle.Location = new System.Drawing.Point(150, 81);
            this.cmdPerStyle.Name = "cmdPerStyle";
            this.cmdPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdPerStyle.TabIndex = 18;
            this.cmdPerStyle.Text = "Detail Per Style";
            this.cmdPerStyle.UseVisualStyleBackColor = true;
            this.cmdPerStyle.Click += new System.EventHandler(this.cmdPerStyle_Click);
            // 
            // cmdSumPerStyle
            // 
            this.cmdSumPerStyle.Location = new System.Drawing.Point(150, 110);
            this.cmdSumPerStyle.Name = "cmdSumPerStyle";
            this.cmdSumPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdSumPerStyle.TabIndex = 19;
            this.cmdSumPerStyle.Text = "Summary Per Style";
            this.cmdSumPerStyle.UseVisualStyleBackColor = true;
            this.cmdSumPerStyle.Click += new System.EventHandler(this.cmdSumPerStyle_Click);
            // 
            // frmReportbyDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 179);
            this.Controls.Add(this.cmdSumPerStyle);
            this.Controls.Add(this.cmdPerStyle);
            this.Controls.Add(this.cmdPerLine);
            this.Controls.Add(this.cmdSummary);
            this.Controls.Add(this.cmdXsd);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Name = "frmReportbyDate";
            this.Text = "frmReportbyDate";
            this.Load += new System.EventHandler(this.frmReportbyDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Button cmdXsd;
        private System.Windows.Forms.Button cmdSummary;
        private System.Windows.Forms.Button cmdPerLine;
        private System.Windows.Forms.Button cmdPerStyle;
        private System.Windows.Forms.Button cmdSumPerStyle;


    }
}