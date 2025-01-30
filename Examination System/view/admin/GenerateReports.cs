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
            if (report_box.Text != string.Empty)
            {
                setEnabledItems();
                if (report_box.SelectedIndex == 0)
                {
                    param1.Enabled = true;
                }
                else
                    param2.Enabled= false;


                if (report_box.SelectedIndex == 1)
                {
                    param1.Enabled = true;
                }
                else 
                    param2.Enabled= false;


                if (report_box.SelectedIndex == 2)
                {
                    param1.Enabled = true;
                }
                else
                    param2.Enabled= false;


                if (report_box.SelectedIndex == 3)
                {
                    param1.Enabled = true;
                }
                else
                    param2.Enabled = false;


                if (report_box.SelectedIndex == 4)
                {
                    param1.Enabled = true;
                }
                else
                    param2.Enabled= false;


                if (report_box.SelectedIndex == 5)
                {
                    param1.Enabled = true;
                    param2.Enabled= true;
                }
            }
            else
            {
                setDisabledItems();
            }
        }
    }
}
