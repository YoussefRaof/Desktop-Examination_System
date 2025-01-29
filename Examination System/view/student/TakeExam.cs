using Examination_System.Controller;
using Examination_System.Controller.StudentController;
using Examination_System.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.view.student
{
    public partial class TakeExam : Form
    {
        private bool flag = false; //
        private int totalSeconds = 10 * 60; //
        private Form _Home;
        private string _email;

        private IExamRepo examMethods;
        private IStudentRepo studentMethods;
        private Exam exam;
        private int studentSSN;
        private int examID;

        private DataTable examData;
        //private List<int> questions_id = new List<int>();

        public TakeExam(Form Home, string email, string crs_name)
        {
            InitializeComponent();
            //CheckExamStatus();

            panel3.BorderStyle = BorderStyle.FixedSingle;
            exit.Click -= exit_Click;
            //exit.Enabled = false;
            //back.Enabled = false;

            _Home = Home;
            _email = email;
            course_name.Text = crs_name;

            examMethods = new ExamMethods();
            studentMethods = new StudentMethods();
            exam = new Exam();
            //studentAnswer = new Student_Exam_Questions();

            studentSSN = studentMethods.getSSN("student", _email);
            examID = examMethods.GetExamID("exam", crs_name); // examData.Rows[0]["exam_id"].ToString();
            examData = examMethods.GetExamData(studentSSN, crs_name);

            LoadExamData();
        }


        private void CheckExamStatus()
        {
            if(flag) //
            {
                MessageBox.Show("Exam is OFF", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
                _Home.Show();
            }
        }


        private void LoadExamData()
        {
            //DataTable examData = examMethods.GetExamData(0, "SQL Server");

            if (examData == null || examData.Rows.Count == 0)
                MessageBox.Show("No exam data found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            Dictionary<int, Label[]> questionLabels = new Dictionary<int, Label[]>
            {
                {1, new Label[] {q1label1, q1label2, q1label3, q1label4}},
                {2, new Label[] {q2label1, q2label2, q2label3, q2label4}},
                {3, new Label[] {q3label1, q3label2, q3label3, q3label4}},
                {4, new Label[] {q4label1, q4label2, q4label3, q4label4}},
                {5, new Label[] {q5label1, q5label2, q5label3, q5label4}},
                {6, new Label[] {q6label1, q6label2, q6label3, q6label4}},
                {7, new Label[] {q7label1, q7label2, q7label3, q7label4}},
                {8, new Label[] {q8label1, q8label2, q8label3, q8label4}},
                {9, new Label[] {q9label1, q9label2, q9label3, q9label4}},
                {10, new Label[] {q10label1, q10label2, q10label3, q10label4}}
            };

            Dictionary<int, Label> questionText = new Dictionary<int, Label>
            {
                {1, question1}, {2, question2}, {3, question3}, {4, question4}, {5, question5},
                {6, question6}, {7, question7}, {8, question8}, {9, question9}, {10, question10}
            };

            Dictionary<int, Panel> questionPanel = new Dictionary<int, Panel>
            {
                {1, panel_q1}, {2, panel_q2}, {3, panel_q3}, {4, panel_q4}, {5, panel_q5},
                {6, panel_q6}, {7, panel_q7}, {8, panel_q8}, {9, panel_q9}, {10, panel_q10}
            };

            Dictionary<int, RadioButton[]> choiceRadioButtons = new Dictionary<int, RadioButton[]>
            {
                {1, new RadioButton[] {q1_c1_rbtn, q1_c2_rbtn, q1_c3_rbtn, q1_c4_rbtn}},
                {2, new RadioButton[] {q2_c1_rbtn, q2_c2_rbtn, q2_c3_rbtn, q2_c4_rbtn}},
                {3, new RadioButton[] {q3_c1_rbtn, q3_c2_rbtn, q3_c3_rbtn, q3_c4_rbtn}},
                {4, new RadioButton[] {q4_c1_rbtn, q4_c2_rbtn, q4_c3_rbtn, q4_c4_rbtn}},
                {5, new RadioButton[] {q5_c1_rbtn, q5_c2_rbtn, q5_c3_rbtn, q5_c4_rbtn}},
                {6, new RadioButton[] {q6_c1_rbtn, q6_c2_rbtn, q6_c3_rbtn, q6_c4_rbtn}},
                {7, new RadioButton[] {q7_c1_rbtn, q7_c2_rbtn, q7_c3_rbtn, q7_c4_rbtn}},
                {8, new RadioButton[] {q8_c1_rbtn, q8_c2_rbtn, q8_c3_rbtn, q8_c4_rbtn}},
                {9, new RadioButton[] {q9_c1_rbtn, q9_c2_rbtn, q9_c3_rbtn, q9_c4_rbtn}},
                {10, new RadioButton[] {q10_c1_rbtn, q10_c2_rbtn, q10_c3_rbtn, q10_c4_rbtn}}
            };


            for (int i = 0; i < 10; i++)
            {
                if (examData.Rows.Count > i)
                {
                    questionText[i + 1].Text = examData.Rows[i]["QuestionText"].ToString();

                    questionPanel[i + 1].Size = new Size(1150, 175);
                    questionPanel[i + 1].BorderStyle = BorderStyle.FixedSingle;


                    if (examData.Rows[i]["Choice1"] != DBNull.Value)
                    {
                        choiceRadioButtons[i + 1][0].Text = examData.Rows[i]["Choice1"].ToString();
                        choiceRadioButtons[i + 1][0].Enabled = true;

                        questionLabels[i + 1][0].Enabled = true;
                    }
                    //else
                    //{
                    //    choiceRadioButtons[i + 1][0].Text = "Not Allowed";
                    //    choiceRadioButtons[i + 1][0].Enabled = false;

                    //    questionLabels[i + 1][0].Enabled = false;
                    //}

                    if (examData.Rows[i]["Choice2"] != DBNull.Value)
                    {
                        choiceRadioButtons[i + 1][1].Text = examData.Rows[i]["Choice2"].ToString();
                        choiceRadioButtons[i + 1][1].Enabled = true;

                        questionLabels[i + 1][1].Enabled = true;
                    }
                    //else
                    //{
                    //    choiceRadioButtons[i + 1][1].Text = "Not Allowed";
                    //    choiceRadioButtons[i + 1][1].Enabled = false;

                    //    questionLabels[i + 1][1].Enabled = false;
                    //}

                    if (examData.Rows[i]["Choice3"] != DBNull.Value)
                    {
                        choiceRadioButtons[i + 1][2].Text = examData.Rows[i]["Choice3"].ToString();

                        choiceRadioButtons[i + 1][2].Visible = true;
                        questionLabels[i + 1][2].Visible = true;
                    }
                    else
                    {
                        choiceRadioButtons[i + 1][2].Visible = false;
                        questionLabels[i + 1][2].Visible = false;

                        questionPanel[i + 1].Size = new Size(1150, 107);
                    }

                    if (examData.Rows[i]["Choice4"] != DBNull.Value)
                    {
                        choiceRadioButtons[i + 1][3].Text = examData.Rows[i]["Choice4"].ToString();

                        choiceRadioButtons[i + 1][3].Visible = true;
                        questionLabels[i + 1][3].Visible = true;
                    }
                    else
                    {
                        choiceRadioButtons[i + 1][3].Visible = false;
                        questionLabels[i + 1][3].Visible = false;

                        questionPanel[i + 1].Size = new Size(1150, 107);
                    }
                }
            }

            //if (examData.Rows.Count > 9)
            //{
            //    question10.Text = examData.Rows[9]["QuestionText"].ToString();
            //    q10_c1_rbtn.Text = examData.Rows[9]["Choice1"].ToString();
            //    q10_c2_rbtn.Text = examData.Rows[9]["Choice2"].ToString();
            //    q10_c3_rbtn.Text = examData.Rows[9]["Choice3"] != DBNull.Value ? examData.Rows[2]["Choice3"].ToString() : "";
            //    q10_c4_rbtn.Text = examData.Rows[9]["Choice4"] != DBNull.Value ? examData.Rows[2]["Choice4"].ToString() : "";
            //}
        }

        private void setStudentAnswer(int questionID, string answer)
        {
            exam.Question.StudentId = studentSSN;
            exam.Question.ExamId = examID;
            exam.Question.QuestionId = questionID; //
            exam.Question.Answer = answer;
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !flag)
            {
                e.Cancel = true;
                MessageBox.Show("Closing the application is not allowed !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            base.OnFormClosing(e);
        }


        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Show();
        }

        private void endExam_btn_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to exit exam?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                //setStudentAnswer();
                //examMethods.SaveStudentAnswers(studentAnswer);
                examMethods.CorrectExam(studentSSN, examID);

                flag = true;

                this.Close();
                _Home.Show();

                MessageBox.Show("The Exam is End", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (totalSeconds >= 0)
            {
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                totalSeconds--;

                timer_txt.Text = $"{minutes:D2}:{seconds:D2}";
            }
            else
            {
                examMethods.CorrectExam(studentSSN, examID);
                
                flag = true;

                this.Close();
                _Home.Show();

                MessageBox.Show("The Exam is Over", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void q1_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q1_c1_rbtn.Checked)
            {
                string answer = q1_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[0]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q1_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q1_c2_rbtn.Checked)
            {
                string answer = q1_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[0]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q1_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q1_c3_rbtn.Checked)
            {
                string answer = q1_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[0]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q1_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q1_c4_rbtn.Checked)
            {
                string answer = q1_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[0]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q2_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q2_c1_rbtn.Checked)
            {
                string answer = q2_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[1]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q2_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q2_c2_rbtn.Checked)
            {
                string answer = q2_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[1]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q2_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q2_c3_rbtn.Checked)
            {
                string answer = q2_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[1]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q2_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q2_c4_rbtn.Checked)
            {
                string answer = q2_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[1]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q3_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q3_c1_rbtn.Checked)
            {
                string answer = q3_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[2]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q3_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q3_c2_rbtn.Checked)
            {
                string answer = q3_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[2]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q3_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q3_c3_rbtn.Checked)
            {
                string answer = q3_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[2]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q3_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q3_c4_rbtn.Checked)
            {
                string answer = q3_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[2]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q4_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q4_c1_rbtn.Checked)
            {
                string answer = q4_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[3]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q4.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q4_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q4_c2_rbtn.Checked)
            {
                string answer = q4_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[3]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q4.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q4_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q4_c3_rbtn.Checked)
            {
                string answer = q4_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[3]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q4.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q4_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q4_c4_rbtn.Checked)
            {
                string answer = q4_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[3]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q4.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q5_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q5_c1_rbtn.Checked)
            {
                string answer = q5_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[4]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q5_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q5_c2_rbtn.Checked)
            {
                string answer = q5_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[4]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q5_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q5_c3_rbtn.Checked)
            {
                string answer = q5_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[4]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q5_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q5_c4_rbtn.Checked)
            {
                string answer = q5_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[4]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q6_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q6_c1_rbtn.Checked)
            {
                string answer = q6_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[5]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q6.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q6_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q6_c2_rbtn.Checked)
            {
                string answer = q6_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[5]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q6.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q6_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q6_c3_rbtn.Checked)
            {
                string answer = q6_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[5]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q6.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q6_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q6_c4_rbtn.Checked)
            {
                string answer = q6_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[5]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q6.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q7_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q7_c1_rbtn.Checked)
            {
                string answer = q7_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[6]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q7.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q7_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q7_c2_rbtn.Checked)
            {
                string answer = q7_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[6]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q7.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q7_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q7_c3_rbtn.Checked)
            {
                string answer = q7_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[6]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q7.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q7_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q7_c4_rbtn.Checked)
            {
                string answer = q7_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[6]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q7.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q8_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q8_c1_rbtn.Checked)
            {
                string answer = q8_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[7]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q8.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q8_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q8_c2_rbtn.Checked)
            {
                string answer = q8_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[7]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q8.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q8_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q8_c3_rbtn.Checked)
            {
                string answer = q8_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[7]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q8.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q8_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q8_c4_rbtn.Checked)
            {
                string answer = q8_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[7]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q8.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q9_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q9_c1_rbtn.Checked)
            {
                string answer = q9_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[8]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q9.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q9_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q9_c2_rbtn.Checked)
            {
                string answer = q9_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[8]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q9.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q9_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q9_c3_rbtn.Checked)
            {
                string answer = q9_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[8]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q9.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q9_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q9_c4_rbtn.Checked)
            {
                string answer = q9_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[8]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q9.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q10_c1_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q10_c1_rbtn.Checked)
            {
                string answer = q10_c1_rbtn.Text;
                if (int.TryParse(examData.Rows[9]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q10_c2_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q10_c2_rbtn.Checked)
            {
                string answer = q10_c2_rbtn.Text;
                if (int.TryParse(examData.Rows[9]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q10_c3_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q10_c3_rbtn.Checked)
            {
                string answer = q10_c3_rbtn.Text;
                if (int.TryParse(examData.Rows[9]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void q10_c4_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (q10_c4_rbtn.Checked)
            {
                string answer = q10_c4_rbtn.Text;
                if (int.TryParse(examData.Rows[9]["ques_id"].ToString(), out int questionId))
                {
                    setStudentAnswer(questionId, answer);
                    examMethods.SaveStudentAnswers(exam.Question);

                    ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Invalid question ID for Q10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
