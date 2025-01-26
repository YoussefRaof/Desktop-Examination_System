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
using System.Xml;

namespace Examination_System.view.student
{
    public partial class Information : Form
    {
        private Student student;
        private IStudentRepo studentMethods;
        private Form _Home;

        public Information(Form home, string email)
        {
            InitializeComponent();

            setDisabledItems();
            currentPass.UseSystemPasswordChar = true;
            newPass.UseSystemPasswordChar = true;
            confirmPass.UseSystemPasswordChar = true;

            student = new Student();
            studentMethods = new StudentMethods();
            emailLabel.Text = email;
            nameLabel.Text = studentMethods.getName("Student", email);
            _Home = home;
        }


        private void setDisabledItems()
        {
            edit_btn.Enabled = false;
        }

        private void setEnabledItems()
        {
            edit_btn.Enabled = true;
        }

        private void inputTextChange()
        {
            if (currentPass.Text == "" || newPass.Text == "" || confirmPass.Text == "")
                setDisabledItems();
            else
                setEnabledItems();
        }


        private void setData()
        {
            student.Email = emailLabel.Text;
            student.SSN = studentMethods.getSSN("Student", student.Email);
            student.Password = newPass.Text;
        }


        private bool checkData()
        {
            if (currentPass.Text != string.Empty && newPass.Text != string.Empty && confirmPass.Text != string.Empty)
                if (newPass.Text == confirmPass.Text)
                    return true;

            return false;
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

        private void currentPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void newPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void confirmPass_TextChanged(object sender, EventArgs e)
        {
            inputTextChange();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                setData();

                try
                {
                    if (studentMethods.checkPassword(currentPass.Text, "Student", student.Email))
                    {
                        studentMethods.Update(student, 1);
                        MessageBox.Show("Successfuly Updated !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Update failed check your data !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
                MessageBox.Show("Update failed check your data !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
