using Examination_System.View.student;
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
        public static string _email;

        public Home(string email)
        {
            InitializeComponent();
            _email = email;
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
            this.Visible = false;
            new Information(this, _email).Show();
        }

        private void exam_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ChoseExam(this, _email).Show();
        }

        private void result_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ShowResult(this, _email).Show();
        }

        private void courses_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Courses(this, _email).Show();
        }
    }
}
