using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Examination_System.Controller.CourseController
{
    internal class CourseMethods : ICourseRepo
    {
        public void Delete(Course course)
        {
            if (course.CourseId>= 0)
            {
                string condition = $"crs_id   = {course.CourseId}";
                HelperMethods.ExecuteDmlQuery("Course", "delete", null, null, condition, 0);
            }
            else
            {

                MessageBox.Show("Course not found. Please Choose a valid Course ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert(Course course)
        {
            string columns = "crs_name, admin_id_FK, topic_id_FK";
            string values = $"'{course.CourseName}', {course.Admin_id_FK}, {course.TopicId}";
            HelperMethods.ExecuteDmlQuery("Course", "insert", columns, values, null, 0);
        }

        public void Update(Course course)
        {
            if (course.CourseId> 0)
            {
                string columns = "crs_name = '{0}', topic_id_FK = {1}";

                string formattedColumns = string.Format(columns, course.CourseName, course.TopicId);

                string condition = $"crs_id = {course.CourseId}";
                HelperMethods.ExecuteDmlQuery("Course", "update", formattedColumns, null, condition, 0);
            }
        }

        public int GetCourseID(string table, string courseName)
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
                        command.Parameters.AddWithValue("@param", courseName);

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

    }
}
