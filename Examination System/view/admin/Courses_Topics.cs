using Examination_System.controller;
using Examination_System.Controller.BranchController;
using Examination_System.Controller;
using Examination_System.Controller.TopicController;
using Examination_System.Controller.TrackController;
using Examination_System.model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using Examination_System.Controller.CourseController;

namespace Examination_System.view.admin
{
    public partial class Courses_Topics : Form
    {
        private Form _Home;
        private string _adminEmail;
        Topic topic;
        Course course;
        model.Track track;
        ICourseRepo courseMethods;
        ITopicRepo topicMethods;
        IAdminRepo adminMethods;

        public Courses_Topics(Form home, string adminEmail)
        {
            InitializeComponent();
            setDisabledItems();
            _Home = home;
            _adminEmail = adminEmail;
            topic = new Topic();
            course = new Course();
            track = new model.Track();
            courseMethods = new CourseMethods();
            topicMethods = new TopicMethods();
            adminMethods = new AdminMethods();

            TableData.getData("courseView", "[Course Name]", search.Text, course_table);
            TableData.getData("topicsDetails", "[Topic Name]", search.Text, topic_table);

            TableData.getData("trackView", "[Track Name]", "", track_table);
            TableData.getData("Track_Has_CourseView", "[Track Name]", "", assigned_table);
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

        private string CheckTableToInsertInto()
        {
            if (topic_name.Text != string.Empty && (course_name.Text == string.Empty && topic_id.Text == string.Empty))
            {
                return "Topic";
            }
            else if (topic_name.Text == string.Empty && (course_name.Text != string.Empty || topic_id.Text != string.Empty))
            {
                return "Course";
            }
            return string.Empty;
        }
        private void insert_btn_Click(object sender, EventArgs e)
        {
            //Check Which Table To Insert 
            var r = CheckTableToInsertInto();
            if (r == "Topic")
            {
                if (topic_name.Text != string.Empty)
                {
                    topic.TopicName= topic_name.Text;
                    topic.Admin_id_FK = adminMethods.getID("Admin", Home._email);
                    topicMethods.Insert(topic);
                    MessageBox.Show("Topic is Inserted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TableData.getData("topicsDetails", "[Topic Name]", search.Text, topic_table);

                    ClearTopicData();

                }
                else
                {
                    MessageBox.Show("Enter New Topic Name To Insert It!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (r == "Course")
            {
                if (course_name.Text != string.Empty && topic_id.Text != string.Empty)
                {
                    course.CourseName= course_name.Text;
                    course.Admin_id_FK = adminMethods.getID("Admin", Home._email);
                    var topicId = Convert.ToInt32(topic_id.Text);
                    var result = HelperMethods.CheckTopic(topicId);
                    if (result == 1)
                    {
                        course.TopicId = topicId;
                        courseMethods.Insert(course); // Im
                        MessageBox.Show("Course is Inserted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TableData.getData("courseView", "[Course Name]", search.Text, course_table);

                        ClearCourseData();


                    }
                    else if (result == 0)
                    {
                        MessageBox.Show(" Enter Topic ID That Already Exists !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    else
                        MessageBox.Show("Fatal Error In Database !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

                else
                {
                    MessageBox.Show("Enter New Course Name & Topic Id For This Course!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;


                }


            }
            else
            {
                MessageBox.Show("Determine Which Table To Insert Into!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void ClearCourseData()
        {
           course_name.Text = string.Empty;
           topic_id.Text = string.Empty;
        }

        private void ClearTopicData()
        {
            topic_name.Text = string.Empty;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            var r = CheckTableToDeleteOrUpdate();
            if (r == "Topic")
            {
                if (topic_table.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = topic_table.SelectedRows[0];


                    if (selectedRow.Cells["Topic ID"] != null && int.TryParse(selectedRow.Cells["Topic ID"].Value.ToString(), out int topicId))
                    {

                        topic.TopicId = topicId;
                        if (topic_name.Text == string.Empty)
                        {
                            MessageBox.Show("Enter New Topic Name !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }
                        else
                        {
                            topic.TopicName = topic_name.Text;
                        }



                        var confirmation = MessageBox.Show($"Are you sure you want to update Topic with ID {topicId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        if (confirmation == DialogResult.Yes)
                        {

                            topicMethods.Update(topic);


                            MessageBox.Show("Topic Name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TableData.getData("topicsDetails", "[Topic Name]", search.Text, topic_table);

                            ClearTopicData();




                        }

                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the Topic's ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (r == "Course")
            {
                if (course_table.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = course_table.SelectedRows[0];


                    if (selectedRow.Cells["Course ID"] != null && int.TryParse(selectedRow.Cells["Course ID"].Value.ToString(), out int courseId))
                    {

                        course.CourseId= courseId;
                        if (course_name.Text == string.Empty && topic_id.Text == string.Empty)
                        {
                            MessageBox.Show("Enter New Course Name Or Existing Topic Id!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }
                        if (course_name.Text == string.Empty)
                        {
                            course.CourseName= selectedRow.Cells["Course Name"].Value.ToString();
                        }
                        else
                        {
                            course.CourseName= course_name.Text;
                        }

                        int topicId;
                        if (topic_id.Text == string.Empty)
                        {
                            topicId = HelperMethods.GetTopicIdByName(selectedRow.Cells["Topic Name"].Value.ToString());
                            course.TopicId= topicId;
                        }
                        else
                        {
                            var check = HelperMethods.CheckTopic(Convert.ToInt32(topic_id.Text));
                            if (check == 1)
                                course.TopicId= Convert.ToInt32(topic_id.Text);
                            else
                            {
                                MessageBox.Show("Update Course With Topic Already Exists!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCourseData();
                                return;
                            }

                        }



                        var confirmation = MessageBox.Show($"Are you sure you want to update Course with ID {courseId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        if (confirmation == DialogResult.Yes)
                        {

                            courseMethods.Update(course);


                            MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TableData.getData("courseView", "[Course Name]", search.Text, course_table);


                            ClearCourseData();




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
            if (r == "Topic")
            {
                if (topic_table.SelectedRows.Count == 1)
                {

                    DataGridViewRow selectedRow = topic_table.SelectedRows[0];


                    if (selectedRow.Cells["Topic ID"] != null && int.TryParse(selectedRow.Cells["Topic ID"].Value.ToString(), out int topicId))
                    {

                        var confirmation = MessageBox.Show($"Are you sure you want to delete topic with ID {topicId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        int rowCount = topic_table.RowCount;
                        if (confirmation == DialogResult.Yes)
                        {
                            topic.TopicId = topicId;

                            topicMethods.Delete(topic);
                            TableData.getData("topicsDetails", "[Topic Name]", search.Text, topic_table);



                            if (topic_table.RowCount == rowCount - 1)
                                MessageBox.Show("Topic deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Topic deleted failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the branch's Id. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (r == "Course")
            {
                if (course_table.SelectedRows.Count == 1)
                {

                    DataGridViewRow selectedRow = course_table.SelectedRows[0];


                    if (selectedRow.Cells["Course ID"] != null && int.TryParse(selectedRow.Cells["Course ID"].Value.ToString(), out int courseId))
                    {

                        var confirmation = MessageBox.Show($"Are you sure you want to delete Course with ID {courseId}?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                        int rowCount = course_table.RowCount;
                        if (confirmation == DialogResult.Yes)
                        {
                            course.CourseId = courseId;

                            courseMethods.Delete(course);
                            TableData.getData("courseView", "[Course Name]", search.Text, course_table);



                            if (course_table.RowCount == rowCount - 1)
                                MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Course deleted failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the tracks's Id. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

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
        private string CheckTableToDeleteOrUpdate()
        {
            if (topic_table.SelectedRows.Count >= 1 && course_table.SelectedRows.Count >= 1)
            {
                MessageBox.Show("Please select exactly one row from One table (Topic Or Course).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            if (topic_table.SelectedRows.Count == 1)
            {
                return "Topic";
            }
            if (topic_table.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select exactly one row from Topic .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }

            if (course_table.SelectedRows.Count == 1)
            {
                return "Course";
            }
            if (course_table.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select exactly one row from Course .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }

            return string.Empty;
        }

        private void assign_btn_Click(object sender, EventArgs e)
        {
            if (track_table.SelectedRows.Count != 1 || course_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Course and Track).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int courseId = Convert.ToInt32(course_table.SelectedRows[0].Cells["Course ID"].Value);


            int trackId = Convert.ToInt32(track_table.SelectedRows[0].Cells["Track ID"].Value);

            course.CourseId= courseId;
            track.TrackId = trackId;




            int r = adminMethods.AssginCourseToTrack(course, track);


            if (r == 1)
            {
                MessageBox.Show("Course successfully assigned to the Track.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //TableData.getData("studentAssignCourse", "crs_name", "", stud_course_table);
                TableData.getData("Track_Has_CourseView", "[Track Name]", "", assigned_table);


            }
            else if (r == 0)
                MessageBox.Show("Duplicate Entry", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void unassign_btn_Click(object sender, EventArgs e)
        {
            if (course_table.SelectedRows.Count != 1 || track_table.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one row from each table (Course and Track).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = Convert.ToInt32(course_table.SelectedRows[0].Cells["Course ID"].Value);

            int trackId = Convert.ToInt32(track_table.SelectedRows[0].Cells["Track ID"].Value);


            course.CourseId= courseId;
            track.TrackId = trackId;

            int r = adminMethods.UnAssginCourseToTrack(course, track);

            if (r == 1)
            {
                MessageBox.Show("Course successfully Unassigned to the Track.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TableData.getData("Track_Has_CourseView", "[Track Name]", "", assigned_table);

            }
            else
                MessageBox.Show("Database Exception", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
