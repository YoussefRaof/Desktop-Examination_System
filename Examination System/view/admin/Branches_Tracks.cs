using Examination_System.controller;
using Examination_System.Controller;
using Examination_System.Controller.BranchController;
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
        Branch branch;
        Track track;
        ITrackRepo trackMethods;

        public Branches_Tracks(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();
            branchMethods = new BranchMethods();
            adminMethods = new AdminMethods();
            branch = new Branch();
            track = new Track();
            trackMethods = new TrackMethods();

            _Home = home;

            _adminEmail = adminEmail;

            TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
            TableData.getData("trackView", "[Track Name]", search.Text, track_table);

           
            TableData.getData("branchAssignTrackView", "Track_Name", "", assigned_table);


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
                if (branch_name.Text != string.Empty)
                {
                    branch.BranchName = branch_name.Text;
                    branch.Admin_id_FK = adminMethods.getID("Admin", Home._email);
                    branchMethods.Insert(branch);
                    MessageBox.Show(" Branch is Insert Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
                    ClearBranchData();

                }
                else
                {
                    MessageBox.Show("Enter New Branch Name To Insert It!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (r == "Track")
            {
                if (track_name.Text != string.Empty && ins_id.Text != string.Empty)
                {
                    track.TrackName = track_name.Text;
                    track.Admin_id_FK = adminMethods.getID("Admin", Home._email);
                    var InsId = Convert.ToInt32(ins_id.Text);
                    var result = HelperMethods.CheckInstructor(InsId);
                    if (result == 1)
                    {
                        track.InstructorId = InsId;
                        trackMethods.Insert(track);
                        MessageBox.Show(" Track is Insert Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TableData.getData("trackView", "[Track Name]", search.Text, track_table);
                        ClearTrackData();


                    }
                    else if (result == 0)
                    {
                        MessageBox.Show(" Enter Instructor ID That Already Exists !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    else
                        MessageBox.Show("Fatal Error In Database !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

                else
                {
                    MessageBox.Show("Enter New Track Name & Instructor Id Manage Track!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;


                }


            }
            else
            {
                MessageBox.Show("Determine Which Table To Insert Into!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void ClearBranchData()
        {
            branch_name.Text = string.Empty;
        }

        private void ClearTrackData()
        {
            track_name.Text = string.Empty;
            ins_id.Text = string.Empty; 
        }

        private string CheckTableToInsertInto()
        {
            if (branch_name.Text != string.Empty && (track_name.Text == string.Empty && ins_id.Text == string.Empty))
            {
                return "Branch";
            }
            else if (branch_name.Text == string.Empty && (track_name.Text != string.Empty || ins_id.Text != string.Empty))
            {
                return "Track";
            }
            return string.Empty;
        }

       
        private void update_btn_Click(object sender, EventArgs e)
        {
            var r = CheckTableToDeleteOrUpdate();
            if (r == "Branch")
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
                            branch.BranchName = branch_name.Text;
                        }



                        var confirmation = MessageBox.Show($"Are you sure you want to update Branch with ID {branchId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        if (confirmation == DialogResult.Yes)
                        {

                            branchMethods.Update(branch);


                            MessageBox.Show("Branch Name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TableData.getData("branchView", "[Branch Name]", search.Text, branch_table);
                            ClearBranchData();




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
            else if (r == "Track")
            {
                if (track_table.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = track_table.SelectedRows[0];


                    if (selectedRow.Cells["Track ID"] != null && int.TryParse(selectedRow.Cells["Track ID"].Value.ToString(), out int trackId))
                    {

                        track.TrackId= trackId;
                        if (track_name.Text == string.Empty && ins_id.Text == string.Empty)
                        {
                            MessageBox.Show("Enter New Track Name Or Track Manager Id!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }
                        if (track_name.Text == string.Empty)
                        {
                            track.TrackName= selectedRow.Cells["Track Name"].Value.ToString();
                        }
                        else
                        {
                            track.TrackName= track_name.Text;
                        }

                        int Insid;
                        if (ins_id.Text == string.Empty)
                        {
                             Insid = HelperMethods.GetInstructorIdByName(selectedRow.Cells["Track Manager"].Value.ToString());
                            track.InstructorId = Insid;
                        }
                        else
                        {
                            var check = HelperMethods.CheckInstructor(Convert.ToInt32(ins_id.Text));
                            if(check == 1)
                                track.InstructorId = Convert.ToInt32(ins_id.Text);
                            else
                            {
                                MessageBox.Show("Update Track With Instructor Already Exists!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                        }



                        var confirmation = MessageBox.Show($"Are you sure you want to update Track with ID {trackId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        if (confirmation == DialogResult.Yes)
                        {

                            trackMethods.Update(track);


                            MessageBox.Show("Track updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TableData.getData("trackView", "[Track Name]", search.Text, track_table);

                            ClearTrackData();




                        }

                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the tracks 's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


            else if (r == "Track")
            {
                if (track_table.SelectedRows.Count == 1)
                {

                    DataGridViewRow selectedRow = track_table.SelectedRows[0];


                    if (selectedRow.Cells["Track ID"] != null && int.TryParse(selectedRow.Cells["Track ID"].Value.ToString(), out int trackId))
                    {

                        var confirmation = MessageBox.Show($"Are you sure you want to delete Track with ID {trackId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        int rowCount = track_table.RowCount;
                        if (confirmation == DialogResult.Yes)
                        {
                            track.TrackId= trackId;

                            trackMethods.Delete(track);
                            TableData.getData("trackView", "[Track Name]", search.Text, track_table);


                            if (track_table.RowCount == rowCount - 1)
                                MessageBox.Show("Track deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Track deleted failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the tracks's Id. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (branch_table.SelectedRows.Count > 1 )
            {
                MessageBox.Show("Please select exactly one row from Branch .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }

            if (track_table.SelectedRows.Count == 1)
            {
                return "Track";
            }
            if (track_table.SelectedRows.Count > 1 )
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

        private void assign_btn_Click(object sender, EventArgs e)
        {
            if (track_table.SelectedRows.Count != 1 || branch_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Branch and Track).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int branchId = Convert.ToInt32(branch_table.SelectedRows[0].Cells["Branch ID"].Value);


            int trackId = Convert.ToInt32(track_table.SelectedRows[0].Cells["Track ID"].Value);

            branch.BranchId= branchId;
            track.TrackId = trackId;




            int r = adminMethods.AssignTrackToBranch(branch, track);


            if (r == 1)
            {
                MessageBox.Show("Track successfully assigned to the Branch.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //TableData.getData("studentAssignCourse", "crs_name", "", stud_course_table);
                TableData.getData("branchAssignTrackView", "Track_Name", "", assigned_table);

            }
            else if (r == 0)
                MessageBox.Show("Duplicate Entry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void unassign_btn_Click(object sender, EventArgs e)
        {

            if (branch_table.SelectedRows.Count != 1 || track_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Branch and Track).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int trackId = Convert.ToInt32(track_table.SelectedRows[0].Cells["Track ID"].Value);


            int branchId = Convert.ToInt32(branch_table.SelectedRows[0].Cells["Branch ID"].Value);

            track.TrackId = trackId;
            branch.BranchId = branchId;

            int r = adminMethods.UnAssignTrackToBranch(branch, track);

            if (r == 1)
            {
                MessageBox.Show("Track successfully Unassigned to the Branch.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                TableData.getData("branchAssignTrackView", "Track_Name", "", assigned_table);

            }
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
