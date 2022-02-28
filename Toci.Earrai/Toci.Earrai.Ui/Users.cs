﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui
{
    public partial class Users : Form
    {
        protected DataManager Dm = new DataManager();

        protected List<Userrole> users;

        protected Dictionary<string, RadioButton> privelegeButtons = new();

        protected Dictionary<string, PrivilegesEnum> privilegesMap = new Dictionary<string, PrivilegesEnum>()
        {
            { "User", PrivilegesEnum.User },
            { "Office", PrivilegesEnum.Office },
            { "Pc", PrivilegesEnum.Pc },
            { "Admin", PrivilegesEnum.Admin }
        };
        public Users()
        {
            InitializeComponent();

            users = Dm.GetAllUsers();

            Setup();
        }

        protected virtual void Setup()
        {
            privelegeButtons.Add("User", userPrivelegeButton);
            privelegeButtons.Add("Office", officePrivelegeButton);
            privelegeButtons.Add("Pc", pcPrivelegeButton);
            privelegeButtons.Add("Admin", adminPrivelegeButton);

            allUsers.ValueMember = "Id";
            allUsers.DisplayMember = "Email";
            allUsers.DataSource = users;
        }

        private void allUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = (int)allUsers.SelectedValue;

            Userrole user = users.First(m => m.Id == selectedId);

            privelegeButtons[user.Name].Checked = true;

            //foreach (KeyValuePair<int, RadioButton> btn in privelegeButtons)
            //{
            //    if (btn.Key == user.Idrole)
            //    {
            //        btn.Value.Checked = true;
            //    }
            //}
            //var currentUser = privelegeButtons.First(x => x.Key == user.Idrole);

        }

        private void submit_Click(object sender, EventArgs e)
        {
            Userrole user = (Userrole)allUsers.SelectedItem;

            string priveleges = privelegeButtons.Where(m => m.Value.Checked == true).First().Key;

            Dm.ChangePrivileges(new User() {Id = user.Id.Value}, (int)privilegesMap[priveleges]);
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            Userrole user = (Userrole)allUsers.SelectedItem;

            Dm.ResetPassword(user.Id.Value, "XD");
        }
    }
}