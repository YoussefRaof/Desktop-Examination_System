using Examination_System.View.instractor;
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

namespace Examination_System.view.instractor
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
            new MakeExam(this, _email).Show();
        }

        private void result_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ShowResult(this, _email).Show();
        }

        private void examStatus_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Courses(this, _email).Show();
        }

        private void exam_status_btn_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            new ExamStatus(this, _email).Show();
        }
    }
}
