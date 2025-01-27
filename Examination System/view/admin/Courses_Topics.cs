using Examination_System.controller;
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

namespace Examination_System.view.admin
{
    public partial class Courses_Topics : Form
    {
        private Form _Home;
        private string _adminEmail;

        public Courses_Topics(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();
            _Home = home;
            _adminEmail = adminEmail;

            TableData.getData("courseView", "[Course Name]", search.Text, course_table);
            TableData.getData("topicsDetails", "[Topic Name]", search.Text, topic_table);

            topic_id.Enabled = false;
            topic_name.Enabled = false;
            course_id2.Enabled = false;
        }

        private void setDisabledItems()
        {
            search.Enabled = false;
        }

        private void setEnabledItems()
        {
            search.Enabled = true;
            search.Clear();
            search.Focus();
        }


        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Visible = true;
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

        private void course_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void topic_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (course_rbtn.Checked)
                TableData.getData("courseView", "[Course Name]", search.Text, course_table);
            else if (topic_rbtn.Checked)
                TableData.getData("topicsDetails", "[Topic Name]", search.Text, topic_table);
        }
    }
}
