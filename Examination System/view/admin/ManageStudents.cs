using Examination_System.controller;
using Examination_System.Controller.InstructorController;
using Examination_System.Controller.StudentController;
using Examination_System.model;
using Examination_System.Model;
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
    public partial class ManageStudents : Form
    {
        private Form _Home;
        private string _adminEmail;

        private Student student;
        private IStudentRepo studentMethods;
        private IAdminRepo adminMethods;

        public ManageStudents(Form home, string adminEmail)
        {
            InitializeComponent();
            TableData.getData("studentView", "stud_fname", search.Text, students_table);
            _Home = home;
            _adminEmail = adminEmail;

            student = new Student();
            studentMethods = new StudentMethods();
            adminMethods = new AdminMethods();
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

        private void insert_btn_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                setData();

                int rowCount = students_table.RowCount;

                studentMethods.Insert(student);
                TableData.getData("studentView", "stud_fname", search.Text, students_table);


                if (students_table.RowCount == rowCount + 1)
                    MessageBox.Show("Student Created Successfuly !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Student Created failed !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                clearData();
            }
            else
            {
                MessageBox.Show("Please Enter Student Data!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearData()
        {
            ssn.Text = string.Empty;
            fname.Text = string.Empty;
            lname.Text = string.Empty;
            email.Text = string.Empty;
            phone.Text = string.Empty;
            address.Text = string.Empty;
            gender.Text = string.Empty;
            track_id.Text = string.Empty;
            birthdate.Text = string.Empty;
        }

        private void setData()
        {
            student.SSN = Convert.ToInt32(ssn.Text);
            student.FName = fname.Text;
            student.LName = lname.Text;
            if (email.Text.Contains("@"))
            {

                student.Email = email.Text;
            }
            else
            {
                MessageBox.Show("Make Sure Email Conatins @ !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearData();
                return;

            }

            student.Phone = phone.Text;
            student.Address = address.Text;
            student.Gender = (Gender)Enum.Parse(typeof(Gender), gender.Text);
            student.TrackId = Convert.ToInt32(track_id.Text);
            student.BirthDate = birthdate.Value.ToString("yyyy-MM-dd");
            student.AdminId = adminMethods.getID("admin", _adminEmail);
        }

        private bool checkData()
        {
            if (ssn.Text != string.Empty
                && fname.Text != string.Empty
                && lname.Text != string.Empty
                && email.Text != string.Empty
                && phone.Text != string.Empty
                && address.Text != string.Empty
                && gender.Text != string.Empty
                && track_id.Text != string.Empty
                && birthdate.Text != string.Empty)
                return true;

            return false;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (students_table.SelectedRows.Count == 1)
            {

                DataGridViewRow selectedRow = students_table.SelectedRows[0];


                if (selectedRow.Cells["SSN"] != null && int.TryParse(selectedRow.Cells["SSN"].Value.ToString(), out int studentSSN))
                {

                    student.SSN = studentSSN;
                    if (fname.Text == string.Empty)
                    {
                        student.FName = selectedRow.Cells["stud_fname"].Value.ToString();
                    }
                    else
                    {
                        student.FName = fname.Text;
                    }

                    if (lname.Text == string.Empty)
                    {
                        student.LName = selectedRow.Cells["stud_lname"].Value.ToString();
                    }
                    else
                    {
                        student.LName = lname.Text;
                    }




                    if (email.Text == string.Empty)
                    {
                        student.Email = selectedRow.Cells["stud_email"].Value.ToString();
                    }
                    else
                    {
                        student.Email = email.Text;
                    }


                    if (phone.Text == string.Empty)
                    {
                        student.Phone = selectedRow.Cells["stud_phone"].Value.ToString();
                    }
                    else
                    {
                        student.Phone = phone.Text;
                    }

                    //Address
                    if (address.Text == string.Empty)
                    {
                        student.Address = selectedRow.Cells["stud_address"].Value.ToString();
                    }
                    else
                    {
                        student.Address = address.Text;
                    }


                    //Gender
                    if (gender.Text == string.Empty)
                    {
                        student.Gender = (Gender)Enum.Parse(typeof(Gender), selectedRow.Cells["stud_gender"].Value.ToString());
                    }
                    else
                    {
                        student.Gender = (Gender)Enum.Parse(typeof(Gender), gender.Text);
                    }


                    student.BirthDate = birthdate.Value.ToString("yyyy-MM-dd");


                    //DataGridViewRow row = students_table.SelectedRows[0];
                    //student.BirthDate = row.Cells["stud_birthdate"].Value?.ToString();


                    //Bdate

                    //if (birthdate.Text == string.Empty)
                    //{
                    //    student.BirthDate= selectedRow.Cells["stud_birthdate"].Value.ToString();
                    //}
                    //else
                    //{
                    //    student.BirthDate= birthdate.Value.ToString("yyyy-MM-dd");
                    //}

                    //TrackId

                    if (track_id.Text == string.Empty)
                    {
                        student.TrackId = Convert.ToInt32(selectedRow.Cells["track_id_FK"].Value.ToString());
                    }
                    else
                    {
                        student.TrackId = Convert.ToInt32(track_id.Text);
                    }

                    student.TrackId = int.TryParse(track_id.Text, out int TrackValue) ? TrackValue : Convert.ToInt32(selectedRow.Cells["track_id_FK"].Value.ToString());


                    student.Gender = Enum.TryParse(gender.Text, out Gender Value) ? Value : (Gender)Enum.Parse(typeof(Gender), (selectedRow.Cells["stud_gender"].Value.ToString()));




                    var confirmation = MessageBox.Show($"Are you sure you want to update Student with SSN {studentSSN}?",
                                                       "Confirmation",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Yes)
                    {

                        studentMethods.Update(student, null);


                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearData();

                        TableData.getData("studentView", "stud_fname", search.Text, students_table);
                    }

                }
                else
                {
                    MessageBox.Show("Unable to retrieve the student's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (students_table.SelectedRows.Count == 1)
            {

                DataGridViewRow selectedRow = students_table.SelectedRows[0];


                if (selectedRow.Cells["SSN"] != null && int.TryParse(selectedRow.Cells["SSN"].Value.ToString(), out int StudentSSN))
                {

                    var confirmation = MessageBox.Show($"Are you sure you want to delete student with ID {StudentSSN}?",
                                                       "Confirmation",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);

                    int rowCount = students_table.RowCount;
                    if (confirmation == DialogResult.Yes)
                    {
                        student.SSN = StudentSSN;

                        studentMethods.Delete(student);
                        TableData.getData("studentView", "stud_fname", search.Text, students_table);

                        if (students_table.RowCount == rowCount - 1)
                            MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Student deleted failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to retrieve the Student's SSN. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            TableData.getData("studentView", "stud_fname", search.Text, students_table);
        }


        private void students_table_SelectionChanged(object sender, EventArgs e)
        {
            if (students_table.SelectedRows.Count > 0)
            {
                DataGridViewRow row = students_table.SelectedRows[0];
                DateTime existingBirthDate;
                if (DateTime.TryParse(row.Cells["stud_birthdate"].Value?.ToString(), out existingBirthDate))
                {
                    birthdate.Value = existingBirthDate;
                }
            }
        }

    }
}
