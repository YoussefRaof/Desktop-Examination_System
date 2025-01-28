using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.View
{
    public partial class Start : Form
    {
        private static Mutex mutex = null;

        public Start()
        {
            OpenUniqueTab();
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

        private void OpenUniqueTab()
        {
            const string appName = "Examination System";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("The application is already running !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

    }
}
