using Examination_System.controller;
using Examination_System.Controller.InstructorController;
using Examination_System.Controller.StudentController;
using Examination_System.view.student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.View.student
{
    public partial class ChoseExam : Form
    {
        private Form _Home;
        private string _email;
        private IStudentRepo studentMethods;

        public ChoseExam(Form Home, string email)
        {
            InitializeComponent();
            
            studentMethods = new StudentMethods();
            _Home = Home;
            _email = email;

            TableData.fillComboBoxAndTable(course_box, "stud_course", "ssn", studentMethods.getSSN("student", _email));
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

        private void next_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (course_box.Text != string.Empty)
                {
                    new TakeExam(_Home, _email, course_box.Text).Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Please select course!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
