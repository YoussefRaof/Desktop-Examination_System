using Examination_System.controller;
using Examination_System.model;
using Examination_System.view.admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.view
{
    public partial class SignUpAdmin : Form
    {
        private Admin admin;
        private IAdminRepo adminMethods;

        public SignUpAdmin()
        {
            InitializeComponent();

            setDisabledItems();
            password.UseSystemPasswordChar = true;
            confirmPassword.UseSystemPasswordChar = true;

            admin = new Admin();
            adminMethods = new AdminMethods();
        }

        private void setDisabledItems()
        {
            createAcc_btn.Enabled = false;
            clear_btn.Enabled = false;
        }

        private void setEnabledItems()
        {
            createAcc_btn.Enabled = true;
            clear_btn.Enabled = true;
        }

        private void setData()
        {
            admin.Name = username.Text;
            admin.Email = email.Text;
            admin.Password = password.Text;
        }

        private bool checkData()
        {
            if (username.Text != string.Empty && email.Text != string.Empty && password.Text != string.Empty && confirmPassword.Text != string.Empty)
                return true;

            return false;
        }

        private void inputTextChange()
        {
            if (username.Text.Equals("") || email.Text.Equals("") ||
                password.Text.Equals("") || confirmPassword.Text.Equals(""))
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
            new LoginAdmin().Show();
            this.Close(); 
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            username.Text = "";
            email.Text = "";
            password.Text = "";
            confirmPassword.Text = "";
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void confirmPassword_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void createAcc_btn_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                setData();
                adminMethods.Insert(admin);

                MessageBox.Show("Account Successfuly Created !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                new LoginAdmin().Show();
            }

        }
    }
}
