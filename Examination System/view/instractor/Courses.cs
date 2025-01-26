using Examination_System.controller;
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
    public partial class Courses : Form
    {
        private Form _Home;
        private string _email;
        public Courses(Form home, string email)
        {
            InitializeComponent();
            _Home = home;
            _email = email;

            TableData.getData("CourseInsView", "crs_name", search.Text, courses_table); //
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Visible = true;
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            TableData.getData("CourseInsView", "crs_name", search.Text, courses_table); //
        }

        private void update_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
