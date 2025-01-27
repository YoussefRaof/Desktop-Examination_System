using Examination_System.controller;
using Examination_System.Controller.StudentController;
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
    public partial class ShowResult : Form
    {
        private Form _Home;
        private string _email;
        private IStudentRepo studentMethods;

        public ShowResult(Form Home, string email)
        {
            InitializeComponent();
            _Home = Home;
            _email = email;
            search.Enabled = false;

            studentMethods = new StudentMethods();
            TableData.fillComboBoxAndTable(grades_table, "GetStudentGradesStatus", "ssn", studentMethods.getSSN("student", _email));
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
            TableData.getData("GradeStudView", "_name", search.Text, grades_table); //
        }
    }
}
