using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.view.student
{
    public partial class TakeExam : Form
    {
        private bool flag = false; //
        private int totalSeconds = 10 * 60;

        public TakeExam()
        {
            InitializeComponent();

            panel3.BorderStyle = BorderStyle.FixedSingle;
            checkExamStatus();
        }


        private void checkExamStatus()
        {
            if(flag) //
            {
                MessageBox.Show("Exam is OFF", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
                new Home().Show();
            }
        }


        ////////////////////////////////////////////////////////////


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

        private void endExam_btn_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (totalSeconds >= 0)
            {
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                totalSeconds--;

                timer_txt.Text = $"{minutes:D2}:{seconds:D2}";
            }
            else
            {
                this.Close();
                new Home().Show();
                
                MessageBox.Show("The Exam is Over", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
