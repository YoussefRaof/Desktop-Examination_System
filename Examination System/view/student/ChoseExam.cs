using Examination_System.controller;
using Examination_System.view.student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.View.student
{
    public partial class ChoseExam : Form
    {
        private Form _Home;
        private string _email;

        public ChoseExam(Form Home, string email)
        {
            InitializeComponent();
            TableData.fillComboBox(course); //

            _Home = Home;
            _email = email;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Show();
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            try
            {
                new TakeExam(_Home, _email).Show();
            }
            catch (Exception ex)
            {
                //
            }
            this.Close();
        }
    }
}
