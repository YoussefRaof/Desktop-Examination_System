using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Examination_System.controller;


namespace Examination_System.view.instractor
{
    public partial class ShowResult : Form
    {
        private Form _Home;
        private string _email;

        public ShowResult(Form home, string email)
        {
            InitializeComponent();
            _Home = home;
            _email = email;

            TableData.getData("GradeIndView", "_name", search.Text, grades_table); //
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Show();
        }


        private void report_btn_Click(object sender, EventArgs e)
        {
            TableData.generateReport(grades_table);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            TableData.getData("GradeIndView", "_name", search.Text, grades_table); //
        }
    }
}
