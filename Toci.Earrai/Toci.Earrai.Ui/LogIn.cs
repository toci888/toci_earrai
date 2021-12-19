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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = Dm.Login("user@wp.pl", "123456789");

            if (user != null)
            {
                //passwordTextbox.Text
                Form1 f = new Form1(user);
                f.Show();
                Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
