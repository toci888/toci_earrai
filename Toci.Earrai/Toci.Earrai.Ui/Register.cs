using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui
{
    public partial class Register : Form
    {
        DataManager Dm = new ();

        public Register()
        {
            InitializeComponent();

            passwordTextbox.PasswordChar = '*';
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            //User user = Dm.Register(,registerTextbox.Text, passwordTextbox.Text);

            //if (user != null)
            //{
            //    LogIn f = new LogIn();
            //    f.Show();
            //    Hide();
            //}
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LogIn f = new LogIn();
            f.Show();
            Hide();
        }
    }
}
