using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.View.Admin
{
    public partial class GenerateReports : Form
    {
        private Form _Home;
        private string _adminEmail;

        public GenerateReports(Form home, string adminEmail)
        {
            InitializeComponent();

            _Home = home;
            _adminEmail = adminEmail;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            _Home.Visible = true;
        }
    }
}
