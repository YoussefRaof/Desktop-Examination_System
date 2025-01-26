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
    public partial class Information : Form
    {
        private Admin admin;
        private IAdminRepo adminMethods;
        private Form _Home;

        public Information(Form home, string email)
        {
            InitializeComponent();

            setDisabledItems();
            currentPass.UseSystemPasswordChar = true;
            newPass.UseSystemPasswordChar = true;
            confirmPass.UseSystemPasswordChar = true;

            admin = new Admin();
            adminMethods = new AdminMethods();
            emailLabel.Text = email;
            _Home = home;
        }


        private void setDisabledItems()
        {
            edit_btn.Enabled = false;
        }

        private void setEnabledItems()
        {
            edit_btn.Enabled = true;
        }

        private void inputTextChange()
        {
            if (name.Text == "" || currentPass.Text == "" || newPass.Text == "" || confirmPass.Text == "")
                setDisabledItems();
            else
                setEnabledItems();
        }

        private void setData()
        {
            admin.Email = emailLabel.Text;
            admin.Id = adminMethods.getID("admin", admin.Email);
            admin.Name = name.Text;
            admin.Password = newPass.Text;
        }

        private bool checkData()
        {
            if (name.Text != string.Empty && currentPass.Text != string.Empty && newPass.Text != string.Empty && confirmPass.Text != string.Empty)
                if(newPass.Text == confirmPass.Text)
                    return true;

            return false;
        }


        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Visible = true;
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                setData();

                try
                {
                    if (adminMethods.checkPassword(currentPass.Text, "admin", admin.Email))
                    {
                        adminMethods.Update(admin);
                        MessageBox.Show("Successfuly Updated !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Update failed check your data !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
                MessageBox.Show("Update failed check your data !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void confirmPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void currentPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }
    }
}
