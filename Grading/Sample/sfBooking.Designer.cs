namespace Grading.Sample
{
    partial class sfBooking
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
            this.label2 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.cmdXSD = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.cmdView = new System.Windows.Forms.Button();
            this.masterDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "s/d";
            // 
            // date2
            // 
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date2.Location = new System.Drawing.Point(185, 10);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(101, 20);
            this.date2.TabIndex = 103;
            // 
            // cmdXSD
            // 
            this.cmdXSD.Location = new System.Drawing.Point(336, 501);
            this.cmdXSD.Name = "cmdXSD";
            this.cmdXSD.Size = new System.Drawing.Size(75, 23);
            this.cmdXSD.TabIndex = 102;
            this.cmdXSD.Text = "XSD";
            this.cmdXSD.UseVisualStyleBackColor = true;
            this.cmdXSD.Click += new System.EventHandler(this.cmdXSD_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(174, 501);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(75, 23);
            this.cmdPrint.TabIndex = 101;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(760, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Syle";
            // 
            // txtStyle
            // 
            this.txtStyle.Location = new System.Drawing.Point(793, 10);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(125, 20);
            this.txtStyle.TabIndex = 99;
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(302, 9);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(75, 23);
            this.cmdView.TabIndex = 97;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // masterDataGridView
            // 
            this.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDataGridView.Location = new System.Drawing.Point(12, 38);
            this.masterDataGridView.Name = "masterDataGridView";
            this.masterDataGridView.Size = new System.Drawing.Size(1018, 428);
            this.masterDataGridView.TabIndex = 91;
            this.masterDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.masterDataGridView_CellBeginEdit);
            this.masterDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Date";
            // 
            // date1
            // 
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date1.Location = new System.Drawing.Point(47, 10);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(103, 20);
            this.date1.TabIndex = 95;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(14, 501);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(73, 23);
            this.cmdSave.TabIndex = 92;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(257, 501);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(73, 23);
            this.cmdClose.TabIndex = 94;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(95, 501);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(73, 23);
            this.cmdDelete.TabIndex = 93;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(924, 8);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 23);
            this.cmdFind.TabIndex = 98;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Doc No";
            // 
            // txtDocNo
            // 
            this.txtDocNo.Location = new System.Drawing.Point(629, 10);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(125, 20);
            this.txtDocNo.TabIndex = 105;
            // 
            // sfBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 586);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDocNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.cmdXSD);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.cmdView);
            this.Controls.Add(this.masterDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdFind);
            this.Name = "sfBooking";
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.sfBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Button cmdXSD;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.DataGridView masterDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocNo;
    }
}