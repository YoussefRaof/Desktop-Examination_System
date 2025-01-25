using Examination_System.controller;
using Examination_System.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Examination_System.view.admin
{
    public partial class LoginAdmin : Form
    {
        private Admin admin;
        private IAdminRepo adminMethods;
        public LoginAdmin()
        {
            InitializeComponent();

            setDisabledItems();
            password.UseSystemPasswordChar = true;
            admin = new Admin();
            adminMethods = new AdminMethods();
        }

        private void setDisabledItems()
        {
            login_btn.Enabled = false;
            clear_btn.Enabled = false;
        }

        private void setEnabledItems()
        {
            login_btn.Enabled = true;
            clear_btn.Enabled = true;
        }

        private void inputTextChange()
        {
            if (email.Text.Equals("") || password.Text.Equals(""))
                setDisabledItems();
            else
                setEnabledItems();
        }

        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            new SignUpAdmin().Show();
            this.Close();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {

            setData();

            var r= adminMethods.Login(admin);
            if (r == true)
            {
                MessageBox.Show("Successfuly Login !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new admin.Home(email.Text).Show();
                this.Close();
            }

            else
                MessageBox.Show("Faild to Login!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //if (true) ///
            //{
            //    MessageBox.Show("Successfuly Login !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    new admin.Home(email.Text).Show();
                //    this.Close();
                //}
        }
        private void setData()
        {
            //admin.Id = adminMethods.getID(admin.Email); 
            admin.Email = email.Text;
            admin.Password = password.Text;
        }
        private void clear_btn_Click(object sender, EventArgs e)
        {
            email.Text = "";
            password.Text = "";
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }
    }
}
