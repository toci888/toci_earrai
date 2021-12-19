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
            Dictionary<TextBox, Label> map = new Dictionary<TextBox, Label>()
            {
                { firstnameTextbox, registerValidation1 },
                { lastnameTextbox, registerValidation2 },
                { emailTextBox, registerValidation3 },
                { passwordtextBox2, registerValidation4 },
                { confirmPasswordtextBox, registerValidation5 },
            };

            bool isValid = true;

            foreach (KeyValuePair<TextBox, Label> item in map)
            {
                if (item.Key.Text == string.Empty)
                {
                    item.Value.Visible = true;
                    isValid = false;
                }
                else
                {
                    item.Value.Visible = false;
                }
            }

            if (!isValid)
            {
                return;
            }

            if (passwordtextBox2.Text != confirmPasswordtextBox.Text)
            {
                registerValidation4.Visible = registerValidation5.Visible = true;
                registerValidation4.Text = registerValidation5.Text = "Password must have the same value";

                return;
            }

            registerValidation1.Text = registerValidation2.Text = registerValidation3.Text =
                registerValidation4.Text = registerValidation5.Text = "This field can't be empty!";

            registerValidation1.Visible = registerValidation2.Visible = registerValidation3.Visible =
                registerValidation4.Visible = registerValidation5.Visible = false;

            int userId = Dm.Register(firstnameTextbox.Text, lastnameTextbox.Text, emailTextBox.Text, passwordtextBox2.Text);

            if (userId > 0)
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
