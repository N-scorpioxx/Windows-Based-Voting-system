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
using System.IO;

namespace Voting_system_Semister_project
{
    public partial class candidateadder : Form
    {
        public static string pollname = "";
        public static int voternum=0;
        string connection = "Data Source=DESKTOP-LE3U1BT;Initial Catalog=voting_system;Integrated Security=True";
        
        public candidateadder()
        {
            InitializeComponent();
        }

        
         public string getpollingname()
        { 
            pollname = bunifuMetroTextbox7.Text+"_Audience";
            return pollname;  
        }

          public void getvoternum()
        {
            voternum = int.Parse(bunifuMetroTextbox8.Text);
            //return voternum;
        }

        

        private void label4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            login1 f2 = new login1();
            this.Visible = false;
            f2.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox7.Text == "" || bunifuMetroTextbox1.Text == "" || bunifuMetroTextbox3.Text == "" || bunifuMetroTextbox5.Text == "" || bunifuMetroTextbox2.Text == "" || bunifuMetroTextbox4.Text == "" || bunifuMetroTextbox6.Text == "" || bunifuMetroTextbox8.Text == "" || pictureBox1.Image == null || pictureBox2.Image == null || pictureBox3.Image == null)
            {
                MessageBox.Show("Please Fill all fields", "info", MessageBoxButtons.OK);
            }

            else
            {
                using (DataSet1TableAdapters.ongoing_pollsTableAdapter obj = new DataSet1TableAdapters.ongoing_pollsTableAdapter())
                {
                    obj.InsertQuery(bunifuMetroTextbox7.Text, bunifuMetroTextbox1.Text, bunifuMetroTextbox3.Text, bunifuMetroTextbox5.Text, "xxx", bunifuMetroTextbox2.Text, bunifuMetroTextbox4.Text, bunifuMetroTextbox6.Text);
                }

                MessageBox.Show("ALL CANDIDATE DETAILS ADDED", "info", MessageBoxButtons.OK);

                SqlConnection con = new SqlConnection(connection);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    using (StreamWriter sw = new StreamWriter("C:\\Users\\Hp\\Desktop\\final_project\\votings.txt", true))
                    {
                        sw.WriteLine(bunifuMetroTextbox7.Text);
                        sw.Close();
                    }
                    
                    String querycreatetable = "CREATE TABLE " + bunifuMetroTextbox7.Text + "(candidate1_name nchar(50),candidate2_name nchar(50),candidate3_name nchar(50),candidate1_regno nchar(20),candidate2_regno nchar(20),candidate3_regno nchar(20),candidate1_pic image,candidate2_pic image,candidate3_pic image,candidate1_votes bigint,candidate2_votes bigint,candidate3_votes bigint,no_of_audience bigint);";
                    SqlCommand cmd = new SqlCommand(querycreatetable, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Table Created " + bunifuMetroTextbox7.Text , "Table Creation");

                    string queryadd = "insert into " + bunifuMetroTextbox7.Text + "(candidate1_name, candidate2_name, candidate3_name, candidate1_regno, candidate2_regno, candidate3_regno, candidate1_pic, candidate2_pic, candidate3_pic, candidate1_votes, candidate2_votes, candidate3_votes, no_of_audience)values('" + bunifuMetroTextbox1.Text + "', '" + bunifuMetroTextbox3.Text + "', '" + bunifuMetroTextbox5.Text + "', '" + bunifuMetroTextbox2.Text + "', '" + bunifuMetroTextbox4.Text + "', '" + bunifuMetroTextbox6.Text + "', '" + pictureBox1.Image + "', '" + pictureBox2.Image + "', '" + pictureBox3.Image + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + bunifuMetroTextbox8.Text + "')";
                    SqlCommand cmd1 = new SqlCommand(queryadd, con);
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("All Details Added", "Info");

                    String querycreatetablepoll = "CREATE TABLE " + bunifuMetroTextbox7.Text+"_Audience" + "(Name nchar(50),reg_No nchar(50),Fingerprint nchar(50),voted_to nchar(50));";
                    SqlCommand cmd2 = new SqlCommand(querycreatetablepoll, con);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Table Created"+bunifuMetroTextbox7.Text+"_Audience", "Table Message");
                    getpollingname();
                    getvoternum();
                }

                else
                {
                    MessageBox.Show("error connection state", "Connection Error");
                }

                votersadder f5 = new votersadder();
                this.Visible = false;
                f5.Show();
            } 
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            login1 f3 = new login1();
            this.Hide();
            f3.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.jpg;*.png,*.gif)|*.jpg;*.png,*.gif";

            if(opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.jpg;*.png,*.gif)|*.jpg;*.png,*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.jpg;*.png,*.gif)|*.jpg;*.png,*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(opf.FileName);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

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

        //private void candidatesadder_Load(object sender, EventArgs e)
        //{
            
        //}

        private void candidateadder_Load(object sender, EventArgs e)
        {
            starttimer();
            label17.Text = DateTime.Now.ToShortDateString();
        }
    }
}
