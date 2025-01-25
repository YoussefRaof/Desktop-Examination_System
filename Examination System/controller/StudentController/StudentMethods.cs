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
        public void Delete(Student student)
        {
            if (student.SSN >= 0)
            {

                string condition = $"SSN = {student.SSN}";
                ExecuteDmlQuery("Student", "delete", null, null, condition, 0);

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
            ExecuteDmlQuery("Student", "insert", columns, values, null, 0);
        }

        public bool Login(Student student)
        {
            if(CheckLogin("Student",student.Email , student.Password ))
            {
                return true;
            }
            
             return false;
        }

        public void Update(Student student)
        {
            if (student.SSN > 0)
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

                
                ExecuteDmlQuery("Student", "update", formattedColumns, null, condition, 0);
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


    }
}
