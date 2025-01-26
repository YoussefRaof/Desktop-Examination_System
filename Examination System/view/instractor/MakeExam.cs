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

namespace Examination_System.view.instractor
{
    public partial class MakeExam : Form
    {
        private Form _Home;
        private string _email;
        public MakeExam(Form home, string email)
        {
            InitializeComponent();

            setDisabledQuestion();
            setDisabledItems2();
            setDisabledItems3();

            _Home = home;
            _email = email;

            TableData.fillComboBox(course_exam);
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
            if (question_no.Text != string.Empty && question_type.Text != string.Empty && course_exam.Text != string.Empty)
            {
                setEnabledItems();
                if (question_type.Text == "T/F")
                {
                    setDisabledItems2();
                    option_a.Text = "True";
                    option_b.Text = "False";

                    c_rbtn.Enabled = false;
                    d_rbtn.Enabled = false;
                }
                else
                {
                    option_a.Text = "";
                    option_b.Text = "";

                    c_rbtn.Enabled = true;
                    d_rbtn.Enabled = true;
                }
            }
            else
            {
                setDisabledQuestion();
                setDisabledItems2();
            }
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
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {

        }

        private void update_btn_Click(object sender, EventArgs e)
        {

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {

        }

    }
}
