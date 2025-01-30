namespace Examination_System.view.instractor
{
    partial class MakeExam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakeExam));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.question_no = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.question_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.question = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.option_a = new System.Windows.Forms.TextBox();
            this.option_b = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.option_c = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.option_d = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.delete_btn = new System.Windows.Forms.Button();
            this.update_btn = new System.Windows.Forms.Button();
            this.insert_btn = new System.Windows.Forms.Button();
            this.course_exam = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.d_rbtn = new System.Windows.Forms.RadioButton();
            this.c_rbtn = new System.Windows.Forms.RadioButton();
            this.b_rbtn = new System.Windows.Forms.RadioButton();
            this.a_rbtn = new System.Windows.Forms.RadioButton();
            this.question_table = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.question_table)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.panel2.Location = new System.Drawing.Point(-9, 839);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1640, 26);
            this.panel2.TabIndex = 68;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-6, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1626, 119);
            this.panel1.TabIndex = 67;
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
            this.label2.Location = new System.Drawing.Point(659, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "\" Make Exam \"";
            // 
            // exit
            // 
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.exit.Location = new System.Drawing.Point(1532, 16);
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
            this.label1.Location = new System.Drawing.Point(607, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Examination System";
            // 
            // question_no
            // 
            this.question_no.BackColor = System.Drawing.Color.White;
            this.question_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.question_no.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.question_no.FormattingEnabled = true;
            this.question_no.Items.AddRange(new object[] {
            "1)",
            "2)",
            "3)",
            "4)",
            "5)",
            "6)",
            "7)",
            "8)",
            "9)",
            "10)"});
            this.question_no.Location = new System.Drawing.Point(195, 174);
            this.question_no.Name = "question_no";
            this.question_no.Size = new System.Drawing.Size(225, 32);
            this.question_no.TabIndex = 70;
            this.question_no.Tag = "";
            this.question_no.SelectedIndexChanged += new System.EventHandler(this.quesion_no_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label9.Location = new System.Drawing.Point(13, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 24);
            this.label9.TabIndex = 69;
            this.label9.Text = "Question No.";
            // 
            // question_type
            // 
            this.question_type.BackColor = System.Drawing.Color.White;
            this.question_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.question_type.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question_type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.question_type.FormattingEnabled = true;
            this.question_type.Items.AddRange(new object[] {
            "MCQ",
            "T/F"});
            this.question_type.Location = new System.Drawing.Point(195, 224);
            this.question_type.Name = "question_type";
            this.question_type.Size = new System.Drawing.Size(225, 32);
            this.question_type.TabIndex = 72;
            this.question_type.Tag = "";
            this.question_type.SelectedIndexChanged += new System.EventHandler(this.question_type_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label3.Location = new System.Drawing.Point(13, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 24);
            this.label3.TabIndex = 71;
            this.label3.Text = "Question Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label4.Location = new System.Drawing.Point(13, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 24);
            this.label4.TabIndex = 73;
            this.label4.Text = "Question";
            // 
            // question
            // 
            this.question.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question.ForeColor = System.Drawing.Color.Black;
            this.question.Location = new System.Drawing.Point(17, 347);
            this.question.Multiline = true;
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(1579, 149);
            this.question.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label5.Location = new System.Drawing.Point(15, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 75;
            this.label5.Text = "Option A";
            // 
            // option_a
            // 
            this.option_a.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option_a.ForeColor = System.Drawing.Color.Black;
            this.option_a.Location = new System.Drawing.Point(17, 542);
            this.option_a.Multiline = true;
            this.option_a.Name = "option_a";
            this.option_a.Size = new System.Drawing.Size(350, 156);
            this.option_a.TabIndex = 76;
            // 
            // option_b
            // 
            this.option_b.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option_b.ForeColor = System.Drawing.Color.Black;
            this.option_b.Location = new System.Drawing.Point(424, 542);
            this.option_b.Multiline = true;
            this.option_b.Name = "option_b";
            this.option_b.Size = new System.Drawing.Size(350, 156);
            this.option_b.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label6.Location = new System.Drawing.Point(422, 511);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 24);
            this.label6.TabIndex = 77;
            this.label6.Text = "Option B";
            // 
            // option_c
            // 
            this.option_c.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option_c.ForeColor = System.Drawing.Color.Black;
            this.option_c.Location = new System.Drawing.Point(836, 542);
            this.option_c.Multiline = true;
            this.option_c.Name = "option_c";
            this.option_c.Size = new System.Drawing.Size(350, 156);
            this.option_c.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label7.Location = new System.Drawing.Point(834, 511);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 24);
            this.label7.TabIndex = 79;
            this.label7.Text = "Option C";
            // 
            // option_d
            // 
            this.option_d.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option_d.ForeColor = System.Drawing.Color.Black;
            this.option_d.Location = new System.Drawing.Point(1246, 542);
            this.option_d.Multiline = true;
            this.option_d.Name = "option_d";
            this.option_d.Size = new System.Drawing.Size(350, 156);
            this.option_d.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label8.Location = new System.Drawing.Point(1244, 511);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 24);
            this.label8.TabIndex = 81;
            this.label8.Text = "Option D";
            // 
            // delete_btn
            // 
            this.delete_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.delete_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_btn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn.ForeColor = System.Drawing.Color.White;
            this.delete_btn.Location = new System.Drawing.Point(670, 784);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(266, 42);
            this.delete_btn.TabIndex = 85;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = false;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.Color.White;
            this.update_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update_btn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.update_btn.Location = new System.Drawing.Point(807, 731);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(240, 42);
            this.update_btn.TabIndex = 84;
            this.update_btn.Text = "Update";
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // insert_btn
            // 
            this.insert_btn.BackColor = System.Drawing.Color.White;
            this.insert_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insert_btn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.insert_btn.Location = new System.Drawing.Point(561, 731);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(240, 42);
            this.insert_btn.TabIndex = 83;
            this.insert_btn.Text = "Insert";
            this.insert_btn.UseVisualStyleBackColor = false;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // course_exam
            // 
            this.course_exam.BackColor = System.Drawing.Color.White;
            this.course_exam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.course_exam.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course_exam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.course_exam.FormattingEnabled = true;
            this.course_exam.Location = new System.Drawing.Point(195, 125);
            this.course_exam.Name = "course_exam";
            this.course_exam.Size = new System.Drawing.Size(225, 32);
            this.course_exam.TabIndex = 87;
            this.course_exam.Tag = "";
            this.course_exam.SelectedIndexChanged += new System.EventHandler(this.exam_course_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label10.Location = new System.Drawing.Point(15, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 24);
            this.label10.TabIndex = 86;
            this.label10.Text = "Course Exam";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.label11.Location = new System.Drawing.Point(15, 728);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 24);
            this.label11.TabIndex = 88;
            this.label11.Text = "Right Answer :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.d_rbtn);
            this.panel3.Controls.Add(this.c_rbtn);
            this.panel3.Controls.Add(this.b_rbtn);
            this.panel3.Controls.Add(this.a_rbtn);
            this.panel3.Location = new System.Drawing.Point(15, 758);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 40);
            this.panel3.TabIndex = 89;
            // 
            // d_rbtn
            // 
            this.d_rbtn.AutoSize = true;
            this.d_rbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.d_rbtn.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_rbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.d_rbtn.Location = new System.Drawing.Point(233, 3);
            this.d_rbtn.Name = "d_rbtn";
            this.d_rbtn.Size = new System.Drawing.Size(48, 28);
            this.d_rbtn.TabIndex = 3;
            this.d_rbtn.TabStop = true;
            this.d_rbtn.Text = "D";
            this.d_rbtn.UseVisualStyleBackColor = true;
            // 
            // c_rbtn
            // 
            this.c_rbtn.AutoSize = true;
            this.c_rbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.c_rbtn.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_rbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.c_rbtn.Location = new System.Drawing.Point(159, 3);
            this.c_rbtn.Name = "c_rbtn";
            this.c_rbtn.Size = new System.Drawing.Size(46, 28);
            this.c_rbtn.TabIndex = 2;
            this.c_rbtn.TabStop = true;
            this.c_rbtn.Text = "C";
            this.c_rbtn.UseVisualStyleBackColor = true;
            // 
            // b_rbtn
            // 
            this.b_rbtn.AutoSize = true;
            this.b_rbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_rbtn.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_rbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.b_rbtn.Location = new System.Drawing.Point(81, 3);
            this.b_rbtn.Name = "b_rbtn";
            this.b_rbtn.Size = new System.Drawing.Size(46, 28);
            this.b_rbtn.TabIndex = 1;
            this.b_rbtn.TabStop = true;
            this.b_rbtn.Text = "B";
            this.b_rbtn.UseVisualStyleBackColor = true;
            // 
            // a_rbtn
            // 
            this.a_rbtn.AutoSize = true;
            this.a_rbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.a_rbtn.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a_rbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(21)))));
            this.a_rbtn.Location = new System.Drawing.Point(7, 3);
            this.a_rbtn.Name = "a_rbtn";
            this.a_rbtn.Size = new System.Drawing.Size(46, 28);
            this.a_rbtn.TabIndex = 0;
            this.a_rbtn.TabStop = true;
            this.a_rbtn.Text = "A";
            this.a_rbtn.UseVisualStyleBackColor = true;
            // 
            // question_table
            // 
            this.question_table.AllowUserToAddRows = false;
            this.question_table.AllowUserToDeleteRows = false;
            this.question_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.question_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.question_table.Location = new System.Drawing.Point(481, 125);
            this.question_table.Name = "question_table";
            this.question_table.ReadOnly = true;
            this.question_table.RowHeadersWidth = 51;
            this.question_table.RowTemplate.Height = 24;
            this.question_table.Size = new System.Drawing.Size(1115, 209);
            this.question_table.TabIndex = 90;
            // 
            // MakeExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1612, 860);
            this.Controls.Add(this.question_table);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.course_exam);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.update_btn);
            this.Controls.Add(this.insert_btn);
            this.Controls.Add(this.option_d);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.option_c);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.option_b);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.option_a);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.question);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.question_type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.question_no);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MakeExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examination System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.question_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox question_no;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox question_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox question;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox option_a;
        private System.Windows.Forms.TextBox option_b;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox option_c;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox option_d;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button insert_btn;
        private System.Windows.Forms.ComboBox course_exam;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton a_rbtn;
        private System.Windows.Forms.RadioButton d_rbtn;
        private System.Windows.Forms.RadioButton c_rbtn;
        private System.Windows.Forms.RadioButton b_rbtn;
        private System.Windows.Forms.DataGridView question_table;
    }
}