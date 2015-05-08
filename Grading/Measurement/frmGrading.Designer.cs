namespace Grading
{
    partial class frmGrading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrading));
            this.txtStyleName = new System.Windows.Forms.TextBox();
            this.lblStyle = new System.Windows.Forms.Label();
            this.cmdStyleID = new System.Windows.Forms.Button();
            this.txtStyleID = new System.Windows.Forms.TextBox();
            this.detailsDataGridView = new System.Windows.Forms.DataGridView();
            this.dateGrading = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdPrintGrading = new System.Windows.Forms.Button();
            this.cmdPrintSpec = new System.Windows.Forms.Button();
            this.txtColorID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBuyer = new System.Windows.Forms.ComboBox();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStyleName
            // 
            this.txtStyleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStyleName.Location = new System.Drawing.Point(275, 18);
            this.txtStyleName.Name = "txtStyleName";
            this.txtStyleName.ReadOnly = true;
            this.txtStyleName.Size = new System.Drawing.Size(173, 20);
            this.txtStyleName.TabIndex = 126;
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(12, 19);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(30, 13);
            this.lblStyle.TabIndex = 125;
            this.lblStyle.Text = "Style";
            // 
            // cmdStyleID
            // 
            this.cmdStyleID.Image = ((System.Drawing.Image)(resources.GetObject("cmdStyleID.Image")));
            this.cmdStyleID.Location = new System.Drawing.Point(241, 16);
            this.cmdStyleID.Name = "cmdStyleID";
            this.cmdStyleID.Size = new System.Drawing.Size(28, 23);
            this.cmdStyleID.TabIndex = 124;
            this.cmdStyleID.UseVisualStyleBackColor = true;
            this.cmdStyleID.Click += new System.EventHandler(this.cmdCustomer_Click);
            // 
            // txtStyleID
            // 
            this.txtStyleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStyleID.Location = new System.Drawing.Point(62, 19);
            this.txtStyleID.Name = "txtStyleID";
            this.txtStyleID.ReadOnly = true;
            this.txtStyleID.Size = new System.Drawing.Size(173, 20);
            this.txtStyleID.TabIndex = 123;
            // 
            // detailsDataGridView
            // 
            this.detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailsDataGridView.Location = new System.Drawing.Point(12, 86);
            this.detailsDataGridView.Name = "detailsDataGridView";
            this.detailsDataGridView.Size = new System.Drawing.Size(791, 360);
            this.detailsDataGridView.TabIndex = 127;
            // 
            // dateGrading
            // 
            this.dateGrading.Location = new System.Drawing.Point(584, 44);
            this.dateGrading.Name = "dateGrading";
            this.dateGrading.Size = new System.Drawing.Size(200, 20);
            this.dateGrading.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Buyer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 133;
            this.label2.Text = "Date";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(340, 462);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 136;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(97, 462);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 135;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(16, 462);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 134;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdPrintGrading
            // 
            this.cmdPrintGrading.Location = new System.Drawing.Point(259, 462);
            this.cmdPrintGrading.Name = "cmdPrintGrading";
            this.cmdPrintGrading.Size = new System.Drawing.Size(75, 23);
            this.cmdPrintGrading.TabIndex = 137;
            this.cmdPrintGrading.Text = "Print grading";
            this.cmdPrintGrading.UseVisualStyleBackColor = true;
            this.cmdPrintGrading.Click += new System.EventHandler(this.cmdPrintGrading_Click);
            // 
            // cmdPrintSpec
            // 
            this.cmdPrintSpec.Location = new System.Drawing.Point(178, 462);
            this.cmdPrintSpec.Name = "cmdPrintSpec";
            this.cmdPrintSpec.Size = new System.Drawing.Size(75, 23);
            this.cmdPrintSpec.TabIndex = 138;
            this.cmdPrintSpec.Text = "Print Spec";
            this.cmdPrintSpec.UseVisualStyleBackColor = true;
            this.cmdPrintSpec.Click += new System.EventHandler(this.cmdPrintSpec_Click);
            // 
            // txtColorID
            // 
            this.txtColorID.Location = new System.Drawing.Point(584, 18);
            this.txtColorID.Name = "txtColorID";
            this.txtColorID.Size = new System.Drawing.Size(207, 20);
            this.txtColorID.TabIndex = 139;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 140;
            this.label3.Text = "Color";
            // 
            // cbBuyer
            // 
            this.cbBuyer.FormattingEnabled = true;
            this.cbBuyer.Location = new System.Drawing.Point(62, 45);
            this.cbBuyer.Name = "cbBuyer";
            this.cbBuyer.Size = new System.Drawing.Size(173, 21);
            this.cbBuyer.TabIndex = 141;
            this.cbBuyer.SelectedIndexChanged += new System.EventHandler(this.cbBuyer_SelectedIndexChanged);
            this.cbBuyer.SelectedValueChanged += new System.EventHandler(this.cbBuyer_SelectedValueChanged);
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtBuyerName.Location = new System.Drawing.Point(250, 46);
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.ReadOnly = true;
            this.txtBuyerName.Size = new System.Drawing.Size(198, 20);
            this.txtBuyerName.TabIndex = 142;
            // 
            // frmGrading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 497);
            this.Controls.Add(this.txtBuyerName);
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
            this.Name = "frmGrading";
            this.Text = "frmGrading";
            this.Load += new System.EventHandler(this.frmGrading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStyleName;
        private System.Windows.Forms.Label lblStyle;
        internal System.Windows.Forms.Button cmdStyleID;
        private System.Windows.Forms.TextBox txtStyleID;
        private System.Windows.Forms.DataGridView detailsDataGridView;
        private System.Windows.Forms.DateTimePicker dateGrading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdPrintGrading;
        private System.Windows.Forms.Button cmdPrintSpec;
        private System.Windows.Forms.TextBox txtColorID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBuyer;
        private System.Windows.Forms.TextBox txtBuyerName;
    }
}