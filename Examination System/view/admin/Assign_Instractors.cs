using Examination_System.controller;
using Examination_System.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.view.admin
{
    public partial class Assign_Instractors : Form
    {
        private Form _Home;
        private string _adminEmail;
        private IAdminRepo adminMethods;
        private Course course;
        private Instructor instructor;

        public Assign_Instractors(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();
            _Home = home;
            _adminEmail = adminEmail;
            adminMethods = new AdminMethods();
            instructor = new Instructor();
            course = new Course();


            TableData.getData("instructorView", "ins_name", search.Text, instractor_table);
            TableData.getData("courseView", "[Course Name]", search.Text, course_table);
            TableData.getData("instructorTeachCourse", "crs_name", "", ins_course_table);

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

        private void instractor_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void course_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (instractor_rbtn.Checked)
                TableData.getData("instructorView", "ins_name", search.Text, instractor_table);
            else if (course_rbtn.Checked)
                TableData.getData("courseView", "[Course Name]", search.Text, course_table);
        }

        private void assign_btn_Click(object sender, EventArgs e)
        {


            if (instractor_table.SelectedRows.Count != 1 || course_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Instructor and Course).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int instructorID = Convert.ToInt32(instractor_table.SelectedRows[0].Cells["ins_id"].Value);


            int courseID = Convert.ToInt32(course_table.SelectedRows[0].Cells["crs_id"].Value);

            instructor.Id = instructorID;
            course.CourseId = courseID;




            int r = adminMethods.AssginInstructorToCourse(instructor, course);


            if (r == 1)
            {
                MessageBox.Show("Instructor successfully assigned to the course.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableData.getData("instructorTeachCourse", "crs_name", "", ins_course_table);

            }
            else if (r == 0)
                MessageBox.Show("Duplicate Entry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }



        private void unassign_btn_Click(object sender, EventArgs e)
        {
            if (instractor_table.SelectedRows.Count != 1 || course_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Instructor and Course).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int instructorID = Convert.ToInt32(instractor_table.SelectedRows[0].Cells["ins_id"].Value);


            int courseID = Convert.ToInt32(course_table.SelectedRows[0].Cells["crs_id"].Value);

            instructor.Id = instructorID;
            course.CourseId = courseID;

            int r = adminMethods.UnAssignInstructorToCourse(instructor, course);

            if (r == 1)
            {
                MessageBox.Show("Instructor successfully Unassigned to the course.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableData.getData("instructorTeachCourse", "crs_name", "", ins_course_table);

            }
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }
    }
}
