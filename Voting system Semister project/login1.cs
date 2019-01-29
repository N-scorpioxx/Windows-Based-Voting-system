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
    public partial class login1 : Form
    {
        public login1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            starttimer();
            label8.Text = DateTime.Now.ToShortDateString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (label7.Text == "VALIDATED")
            {
                candidateadder f3 = new candidateadder();
                this.Visible = false;
                f3.Show();
            }

            else if(label7.Text == "INVALID PRINT !")
            {

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            mainmenu f1 = new mainmenu();
            this.Visible = false;
            f1.Show();
        }

        private void tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        System.Windows.Forms.Timer t = null;

        private void starttimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(tick);
            t.Enabled = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
