namespace Grading.Quality
{
    partial class frmSettingStyleQC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingStyleQC));
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.detailsDataGridView = new System.Windows.Forms.DataGridView();
            this.lblStyle = new System.Windows.Forms.Label();
            this.cmdCustomer = new System.Windows.Forms.Button();
            this.txtStyleID = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.picItems = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(183, 207);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 127;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(102, 207);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 126;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(21, 207);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 125;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // detailsDataGridView
            // 
            this.detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailsDataGridView.Location = new System.Drawing.Point(18, 49);
            this.detailsDataGridView.Name = "detailsDataGridView";
            this.detailsDataGridView.Size = new System.Drawing.Size(605, 141);
            this.detailsDataGridView.TabIndex = 124;
            this.detailsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailsDataGridView_CellContentClick);
            this.detailsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailsDataGridView_CellDoubleClick);
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(15, 16);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(30, 13);
            this.lblStyle.TabIndex = 123;
            this.lblStyle.Text = "Style";
            // 
            // cmdCustomer
            // 
            this.cmdCustomer.Image = ((System.Drawing.Image)(resources.GetObject("cmdCustomer.Image")));
            this.cmdCustomer.Location = new System.Drawing.Point(234, 10);
            this.cmdCustomer.Name = "cmdCustomer";
            this.cmdCustomer.Size = new System.Drawing.Size(28, 23);
            this.cmdCustomer.TabIndex = 122;
            this.cmdCustomer.UseVisualStyleBackColor = true;
            this.cmdCustomer.Click += new System.EventHandler(this.cmdCustomer_Click);
            // 
            // txtStyleID
            // 
            this.txtStyleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStyleID.Location = new System.Drawing.Point(55, 13);
            this.txtStyleID.Name = "txtStyleID";
            this.txtStyleID.ReadOnly = true;
            this.txtStyleID.Size = new System.Drawing.Size(173, 20);
            this.txtStyleID.TabIndex = 121;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(268, 10);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(173, 20);
            this.txtDesc.TabIndex = 129;
            // 
            // picItems
            // 
            this.picItems.Location = new System.Drawing.Point(629, 49);
            this.picItems.Name = "picItems";
            this.picItems.Size = new System.Drawing.Size(164, 141);
            this.picItems.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItems.TabIndex = 130;
            this.picItems.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(268, 209);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(377, 20);
            this.txtPath.TabIndex = 131;
            this.txtPath.Visible = false;
            // 
            // frmSettingStyleQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 245);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.picItems);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.detailsDataGridView);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.cmdCustomer);
            this.Controls.Add(this.txtStyleID);
            this.Name = "frmSettingStyleQC";
            this.Text = "frmSetting";
            this.Load += new System.EventHandler(this.frmSettingStyleQC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView detailsDataGridView;
        private System.Windows.Forms.Label lblStyle;
        internal System.Windows.Forms.Button cmdCustomer;
        private System.Windows.Forms.TextBox txtStyleID;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.PictureBox picItems;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtPath;
    }
}