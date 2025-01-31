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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Examination_System.View.Admin
{
    public partial class GenerateReports : Form
    {
        private Form _Home;
        private string _adminEmail;

        public GenerateReports(Form home, string adminEmail)
        {
            InitializeComponent();

            setDisabledItems();

            _Home = home;
            _adminEmail = adminEmail;
        }


        private void setDisabledItems()
        {
            param1.Enabled = false;
            param2.Enabled = false;
            generate_btn.Enabled = false;
        }

        private void setEnabledItems()
        {
            param1.Enabled = true;
            param2.Enabled = true;
            generate_btn.Enabled = true;
        }


        private bool checkData(int flag)
        {
            if (param1.Text != string.Empty && flag == 1)
                return true;

            else if (param1.Text != string.Empty && param2.Text != string.Empty && flag == 2)
                return true;

            return false;
        }


        ///////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Visible = true;
        }

        private void report_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(report_box.Text))
            {
                setEnabledItems();

                param1.Enabled = false;
                param2.Enabled = false;

                switch (report_box.SelectedIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        param1.Enabled = true;
                        break;
                    case 5:
                        param1.Enabled = true;
                        param2.Enabled = true;
                        break;
                }
            }
            else
                setDisabledItems();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            int parameter1, parameter2;

            if (int.TryParse(param1.Text, out parameter1))
            {
                switch (report_box.SelectedIndex)
                {
                    case 0:
                        TableData.PrintReports("GetStudentInfoByTracks", parameter1);
                        return;
                    case 1:
                        TableData.PrintReports("GetStudentGrades", parameter1);
                        return;
                    case 2:
                        TableData.PrintReports("GetInsCourse", parameter1);
                        return;
                    case 3:
                        TableData.PrintReports("GetCourseTopics", parameter1);
                        return;
                    case 4:
                        TableData.PrintReports("GetExamQuestionsAndChoices", parameter1);
                        return;
                }
            }


            if (report_box.SelectedIndex == 5 && int.TryParse(param1.Text, out parameter1)
                && int.TryParse(param2.Text, out parameter2))
            {
                TableData.PrintFreeformReport("GetStudentExamReport", parameter1, parameter2);
                return;
            }

            MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


    }
}
