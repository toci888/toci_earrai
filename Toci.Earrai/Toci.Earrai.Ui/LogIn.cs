using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.Common;
using Toci.Earrai.Bll.ErrorLog;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui
{
    public partial class LogIn : Form
    {
        DataManager Dm = new DataManager();

        public LogIn()
        {
            InitializeComponent();

            GlobalExceptionHandler Geh = new GlobalExceptionHandler(new EarraiErrorLogger());
            Geh.ActivateGlobalExceptionHandling();

            loginValidation1.Visible = loginValidation2.Visible = false;

            loginValidation1.Text = loginValidation2.Text = "This field can't be empty!";

            passwordTextbox.PasswordChar = '*';

            loginTextBox.Text = "admin@wp.pl";
            passwordTextbox.Text = "123456783";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == string.Empty)
            {
                loginValidation1.Visible = true;
            }

            if (passwordTextbox.Text == string.Empty)
            {
                loginValidation2.Visible = true;
                return;
            }

            loginValidation1.Visible = false;
            loginValidation2.Visible = false;

            Userrole user = Dm.Login(loginTextBox.Text, passwordTextbox.Text);

            if (user != null)
            {
                LoggedUserContext.User = user;
                Form1 f = new Form1(user, this);
                f.Show();
                Hide();
            }
            else
            {
                loginValidation2.Visible = true;
                loginValidation2.Text = "Wrong credentials.";
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register f = new Register();
            f.Show();
            Hide();
        }
    }
}
