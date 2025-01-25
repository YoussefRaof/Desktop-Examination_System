using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.View
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            circularBar.Value = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            circularBar.Value += 1;
            circularBar.Text = circularBar.Value.ToString() + "%";

            if (circularBar.Value == 100)
            {
                timer.Enabled = false;
                this.Visible = false;

                new view.Login().Show();
            }
        }
    }
}
