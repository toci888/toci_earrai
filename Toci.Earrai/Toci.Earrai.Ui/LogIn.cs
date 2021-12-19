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
    public partial class LogIn : Form
    {
        DataManager Dm = new DataManager();

        public LogIn()
        {
            InitializeComponent();

            passwordTextbox.PasswordChar = '*';
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            User user = Dm.Login(loginTextBox.Text, passwordTextbox.Text);

            if (user != null)
            {
                Form1 f = new Form1(user);
                f.Show();
                Hide();
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
