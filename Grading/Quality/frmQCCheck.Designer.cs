namespace Grading
{
    partial class frmQCCheck
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.masterDataGridView = new System.Windows.Forms.DataGridView();
            this.dateQC = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdView = new System.Windows.Forms.Button();
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
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(176, 419);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(73, 23);
            this.cmdClose.TabIndex = 17;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(95, 419);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(73, 23);
            this.cmdDelete.TabIndex = 16;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(14, 419);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(73, 23);
            this.cmdSave.TabIndex = 15;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // masterDataGridView
            // 
            this.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDataGridView.Location = new System.Drawing.Point(13, 60);
            this.masterDataGridView.Name = "masterDataGridView";
            this.masterDataGridView.Size = new System.Drawing.Size(718, 353);
            this.masterDataGridView.TabIndex = 14;
            this.masterDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellContentClick);
            this.masterDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellEndEdit);
            this.masterDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.masterDataGridView_RowsAdded);
            // 
            // dateQC
            // 
            this.dateQC.Location = new System.Drawing.Point(67, 22);
            this.dateQC.Name = "dateQC";
            this.dateQC.Size = new System.Drawing.Size(214, 20);
            this.dateQC.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Date";
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(313, 19);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(75, 23);
            this.cmdView.TabIndex = 20;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(269, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 76);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // cmdSumPerStyle
            // 
            this.cmdSumPerStyle.Location = new System.Drawing.Point(319, 40);
            this.cmdSumPerStyle.Name = "cmdSumPerStyle";
            this.cmdSumPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdSumPerStyle.TabIndex = 43;
            this.cmdSumPerStyle.Text = "Summary Per Style";
            this.cmdSumPerStyle.UseVisualStyleBackColor = true;
            this.cmdSumPerStyle.Click += new System.EventHandler(this.cmdSumPerStyle_Click);
            // 
            // cmdPerStyle
            // 
            this.cmdPerStyle.Location = new System.Drawing.Point(205, 40);
            this.cmdPerStyle.Name = "cmdPerStyle";
            this.cmdPerStyle.Size = new System.Drawing.Size(108, 23);
            this.cmdPerStyle.TabIndex = 42;
            this.cmdPerStyle.Text = "Detail Per Style";
            this.cmdPerStyle.UseVisualStyleBackColor = true;
            this.cmdPerStyle.Click += new System.EventHandler(this.cmdPerStyle_Click);
            // 
            // cmdPerLine
            // 
            this.cmdPerLine.Location = new System.Drawing.Point(7, 40);
            this.cmdPerLine.Name = "cmdPerLine";
            this.cmdPerLine.Size = new System.Drawing.Size(87, 23);
            this.cmdPerLine.TabIndex = 41;
            this.cmdPerLine.Text = "Detail PerLine";
            this.cmdPerLine.UseVisualStyleBackColor = true;
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
            this.cmdSummary.Click += new System.EventHandler(this.cmdSummary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "From";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(260, 14);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(181, 20);
            this.date2.TabIndex = 37;
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(44, 14);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(184, 20);
            this.date1.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Syle";
            // 
            // txtStyle
            // 
            this.txtStyle.Location = new System.Drawing.Point(459, 19);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(160, 20);
            this.txtStyle.TabIndex = 45;
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(625, 17);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 23);
            this.cmdFind.TabIndex = 44;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // frmQCCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 501);
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
            this.Name = "frmQCCheck";
            this.Text = "frmQCCheck";
            this.Load += new System.EventHandler(this.frmQCCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView masterDataGridView;
        private System.Windows.Forms.DateTimePicker dateQC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdView;
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