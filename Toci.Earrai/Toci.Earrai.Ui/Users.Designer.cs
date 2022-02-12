using System;

namespace Toci.Earrai.Ui
{
    partial class Users
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
            this.submit = new System.Windows.Forms.Button();
            this.allUsers = new System.Windows.Forms.ComboBox();
            this.userPrivelegeButton = new System.Windows.Forms.RadioButton();
            this.officePrivelegeButton = new System.Windows.Forms.RadioButton();
            this.pcPrivelegeButton = new System.Windows.Forms.RadioButton();
            this.adminPrivelegeButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(617, 87);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(137, 61);
            this.submit.TabIndex = 0;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // allUsers
            // 
            this.allUsers.FormattingEnabled = true;
            this.allUsers.Location = new System.Drawing.Point(63, 71);
            this.allUsers.Name = "allUsers";
            this.allUsers.Size = new System.Drawing.Size(296, 23);
            this.allUsers.TabIndex = 1;
            this.allUsers.SelectedIndexChanged += new System.EventHandler(this.allUsers_SelectedIndexChanged);
            // 
            // userPrivelegeButton
            // 
            this.userPrivelegeButton.AutoSize = true;
            this.userPrivelegeButton.Location = new System.Drawing.Point(440, 41);
            this.userPrivelegeButton.Name = "userPrivelegeButton";
            this.userPrivelegeButton.Size = new System.Drawing.Size(48, 19);
            this.userPrivelegeButton.TabIndex = 3;
            this.userPrivelegeButton.TabStop = true;
            this.userPrivelegeButton.Text = "User";
            this.userPrivelegeButton.UseVisualStyleBackColor = true;
            this.userPrivelegeButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // officePrivelegeButton
            // 
            this.officePrivelegeButton.AutoSize = true;
            this.officePrivelegeButton.Location = new System.Drawing.Point(440, 76);
            this.officePrivelegeButton.Name = "officePrivelegeButton";
            this.officePrivelegeButton.Size = new System.Drawing.Size(57, 19);
            this.officePrivelegeButton.TabIndex = 4;
            this.officePrivelegeButton.TabStop = true;
            this.officePrivelegeButton.Text = "Office";
            this.officePrivelegeButton.UseVisualStyleBackColor = true;
            this.officePrivelegeButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // pcPrivelegeButton
            // 
            this.pcPrivelegeButton.AutoSize = true;
            this.pcPrivelegeButton.Location = new System.Drawing.Point(440, 113);
            this.pcPrivelegeButton.Name = "pcPrivelegeButton";
            this.pcPrivelegeButton.Size = new System.Drawing.Size(38, 19);
            this.pcPrivelegeButton.TabIndex = 5;
            this.pcPrivelegeButton.TabStop = true;
            this.pcPrivelegeButton.Text = "Pc";
            this.pcPrivelegeButton.UseVisualStyleBackColor = true;
            this.pcPrivelegeButton.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // adminPrivelegeButton
            // 
            this.adminPrivelegeButton.AutoSize = true;
            this.adminPrivelegeButton.Location = new System.Drawing.Point(440, 147);
            this.adminPrivelegeButton.Name = "adminPrivelegeButton";
            this.adminPrivelegeButton.Size = new System.Drawing.Size(61, 19);
            this.adminPrivelegeButton.TabIndex = 6;
            this.adminPrivelegeButton.TabStop = true;
            this.adminPrivelegeButton.Text = "Admin";
            this.adminPrivelegeButton.UseVisualStyleBackColor = true;
            this.adminPrivelegeButton.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.adminPrivelegeButton);
            this.Controls.Add(this.pcPrivelegeButton);
            this.Controls.Add(this.officePrivelegeButton);
            this.Controls.Add(this.userPrivelegeButton);
            this.Controls.Add(this.allUsers);
            this.Controls.Add(this.submit);
            this.Name = "Users";
            this.Text = "Users";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.ComboBox allUsers;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.RadioButton userPrivelegeButton;
        private System.Windows.Forms.RadioButton officePrivelegeButton;
        private System.Windows.Forms.RadioButton pcPrivelegeButton;
        private System.Windows.Forms.RadioButton adminPrivelegeButton;
    }
}