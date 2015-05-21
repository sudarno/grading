namespace Grading.Quality
{
    partial class qrSewing
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
            this.cmdSumPerStyle = new System.Windows.Forms.Button();
            this.cmdPerStyle = new System.Windows.Forms.Button();
            this.cmdPerLine = new System.Windows.Forms.Button();
            this.cmdSummary = new System.Windows.Forms.Button();
            this.cmdXsd = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSumPerStyle
            // 
            this.cmdSumPerStyle.Location = new System.Drawing.Point(137, 81);
            this.cmdSumPerStyle.Name = "cmdSumPerStyle";
            this.cmdSumPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdSumPerStyle.TabIndex = 29;
            this.cmdSumPerStyle.Text = "Summary";
            this.cmdSumPerStyle.UseVisualStyleBackColor = true;
            this.cmdSumPerStyle.Click += new System.EventHandler(this.cmdSumPerStyle_Click);
            // 
            // cmdPerStyle
            // 
            this.cmdPerStyle.Location = new System.Drawing.Point(12, 81);
            this.cmdPerStyle.Name = "cmdPerStyle";
            this.cmdPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdPerStyle.TabIndex = 28;
            this.cmdPerStyle.Text = "Detail Per Style";
            this.cmdPerStyle.UseVisualStyleBackColor = true;
            this.cmdPerStyle.Click += new System.EventHandler(this.cmdPerStyle_Click);
            // 
            // cmdPerLine
            // 
            this.cmdPerLine.Location = new System.Drawing.Point(265, 178);
            this.cmdPerLine.Name = "cmdPerLine";
            this.cmdPerLine.Size = new System.Drawing.Size(105, 23);
            this.cmdPerLine.TabIndex = 27;
            this.cmdPerLine.Text = "Detail PerLine";
            this.cmdPerLine.UseVisualStyleBackColor = true;
            this.cmdPerLine.Click += new System.EventHandler(this.cmdPerLine_Click);
            // 
            // cmdSummary
            // 
            this.cmdSummary.Location = new System.Drawing.Point(174, 178);
            this.cmdSummary.Name = "cmdSummary";
            this.cmdSummary.Size = new System.Drawing.Size(105, 23);
            this.cmdSummary.TabIndex = 26;
            this.cmdSummary.Text = "Summary PerLine";
            this.cmdSummary.UseVisualStyleBackColor = true;
            // 
            // cmdXsd
            // 
            this.cmdXsd.Location = new System.Drawing.Point(22, 178);
            this.cmdXsd.Name = "cmdXsd";
            this.cmdXsd.Size = new System.Drawing.Size(75, 23);
            this.cmdXsd.TabIndex = 25;
            this.cmdXsd.Text = "xsd";
            this.cmdXsd.UseVisualStyleBackColor = true;
            this.cmdXsd.Click += new System.EventHandler(this.cmdXsd_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(484, 36);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(89, 23);
            this.cmdPrint.TabIndex = 24;
            this.cmdPrint.Text = "Print Detail";
            this.cmdPrint.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "From";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(45, 41);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(200, 20);
            this.date2.TabIndex = 21;
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(45, 12);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(200, 20);
            this.date1.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "xsd style";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // qrSewing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 123);
            this.Controls.Add(this.button1);
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
            this.Name = "qrSewing";
            this.Text = "qrSewing";
            this.Load += new System.EventHandler(this.qrSewing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSumPerStyle;
        private System.Windows.Forms.Button cmdPerStyle;
        private System.Windows.Forms.Button cmdPerLine;
        private System.Windows.Forms.Button cmdSummary;
        private System.Windows.Forms.Button cmdXsd;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Button button1;

    }
}