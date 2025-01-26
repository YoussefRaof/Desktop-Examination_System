using Examination_System.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Examination_System.view.admin
{
    public partial class Branches_Tracks : Form
    {
        private Form _Home;
        private string _adminEmail;

        public Branches_Tracks(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();

            _Home = home;
            _adminEmail = adminEmail;

            TableData.getData("Branch", "branch_name", search.Text, branch_table);
            TableData.getData("Track", "track_name", search.Text, track_table);
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

        private void branch_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void track_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            setEnabledItems();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (branch_rbtn.Checked)
                TableData.getData("Branch", "branch_name", search.Text, branch_table);
            else if (track_rbtn.Checked)
                TableData.getData("Track", "track_name", search.Text, track_table);
        }
    }
}
