using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Examination_System.controller;
using Examination_System.Controller.InstructorController;
using Examination_System.model;
//using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Examination_System.view.admin
{
    public partial class ManageInstractors : Form
    {
        private Form _Home;
        
        private Instructor instructor;
        private IInstructorRepo instructorMethods;

        public ManageInstractors(Form home)
        {
            InitializeComponent();
            TableData.show("Instructor", instractors_table);
            _Home = home;
            instructor = new Instructor();
            instructorMethods = new InstructorMethods();
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

        private void setData()
        {
            instructor.Name = name.Text;
            instructor.Email = email.Text;
            instructor.Phone = phone.Text;
            instructor.Salary = Convert.ToInt32(salary.Text);
            instructor.AdminId = GetAdminIdByEmail(Home._email);

        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                setData();
                instructorMethods.Insert(instructor);
                MessageBox.Show("Instructor Created Successfuly !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableData.show("Instructor", instractors_table);
                name.Text= string.Empty;
                email.Text= string.Empty;
                phone.Text= string.Empty;
                salary.Text= string.Empty;


            }
            else
            {
                MessageBox.Show("Please Enter Instructor Data!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool checkData()
        {
            if (name.Text != string.Empty && email.Text != string.Empty && phone.Text != string.Empty && salary.Text != string.Empty)
                return true;

            return false;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (instractors_table.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = instractors_table.SelectedRows[0];

                
                if (selectedRow.Cells["ins_id"] != null && int.TryParse(selectedRow.Cells["ins_id"].Value.ToString(), out int instructorId))
                {
                    
                    instructor.Id = instructorId; 
                    if(name.Text ==string.Empty)
                    {
                        instructor.Name = selectedRow.Cells["ins_name"].Value.ToString();
                    }
                    else
                    {
                        instructor.Name = name.Text;
                    }


                    if (email.Text == string.Empty)
                    {
                        instructor.Email = selectedRow.Cells["ins_email"].Value.ToString();
                    }
                    else
                    {
                        instructor.Email = email.Text;
                    }


                    if (phone.Text == string.Empty)
                    {
                        instructor.Phone = selectedRow.Cells["ins_phone"].Value.ToString();
                    }
                    else
                    {
                        instructor.Phone = phone.Text;
                    }

                    if (salary.Text == string.Empty)
                    {
                        instructor.Salary = Convert.ToInt32(selectedRow.Cells["ins_salary"].Value.ToString());
                    }
                    else
                    {
                        instructor.Salary = Convert.ToInt32(salary.Text);
                    }






                    instructor.Salary = int.TryParse(salary.Text, out int salaryValue) ? salaryValue : Convert.ToInt32(selectedRow.Cells["ins_salary"].Value.ToString());

                    //if (ValidateInstructorData(instructor))
                    //{
                        
                        var confirmation = MessageBox.Show($"Are you sure you want to update instructor with ID {instructorId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        if (confirmation == DialogResult.Yes)
                        {
                           
                            instructorMethods.Update(instructor);

                            
                            TableData.show("Instructor", instractors_table);

                            MessageBox.Show("Instructor updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Please ensure at least one field is filled correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Unable to retrieve the instructor's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private bool ValidateInstructorData(Instructor instructor)
        //{
        //    if( string.IsNullOrWhiteSpace(instructor.Email) || string.IsNullOrEmpty(instructor.Name) || instructor.Salary  ==0 || string.IsNullOrEmpty(instructor.Phone))
        //    {
        //        return true;
        //    }
        //     return false;
        //}

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (instractors_table.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = instractors_table.SelectedRows[0];

                
                if (selectedRow.Cells["ins_id"] != null && int.TryParse(selectedRow.Cells["ins_id"].Value.ToString(), out int instructorId))
                {
                    
                    var confirmation = MessageBox.Show($"Are you sure you want to delete instructor with ID {instructorId}?",
                                                       "Confirmation",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Yes)
                    {
                        instructor.Id = instructorId;
                   
                        instructorMethods.Delete(instructor);

                        
                        TableData.show("Instructor", instractors_table);

                        MessageBox.Show("Instructor deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to retrieve the instructor's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
        private void search_TextChanged(object sender, EventArgs e)
        {
            TableData.showAfterSearch("admin", search.Text, instractors_table);
        }

        private int GetAdminIdByEmail(string email)
        {

            string connectionString = @"Data Source=(local);Initial Catalog=Examination System;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = $@"SELECT id FROM Admin WHERE admin_email = '{email}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", email);


                    var result = command.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("Admin not found.");
                    }

                    return Convert.ToInt32(result);
                }
            }
        }

        private void instractors_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
