using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.QuestionController
{
    internal class QuestionMethods : IQuestionRepo
    {
        public QuestionMethods() { }


        public void Insert(Object obj, int flag)
        {
            if (obj is Questions question && flag == 1)
            {
                if (question.Choise3 != null || question.Choise4 != null)
                {
                    string columns = "ques_name, ques_type, choice_1, choice_2, choice_3, choice_4, ques_model_answer, crs_id_fk";
                    string values = $"'{question.QuestionName}', '{question.Type}', '{question.Choise1}', '{question.Choise2}', '{question.Choise3}', " +
                        $"'{question.Choise4}', '{question.ModelAnswer}', '{question.CourseId}'";

                    HelperMethods.ExecuteDmlQuery("Questions", "insert", columns, values, null, 0);
                }
                else
                {
                    string columns = "ques_name, ques_type, choice_1, choice_2, ques_model_answer, crs_id_fk";
                    string values = $"'{question.QuestionName}', '{question.Type}', '{question.Choise1}', '{question.Choise2}', " +
                        $"'{question.ModelAnswer}', '{question.CourseId}'";
                
                    HelperMethods.ExecuteDmlQuery("Questions", "insert", columns, values, null, 0);
                }

            }

            else if (obj is Exam_Questions exam_question && flag == 2)
            {
                string columns = "exam_id_FK, ques_id_FK";
                string values = $"'{exam_question.ExamId}', '{exam_question.QuestionId}'";

                HelperMethods.ExecuteDmlQuery("Exam_Has_Questions", "insert", columns, values, null, 0);
            }
        }


        public void Update(Questions question)
        {
            if (question.Choise3 != null || question.Choise4 != null)
            {
                string columns = $"ques_name = '{question.QuestionName}', ques_type = '{question.Type}', choice_1 = '{question.Choise1}', choice_2 = '{question.Choise2}', " +
                $"choice_3 = '{question.Choise3}', choice_4 = '{question.Choise4}', ques_model_answer = '{question.ModelAnswer}', crs_id_fk = '{question.CourseId}'";
            
                string condition = $"ques_id = {question.QuestionId}";
                HelperMethods.ExecuteDmlQuery("Questions", "update", columns, null, condition);
            }
            else
            {
                string columns = $"ques_name = '{question.QuestionName}', ques_type = '{question.Type}', choice_1 = '{question.Choise1}', choice_2 = '{question.Choise2}', " +
                $"ques_model_answer = '{question.ModelAnswer}', crs_id_fk = '{question.CourseId}'";

                string condition = $"ques_id = {question.QuestionId}";
                HelperMethods.ExecuteDmlQuery("Questions", "update", columns, null, condition);
            }
        }


        public void Delete(Questions question)
        {
            string condition = $"ques_id = {question.QuestionId}";
            HelperMethods.ExecuteDmlQuery("Questions", "delete", null, null, condition, 0);
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


        public int GetQuestionID(string table, string quesName)
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
                        command.Parameters.AddWithValue("@param", quesName);

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
