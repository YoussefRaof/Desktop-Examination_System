using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Examination_System.controller
{
    internal class AdminMethods : IAdminRepo
    {
        public AdminMethods() { }

        public void Insert(Admin admin) 
        {
            string columns = "admin_name, admin_email, admin_password";
            string values = $"'{admin.Name}', '{admin.Email}', '{admin.Password}'";
            ExecuteDmlQuery("Admin", "insert", columns, values,null,0);
        }


        public void Update(Admin admin)
        {
            string columns = $"admin_name = '{admin.Name}', admin_password = '{admin.Password}'";
            string condition = $"id = {admin.Id}";
            ExecuteDmlQuery("Admin", "update", columns, null, condition);
        }


        public bool Login(Admin admin)
        {
            //string columns = $"admin_email = '{admin.Email}' , password = '{admin.Password}'";
            //string condition = $"id = {admin.Id}";
            
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("login_check", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@table", "Admin");
                        command.Parameters.AddWithValue("@email", admin.Email);
                        command.Parameters.AddWithValue("@password", admin.Password);
                        
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }
            
        }


        public int getID(string table, string email)
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
                        command.Parameters.AddWithValue("@Email", email);

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


        private void ExecuteDmlQuery(string tableName, string operation, string columns = null, string values = null, string condition = null ,int level = 0)
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
