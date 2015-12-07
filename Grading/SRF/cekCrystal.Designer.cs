namespace Grading.SRF
{
    partial class cekCrystal
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Start = new System.Windows.Forms.TextBox();
            this.textBox_End = new System.Windows.Forms.TextBox();
            this.textBox_Diff = new System.Windows.Forms.TextBox();
            this.textBox_Filename = new System.Windows.Forms.TextBox();
            this.sampleCr1 = new Grading.SRF.SampleCr();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Start
            // 
            this.textBox_Start.Location = new System.Drawing.Point(35, 46);
            this.textBox_Start.Name = "textBox_Start";
            this.textBox_Start.Size = new System.Drawing.Size(100, 20);
            this.textBox_Start.TabIndex = 1;
            // 
            // textBox_End
            // 
            this.textBox_End.Location = new System.Drawing.Point(183, 46);
            this.textBox_End.Name = "textBox_End";
            this.textBox_End.Size = new System.Drawing.Size(100, 20);
            this.textBox_End.TabIndex = 2;
            // 
            // textBox_Diff
            // 
            this.textBox_Diff.Location = new System.Drawing.Point(320, 46);
            this.textBox_Diff.Name = "textBox_Diff";
            this.textBox_Diff.Size = new System.Drawing.Size(100, 20);
            this.textBox_Diff.TabIndex = 3;
            // 
            // textBox_Filename
            // 
            this.textBox_Filename.Location = new System.Drawing.Point(183, 118);
            this.textBox_Filename.Name = "textBox_Filename";
            this.textBox_Filename.Size = new System.Drawing.Size(265, 20);
            this.textBox_Filename.TabIndex = 4;
            // 
            // cekCrystal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 262);
            this.Controls.Add(this.textBox_Filename);
            this.Controls.Add(this.textBox_Diff);
            this.Controls.Add(this.textBox_End);
            this.Controls.Add(this.textBox_Start);
            this.Controls.Add(this.button1);
            this.Name = "cekCrystal";
            this.Text = "cekCrystal";
            this.Load += new System.EventHandler(this.cekCrystal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_Start;
        private System.Windows.Forms.TextBox textBox_End;
        private System.Windows.Forms.TextBox textBox_Diff;
        private System.Windows.Forms.TextBox textBox_Filename;
        private SampleCr sampleCr1;
    }
}