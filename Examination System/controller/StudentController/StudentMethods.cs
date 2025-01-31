using Examination_System.model;
using Examination_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.Controller.StudentController
{
    internal class StudentMethods : IStudentRepo
    {
        public StudentMethods() { }

        public void Delete(Student student)
        {
            if (student.SSN >= 0)
            {
                string condition = $"SSN = {student.SSN}";
                HelperMethods.ExecuteDmlQuery("Student", "delete", null, null, condition, 0);
            }
            else
            {

                MessageBox.Show("Student not found. Please Choose a valid Student SSN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert(Student student)
        {
            string columns = "SSN, stud_fname, stud_lname, stud_email, stud_phone, stud_address, stud_gender, stud_birthdate, track_id_FK, admin_id_FK";
            string values = $"'{student.SSN}', '{student.FName}', '{student.LName}', '{student.Email}', '{student.Phone}', '{student.Address}', '{student.Gender}', '{student.BirthDate}', '{student.TrackId}', '{student.AdminId}'";
            HelperMethods.ExecuteDmlQuery("Student", "insert", columns, values, null, 0);
        }

        public bool Login(Student student)
        {
            if(CheckLogin("Student",student.Email , student.Password ))
            {
                return true;
            }
            
             return false;
        }

        public void Update(Student student, int? flag)
        {
            if (student.SSN > 0 && flag != 1)
            {
                string columns = "stud_fname = '{0}', stud_lname = '{1}', stud_email = '{2}', stud_phone = '{3}', stud_address = '{4}', stud_gender = '{5}', stud_birthdate = '{6}', track_id_FK = {7}";
               
                string formattedColumns = string.Format(columns,
                    student.FName,
                    student.LName,
                    student.Email,
                    student.Phone,
                    student.Address,
                    student.Gender.ToString(),
                    student.BirthDate, 
                    student.TrackId
                );
                    
                string condition = $"SSN = {student.SSN}";
                HelperMethods.ExecuteDmlQuery("Student", "update", formattedColumns, null, condition, 0);
            }
            else if (flag == 1)
            {
                string columns = $"stud_password = '{student.Password}'";
                string condition = $"ssn = {student.SSN}";
                HelperMethods.ExecuteDmlQuery("Student", "update", columns, null, condition);
            }
            else
            {
                throw new Exception("Student SSN is invalid. Update cannot be performed.");
            }
        }
        
        private bool CheckLogin(string tablename,string email ,string password)
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


        public int getSSN(string table, string email)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("get_id", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@table", table);
                        command.Parameters.AddWithValue("@param", email);

                        var result = command.ExecuteScalar();

                        if (result == DBNull.Value)
                            return -1;

                        return Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }
        }


        public string getName(string table, string email)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("get_name", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@table", table);
                        command.Parameters.AddWithValue("@Email", email);

                        var result = command.ExecuteScalar();

                        if (result == DBNull.Value)
                            return null;

                        return result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }
        }


        public bool checkPassword(string password, string table, string email)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("get_password", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@table", table);
                        command.Parameters.AddWithValue("@email", email);

                        var result = command.ExecuteScalar();

                        if (result == DBNull.Value)
                            return false;

                        return result.ToString() == password;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }
        }

    }
}
