namespace Grading.Quality
{
    partial class frmInputQC
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSumPerStyle = new System.Windows.Forms.Button();
            this.cmdPerStyle = new System.Windows.Forms.Button();
            this.cmdPerLine = new System.Windows.Forms.Button();
            this.cmdSummary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.cmdFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(321, 15);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(75, 23);
            this.cmdView.TabIndex = 27;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateQC
            // 
            this.dateQC.Location = new System.Drawing.Point(75, 18);
            this.dateQC.Name = "dateQC";
            this.dateQC.Size = new System.Drawing.Size(214, 20);
            this.dateQC.TabIndex = 25;
            this.dateQC.ValueChanged += new System.EventHandler(this.dateQC_ValueChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(183, 395);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(73, 23);
            this.cmdClose.TabIndex = 24;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(102, 395);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(73, 23);
            this.cmdDelete.TabIndex = 23;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(21, 395);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(73, 23);
            this.cmdSave.TabIndex = 22;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // masterDataGridView
            // 
            this.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDataGridView.Location = new System.Drawing.Point(21, 56);
            this.masterDataGridView.Name = "masterDataGridView";
            this.masterDataGridView.Size = new System.Drawing.Size(718, 327);
            this.masterDataGridView.TabIndex = 21;
            this.masterDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdSumPerStyle);
            this.groupBox1.Controls.Add(this.cmdPerStyle);
            this.groupBox1.Controls.Add(this.cmdPerLine);
            this.groupBox1.Controls.Add(this.cmdSummary);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.date2);
            this.groupBox1.Controls.Add(this.date1);
            this.groupBox1.Location = new System.Drawing.Point(277, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 76);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            this.groupBox1.Visible = false;
            // 
            // cmdSumPerStyle
            // 
            this.cmdSumPerStyle.Location = new System.Drawing.Point(319, 40);
            this.cmdSumPerStyle.Name = "cmdSumPerStyle";
            this.cmdSumPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdSumPerStyle.TabIndex = 43;
            this.cmdSumPerStyle.Text = "Summary Per Style";
            this.cmdSumPerStyle.UseVisualStyleBackColor = true;
            this.cmdSumPerStyle.Visible = false;
            // 
            // cmdPerStyle
            // 
            this.cmdPerStyle.Location = new System.Drawing.Point(205, 40);
            this.cmdPerStyle.Name = "cmdPerStyle";
            this.cmdPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdPerStyle.TabIndex = 42;
            this.cmdPerStyle.Text = "Detail Per Style";
            this.cmdPerStyle.UseVisualStyleBackColor = true;
            this.cmdPerStyle.Visible = false;
            // 
            // cmdPerLine
            // 
            this.cmdPerLine.Location = new System.Drawing.Point(7, 40);
            this.cmdPerLine.Name = "cmdPerLine";
            this.cmdPerLine.Size = new System.Drawing.Size(87, 23);
            this.cmdPerLine.TabIndex = 41;
            this.cmdPerLine.Text = "Detail PerLine";
            this.cmdPerLine.UseVisualStyleBackColor = true;
            this.cmdPerLine.Visible = false;
            this.cmdPerLine.Click += new System.EventHandler(this.cmdPerLine_Click);
            // 
            // cmdSummary
            // 
            this.cmdSummary.Location = new System.Drawing.Point(100, 40);
            this.cmdSummary.Name = "cmdSummary";
            this.cmdSummary.Size = new System.Drawing.Size(99, 23);
            this.cmdSummary.TabIndex = 40;
            this.cmdSummary.Text = "Summary PerLine";
            this.cmdSummary.UseVisualStyleBackColor = true;
            this.cmdSummary.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "To";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "From";
            this.label3.Visible = false;
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(260, 14);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(181, 20);
            this.date2.TabIndex = 37;
            this.date2.Visible = false;
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(44, 14);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(184, 20);
            this.date1.TabIndex = 36;
            this.date1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Syle";
            // 
            // txtStyle
            // 
            this.txtStyle.Location = new System.Drawing.Point(456, 17);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(160, 20);
            this.txtStyle.TabIndex = 42;
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(622, 15);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 23);
            this.cmdFind.TabIndex = 41;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            // 
            // frmInputQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 477);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateQC);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.masterDataGridView);
            this.Name = "frmInputQC";
            this.Text = "frmInputQC";
            this.Load += new System.EventHandler(this.frmInputQC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSumPerStyle;
        private System.Windows.Forms.Button cmdPerStyle;
        private System.Windows.Forms.Button cmdPerLine;
        private System.Windows.Forms.Button cmdSummary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Button cmdFind;
    }
}