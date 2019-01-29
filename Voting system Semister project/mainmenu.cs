using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Voting_system_Semister_project
{
    public partial class mainmenu : Form
    {
        public static string pollname = "";
        public mainmenu()
        {
            InitializeComponent();
        }

        public string getpollingname()
        {
            pollname = comboBox1.Text;
            return pollname;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            login1 f2 = new login1();
            this.Visible = false;
            f2.Show();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text != "")
            {
                getpollingname();

                votingmenu f6 = new votingmenu();
                this.Visible = false;
                f6.Show();
            }

           else 
            {
                MessageBox.Show("Please Select option in Polling box");
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if(comboBox2.Text != "")
            {
                results rs = new results();
                this.Hide();
                rs.Show();

            }

            else
            {
               
             MessageBox.Show("Please Select option in result box");
                
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        System.Windows.Forms.Timer t = null;
        private void starttimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(tick);
            t.Enabled = true;
        }

        private void mainmenu_Load(object sender, EventArgs e)
        {
            starttimer();
            label6.Text = DateTime.Now.ToShortDateString();

       //     String[] lineOfContents = File.ReadAllLines("C:\\Users\\Hp\\Desktop\\arduieno\\votings.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split('\n');
                comboBox1.Items.Add(tokens[0]);
            }

            String[] lineOfContents1 = File.ReadAllLines("C:\\Users\\Hp\\Desktop\\arduieno\\votings_compleated.txt");
            foreach (var line in lineOfContents1)
            {
                string[] tokens = line.Split('\n');
                comboBox2.Items.Add(tokens[0]);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
