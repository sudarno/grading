namespace Grading.Quality
{
    partial class qRepair
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.cmdView = new System.Windows.Forms.Button();
            this.masterDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateQC = new System.Windows.Forms.DateTimePicker();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Syle";
            // 
            // txtStyle
            // 
            this.txtStyle.Location = new System.Drawing.Point(464, 11);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(160, 20);
            this.txtStyle.TabIndex = 63;
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(297, 9);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(75, 23);
            this.cmdView.TabIndex = 61;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // masterDataGridView
            // 
            this.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDataGridView.Location = new System.Drawing.Point(14, 50);
            this.masterDataGridView.Name = "masterDataGridView";
            this.masterDataGridView.Size = new System.Drawing.Size(718, 327);
            this.masterDataGridView.TabIndex = 55;
            this.masterDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellContentClick);
            this.masterDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellEndEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Date";
            // 
            // dateQC
            // 
            this.dateQC.Location = new System.Drawing.Point(68, 12);
            this.dateQC.Name = "dateQC";
            this.dateQC.Size = new System.Drawing.Size(214, 20);
            this.dateQC.TabIndex = 59;
            this.dateQC.ValueChanged += new System.EventHandler(this.dateQC_ValueChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(14, 389);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(73, 23);
            this.cmdSave.TabIndex = 56;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(176, 389);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(73, 23);
            this.cmdClose.TabIndex = 58;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(95, 389);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(73, 23);
            this.cmdDelete.TabIndex = 57;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(630, 9);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 23);
            this.cmdFind.TabIndex = 62;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // qRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 437);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.cmdView);
            this.Controls.Add(this.masterDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateQC);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdFind);
            this.Name = "qRepair";
            this.Text = "QC Repair";
            this.Load += new System.EventHandler(this.qRepair_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.DataGridView masterDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateQC;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdFind;
    }
}