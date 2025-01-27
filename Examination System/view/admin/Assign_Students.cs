using Examination_System.controller;
using Examination_System.model;
using Examination_System.Model;
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
    public partial class Assign_Students : Form
    {
        private Form _Home;
        private string _adminEmail;
        private Student student;
        private IAdminRepo adminMethods;
        private Course course;

        public Assign_Students(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();
            _Home = home;
            _adminEmail = adminEmail;
            student = new Student();
            course = new Course();
            adminMethods = new AdminMethods();

            TableData.getData("studentDetails", "[Full Name]", search.Text, student_table);
            TableData.getData("courseView", "[Course Name]", search.Text, course_table);
            TableData.getData("studentAssignCourse", "crs_name", "", stud_course_table);
            //TableData.search("", "", search.Text, );
        }

        private void setDisabledItems()
        {
            search.Enabled = false;
        }

        private void setEnabledItems()
        {
            search.Enabled = true;
            search.Clear();
            search.Focus();
        }


        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Visible = true;
        }

        private void assign_btn_Click(object sender, EventArgs e)
        {

            if (student_table.SelectedRows.Count != 1 || course_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Student and Course).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int studentSSN = Convert.ToInt32(student_table.SelectedRows[0].Cells["SSN"].Value);


            int courseID = Convert.ToInt32(course_table.SelectedRows[0].Cells["crs_id"].Value);

            student.SSN = studentSSN;
            course.CourseId = courseID;




            int r = adminMethods.AssginStudentToCourse(student, course);


            if (r == 1)
            {
                MessageBox.Show("Student successfully assigned to the course.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableData.getData("studentAssignCourse", "crs_name", "", stud_course_table);

            }
            else if (r == 0)
                MessageBox.Show("Duplicate Entry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void topic_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void course_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (student_rbtn.Checked)
                TableData.getData("studentDetails", "[Full Name]", search.Text, student_table);
            else if (course_rbtn.Checked)
                TableData.getData("courseView", "[Course Name]", search.Text, course_table);
        }

        private void unassign_btn_Click(object sender, EventArgs e)
        {

            if (student_table.SelectedRows.Count != 1 || course_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Student and Course).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentSSN = Convert.ToInt32(student_table.SelectedRows[0].Cells["SSN"].Value);


            int courseID = Convert.ToInt32(course_table.SelectedRows[0].Cells["crs_id"].Value);

            student.SSN = studentSSN;
            course.CourseId = courseID;

            int r = adminMethods.UnAssignStudentToCourse(student, course);

            if (r == 1)
            {
                MessageBox.Show("Student successfully Unassigned to the course.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableData.getData("studentAssignCourse", "crs_name", "", stud_course_table);

            }
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
