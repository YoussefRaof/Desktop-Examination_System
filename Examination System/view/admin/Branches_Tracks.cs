using Examination_System.controller;
using Examination_System.Controller.BranchController;
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
        IBranchRepo branchMethods;
        IAdminRepo adminMethods;
        Branch branch;

        public Branches_Tracks(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();
            branchMethods = new BranchMethods();
            adminMethods = new AdminMethods();
            branch = new Branch();

            _Home = home;

            _adminEmail = adminEmail;

            TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
            TableData.getData("trackView", "[Track Name]", search.Text, track_table);

            //TableData.getData("", "", "", assigned_table);
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
            //Check Which Table To Insert 
            //var r = CheckTableToInsertInto();
            //if (r == "Branch")
            //{
            //    branch.BranchName = branch_name.Text;
            //    branch.Admin_id_FK = adminMethods.getID("Admin", Home._email);
            //    branchMethods.Insert(branch);
            //    TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
            //    branch_name.Text = string.Empty;
            //    MessageBox.Show("Branch Added Successfuly !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        //private string CheckTableToInsertInto()
        //{
        //    if ((track_id.Text == string.Empty ||
        //        track_name.Text == string.Empty ||
        //        ins_id.Text == string.Empty ||
        //        branch_id2.Text == string.Empty) &&
        //        branch_name.Text != string.Empty)
        //    {
        //        return "Branch";

        //    }
        //    else if (branch_name.Text == string.Empty && ((track_id.Text != string.Empty &&
        //        track_name.Text != string.Empty &&
        //        ins_id.Text != string.Empty &&
        //        branch_id2.Text != string.Empty)))
        //        return "Track";
        //    else
        //        MessageBox.Show("Classify Which Table To Insert Into");

        //    return string.Empty;

        //}

        private void update_btn_Click(object sender, EventArgs e)
        {
            var r = CheckTableToDeleteOrUpdate();
            if(r == "Branch")
            {
                if (branch_table.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = branch_table.SelectedRows[0];


                    if (selectedRow.Cells["Branch ID"] != null && int.TryParse(selectedRow.Cells["Branch ID"].Value.ToString(), out int branchId))
                    {

                        branch.BranchId = branchId;
                        if (branch_name.Text == string.Empty)
                        {
                            MessageBox.Show("Enter New Branch Name !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }
                        else
                        {
                            branch.BranchName= branch_name.Text;
                        }


                        var confirmation = MessageBox.Show($"Are you sure you want to update Branch with SSN {branchId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        if (confirmation == DialogResult.Yes)
                        {

                            branchMethods.Update(branch);


                            MessageBox.Show("Branch Name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
                            branch_name.Text = string.Empty;




                        }

                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the branch 's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            var r = CheckTableToDeleteOrUpdate();
            if (r == "Branch")
            {
                if (branch_table.SelectedRows.Count == 1)
                {

                    DataGridViewRow selectedRow = branch_table.SelectedRows[0];


                    if (selectedRow.Cells["Branch ID"] != null && int.TryParse(selectedRow.Cells["Branch ID"].Value.ToString(), out int branchId))
                    {

                        var confirmation = MessageBox.Show($"Are you sure you want to delete branch with ID {branchId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        int rowCount = branch_table.RowCount;
                        if (confirmation == DialogResult.Yes)
                        {
                            branch.BranchId = branchId;

                            branchMethods.Delete(branch);
                            TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);


                            if (branch_table.RowCount == rowCount - 1)
                                MessageBox.Show("Branch deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Branch deleted failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the branch's Id. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string CheckTableToDeleteOrUpdate()
        {
            if (track_table.SelectedRows.Count >= 1 && branch_table.SelectedRows.Count >= 1)
            {
                MessageBox.Show("Please select exactly one row from One table (Branch Or Track).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            if (branch_table.SelectedRows.Count == 1)
            {
                return "Branch";
            }
            if (branch_table.SelectedRows.Count > 1 || branch_table.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select exactly one row from Branch .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }

            if (track_table.SelectedRows.Count == 1)
            {
                return "Track";
            }
            if (track_table.SelectedRows.Count > 1 || track_table.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select exactly one row from Track .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }

            return string.Empty;
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
                TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
            else if (track_rbtn.Checked)
                TableData.getData("trackView", "[Track Name]", search.Text, track_table);
        }
    }
}
