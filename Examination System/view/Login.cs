using Examination_System.controller;
using Examination_System.Controller.InstructorController;
using Examination_System.Controller.StudentController;
using Examination_System.model;
using Examination_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Examination_System.view
{
    public partial class Login : Form
    {
        private Student student;
        private IStudentRepo studentMethods;

        private Instructor instructor;
        private IInstructorRepo instrcutorMethods;
        public Login()
        {
            InitializeComponent();

            setDisabledItems();
            setDisabledBtn();
            password.UseSystemPasswordChar = true;
            studentMethods = new StudentMethods();
            student = new Student();

            instructor = new Instructor();
            instrcutorMethods = new InstructorMethods();
        }

        private void setDisabledItems()
        {
            email.Enabled = false;
            password.Enabled = false;
        }

        private void setEnabledItems()
        {
            email.Enabled = true;
            password.Enabled = true;
        }

        private void setDisabledBtn()
        {
            login_btn.Enabled = false;
            clear_btn.Enabled = false;
        }

        private void setEnabledIBtn()
        {
            login_btn.Enabled = true;
            clear_btn.Enabled = true;
        }


        private void inputTextChange()
        {
            if (email.Text.Equals("") || password.Text.Equals(""))
                setDisabledBtn();
            else
                setEnabledIBtn();
        }

        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void admin_btn_Click(object sender, EventArgs e)
        {
            new Prompt(this).Show();
        }
        
       
        private void setStudentData()
        {
            //admin.Id = adminMethods.getID(admin.Email); 
            student.Email = email.Text;
            student.Password = password.Text;
        }
        
        private void login_btn_Click(object sender, EventArgs e)
        {
            if(instractor_rbtn.Checked)
            {
                setInstructorData();
                if(instrcutorMethods.Login(instructor))
                {
                    MessageBox.Show("Successfuly Login !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    new instractor.Home(instructor.Email).Show();

                }
                else
                    MessageBox.Show("Invalid Login !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            else if (student_rbtn.Checked)
            {
                setStudentData();
                if(studentMethods.Login(student))
                {
                    MessageBox.Show("Successfuly Login !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    new student.Home(student.Email).Show();
                }
                else
                    MessageBox.Show("Invalid Login !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Choose Role To Login !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void setInstructorData()
        {
            instructor.Email = email.Text;
            instructor.Password = password.Text;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            email.Text = "";
           password.Text = "";
        }

        private void instractor_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void student_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
             inputTextChange();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }
    }
}
