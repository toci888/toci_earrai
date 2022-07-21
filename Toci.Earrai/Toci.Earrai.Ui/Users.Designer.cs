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
            this.newUserButton = new System.Windows.Forms.Button();
            this.resetPasswordButton = new System.Windows.Forms.Button();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.retypePassTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwdNotMatchLabel = new System.Windows.Forms.Label();
            this.changePasswd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(617, 87);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(137, 61);
            this.submit.TabIndex = 0;
            this.submit.Text = "Change privileges";
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
            // newUserButton
            // 
            this.newUserButton.Location = new System.Drawing.Point(617, 175);
            this.newUserButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(137, 60);
            this.newUserButton.TabIndex = 7;
            this.newUserButton.Text = "Add User";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.Location = new System.Drawing.Point(12, 408);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(114, 30);
            this.resetPasswordButton.TabIndex = 8;
            this.resetPasswordButton.Text = "Disable account";
            this.resetPasswordButton.UseVisualStyleBackColor = true;
            this.resetPasswordButton.Click += new System.EventHandler(this.resetPasswordButton_Click);
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(63, 125);
            this.passTxt.Name = "passTxt";
            this.passTxt.Size = new System.Drawing.Size(296, 23);
            this.passTxt.TabIndex = 9;
            // 
            // retypePassTxt
            // 
            this.retypePassTxt.Location = new System.Drawing.Point(63, 175);
            this.retypePassTxt.Name = "retypePassTxt";
            this.retypePassTxt.Size = new System.Drawing.Size(296, 23);
            this.retypePassTxt.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Users list";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "New password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Retype new password";
            // 
            // passwdNotMatchLabel
            // 
            this.passwdNotMatchLabel.AutoSize = true;
            this.passwdNotMatchLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwdNotMatchLabel.ForeColor = System.Drawing.Color.Red;
            this.passwdNotMatchLabel.Location = new System.Drawing.Point(62, 206);
            this.passwdNotMatchLabel.Name = "passwdNotMatchLabel";
            this.passwdNotMatchLabel.Size = new System.Drawing.Size(137, 15);
            this.passwdNotMatchLabel.TabIndex = 14;
            this.passwdNotMatchLabel.Text = "Passwords do not match";
            // 
            // changePasswd
            // 
            this.changePasswd.Location = new System.Drawing.Point(62, 241);
            this.changePasswd.Name = "changePasswd";
            this.changePasswd.Size = new System.Drawing.Size(155, 23);
            this.changePasswd.TabIndex = 15;
            this.changePasswd.Text = "Change Password";
            this.changePasswd.UseVisualStyleBackColor = true;
            this.changePasswd.Click += new System.EventHandler(this.changePasswd_Click);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.changePasswd);
            this.Controls.Add(this.passwdNotMatchLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retypePassTxt);
            this.Controls.Add(this.passTxt);
            this.Controls.Add(this.resetPasswordButton);
            this.Controls.Add(this.newUserButton);
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
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Button resetPasswordButton;
        private System.Windows.Forms.TextBox passTxt;
        private System.Windows.Forms.TextBox retypePassTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label passwdNotMatchLabel;
        private System.Windows.Forms.Button changePasswd;
    }
}