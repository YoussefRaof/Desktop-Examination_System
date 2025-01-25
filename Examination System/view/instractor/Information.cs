using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.view.instractor
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();

            setDisabledItems();
            currentPass.UseSystemPasswordChar = true;
            newPass.UseSystemPasswordChar = true;
            confirmPass.UseSystemPasswordChar = true;
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
            if (currentPass.Text == "" || newPass.Text == "" || confirmPass.Text == "")
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
            this.Close();
            new Home().Show();
        }

        private void currentPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void newPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void confirmPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
