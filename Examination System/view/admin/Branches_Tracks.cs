using Examination_System.controller;
using Examination_System.Controller;
using Examination_System.Controller.BranchController;
using Examination_System.Controller.BranchTrackController;
using Examination_System.Controller.StudentController;
using Examination_System.Controller.TrackController;
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
        ITrackRepo trackMethods;
        IBranchTrackRepo branchTrackMethods;
        Branch branch;
        Track trackobj;
        Branch_Track branch_Track;

        public Branches_Tracks(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();
            branchMethods = new BranchMethods();
            adminMethods = new AdminMethods();
            branch = new Branch();
            trackobj = new Track();
            branch_Track = new Branch_Track();
            trackMethods = new TrackMethods();
            branchTrackMethods = new BranchTrackMethods();

            _Home = home;

            _adminEmail = adminEmail;

            TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
            TableData.getData("trackView", "[Track Name]", search.Text, track_table);
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
            var r = CheckTableToInsertInto();
            if (r == "Branch")
            {
                branch.BranchName = branch_name.Text;
                branch.Admin_id_FK = adminMethods.getID("Admin", Home._email);
                branchMethods.Insert(branch);
                TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
                branch_name.Text = string.Empty;
                MessageBox.Show("Branch Added Successfuly !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (r == "Track")
            {
                if (track_name.Text == string.Empty || ins_id.Text == string.Empty || branch_id2.Text == string.Empty)
                    MessageBox.Show("Enter All Fields To Insert Track !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    trackobj.TrackName = track_name.Text;
                    trackobj.InstructorId = Convert.ToInt32(ins_id.Text);
                    trackobj.BranchId = Convert.ToInt32(branch_id2.Text);
                    trackobj.Admin_id_FK = adminMethods.getID("Admin", Home._email);
                    if (HelperMethods.CheckBranch(trackobj.BranchId) == 1 && HelperMethods.CheckInstructor(trackobj.InstructorId) == 1)
                    {
                        trackobj.TrackId = HelperMethods.InsertTrack(trackobj);
                        MessageBox.Show("Track Inserted Successfully !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TableData.getData("trackView", "[Track Name]", search.Text, track_table);

                        branch_Track.BranchId = trackobj.BranchId;
                        branch_Track.TrackId = trackobj.TrackId;

                        branchTrackMethods.Insert(branch_Track);
                        MessageBox.Show($"Track With Id {branch_Track.TrackId}  Successfully Assigned To Branch {branch_Track.BranchId} !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearData();

                    }
                    else
                    {
                        MessageBox.Show("Enter BranchId & Instructor Id Already Exists !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData();
                        return;
                    }
                }


            }
        }

        private void ClearData()
        {
            track_name.Text = string.Empty;
            ins_id.Text = string.Empty;
            branch_id2.Text = string.Empty;
        }

        private string CheckTableToInsertInto()
        {
            if ((track_name.Text == string.Empty ||
                ins_id.Text == string.Empty ||
                branch_id2.Text == string.Empty) &&
                branch_name.Text != string.Empty)
            {
                return "Branch";

            }
            else if (branch_name.Text == string.Empty && ((track_name.Text != string.Empty &&
                ins_id.Text != string.Empty &&
                branch_id2.Text != string.Empty)))
                return "Track";
            else
                MessageBox.Show("Classify Which Table To Insert Into");

            return string.Empty;

        }

        //private void update_btn_Click(object sender, EventArgs e)
        //{
        //    var r = CheckTableToDeleteOrUpdate();
        //    if (r == "Branch")
        //    {
        //        if (branch_table.SelectedRows.Count > 0)
        //        {

        //            DataGridViewRow selectedRow = branch_table.SelectedRows[0];


        //            if (selectedRow.Cells["Branch ID"] != null && int.TryParse(selectedRow.Cells["Branch ID"].Value.ToString(), out int branchId))
        //            {

        //                branch.BranchId = branchId;
        //                if (branch_name.Text == string.Empty)
        //                {
        //                    MessageBox.Show("Enter New Branch Name !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return;

        //                }
        //                else
        //                {
        //                    branch.BranchName = branch_name.Text;
        //                }


        //                var confirmation = MessageBox.Show($"Are you sure you want to update Branch with SSN {branchId}?",
        //                                                   "Confirmation",
        //                                                   MessageBoxButtons.YesNo,
        //                                                   MessageBoxIcon.Warning);

        //                if (confirmation == DialogResult.Yes)
        //                {

        //                    branchMethods.Update(branch);


        //                    MessageBox.Show("Branch Name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
        //                    branch_name.Text = string.Empty;




        //                }

        //            }
        //            else
        //            {
        //                MessageBox.Show("Unable to retrieve the branch 's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else if (r == "Track")
        //    {
        //        if (track_table.SelectedRows.Count > 0)
        //        {

        //            DataGridViewRow selectedRow = track_table.SelectedRows[0];


        //            if (selectedRow.Cells["Track ID"] != null && int.TryParse(selectedRow.Cells["Track ID"].Value.ToString(), out int trackId))
        //            {

        //                trackobj.TrackId = trackId;
        //                if (track_name.Text == string.Empty)
        //                {
        //                    trackobj.TrackName = selectedRow.Cells["Track Name"].Value.ToString();
        //                }
        //                else
        //                {
        //                    trackobj.TrackName = track_name.Text;
        //                }

        //                if (ins_id.Text == string.Empty)
        //                {
        //                    string TrackManager = selectedRow.Cells["Track Manager"].Value.ToString();
        //                    int InsId = HelperMethods.GetInstructorIdByName(TrackManager);
        //                    trackobj.InstructorId = InsId;
        //                }
        //                else
        //                {
        //                    int InsId = Convert.ToInt32(ins_id.Text);
        //                    if (HelperMethods.CheckInstructor(InsId) == 1)
        //                    {
        //                        trackobj.InstructorId = Convert.ToInt32(ins_id.Text);

        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Update Instructor Id By Exisiting ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        ins_id.Text = string.Empty;
        //                        return;

        //                    }
        //                }




        //                if (branch_id2.Text == string.Empty)
        //                {
        //                    int BId = Convert.ToInt32(branch_id2.Text);
        //                    if (HelperMethods.CheckBranch(BId) == 1)
        //                    {

        //                        branch_Track.BranchId = selectedRow.Cells["stud_email"].Value.ToString();
        //                    }
        //                }
        //                else
        //                {
        //                    student.Email = email.Text;
        //                }


        //                if (phone.Text == string.Empty)
        //                {
        //                    student.Phone = selectedRow.Cells["stud_phone"].Value.ToString();
        //                }
        //                else
        //                {
        //                    student.Phone = phone.Text;
        //                }

        //                //Address
        //                if (address.Text == string.Empty)
        //                {
        //                    student.Address = selectedRow.Cells["stud_address"].Value.ToString();
        //                }
        //                else
        //                {
        //                    student.Address = address.Text;
        //                }


        //                //Gender
        //                if (gender.Text == string.Empty)
        //                {
        //                    student.Gender = (Gender)Enum.Parse(typeof(Gender), selectedRow.Cells["stud_gender"].Value.ToString());
        //                }
        //                else
        //                {
        //                    student.Gender = (Gender)Enum.Parse(typeof(Gender), gender.Text);
        //                }

        //                //Bdate

        //                if (birthdate.Text == string.Empty)
        //                {
        //                    student.BirthDate = selectedRow.Cells["stud_birthdate"].Value.ToString();
        //                }
        //                else
        //                {
        //                    student.BirthDate = birthdate.Value.ToString("yyyy-MM-dd");
        //                }

        //                //TrackId

        //                if (track_id.Text == string.Empty)
        //                {
        //                    student.TrackId = Convert.ToInt32(selectedRow.Cells["track_id_FK"].Value.ToString());
        //                }
        //                else
        //                {
        //                    student.TrackId = Convert.ToInt32(track_id.Text);
        //                }

        //                student.TrackId = int.TryParse(track_id.Text, out int TrackValue) ? TrackValue : Convert.ToInt32(selectedRow.Cells["track_id_FK"].Value.ToString());


        //                student.Gender = Enum.TryParse(gender.Text, out Gender Value) ? Value : (Gender)Enum.Parse(typeof(Gender), (selectedRow.Cells["stud_gender"].Value.ToString()));




        //                var confirmation = MessageBox.Show($"Are you sure you want to update Student with SSN {studentSSN}?",
        //                                                   "Confirmation",
        //                                                   MessageBoxButtons.YesNo,
        //                                                   MessageBoxIcon.Warning);

        //                if (confirmation == DialogResult.Yes)
        //                {

        //                    studentMethods.Update(student, null);


        //                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    clearData();

        //                    TableData.getData("studentView", "stud_fname", search.Text, students_table);
        //                }

        //            }
        //            else
        //            {
        //                MessageBox.Show("Unable to retrieve the student's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}

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
