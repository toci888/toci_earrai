﻿
namespace Toci.Earrai.Ui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showBtn = new System.Windows.Forms.Button();
            this.workbookDdl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.excelDataGrid = new System.Windows.Forms.DataGridView();
            this.internetConnection = new System.Windows.Forms.Label();
            this.SearchWorksheetBtn = new System.Windows.Forms.Button();
            this.KindDdl = new System.Windows.Forms.ComboBox();
            this.valueDdl = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.excelDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(995, 79);
            this.showBtn.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(280, 63);
            this.showBtn.TabIndex = 0;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // workbookDdl
            // 
            this.workbookDdl.FormattingEnabled = true;
            this.workbookDdl.Location = new System.Drawing.Point(235, 76);
            this.workbookDdl.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.workbookDdl.Name = "workbookDdl";
            this.workbookDdl.Size = new System.Drawing.Size(352, 23);
            this.workbookDdl.TabIndex = 1;
            this.workbookDdl.SelectedIndexChanged += new System.EventHandler(this.workbookDdl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Worksheet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(603, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search kind";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // excelDataGrid
            // 
            this.excelDataGrid.Location = new System.Drawing.Point(40, 181);
            this.excelDataGrid.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.excelDataGrid.Name = "excelDataGrid";
            this.excelDataGrid.RowHeadersWidth = 123;
            this.excelDataGrid.RowTemplate.Height = 25;
            this.excelDataGrid.Size = new System.Drawing.Size(1700, 565);
            this.excelDataGrid.TabIndex = 5;
            this.excelDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.excelDataGrid_CellClick);
           // this.excelDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.excelDataGrid_CellContentClick);
            // 
            // internetConnection
            // 
            this.internetConnection.AutoSize = true;
            this.internetConnection.Location = new System.Drawing.Point(0, 0);
            this.internetConnection.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.internetConnection.Name = "internetConnection";
            this.internetConnection.Size = new System.Drawing.Size(79, 15);
            this.internetConnection.TabIndex = 3;
            this.internetConnection.Text = "";
            this.internetConnection.Click += new System.EventHandler(this.internetConnection_Click);
            // 
            // SearchWorksheetBtn
            // 
            this.SearchWorksheetBtn.Location = new System.Drawing.Point(167, 111);
            this.SearchWorksheetBtn.Name = "SearchWorksheetBtn";
            this.SearchWorksheetBtn.Size = new System.Drawing.Size(188, 58);
            this.SearchWorksheetBtn.TabIndex = 6;
            this.SearchWorksheetBtn.Text = "Search";
            this.SearchWorksheetBtn.UseVisualStyleBackColor = true;
            this.SearchWorksheetBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // KindDdl
            // 
            this.KindDdl.FormattingEnabled = true;
            this.KindDdl.Location = new System.Drawing.Point(682, 79);
            this.KindDdl.Name = "KindDdl";
            this.KindDdl.Size = new System.Drawing.Size(302, 23);
            this.KindDdl.TabIndex = 7;
            this.KindDdl.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // valueDdl
            // 
            this.valueDdl.FormattingEnabled = true;
            this.valueDdl.Location = new System.Drawing.Point(682, 108);
            this.valueDdl.Name = "valueDdl";
            this.valueDdl.Size = new System.Drawing.Size(302, 23);
            this.valueDdl.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 850);
            this.Controls.Add(this.valueDdl);
            this.Controls.Add(this.KindDdl);
            this.Controls.Add(this.SearchWorksheetBtn);
            this.Controls.Add(this.excelDataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workbookDdl);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.internetConnection);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "Form1";
            this.Text = "Earrai";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.excelDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.ComboBox workbookDdl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label internetConnection;
        private System.Windows.Forms.DataGridView excelDataGrid;
        private System.Windows.Forms.Button SearchWorksheetBtn;
        private System.Windows.Forms.ComboBox KindDdl;
        private System.Windows.Forms.ComboBox valueDdl;
    }
}

