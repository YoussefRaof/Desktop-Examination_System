﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examination_System.model;

namespace Examination_System.Controller
{
    internal class ExamMethods : IExamRepo
    {
        public ExamMethods() { }

        public DataTable GetExamData(int ssn, string course_name)
        {
            DataTable examData = new DataTable();

            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    return null;

                try
                {
                    using (SqlCommand command = new SqlCommand("GetRandomExamQuestions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ssn", ssn);
                        command.Parameters.AddWithValue("@course_name", course_name);

                        //connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(examData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return examData;
        }


        public void CorrectExam(int ssn, int exam_id)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    return;

                try
                {
                    using (SqlCommand command = new SqlCommand("Exam_Correction", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@st_id", ssn);
                        command.Parameters.AddWithValue("@exam_id", exam_id);
                       
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public int GetExamID(string table, string examName)
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
                        command.Parameters.AddWithValue("@Email", examName);

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

        public void SaveStudentAnswers(Student_Exam_Questions studentAnswer)
        {
            string columns = "SSN_FK, exam_id_FK, ques_id_FK, answer";
            string values = $"'{studentAnswer.StudentId}', '{studentAnswer.ExamId}', '{studentAnswer.QuestionId}', '{studentAnswer.Answer}'";
            HelperMethods.ExecuteDmlQuery("Student_Take_Exam_Has_Questions", "insert", columns, values, null, 0);
        }

        public void InsertQuestion(Questions question)
        {

        }

        public void UpdateQuestion(Questions question)
        {

        }

        public bool LoginQuestion(Questions question)
        {
            return false;
        }
    }
}
