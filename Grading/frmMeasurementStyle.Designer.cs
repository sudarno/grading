namespace Grading
{
    partial class frmMeasurementStyle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasurementStyle));
            this.label1 = new System.Windows.Forms.Label();
            this.cbBuyer = new System.Windows.Forms.ComboBox();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.masterDataGridView = new System.Windows.Forms.DataGridView();
            this.cmdStyleID = new System.Windows.Forms.Button();
            this.txtStyleID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStyleName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "BUYER";
            // 
            // cbBuyer
            // 
            this.cbBuyer.FormattingEnabled = true;
            this.cbBuyer.Location = new System.Drawing.Point(124, 38);
            this.cbBuyer.Name = "cbBuyer";
            this.cbBuyer.Size = new System.Drawing.Size(167, 21);
            this.cbBuyer.TabIndex = 17;
            this.cbBuyer.SelectedIndexChanged += new System.EventHandler(this.cbBuyer_SelectedIndexChanged);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(261, 464);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(75, 23);
            this.cmdLoad.TabIndex = 16;
            this.cmdLoad.Text = "Load";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(99, 464);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 15;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(18, 464);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // masterDataGridView
            // 
            this.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDataGridView.Location = new System.Drawing.Point(30, 81);
            this.masterDataGridView.Name = "masterDataGridView";
            this.masterDataGridView.Size = new System.Drawing.Size(686, 377);
            this.masterDataGridView.TabIndex = 12;
            // 
            // cmdStyleID
            // 
            this.cmdStyleID.Image = ((System.Drawing.Image)(resources.GetObject("cmdStyleID.Image")));
            this.cmdStyleID.Location = new System.Drawing.Point(308, 10);
            this.cmdStyleID.Name = "cmdStyleID";
            this.cmdStyleID.Size = new System.Drawing.Size(28, 23);
            this.cmdStyleID.TabIndex = 151;
            this.cmdStyleID.UseVisualStyleBackColor = true;
            this.cmdStyleID.Click += new System.EventHandler(this.cmdStyleID_Click);
            // 
            // txtStyleID
            // 
            this.txtStyleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStyleID.Location = new System.Drawing.Point(124, 12);
            this.txtStyleID.Name = "txtStyleID";
            this.txtStyleID.ReadOnly = true;
            this.txtStyleID.Size = new System.Drawing.Size(173, 20);
            this.txtStyleID.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 152;
            this.label2.Text = "STYLE";
            // 
            // txtStyleName
            // 
            this.txtStyleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStyleName.Location = new System.Drawing.Point(342, 12);
            this.txtStyleName.Name = "txtStyleName";
            this.txtStyleName.ReadOnly = true;
            this.txtStyleName.Size = new System.Drawing.Size(173, 20);
            this.txtStyleName.TabIndex = 153;
            // 
            // frmMeasurementStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 511);
            this.Controls.Add(this.txtStyleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdStyleID);
            this.Controls.Add(this.txtStyleID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBuyer);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.masterDataGridView);
            this.Name = "frmMeasurementStyle";
            this.Text = "frmMeasurementStyle";
            this.Load += new System.EventHandler(this.frmMeasurementStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBuyer;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView masterDataGridView;
        internal System.Windows.Forms.Button cmdStyleID;
        private System.Windows.Forms.TextBox txtStyleID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStyleName;
    }
}