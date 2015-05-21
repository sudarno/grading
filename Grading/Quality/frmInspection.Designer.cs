namespace Grading.Quality
{
    partial class frmInspection
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
            this.cmdView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateQC = new System.Windows.Forms.DateTimePicker();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.masterDataGridView = new System.Windows.Forms.DataGridView();
            this.detailsDataGridView = new System.Windows.Forms.DataGridView();
            this.dateQC2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdFind = new System.Windows.Forms.Button();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdPrintDetail = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.hSTYLEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hCOLORID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hMAJOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hMINOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(448, 12);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(75, 23);
            this.cmdView.TabIndex = 34;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date";
            // 
            // dateQC
            // 
            this.dateQC.Location = new System.Drawing.Point(47, 15);
            this.dateQC.Name = "dateQC";
            this.dateQC.Size = new System.Drawing.Size(181, 20);
            this.dateQC.TabIndex = 32;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(175, 412);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(73, 23);
            this.cmdClose.TabIndex = 31;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(94, 412);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(73, 23);
            this.cmdDelete.TabIndex = 30;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(13, 412);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(73, 23);
            this.cmdSave.TabIndex = 29;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // masterDataGridView
            // 
            this.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDataGridView.Location = new System.Drawing.Point(12, 53);
            this.masterDataGridView.Name = "masterDataGridView";
            this.masterDataGridView.Size = new System.Drawing.Size(914, 197);
            this.masterDataGridView.TabIndex = 28;
            this.masterDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellClick);
            this.masterDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellContentClick);
            this.masterDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellEndEdit);
            // 
            // detailsDataGridView
            // 
            this.detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hSTYLEID,
            this.hCOLORID,
            this.hID1,
            this.hID,
            this.hMAJOR,
            this.hMINOR,
            this.hNAME});
            this.detailsDataGridView.Location = new System.Drawing.Point(12, 256);
            this.detailsDataGridView.Name = "detailsDataGridView";
            this.detailsDataGridView.Size = new System.Drawing.Size(912, 150);
            this.detailsDataGridView.TabIndex = 35;
            // 
            // dateQC2
            // 
            this.dateQC2.Location = new System.Drawing.Point(260, 15);
            this.dateQC2.Name = "dateQC2";
            this.dateQC2.Size = new System.Drawing.Size(182, 20);
            this.dateQC2.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "To";
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(810, 10);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 23);
            this.cmdFind.TabIndex = 38;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // txtStyle
            // 
            this.txtStyle.Location = new System.Drawing.Point(644, 12);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(160, 20);
            this.txtStyle.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Syle";
            // 
            // cmdPrintDetail
            // 
            this.cmdPrintDetail.Location = new System.Drawing.Point(505, 412);
            this.cmdPrintDetail.Name = "cmdPrintDetail";
            this.cmdPrintDetail.Size = new System.Drawing.Size(75, 23);
            this.cmdPrintDetail.TabIndex = 42;
            this.cmdPrintDetail.Text = "Print Detail";
            this.cmdPrintDetail.UseVisualStyleBackColor = true;
            this.cmdPrintDetail.Click += new System.EventHandler(this.cmdPrintDetail_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(420, 412);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(79, 23);
            this.cmdPrint.TabIndex = 41;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // hSTYLEID
            // 
            this.hSTYLEID.HeaderText = "STYLE";
            this.hSTYLEID.Name = "hSTYLEID";
            this.hSTYLEID.Visible = false;
            // 
            // hCOLORID
            // 
            this.hCOLORID.HeaderText = "COLORID";
            this.hCOLORID.Name = "hCOLORID";
            this.hCOLORID.Visible = false;
            // 
            // hID1
            // 
            this.hID1.HeaderText = "ID1";
            this.hID1.Name = "hID1";
            this.hID1.Visible = false;
            // 
            // hID
            // 
            this.hID.HeaderText = "NO";
            this.hID.Name = "hID";
            this.hID.Width = 50;
            // 
            // hMAJOR
            // 
            this.hMAJOR.HeaderText = "MAJOR";
            this.hMAJOR.Name = "hMAJOR";
            this.hMAJOR.Width = 50;
            // 
            // hMINOR
            // 
            this.hMINOR.HeaderText = "MINOR";
            this.hMINOR.Name = "hMINOR";
            this.hMINOR.Width = 50;
            // 
            // hNAME
            // 
            this.hNAME.HeaderText = "DECRIPTION";
            this.hNAME.Name = "hNAME";
            this.hNAME.Width = 250;
            // 
            // frmInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 465);
            this.Controls.Add(this.cmdPrintDetail);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateQC2);
            this.Controls.Add(this.detailsDataGridView);
            this.Controls.Add(this.cmdView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateQC);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.masterDataGridView);
            this.Name = "frmInspection";
            this.Text = "frmInpections";
            this.Load += new System.EventHandler(this.frmInspection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateQC;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView masterDataGridView;
        private System.Windows.Forms.DataGridView detailsDataGridView;
        private System.Windows.Forms.DateTimePicker dateQC2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdPrintDetail;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn hSTYLEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hCOLORID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hMAJOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn hMINOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNAME;
    }
}