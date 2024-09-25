using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    public partial class LoginForm : Form
    {
        Database1Entities dbe = new Database1Entities();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            tblUsers l = new tblUsers();

            foreach (var p in dbe.tblUsers)
            {
                if (p.userName == txtUserName.Text && p.password == txtPassword.Text)
                {
                    MessageBox.Show("Successfully Logged In");

                    Form1 f1 = new Form1();

                    f1.lblHello.Text = "User: " + p.userName;

                    f1.Show();

                    return;
                }
            }
            foreach (var p in dbe.tblUsers)
            {
                if (p.userName != txtUserName.Text || p.password != txtPassword.Text)
                {
                    MessageBox.Show("Wrong Username and/or Password.");
                    return;
                }
            }
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm rf1 = new RegisterForm();

            rf1.Show();
        }
    }
}
