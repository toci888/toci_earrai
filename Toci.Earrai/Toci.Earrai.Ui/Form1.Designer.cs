
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
            this.queryTextbox = new System.Windows.Forms.TextBox();
            this.excelDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.excelDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(531, 25);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(115, 23);
            this.showBtn.TabIndex = 0;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = true;
            // 
            // workbookDdl
            // 
            this.workbookDdl.FormattingEnabled = true;
            this.workbookDdl.Location = new System.Drawing.Point(137, 26);
            this.workbookDdl.Name = "workbookDdl";
            this.workbookDdl.Size = new System.Drawing.Size(147, 23);
            this.workbookDdl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Workbook";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search clause";
            // 
            // queryTextbox
            // 
            this.queryTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.queryTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.queryTextbox.Location = new System.Drawing.Point(374, 26);
            this.queryTextbox.Name = "queryTextbox";
            this.queryTextbox.Size = new System.Drawing.Size(151, 23);
            this.queryTextbox.TabIndex = 4;
            this.queryTextbox.TextChanged += new System.EventHandler(this.queryTextbox_TextChanged);
            // 
            // excelDataGrid
            // 
            this.excelDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excelDataGrid.Location = new System.Drawing.Point(32, 88);
            this.excelDataGrid.Name = "excelDataGrid";
            this.excelDataGrid.RowTemplate.Height = 25;
            this.excelDataGrid.Size = new System.Drawing.Size(478, 207);
            this.excelDataGrid.TabIndex = 5;
            this.excelDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.excelDataGrid_CellClick);
            this.excelDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.excelDataGrid_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 563);
            this.Controls.Add(this.excelDataGrid);
            this.Controls.Add(this.queryTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workbookDdl);
            this.Controls.Add(this.showBtn);
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
        private System.Windows.Forms.TextBox queryTextbox;
        private System.Windows.Forms.DataGridView excelDataGrid;
    }
}

