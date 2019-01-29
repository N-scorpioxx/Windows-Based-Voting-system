using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voting_system_Semister_project
{
    public partial class results : Form
    {
        public results()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            mainmenu mm = new mainmenu();
            this.Hide();
            mm.Show();
           
           
        }

        private void tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        System.Windows.Forms.Timer t = null;

        private void starttimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(tick);
            t.Enabled = true;
        }

        private void results_Load(object sender, EventArgs e)
        {
            starttimer();
            label15.Text = DateTime.Now.ToShortDateString();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
