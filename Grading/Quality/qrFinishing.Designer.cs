namespace Grading.Quality
{
    partial class qrFinishing
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.cmdXsd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSumPerStyle
            // 
            this.cmdSumPerStyle.Location = new System.Drawing.Point(151, 81);
            this.cmdSumPerStyle.Name = "cmdSumPerStyle";
            this.cmdSumPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdSumPerStyle.TabIndex = 40;
            this.cmdSumPerStyle.Text = "Summary";
            this.cmdSumPerStyle.UseVisualStyleBackColor = true;
            this.cmdSumPerStyle.Click += new System.EventHandler(this.cmdSumPerStyle_Click);
            // 
            // cmdPerStyle
            // 
            this.cmdPerStyle.Location = new System.Drawing.Point(26, 81);
            this.cmdPerStyle.Name = "cmdPerStyle";
            this.cmdPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdPerStyle.TabIndex = 39;
            this.cmdPerStyle.Text = "Detail Per Style";
            this.cmdPerStyle.UseVisualStyleBackColor = true;
            this.cmdPerStyle.Click += new System.EventHandler(this.cmdPerStyle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "From";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(59, 41);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(200, 20);
            this.date2.TabIndex = 32;
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(59, 12);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(200, 20);
            this.date1.TabIndex = 31;
            // 
            // cmdXsd
            // 
            this.cmdXsd.Location = new System.Drawing.Point(22, 155);
            this.cmdXsd.Name = "cmdXsd";
            this.cmdXsd.Size = new System.Drawing.Size(75, 23);
            this.cmdXsd.TabIndex = 36;
            this.cmdXsd.Text = "xsd";
            this.cmdXsd.UseVisualStyleBackColor = true;
            this.cmdXsd.Click += new System.EventHandler(this.cmdXsd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "xsd finishing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdSum
            // 
            this.cmdSum.Location = new System.Drawing.Point(212, 155);
            this.cmdSum.Name = "cmdSum";
            this.cmdSum.Size = new System.Drawing.Size(75, 23);
            this.cmdSum.TabIndex = 42;
            this.cmdSum.Text = "xsd sum";
            this.cmdSum.UseVisualStyleBackColor = true;
            this.cmdSum.Click += new System.EventHandler(this.cmdSum_Click);
            // 
            // qrFinishing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 126);
            this.Controls.Add(this.cmdSum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdSumPerStyle);
            this.Controls.Add(this.cmdPerStyle);
            this.Controls.Add(this.cmdXsd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Name = "qrFinishing";
            this.Text = "qrFinishing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSumPerStyle;
        private System.Windows.Forms.Button cmdPerStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Button cmdXsd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdSum;
    }
}