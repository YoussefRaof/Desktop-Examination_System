using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.view.admin
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
            new LoginAdmin().Show();
        }

        private void info_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Information(_email, this).Show();
        }

        private void instractor_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ManageInstractors(this).Show();
        }

        private void student_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ManageStudents(this).Show();
        }

        private void branchTrack_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Branches_Tracks(this).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Courses_Topics(this).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Assign_Instractors(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Assign_Students(this).Show();
        }
    }
}
