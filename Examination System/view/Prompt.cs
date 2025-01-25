using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Examination_System.view
{
    public partial class Prompt : Form
    {
        private Form loginForm;
        public Prompt(Login login)
        {
            InitializeComponent();
            this.loginForm = login;
            this.MaximizeBox = false;

            password.Focus();
            setDisabledItems();
            password.UseSystemPasswordChar = true;            
        }

        private void setDisabledItems()
        {
            ok_btn.Enabled = false;
        }

        private void setEnabledItems()
        {
            ok_btn.Enabled = true;
        }


        ////////////////////////////////////////////////////////////


        private void password_TextChanged(object sender, EventArgs e)
        {
            if (password.Text.Equals(""))
                setDisabledItems();
            else
                setEnabledItems();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            string userInput = password.Text;
            
            if(userInput == "admin")
            {
                this.Close();
                loginForm.Close();

                new admin.LoginAdmin().Show();
            }
            else
                MessageBox.Show("Wrong Password!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
