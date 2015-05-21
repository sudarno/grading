namespace Grading.Quality
{
    partial class rejectRpt
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
            this.SuspendLayout();
            // 
            // cmdXsd
            // 
            this.cmdXsd.Location = new System.Drawing.Point(68, 132);
            this.cmdXsd.Name = "cmdXsd";
            this.cmdXsd.Size = new System.Drawing.Size(75, 23);
            this.cmdXsd.TabIndex = 28;
            this.cmdXsd.Text = "xsd";
            this.cmdXsd.UseVisualStyleBackColor = true;
            this.cmdXsd.Click += new System.EventHandler(this.cmdXsd_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(54, 81);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(89, 23);
            this.cmdPrint.TabIndex = 27;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "From";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(54, 41);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(200, 20);
            this.date2.TabIndex = 24;
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(54, 12);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(200, 20);
            this.date1.TabIndex = 23;
            // 
            // rejectRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 119);
            this.Controls.Add(this.cmdXsd);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Name = "rejectRpt";
            this.Text = "rejectRpt";
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
    }
}