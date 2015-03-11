namespace Grading
{
    partial class frmGradingSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradingSet));
            this.cmdPrintSpec = new System.Windows.Forms.Button();
            this.cmdPrintGrading = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.detailsDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtStyleID = new System.Windows.Forms.TextBox();
            this.cmdStyleID = new System.Windows.Forms.Button();
            this.lblStyle = new System.Windows.Forms.Label();
            this.txtStyleName = new System.Windows.Forms.TextBox();
            this.dateGrading = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColorID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBuyer = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.cbPrint = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdPrintSpec
            // 
            this.cmdPrintSpec.Location = new System.Drawing.Point(259, 416);
            this.cmdPrintSpec.Name = "cmdPrintSpec";
            this.cmdPrintSpec.Size = new System.Drawing.Size(75, 23);
            this.cmdPrintSpec.TabIndex = 154;
            this.cmdPrintSpec.Text = "Print Spec";
            this.cmdPrintSpec.UseVisualStyleBackColor = true;
            this.cmdPrintSpec.Click += new System.EventHandler(this.cmdPrintSpec_Click);
            // 
            // cmdPrintGrading
            // 
            this.cmdPrintGrading.Location = new System.Drawing.Point(178, 416);
            this.cmdPrintGrading.Name = "cmdPrintGrading";
            this.cmdPrintGrading.Size = new System.Drawing.Size(75, 23);
            this.cmdPrintGrading.TabIndex = 153;
            this.cmdPrintGrading.Text = "Print grading";
            this.cmdPrintGrading.UseVisualStyleBackColor = true;
            this.cmdPrintGrading.Click += new System.EventHandler(this.cmdPrintGrading_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(521, 414);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 152;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(97, 416);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 151;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(16, 416);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 150;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // detailsDataGridView
            // 
            this.detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailsDataGridView.Location = new System.Drawing.Point(13, 143);
            this.detailsDataGridView.Name = "detailsDataGridView";
            this.detailsDataGridView.Size = new System.Drawing.Size(1139, 251);
            this.detailsDataGridView.TabIndex = 146;
            this.detailsDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.detailsDataGridView_EditingControlShowing);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 158;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(455, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 159;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtStyleID
            // 
            this.txtStyleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStyleID.Location = new System.Drawing.Point(63, 12);
            this.txtStyleID.Name = "txtStyleID";
            this.txtStyleID.ReadOnly = true;
            this.txtStyleID.Size = new System.Drawing.Size(173, 20);
            this.txtStyleID.TabIndex = 142;
            this.txtStyleID.TextChanged += new System.EventHandler(this.txtStyleID_TextChanged);
            // 
            // cmdStyleID
            // 
            this.cmdStyleID.Image = ((System.Drawing.Image)(resources.GetObject("cmdStyleID.Image")));
            this.cmdStyleID.Location = new System.Drawing.Point(242, 9);
            this.cmdStyleID.Name = "cmdStyleID";
            this.cmdStyleID.Size = new System.Drawing.Size(28, 23);
            this.cmdStyleID.TabIndex = 143;
            this.cmdStyleID.UseVisualStyleBackColor = true;
            this.cmdStyleID.Click += new System.EventHandler(this.cmdStyleID_Click);
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(13, 12);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(30, 13);
            this.lblStyle.TabIndex = 144;
            this.lblStyle.Text = "Style";
            this.lblStyle.Click += new System.EventHandler(this.lblStyle_Click);
            // 
            // txtStyleName
            // 
            this.txtStyleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStyleName.Location = new System.Drawing.Point(276, 11);
            this.txtStyleName.Name = "txtStyleName";
            this.txtStyleName.ReadOnly = true;
            this.txtStyleName.Size = new System.Drawing.Size(173, 20);
            this.txtStyleName.TabIndex = 145;
            this.txtStyleName.TextChanged += new System.EventHandler(this.txtStyleName_TextChanged);
            // 
            // dateGrading
            // 
            this.dateGrading.Location = new System.Drawing.Point(63, 90);
            this.dateGrading.Name = "dateGrading";
            this.dateGrading.Size = new System.Drawing.Size(200, 20);
            this.dateGrading.TabIndex = 147;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "Buyer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 149;
            this.label2.Text = "Date";
            // 
            // txtColorID
            // 
            this.txtColorID.Location = new System.Drawing.Point(63, 64);
            this.txtColorID.Name = "txtColorID";
            this.txtColorID.Size = new System.Drawing.Size(207, 20);
            this.txtColorID.TabIndex = 155;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "Color";
            // 
            // cbBuyer
            // 
            this.cbBuyer.FormattingEnabled = true;
            this.cbBuyer.Location = new System.Drawing.Point(63, 38);
            this.cbBuyer.Name = "cbBuyer";
            this.cbBuyer.Size = new System.Drawing.Size(207, 21);
            this.cbBuyer.TabIndex = 157;
            this.cbBuyer.SelectedIndexChanged += new System.EventHandler(this.cbBuyer_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(536, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 160;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(617, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 161;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(698, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 162;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtBuyer
            // 
            this.txtBuyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtBuyer.Location = new System.Drawing.Point(276, 37);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.ReadOnly = true;
            this.txtBuyer.Size = new System.Drawing.Size(100, 20);
            this.txtBuyer.TabIndex = 163;
            // 
            // cbPrint
            // 
            this.cbPrint.AutoCompleteCustomSource.AddRange(new string[] {
            "NONE",
            "BW",
            "BW & AW"});
            this.cbPrint.FormattingEnabled = true;
            this.cbPrint.Items.AddRange(new object[] {
            "NORMAL",
            "BW",
            "BW & AW"});
            this.cbPrint.Location = new System.Drawing.Point(340, 416);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(160, 21);
            this.cbPrint.TabIndex = 164;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(617, 414);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 165;
            this.button6.Text = "test LW";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // frmGradingSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 460);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.cbPrint);
            this.Controls.Add(this.txtBuyer);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbBuyer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtColorID);
            this.Controls.Add(this.cmdPrintSpec);
            this.Controls.Add(this.cmdPrintGrading);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateGrading);
            this.Controls.Add(this.detailsDataGridView);
            this.Controls.Add(this.txtStyleName);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.cmdStyleID);
            this.Controls.Add(this.txtStyleID);
            this.Name = "frmGradingSet";
            this.Text = "Grading";
            this.Load += new System.EventHandler(this.frmGradingSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPrintSpec;
        private System.Windows.Forms.Button cmdPrintGrading;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView detailsDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtStyleID;
        internal System.Windows.Forms.Button cmdStyleID;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.TextBox txtStyleName;
        private System.Windows.Forms.DateTimePicker dateGrading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColorID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBuyer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.ComboBox cbPrint;
        private System.Windows.Forms.Button button6;
    }
}