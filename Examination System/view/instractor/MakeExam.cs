using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

using Examination_System.controller;
using Examination_System.Controller.InstructorController;
using System.Security.Cryptography;
using Examination_System.model;
using Examination_System.Controller.QuestionController;
using Examination_System.View.student;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Examination_System.Controller;

namespace Examination_System.view.instractor
{
    public partial class MakeExam : Form
    {
        private Form _Home;
        private string _email;

        private Exam exam;
        private ExamMethods examMethods;
        private IQuestionRepo questionMethods;
        private IInstructorRepo instructorMethods;

        private int _ins_id;

        public MakeExam(Form home, string email)
        {
            InitializeComponent();

            setDisabledQuestion();
            setDisabledItems2();
            setDisabledItems3();

            _Home = home;
            _email = email;

            exam = new Exam();
            examMethods = new ExamMethods();
            questionMethods = new QuestionMethods();

            instructorMethods = new InstructorMethods();
            _ins_id = instructorMethods.getID("instructor", _email);
            TableData.fillComboBoxAndTable(course_exam_box, "ins_course", "insId", _ins_id);

            question.BorderStyle = BorderStyle.FixedSingle;
            option_a.BorderStyle = BorderStyle.FixedSingle;
            option_b.BorderStyle = BorderStyle.FixedSingle;
            option_c.BorderStyle = BorderStyle.FixedSingle;
            option_d.BorderStyle = BorderStyle.FixedSingle;
        }

        private void setDisabledQuestion()
        {
            question.Enabled = false;
        }

        private void setDisabledItems2()
        {
            option_a.Enabled = false;
            option_b.Enabled = false;
            option_c.Enabled = false;
            option_d.Enabled = false;
        }

        private void setDisabledItems3()
        {
            a_rbtn.Enabled = false;
            b_rbtn.Enabled = false;
            c_rbtn.Enabled = false;
            d_rbtn.Enabled = false;
        }

        private void setEnabledItems()
        {
            question.Enabled = true;
            option_a.Enabled = true;
            option_b.Enabled = true;
            option_c.Enabled = true;
            option_d.Enabled = true;
            a_rbtn.Enabled = true;
            b_rbtn.Enabled = true;
            c_rbtn.Enabled = true;
            d_rbtn.Enabled = true;
        }

        private void inputChanges()
        {
            if (!string.IsNullOrEmpty(question_type_box.Text) && !string.IsNullOrEmpty(course_exam_box.Text))
            {
                setEnabledItems();

                if (question_type_box.Text == "T/F")
                {
                    setDisabledItems2();

                    // Ensure a row is selected before calling fillData()
                    if (question_table.SelectedRows.Count == 1)
                        fillData();

                    option_a.Text = "True";
                    option_b.Text = "False";

                    option_c.Text = null;
                    option_d.Text = null;

                    c_rbtn.Checked = false;
                    d_rbtn.Checked = false;

                    c_rbtn.Enabled = false;
                    d_rbtn.Enabled = false;
                }
                else
                {
                    c_rbtn.Enabled = true;
                    d_rbtn.Enabled = true;

                    // Ensure a row is selected before calling fillData()
                    if (question_table.SelectedRows.Count == 1)
                        fillData();
                }
            }
            else
            {
                setDisabledQuestion();
                setDisabledItems2();
            }
        }


        private void fillData()
        {
            if (question_table.SelectedRows.Count == 1)
            {
                DataGridViewRow row = question_table.SelectedRows[0];

                question.Text = row.Cells["ques_name"].Value?.ToString();
                option_a.Text = row.Cells["choice_1"].Value?.ToString();
                option_b.Text = row.Cells["choice_2"].Value?.ToString();
                option_c.Text = row.Cells["choice_3"].Value?.ToString();
                option_d.Text = row.Cells["choice_4"].Value?.ToString();

                string correctAnswer = row.Cells["ques_model_answer"].Value?.ToString();
                if (correctAnswer == option_a.Text) a_rbtn.Checked = true;
                else if (correctAnswer == option_b.Text) b_rbtn.Checked = true;
                else if (correctAnswer == option_c.Text) c_rbtn.Checked = true;
                else if (correctAnswer == option_d.Text) d_rbtn.Checked = true;
            }
            else if (question_table.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select only one row from the table.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void setQuestionData()
        {
            exam.Question.QuestionName = question.Text;
            exam.Question.Type = question_type_box.Text;


            if (question_type_box.Text == "MCQ")
            {
                exam.Question.Choise1 = option_a.Text;
                exam.Question.Choise2 = option_b.Text;
                exam.Question.Choise3 = option_c.Text;
                exam.Question.Choise4 = option_d.Text;
            }
            else if (question_type_box.Text == "T/F")
            {
                exam.Question.Choise1 = option_a.Text;
                exam.Question.Choise2 = option_b.Text;
                exam.Question.Choise3 = null;
                exam.Question.Choise4 = null;
            }


            if (a_rbtn.Checked)
                exam.Question.ModelAnswer = option_a.Text;

            else if (b_rbtn.Checked)
                exam.Question.ModelAnswer = option_b.Text;

            else if (c_rbtn.Checked)
                exam.Question.ModelAnswer = option_c.Text;

            else if (d_rbtn.Checked)
                exam.Question.ModelAnswer = option_d.Text;
            

            exam.Question.CourseId = questionMethods.GetCourseID("Course", course_exam_box.Text);
            exam.ExamQuestion.ExamId = examMethods.GetExamID("Exam", course_exam_box.Text);
        }


        private bool checkData()
        {
            if (course_exam_box.Text != string.Empty && question_type_box.Text != string.Empty && question.Text != string.Empty && 
                (a_rbtn.Checked || b_rbtn.Checked || c_rbtn.Checked || d_rbtn.Checked))
            {
                if (question_type_box.Text == "MCQ")
                {
                    if (option_a.Text != string.Empty && option_b.Text != string.Empty && option_c.Text != string.Empty && option_d.Text != string.Empty)
                        return true;
                }
                else if (question_type_box.Text == "T/F")
                {
                    if (option_a.Text != string.Empty && option_b.Text != string.Empty)
                        return true;
                }
            }

            return false;
        }


        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            bool canInsert = TableData.fillQuesTable(question_table, "GetInstructorCourseQuestions", _ins_id, course_exam_box.Text);

            if (course_exam_box.Text != string.Empty && canInsert)
            {
                var confirmation = MessageBox.Show($"You haven't added 10 questions in {course_exam_box.Text} course yet. \n\nAre you sure you want exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                    Application.Exit();
            }
            else
                Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            bool canInsert = TableData.fillQuesTable(question_table, "GetInstructorCourseQuestions", _ins_id, course_exam_box.Text);

            if (course_exam_box.Text != string.Empty && canInsert)
            {
                var confirmation = MessageBox.Show($"You haven't added 10 questions in course {course_exam_box.Text} course yet. \n\nAre you sure you want back to home?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    this.Close();
                    _Home.Show();
                }
            }
            else
            {
                this.Close();
                _Home.Show();
            }
        }

        private void quesion_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputChanges();
        }

        private void question_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputChanges();
        }


        private void exam_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputChanges();
            TableData.fillQuesTable(question_table, "GetInstructorCourseQuestions", _ins_id, course_exam_box.Text);
        }


        private void insert_btn_Click(object sender, EventArgs e)
        {
            bool canInsert = TableData.fillQuesTable(question_table, "GetInstructorCourseQuestions", _ins_id, course_exam_box.Text);
            if (checkData())
            {
                if (canInsert)
                {
                    setQuestionData();
                    questionMethods.Insert(exam.Question, 1);

                    exam.ExamQuestion.QuestionId = questionMethods.GetQuestionID("Questions", question.Text);
                    questionMethods.Insert(exam.ExamQuestion, 2);

                    TableData.fillQuesTable(question_table, "GetInstructorCourseQuestions", _ins_id, course_exam_box.Text);
                    MessageBox.Show("Question Inserted!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("You cannot insert more than 10 questions!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please complete question data!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void update_btn_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                if (question_table.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = question_table.SelectedRows[0];

                    if (selectedRow.Cells["ques_id"] != null && int.TryParse(selectedRow.Cells["ques_id"].Value.ToString(), out int quesID))
                    {
                        var confirmation = MessageBox.Show($"Are you sure you want to update question with ID {quesID}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        int rowCount = question_table.RowCount;
                        if (confirmation == DialogResult.Yes)
                        {
                            exam.Question.QuestionId = quesID;

                            setQuestionData();
                            questionMethods.Update(exam.Question);
                            TableData.fillQuesTable(question_table, "GetInstructorCourseQuestions", _ins_id, course_exam_box.Text);

                            MessageBox.Show("Question updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Unable to retrieve the Question's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please complete question data!!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void delete_btn_Click(object sender, EventArgs e)
        {
        }


        private void question_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fillData();

                DataGridViewRow row = question_table.SelectedRows[0];

                if (row.Cells["ques_type"].Value.ToString() == "MCQ")
                    question_type_box.Text = "MCQ";

                else if (row.Cells["ques_type"].Value.ToString() == "T/F")
                {
                    question_type_box.Text = "T/f";

                    option_c.Text = null;
                    option_d.Text = null;

                    option_a.Enabled = false;
                    option_b.Enabled = false;
                    option_c.Enabled = false;
                    option_d.Enabled = false;
                }
            }
            catch
            {
                //
            }

            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = question_table.Rows[e.RowIndex];

            //    question.Text = row.Cells["ques_name"].Value?.ToString();
            //    option_a.Text = row.Cells["choice_1"].Value?.ToString();
            //    option_b.Text = row.Cells["choice_2"].Value?.ToString();
            //    option_c.Text = row.Cells["choice_3"].Value?.ToString();
            //    option_d.Text = row.Cells["choice_4"].Value?.ToString();


            //    string correctAnswer = row.Cells["ques_model_answer"].Value?.ToString();
            //    if (correctAnswer == option_a.Text) a_rbtn.Checked = true;
            //    else if (correctAnswer == option_b.Text) b_rbtn.Checked = true;
            //    else if (correctAnswer == option_c.Text) c_rbtn.Checked = true;
            //    else if (correctAnswer == option_d.Text) d_rbtn.Checked = true;
            //}
            //else
            //    MessageBox.Show("Please select only one row from table.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            question.Text = "";
            question_type_box.Text = "";

            option_a.Text = "";
            option_b.Text = "";
            option_c.Text = "";
            option_d.Text = "";

            a_rbtn.Checked = false;
            b_rbtn.Checked = false;
            c_rbtn.Checked = false;
            d_rbtn.Checked = false;
        }
    }
}
