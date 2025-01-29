using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination_System.model;

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

        public static int CheckBranch(int branchId)
        {
            int result = 0; 

            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("check_branch", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        
                        command.Parameters.AddWithValue("@id", branchId);




                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);


                        command.ExecuteNonQuery();


                        result = (int)returnValue.Value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }

            return result;
        }

        public static int CheckInstructor(int insId)
        {
            int result = 0;

            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("check_instructor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@id", insId);

                        
                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                       
                        command.ExecuteNonQuery();

                        
                        result = (int)returnValue.Value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }

            return result;
        }
        //public static int GetLastInsertedTrackId()
        //{
        //    int trackId = 0;

        //    using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
        //    {
        //        if (connection == null)
        //            throw new Exception("Database connection failed.");

        //        try
        //        {
        //            using (SqlCommand command = new SqlCommand("GetLastInsertedTrackId", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;

                        

                        
        //                object result = command.ExecuteScalar();
        //                if (result != null && int.TryParse(result.ToString(), out trackId))
        //                {
        //                    return trackId;
        //                }
        //                else
        //                {
        //                    throw new Exception("Failed to retrieve the last inserted Track ID.");
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("An error occurred while retrieving the last Track ID: " + ex.Message, ex);
        //        }
        //    }
        //}
        public static int InsertTrack(Track track)
        {
            int trackId = 0;

            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("InsertTrack", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TrackName", track.TrackName);
                        command.Parameters.AddWithValue("@InstructorId", track.InstructorId);
                        command.Parameters.AddWithValue("@AdminId", track.Admin_id_FK);

                      
                        SqlParameter trackIdParam = new SqlParameter("@TrackId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(trackIdParam);

                        command.ExecuteNonQuery();

                       
                        trackId = (int)trackIdParam.Value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while inserting the track: " + ex.Message, ex);
                }
            }

            return trackId;
        }
        public static int GetInstructorIdByName(string instructorName)
        {
            int instructorId = 0;

            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("GetInstructorIdByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        
                        command.Parameters.AddWithValue("@InstructorName", instructorName);

                        
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            instructorId = id; 
                        }
                        else
                        {
                            throw new Exception($"Instructor with name '{instructorName}' not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while retrieving the instructor ID: " + ex.Message, ex);
                }
            }

            return instructorId;
        }



    }
}
