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
        public ShowResult()
        {
            InitializeComponent();
            TableData.show("Stud_Course", grades_table);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }


        private void report_btn_Click(object sender, EventArgs e)
        {
            TableData.generateReport(grades_table);
        }

    }
}
