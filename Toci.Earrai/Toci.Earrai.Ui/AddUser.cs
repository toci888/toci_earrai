﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui
{
    public partial class AddUser : Form
    {
        private Users usersForm;
        protected DataManager Dm = new DataManager();
        protected Dictionary<string, RadioButton> privelegeButtons = new();
        protected Dictionary<string, PrivilegesEnum> privilegesMap = new Dictionary<string, PrivilegesEnum>()
        {
            { "User", PrivilegesEnum.User },
            { "Office", PrivilegesEnum.Office },
            { "Pc", PrivilegesEnum.Pc },
            { "Admin", PrivilegesEnum.Admin }
        };

        protected Dictionary<TextBox, Label> validationLabels = new Dictionary<TextBox, Label>();

        public AddUser(Users usersForm)
        {
            InitializeComponent();

            userPrivelegeButton.Checked = true;

            privelegeButtons.Add("User", userPrivelegeButton);
            privelegeButtons.Add("Office", officePrivelegeButton);
            privelegeButtons.Add("Pc", pcPrivelegeButton);
            privelegeButtons.Add("Admin", adminPrivelegeButton);

            validationLabels.Add(firstnameTextBox, firstnameValidationLabel);
            validationLabels.Add(lastnameTextBox, lastnameValidationLabel);
            validationLabels.Add(emailTextBox, emailValidationLabel);
            validationLabels.Add(passwordTextBox, passwordValidationLabel);

            passwordTextBox.PasswordChar = '*';

            foreach (KeyValuePair<TextBox, Label> el in validationLabels)
            {
                el.Value.Visible = false;
            }

            this.usersForm = usersForm;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            foreach (KeyValuePair<TextBox, Label> el in validationLabels)
            {
                if (el.Key.Text == string.Empty)
                {
                    el.Value.Visible = true;
                    isValid = false;
                }
                else
                {
                    el.Value.Visible = false;
                }
            }

            if (!isValid)
            {
                return;
            }
            
            string priveleges = privelegeButtons.Where(m => m.Value.Checked == true).First().Key;

            User user = new User()
            {
                Firstname = firstnameTextBox.Text,
                Lastname = lastnameTextBox.Text,
                Email = emailTextBox.Text,
                Password = passwordTextBox.Text,
                Idrole = (int)privilegesMap[priveleges]
            };

            if (Dm.CreateUser(user) > 0)
            {
                MessageBox.Show("Account created.", "", MessageBoxButtons.OK);
                usersForm.UpdateUsers();

                Hide();
            }
            else
            {
                MessageBox.Show("Can't create account.", "", MessageBoxButtons.OK);
            }

        }
    }
}
