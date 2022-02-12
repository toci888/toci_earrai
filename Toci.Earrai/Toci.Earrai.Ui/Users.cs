using System;
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
    public partial class Users : Form
    {
        protected DataManager Dm = new DataManager();

        protected List<User> users;

        protected Dictionary<int, RadioButton> privelegeButtons = new();

        public Users()
        {
            InitializeComponent();

            TaskFactory taskFactory = new TaskFactory();
            Task<List<User>> taskUsers = taskFactory.StartNew(() => users = Dm.GetAllUsers());
            users = taskUsers.Result;

            Setup();
        }

        protected virtual void Setup()
        {
            allUsers.ValueMember = "Id";
            allUsers.DisplayMember = "Email";
            allUsers.DataSource = users;
            
            privelegeButtons.Add(1,userPrivelegeButton);
            privelegeButtons.Add(2,officePrivelegeButton);
            privelegeButtons.Add(3,pcPrivelegeButton);
            privelegeButtons.Add(4,adminPrivelegeButton);
        }

        private void allUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = (int)allUsers.SelectedValue;

            User user = users.First(m => m.Id == selectedId);

            privelegeButtons[user.Idrole].Checked = true;

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

        }
    }
}
