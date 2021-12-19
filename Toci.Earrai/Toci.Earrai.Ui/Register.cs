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

            registerValidation1.Text = registerValidation2.Text = registerValidation3.Text =
                registerValidation4.Text = registerValidation5.Text = "This field can't be empty!";

            registerValidation1.Visible = registerValidation2.Visible = registerValidation3.Visible =
                registerValidation4.Visible = registerValidation5.Visible = false;

            passwordtextBox2.PasswordChar = confirmPasswordtextBox.PasswordChar = '*';
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (passwordtextBox2 != confirmPasswordtextBox)
            {
                registerValidation4.Visible = registerValidation5.Visible = true;
                registerValidation4.Text = registerValidation5.Text = "Password must have the same value";
            }

            if (firstnameTextbox.Text == string.Empty)
            {
                registerValidation1.Visible = true;
            }
            if (lastnameTextbox.Text == string.Empty)
            {
                registerValidation2.Visible = true;
            }
            if (emailTextBox.Text == string.Empty)
            {
                registerValidation3.Visible = true;
            }
            if (passwordtextBox2.Text == string.Empty)
            {
                registerValidation4.Visible = true;
            }
            if (confirmPasswordtextBox.Text == string.Empty)
            {
                registerValidation5.Visible = true;
                return;
            }

            registerValidation1.Text = registerValidation2.Text = registerValidation3.Text =
                registerValidation4.Text = registerValidation5.Text = "This field can't be empty!";

            registerValidation1.Visible = registerValidation2.Visible = registerValidation3.Visible =
                registerValidation4.Visible = registerValidation5.Visible = false;

            User user = Dm.Register(firstnameTextbox.Text, lastnameTextbox.Text, emailTextBox.Text, passwordtextBox2.Text);

            if (user != null)
            {
                LogIn f = new LogIn();
                f.Show();
                Hide();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LogIn f = new LogIn();
            f.Show();
            Hide();
        }
    }
}
