
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

        protected int clientX = 1800;
        protected int clientY = 850;

        //protected Font LayoutFont = new System.Drawing.Font("Calibri", 10);

        //protected List<Control> UiControls = new List<Control>();
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
            this.logout = new System.Windows.Forms.Button();
            this.users = new System.Windows.Forms.Button();
            this.addNewProductButton = new System.Windows.Forms.Button();
            this.sageExportButton = new System.Windows.Forms.Button();
            this.sageImportButton = new System.Windows.Forms.Button();
            this.stockTakeValueMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stockTakeValueMax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.excelDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(1344, 81);
            this.showBtn.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(280, 63);
            this.showBtn.TabIndex = 0;
            this.showBtn.Text = "Filter";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // workbookDdl
            // 
            this.workbookDdl.FormattingEnabled = true;
            this.workbookDdl.Location = new System.Drawing.Point(219, 81);
            this.workbookDdl.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.workbookDdl.Name = "workbookDdl";
            this.workbookDdl.Size = new System.Drawing.Size(352, 49);
            this.workbookDdl.TabIndex = 1;
            this.workbookDdl.SelectedIndexChanged += new System.EventHandler(this.workbookDdl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(70, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Worksheet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(603, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search kind";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // excelDataGrid
            // 
            this.excelDataGrid.ColumnHeadersHeight = 58;
            this.excelDataGrid.Location = new System.Drawing.Point(31, 290);
            this.excelDataGrid.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.excelDataGrid.Name = "excelDataGrid";
            this.excelDataGrid.RowHeadersWidth = 123;
            this.excelDataGrid.RowTemplate.Height = 25;
            this.excelDataGrid.Size = new System.Drawing.Size(3552, 1513);
            this.excelDataGrid.TabIndex = 5;
            this.excelDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.excelDataGrid_CellClick);
            // 
            // internetConnection
            // 
            this.internetConnection.AutoSize = true;
            this.internetConnection.Location = new System.Drawing.Point(0, 0);
            this.internetConnection.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.internetConnection.Name = "internetConnection";
            this.internetConnection.Size = new System.Drawing.Size(0, 41);
            this.internetConnection.TabIndex = 3;
            this.internetConnection.Click += new System.EventHandler(this.internetConnection_Click);
            // 
            // SearchWorksheetBtn
            // 
            this.SearchWorksheetBtn.Location = new System.Drawing.Point(167, 173);
            this.SearchWorksheetBtn.Name = "SearchWorksheetBtn";
            this.SearchWorksheetBtn.Size = new System.Drawing.Size(188, 58);
            this.SearchWorksheetBtn.TabIndex = 6;
            this.SearchWorksheetBtn.Text = "Show All";
            this.SearchWorksheetBtn.UseVisualStyleBackColor = true;
            this.SearchWorksheetBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // KindDdl
            // 
            this.KindDdl.FormattingEnabled = true;
            this.KindDdl.Location = new System.Drawing.Point(907, 76);
            this.KindDdl.Name = "KindDdl";
            this.KindDdl.Size = new System.Drawing.Size(360, 49);
            this.KindDdl.TabIndex = 7;
            this.KindDdl.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // valueDdl
            // 
            this.valueDdl.FormattingEnabled = true;
            this.valueDdl.Location = new System.Drawing.Point(907, 158);
            this.valueDdl.Name = "valueDdl";
            this.valueDdl.Size = new System.Drawing.Size(360, 49);
            this.valueDdl.TabIndex = 8;
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(2138, 79);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(126, 51);
            this.logout.TabIndex = 9;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // users
            // 
            this.users.Location = new System.Drawing.Point(2138, 148);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(126, 49);
            this.users.TabIndex = 10;
            this.users.Text = "Users";
            this.users.UseVisualStyleBackColor = true;
            this.users.Click += new System.EventHandler(this.users_Click);
            // 
            // addNewProductButton
            // 
            this.addNewProductButton.Location = new System.Drawing.Point(399, 173);
            this.addNewProductButton.Name = "addNewProductButton";
            this.addNewProductButton.Size = new System.Drawing.Size(154, 58);
            this.addNewProductButton.TabIndex = 11;
            this.addNewProductButton.Text = "New Product";
            this.addNewProductButton.UseVisualStyleBackColor = true;
            this.addNewProductButton.Click += new System.EventHandler(this.addNewProductButton_Click);
            // 
            // sageExportButton
            // 
            this.sageExportButton.Location = new System.Drawing.Point(1663, 156);
            this.sageExportButton.Name = "sageExportButton";
            this.sageExportButton.Size = new System.Drawing.Size(223, 51);
            this.sageExportButton.TabIndex = 12;
            this.sageExportButton.Text = "Sage Export";
            this.sageExportButton.UseVisualStyleBackColor = true;
            this.sageExportButton.Click += new System.EventHandler(this.sageExportButton_Click);
            // 
            // sageImportButton
            // 
            this.sageImportButton.Location = new System.Drawing.Point(1663, 87);
            this.sageImportButton.Name = "sageImportButton";
            this.sageImportButton.Size = new System.Drawing.Size(223, 49);
            this.sageImportButton.TabIndex = 13;
            this.sageImportButton.Text = "Sage Import";
            this.sageImportButton.UseVisualStyleBackColor = true;
            this.sageImportButton.Click += new System.EventHandler(this.sageImportButton_Click);
            // 
            // stockTakeValueMin
            // 
            this.stockTakeValueMin.Location = new System.Drawing.Point(991, 231);
            this.stockTakeValueMin.Name = "stockTakeValueMin";
            this.stockTakeValueMin.Size = new System.Drawing.Size(100, 47);
            this.stockTakeValueMin.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(612, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 41);
            this.label3.TabIndex = 15;
            this.label3.Text = "Balance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(907, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 41);
            this.label4.TabIndex = 16;
            this.label4.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1097, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 41);
            this.label5.TabIndex = 17;
            this.label5.Text = "Max";
            // 
            // stockTakeValueMax
            // 
            this.stockTakeValueMax.Location = new System.Drawing.Point(1167, 234);
            this.stockTakeValueMax.Name = "stockTakeValueMax";
            this.stockTakeValueMax.Size = new System.Drawing.Size(100, 47);
            this.stockTakeValueMax.TabIndex = 18;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(2293, 954);
            this.Controls.Add(this.stockTakeValueMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stockTakeValueMin);
            this.Controls.Add(this.sageImportButton);
            this.Controls.Add(this.sageExportButton);
            this.Controls.Add(this.addNewProductButton);
            this.Controls.Add(this.users);
            this.Controls.Add(this.logout);
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

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            /*Size gridSize = excelDataGrid.Size;

            gridSize.Width += ((Form1)sender).ClientSize.Width - clientX;
            gridSize.Height += ((Form1)sender).ClientSize.Height - clientY;

            clientX = ((Form1)sender).ClientSize.Width;
            clientY = ((Form1)sender).ClientSize.Height;

            excelDataGrid.Size = gridSize;*/
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
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button users;
        private System.Windows.Forms.Button addNewProductButton;
        private System.Windows.Forms.Button sageExportButton;
        private System.Windows.Forms.Button sageImportButton;
        private TextBox stockTakeValueMin;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox stockTakeValueMax;
    }
}

