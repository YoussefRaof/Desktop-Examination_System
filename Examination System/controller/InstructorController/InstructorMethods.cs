﻿using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination_System.view.admin;
using System.Windows.Forms;
using Examination_System.Model;

namespace Examination_System.Controller.InstructorController
{
    internal class InstructorMethods : IInstructorRepo
    {
        public InstructorMethods() { }
        public void Delete(Instructor instructor)
        {
           

            if (instructor.Id > 0)
            {
                
                string condition = $"ins_id = {instructor.Id}";
                ExecuteDmlQuery("Instructor", "delete", null, null, condition, 0);
                
            }
            else
            {
                
                MessageBox.Show("Instructor not found. Please Choose a valid Instructor Id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Insert(Instructor instructor)
        {
            string columns = "ins_name, ins_email, ins_phone, ins_salary, admin_id_FK";
            string values = $"'{instructor.Name}', '{instructor.Email}', '{instructor.Phone}', '{instructor.Salary}', {instructor.AdminId}";
            ExecuteDmlQuery("Instructor", "insert", columns, values, null, 0);
        }

        public bool Login(Instructor instructor)
        {
            if (CheckLogin("Instructor", instructor.Email, instructor.Password))
            {
                return true;
            }

            return false;
        }

        public void Update(Instructor instructor)
        {
            if (instructor.Id > 0)
            {
                
                string columns = "ins_name = '{0}', ins_email = '{1}', ins_phone = '{2}', ins_salary = {3}";
                string formattedColumns = string.Format(columns, instructor.Name, instructor.Email, instructor.Phone, instructor.Salary);

               
                string condition = $"ins_id = {instructor.Id}";

                
                ExecuteDmlQuery("Instructor", "update", formattedColumns, null, condition, 0);
            }
            else
            {
                throw new Exception("Instructor ID is invalid. Update cannot be performed.");
            }
        }

        private void ExecuteDmlQuery(string tableName, string operation, string columns = null, string values = null, string condition = null, int level = 0)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("dmlQuerries", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@tablename", tableName);
                        command.Parameters.AddWithValue("@operation", operation);
                        command.Parameters.AddWithValue("@columns", (object)columns ?? DBNull.Value);
                        command.Parameters.AddWithValue("@values", (object)values ?? DBNull.Value);
                        command.Parameters.AddWithValue("@condition", (object)condition ?? DBNull.Value);
                        command.Parameters.AddWithValue("@nestlevel", (object)level ?? DBNull.Value);


                           command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }
        }

        private bool CheckLogin(string tablename, string email, string password)
        {


            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {

                    string storedProcedureName = "login_check";

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@table", tablename);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);


                        command.Parameters.AddWithValue("@nestlevel", 0);


                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Return true if the count is greater than 0, indicating a valid login
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while validating student login: " + ex.Message, ex);
                }
            }
        }
    }
}

    

