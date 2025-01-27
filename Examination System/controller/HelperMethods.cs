using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller
{
    internal abstract class HelperMethods
    {
        public HelperMethods() { }

        public static void ExecuteDmlQuery(string tableName, string operation, string columns = null, string values = null, string condition = null, int level = 0)
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
