﻿namespace Grading.Sample
{
    partial class findDocNo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStyleID = new System.Windows.Forms.TextBox();
            this.cmdFind = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.masterDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDocNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtStyleID);
            this.panel2.Location = new System.Drawing.Point(12, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 77);
            this.panel2.TabIndex = 126;
            // 
            // txtDocNo
            // 
            this.txtDocNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtDocNo.Location = new System.Drawing.Point(87, 13);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(211, 20);
            this.txtDocNo.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "StyleID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Document No";
            // 
            // txtStyleID
            // 
            this.txtStyleID.Location = new System.Drawing.Point(87, 39);
            this.txtStyleID.Name = "txtStyleID";
            this.txtStyleID.Size = new System.Drawing.Size(211, 20);
            this.txtStyleID.TabIndex = 68;
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(12, 386);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 23);
            this.cmdFind.TabIndex = 127;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(93, 386);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 128;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // masterDataGridView
            // 
            this.masterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDataGridView.Location = new System.Drawing.Point(12, 12);
            this.masterDataGridView.Name = "masterDataGridView";
            this.masterDataGridView.ReadOnly = true;
            this.masterDataGridView.Size = new System.Drawing.Size(631, 264);
            this.masterDataGridView.TabIndex = 129;
            this.masterDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellContentClick);
            this.masterDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterDataGridView_CellDoubleClick);
            // 
            // findDocNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 414);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.masterDataGridView);
            this.Name = "findDocNo";
            this.Text = "findDocNo";
            this.Load += new System.EventHandler(this.findDocNo_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStyleID;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView masterDataGridView;
    }
}