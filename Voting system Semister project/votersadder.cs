using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Voting_system_Semister_project
{
    public partial class votersadder : Form
    {
        string connection = "Data Source=DESKTOP-LE3U1BT;Initial Catalog=voting_system;Integrated Security=True";
        candidateadder fo4 = new candidateadder();
        
        public votersadder()
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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "" || bunifuMetroTextbox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please Enter All fields", "INFO", MessageBoxButtons.OK);
            }

            else
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                   // fo4.getpollingname();
                    string xxx = candidateadder.pollname;
                    
                    String queryadd = "insert into " + xxx + " (Name,reg_No,Fingerprint,voted_to) values ('" + bunifuMetroTextbox1.Text + "', '" + bunifuMetroTextbox2.Text + "', '" + textBox1.Text + "','" + "xxx" + "')";
                    SqlCommand cmd = new SqlCommand(queryadd, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("voter Details Added !", "Details info");

                   
                    int x=a++;
                    label14.Text = "Det Voter No : " + x;

                    bunifuMetroTextbox1.Text = "";
                    bunifuMetroTextbox2.Text = "";
                    textBox1.Text = "";

                    if (x > candidateadder.voternum)
                    {
                        MessageBox.Show("All" + x +" voters Details Are added you will be taken to main menu", "Info");
                        mainmenu mm = new mainmenu();
                        this.Visible = false;
                        mm.Show();
                    }
                       
                }

                else
                {
                    MessageBox.Show("Connection Failed", "Connection Info");
                }

                MessageBox.Show("All details of voter added", "INFO", MessageBoxButtons.OK);

            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            login1 f2 = new login1();
            this.Visible = false;
            f2.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = null;
            bunifuMetroTextbox2.Text = null;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            candidateadder f4 = new candidateadder();
            this.Visible = false;
            f4.Show();
        }
        private void tick(object sender, EventArgs e)
        {
            label18.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        System.Windows.Forms.Timer t = null;

        private void starttimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(tick);
            t.Enabled = true;
        }

        public int a=1;

        private void votersadder_Load(object sender, EventArgs e)
        {
            starttimer();
            label17.Text = DateTime.Now.ToShortDateString();
            label14.Text = "Det Voter No : "+a;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
