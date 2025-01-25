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
        private static string connectionString = @"Data Source=(local);Initial Catalog=Examination System;Integrated Security=True;";

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
            }
            //finally
            //{
            //    connection.Close();
            //}
        }
    }
}
