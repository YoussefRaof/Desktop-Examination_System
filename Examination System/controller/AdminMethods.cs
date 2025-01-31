using Examination_System.Controller;
using Examination_System.model;
using Examination_System.Model;
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
            HelperMethods.ExecuteDmlQuery("Admin", "insert", columns, values,null,0);
        }


        public void Update(Admin admin)
        {
            string columns = $"admin_name = '{admin.Name}', admin_password = '{admin.Password}'";
            string condition = $"id = {admin.Id}";
            HelperMethods.ExecuteDmlQuery("Admin", "update", columns, null, condition);
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
        public int  AssginInstructorToCourse(Instructor instructor, Course course)
        {
             //string columns = "ins_id_FK, crs_id_FK";
            //string values = $"{instructor.Id}, {course.CourseId}";
            return AssginOrUnAssginInstructorToCourseQuery(instructor.Id, course.CourseId, "insert");
        }

       public int UnAssignInstructorToCourse(Instructor instructor , Course course)
       {
            return AssginOrUnAssginInstructorToCourseQuery(instructor.Id, course.CourseId, "delete");
        }

        public int AssginStudentToCourse(Student student, Course course)
        {
            return AssginOrUnAssginStudentToCourseQuery(student.SSN, course.CourseId, "insert");
        }

        public int UnAssignStudentToCourse(Student student, Course course)
        {

            return AssginOrUnAssginStudentToCourseQuery(student.SSN, course.CourseId, "delete");
        }


        public int AssignTrackToBranch(Branch branch , Track track)
        {
            return AssignOrUnassignTrackToBranchQuery(track.TrackId, branch.BranchId, "insert");
        }

        public int UnAssignTrackToBranch(Branch branch, Track track)
        {

            return AssignOrUnassignTrackToBranchQuery(track.TrackId, branch.BranchId, "delete");
        }


        public int AssginCourseToTrack(Course course, Track track)
        {
            return AssignOrUnassignCourseToTrackQuery(course.CourseId, track.TrackId, "insert");

        }
        public int UnAssginCourseToTrack(Course course, Track track)
        {
            return AssignOrUnassignCourseToTrackQuery(course.CourseId, track.TrackId, "delete");
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


        private int AssginOrUnAssginInstructorToCourseQuery(int instrcutorId, int courseID, string operation)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("assigninstructortocourse", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ins_id", instrcutorId);
                        command.Parameters.AddWithValue("@crs_id", courseID);
                        command.Parameters.AddWithValue("@operation", operation);


                      
                        SqlParameter resultParam = new SqlParameter("@result", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultParam);

                        command.ExecuteNonQuery();

                        
                        int returnValue = (int)resultParam.Value;

                        return returnValue;


                    }
                }
                catch (SqlException ex) when (ex.Number == 50000)
                {
                    
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("An error occurred while assigning the instructor to the course: " + ex.Message);
                }
            }


        }

        private int AssginOrUnAssginStudentToCourseQuery(int SSN, int courseID, string operation)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("assignStudentToCourse", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ssn", SSN);
                        command.Parameters.AddWithValue("@crs_id", courseID);
                        command.Parameters.AddWithValue("@operation", operation);



                        SqlParameter resultParam = new SqlParameter("@result", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultParam);

                        command.ExecuteNonQuery();


                        int returnValue = (int)resultParam.Value;

                        return returnValue;


                    }
                }
                catch (SqlException ex) when (ex.Number == 50000)
                {

                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {

                    throw new Exception("An error occurred while assigning the instructor to the course: " + ex.Message);
                }
            }


        }

        private int AssignOrUnassignTrackToBranchQuery(int trackId, int branchId, string operation)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("assignTrackToBranch", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        
                        command.Parameters.AddWithValue("@track_id", trackId);
                        command.Parameters.AddWithValue("@branch_id", branchId);
                        command.Parameters.AddWithValue("@operation", operation);

                        SqlParameter resultParam = new SqlParameter("@result", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultParam);

                        
                        command.ExecuteNonQuery();

                        
                        int returnValue = (int)resultParam.Value;
                        return returnValue;
                    }
                }
                catch (SqlException ex) when (ex.Number == 50000)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the operation: " + ex.Message);
                }
            }
        }
        private int AssignOrUnassignCourseToTrackQuery(int courseId, int trackId, string operation)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    throw new Exception("Database connection failed.");

                try
                {
                    using (SqlCommand command = new SqlCommand("assignCourseToTrack", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                      
                        command.Parameters.AddWithValue("@course_id", courseId);
                        command.Parameters.AddWithValue("@track_id", trackId);
                        command.Parameters.AddWithValue("@operation", operation);

                        // Output parameter for the result
                        SqlParameter resultParam = new SqlParameter("@result", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultParam);

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

                        // Retrieve and return the result
                        int returnValue = (int)resultParam.Value;
                        return returnValue;
                    }
                }
                catch (SqlException ex) when (ex.Number == 50000)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the operation: " + ex.Message);
                }
            }
        }

        
    }
}

