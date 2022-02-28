
namespace Toci.Earrai.Ui
{
    partial class AddUser
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
            this.firstnameTextBox = new System.Windows.Forms.TextBox();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.adminPrivelegeButton = new System.Windows.Forms.RadioButton();
            this.pcPrivelegeButton = new System.Windows.Forms.RadioButton();
            this.officePrivelegeButton = new System.Windows.Forms.RadioButton();
            this.userPrivelegeButton = new System.Windows.Forms.RadioButton();
            this.firstnameValidationLabel = new System.Windows.Forms.Label();
            this.lastnameValidationLabel = new System.Windows.Forms.Label();
            this.emailValidationLabel = new System.Windows.Forms.Label();
            this.passwordValidationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.Location = new System.Drawing.Point(98, 49);
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(200, 39);
            this.firstnameTextBox.TabIndex = 0;
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Location = new System.Drawing.Point(98, 4);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(129, 32);
            this.firstnameLabel.TabIndex = 1;
            this.firstnameLabel.Text = "First Name";
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Location = new System.Drawing.Point(98, 133);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(126, 32);
            this.lastnameLabel.TabIndex = 2;
            this.lastnameLabel.Text = "Last Name";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(98, 270);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(82, 32);
            this.emailLabel.TabIndex = 3;
            this.emailLabel.Text = "E-Mail";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(98, 408);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(111, 32);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Location = new System.Drawing.Point(98, 177);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(200, 39);
            this.lastnameTextBox.TabIndex = 5;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(98, 310);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 39);
            this.emailTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(98, 455);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(200, 39);
            this.passwordTextBox.TabIndex = 7;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(498, 133);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(150, 109);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Add";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // adminPrivelegeButton
            // 
            this.adminPrivelegeButton.AutoSize = true;
            this.adminPrivelegeButton.Location = new System.Drawing.Point(343, 321);
            this.adminPrivelegeButton.Margin = new System.Windows.Forms.Padding(6);
            this.adminPrivelegeButton.Name = "adminPrivelegeButton";
            this.adminPrivelegeButton.Size = new System.Drawing.Size(115, 36);
            this.adminPrivelegeButton.TabIndex = 12;
            this.adminPrivelegeButton.TabStop = true;
            this.adminPrivelegeButton.Text = "Admin";
            this.adminPrivelegeButton.UseVisualStyleBackColor = true;
            // 
            // pcPrivelegeButton
            // 
            this.pcPrivelegeButton.AutoSize = true;
            this.pcPrivelegeButton.Location = new System.Drawing.Point(343, 248);
            this.pcPrivelegeButton.Margin = new System.Windows.Forms.Padding(6);
            this.pcPrivelegeButton.Name = "pcPrivelegeButton";
            this.pcPrivelegeButton.Size = new System.Drawing.Size(68, 36);
            this.pcPrivelegeButton.TabIndex = 11;
            this.pcPrivelegeButton.TabStop = true;
            this.pcPrivelegeButton.Text = "Pc";
            this.pcPrivelegeButton.UseVisualStyleBackColor = true;
            // 
            // officePrivelegeButton
            // 
            this.officePrivelegeButton.AutoSize = true;
            this.officePrivelegeButton.Location = new System.Drawing.Point(343, 169);
            this.officePrivelegeButton.Margin = new System.Windows.Forms.Padding(6);
            this.officePrivelegeButton.Name = "officePrivelegeButton";
            this.officePrivelegeButton.Size = new System.Drawing.Size(109, 36);
            this.officePrivelegeButton.TabIndex = 10;
            this.officePrivelegeButton.TabStop = true;
            this.officePrivelegeButton.Text = "Office";
            this.officePrivelegeButton.UseVisualStyleBackColor = true;
            // 
            // userPrivelegeButton
            // 
            this.userPrivelegeButton.AutoSize = true;
            this.userPrivelegeButton.Location = new System.Drawing.Point(343, 94);
            this.userPrivelegeButton.Margin = new System.Windows.Forms.Padding(6);
            this.userPrivelegeButton.Name = "userPrivelegeButton";
            this.userPrivelegeButton.Size = new System.Drawing.Size(92, 36);
            this.userPrivelegeButton.TabIndex = 9;
            this.userPrivelegeButton.TabStop = true;
            this.userPrivelegeButton.Text = "User";
            this.userPrivelegeButton.UseVisualStyleBackColor = true;
            // 
            // firstnameValidationLabel
            // 
            this.firstnameValidationLabel.AutoSize = true;
            this.firstnameValidationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.firstnameValidationLabel.ForeColor = System.Drawing.Color.Red;
            this.firstnameValidationLabel.Location = new System.Drawing.Point(49, 94);
            this.firstnameValidationLabel.Name = "firstnameValidationLabel";
            this.firstnameValidationLabel.Size = new System.Drawing.Size(282, 36);
            this.firstnameValidationLabel.TabIndex = 13;
            this.firstnameValidationLabel.Text = "First Name is required";
            // 
            // lastnameValidationLabel
            // 
            this.lastnameValidationLabel.AutoSize = true;
            this.lastnameValidationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lastnameValidationLabel.ForeColor = System.Drawing.Color.Red;
            this.lastnameValidationLabel.Location = new System.Drawing.Point(52, 219);
            this.lastnameValidationLabel.Name = "lastnameValidationLabel";
            this.lastnameValidationLabel.Size = new System.Drawing.Size(278, 36);
            this.lastnameValidationLabel.TabIndex = 14;
            this.lastnameValidationLabel.Text = "Last Name is required";
            // 
            // emailValidationLabel
            // 
            this.emailValidationLabel.AutoSize = true;
            this.emailValidationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.emailValidationLabel.ForeColor = System.Drawing.Color.Red;
            this.emailValidationLabel.Location = new System.Drawing.Point(52, 366);
            this.emailValidationLabel.Name = "emailValidationLabel";
            this.emailValidationLabel.Size = new System.Drawing.Size(228, 36);
            this.emailValidationLabel.TabIndex = 15;
            this.emailValidationLabel.Text = "E-Mail is required";
            // 
            // passwordValidationLabel
            // 
            this.passwordValidationLabel.AutoSize = true;
            this.passwordValidationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordValidationLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordValidationLabel.Location = new System.Drawing.Point(52, 497);
            this.passwordValidationLabel.Name = "passwordValidationLabel";
            this.passwordValidationLabel.Size = new System.Drawing.Size(264, 36);
            this.passwordValidationLabel.TabIndex = 16;
            this.passwordValidationLabel.Text = "Password is required";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.Controls.Add(this.passwordValidationLabel);
            this.Controls.Add(this.emailValidationLabel);
            this.Controls.Add(this.lastnameValidationLabel);
            this.Controls.Add(this.firstnameValidationLabel);
            this.Controls.Add(this.adminPrivelegeButton);
            this.Controls.Add(this.pcPrivelegeButton);
            this.Controls.Add(this.officePrivelegeButton);
            this.Controls.Add(this.userPrivelegeButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.lastnameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.lastnameLabel);
            this.Controls.Add(this.firstnameLabel);
            this.Controls.Add(this.firstnameTextBox);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstnameTextBox;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.RadioButton adminPrivelegeButton;
        private System.Windows.Forms.RadioButton pcPrivelegeButton;
        private System.Windows.Forms.RadioButton officePrivelegeButton;
        private System.Windows.Forms.RadioButton userPrivelegeButton;
        private System.Windows.Forms.Label firstnameValidationLabel;
        private System.Windows.Forms.Label lastnameValidationLabel;
        private System.Windows.Forms.Label emailValidationLabel;
        private System.Windows.Forms.Label passwordValidationLabel;
    }
}