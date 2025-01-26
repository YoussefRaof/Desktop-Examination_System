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

namespace Examination_System.View.instractor
{
    public partial class ExamStatus : Form
    {
        private Form _Home;
        private string _email;

        public ExamStatus(Form Home, string email)
        {
            InitializeComponent();
            _Home = Home;
            _email = email;

            TableData.getData("ExamStatusView", "exam_name", search.Text, exam_status_table); //
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

        private void search_TextChanged(object sender, EventArgs e)
        {
            TableData.getData("ExamStatusView", "exam_name", search.Text, exam_status_table); //
        }
    }
}
