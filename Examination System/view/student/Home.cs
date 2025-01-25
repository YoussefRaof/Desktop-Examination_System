using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.view.student
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void info_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            new Information().Show();
        }

        private void exam_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                new TakeExam().Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void result_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            new ShowResult().Show();
        }
    }
}
