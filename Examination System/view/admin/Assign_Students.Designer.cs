﻿namespace Examination_System.view.admin
{
    partial class Assign_Students
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assign_Students));
            this.course_table = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.student_table = new System.Windows.Forms.DataGridView();
            this.assign_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.search = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.course_rbtn = new System.Windows.Forms.RadioButton();
            this.student_rbtn = new System.Windows.Forms.RadioButton();
            this.stud_course_table = new System.Windows.Forms.DataGridView();
            this.unassign_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.course_table)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.student_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stud_course_table)).BeginInit();
            this.SuspendLayout();
            // 
            // course_table
            // 
            this.course_table.AllowUserToAddRows = false;
            this.course_table.AllowUserToDeleteRows = false;
            this.course_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.course_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.course_table.Location = new System.Drawing.Point(656, 155);
            this.course_table.Name = "course_table";
            this.course_table.ReadOnly = true;
            this.course_table.RowHeadersWidth = 51;
            this.course_table.RowTemplate.Height = 24;
            this.course_table.Size = new System.Drawing.Size(632, 250);
            this.course_table.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label5.Location = new System.Drawing.Point(911, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 29);
            this.label5.TabIndex = 104;
            this.label5.Text = "Courses";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-7, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1321, 119);
            this.panel1.TabIndex = 105;
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.back.Location = new System.Drawing.Point(14, 16);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(56, 34);
            this.back.TabIndex = 4;
            this.back.Text = "←";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(469, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "\" Assign Students \"";
            // 
            // exit
            // 
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.exit.Location = new System.Drawing.Point(1222, 14);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 36);
            this.exit.TabIndex = 1;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(459, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Examination System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label3.Location = new System.Drawing.Point(240, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 29);
            this.label3.TabIndex = 106;
            this.label3.Text = "Students";
            // 
            // student_table
            // 
            this.student_table.AllowUserToAddRows = false;
            this.student_table.AllowUserToDeleteRows = false;
            this.student_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.student_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.student_table.Location = new System.Drawing.Point(10, 155);
            this.student_table.Name = "student_table";
            this.student_table.ReadOnly = true;
            this.student_table.RowHeadersWidth = 51;
            this.student_table.RowTemplate.Height = 24;
            this.student_table.Size = new System.Drawing.Size(632, 504);
            this.student_table.TabIndex = 107;
            // 
            // assign_btn
            // 
            this.assign_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.assign_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assign_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assign_btn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assign_btn.ForeColor = System.Drawing.Color.White;
            this.assign_btn.Location = new System.Drawing.Point(442, 761);
            this.assign_btn.Name = "assign_btn";
            this.assign_btn.Size = new System.Drawing.Size(210, 43);
            this.assign_btn.TabIndex = 108;
            this.assign_btn.Text = "Assign";
            this.assign_btn.UseVisualStyleBackColor = false;
            this.assign_btn.Click += new System.EventHandler(this.assign_btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.panel2.Location = new System.Drawing.Point(-7, 811);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1321, 22);
            this.panel2.TabIndex = 106;
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.search.Location = new System.Drawing.Point(442, 677);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(429, 35);
            this.search.TabIndex = 123;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(385, 676);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 124;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.course_rbtn);
            this.panel3.Controls.Add(this.student_rbtn);
            this.panel3.Location = new System.Drawing.Point(463, 714);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 46);
            this.panel3.TabIndex = 125;
            // 
            // course_rbtn
            // 
            this.course_rbtn.AutoSize = true;
            this.course_rbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.course_rbtn.Font = new System.Drawing.Font("Century Schoolbook", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course_rbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.course_rbtn.Location = new System.Drawing.Point(196, 3);
            this.course_rbtn.Name = "course_rbtn";
            this.course_rbtn.Size = new System.Drawing.Size(111, 31);
            this.course_rbtn.TabIndex = 1;
            this.course_rbtn.TabStop = true;
            this.course_rbtn.Text = "Course";
            this.course_rbtn.UseVisualStyleBackColor = true;
            this.course_rbtn.CheckedChanged += new System.EventHandler(this.topic_rbtn_CheckedChanged);
            // 
            // student_rbtn
            // 
            this.student_rbtn.AutoSize = true;
            this.student_rbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.student_rbtn.Font = new System.Drawing.Font("Century Schoolbook", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_rbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.student_rbtn.Location = new System.Drawing.Point(61, 3);
            this.student_rbtn.Name = "student_rbtn";
            this.student_rbtn.Size = new System.Drawing.Size(122, 31);
            this.student_rbtn.TabIndex = 0;
            this.student_rbtn.TabStop = true;
            this.student_rbtn.Text = "Student";
            this.student_rbtn.UseVisualStyleBackColor = true;
            this.student_rbtn.CheckedChanged += new System.EventHandler(this.course_rbtn_CheckedChanged);
            // 
            // stud_course_table
            // 
            this.stud_course_table.AllowUserToAddRows = false;
            this.stud_course_table.AllowUserToDeleteRows = false;
            this.stud_course_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stud_course_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stud_course_table.Location = new System.Drawing.Point(656, 452);
            this.stud_course_table.Name = "stud_course_table";
            this.stud_course_table.ReadOnly = true;
            this.stud_course_table.RowHeadersWidth = 51;
            this.stud_course_table.RowTemplate.Height = 24;
            this.stud_course_table.Size = new System.Drawing.Size(632, 207);
            this.stud_course_table.TabIndex = 126;
            // 
            // unassign_btn
            // 
            this.unassign_btn.BackColor = System.Drawing.Color.White;
            this.unassign_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unassign_btn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassign_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.unassign_btn.Location = new System.Drawing.Point(661, 761);
            this.unassign_btn.Name = "unassign_btn";
            this.unassign_btn.Size = new System.Drawing.Size(210, 43);
            this.unassign_btn.TabIndex = 132;
            this.unassign_btn.Text = "Unassign";
            this.unassign_btn.UseVisualStyleBackColor = false;
            this.unassign_btn.Click += new System.EventHandler(this.unassign_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label4.Location = new System.Drawing.Point(911, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 29);
            this.label4.TabIndex = 133;
            this.label4.Text = "Assigned";
            // 
            // Assign_Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1299, 830);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unassign_btn);
            this.Controls.Add(this.stud_course_table);
            this.Controls.Add(this.search);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.assign_btn);
            this.Controls.Add(this.student_table);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.course_table);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Assign_Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examination System";
            ((System.ComponentModel.ISupportInitialize)(this.course_table)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.student_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stud_course_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView course_table;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView student_table;
        private System.Windows.Forms.Button assign_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton course_rbtn;
        private System.Windows.Forms.RadioButton student_rbtn;
        private System.Windows.Forms.DataGridView stud_course_table;
        private System.Windows.Forms.Button unassign_btn;
        private System.Windows.Forms.Label label4;
    }
}