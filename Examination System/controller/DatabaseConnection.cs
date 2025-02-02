using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace Examination_System.controller
{
    internal class DatabaseConnection
    {
        //private static string connectionString = @"Data Source=lSa3edii\SQLEXPRESS01;Initial Catalog=Examination System;Integrated Security=True;";
        private static string connectionString = Environment.GetEnvironmentVariable("ExamSysDB");

        public DatabaseConnection() { }
    
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                return connection;
            }
            catch (Exception ex)
            {
                throw;
                //throw new Exception("An error occurred: " + ex.Message, ex);
            }

            //finally
            //{
            //    connection.Close();
            //}

        }
    }
}
