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

    public partial class votingmenu : Form
    {
        string connection = "Data Source=DESKTOP-LE3U1BT;Initial Catalog=voting_system;Integrated Security=True";

        string[] alreadyvoted = new String[50];
        int voted = 0;
        public votingmenu()
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            login2 l2 = new login2();
            this.Visible = true;
            l2.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            mainmenu f1 = new mainmenu();
            this.Visible = false;
            f1.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (label14.Text == "VERIFIED")
            {
                if (bunifuCheckbox1.Checked == true)
                {
                    string tablename = mainmenu.pollname + "_Audience";

                    SqlConnection con1 = new SqlConnection(connection);
                    con1.Open();
                    if (con1.State == System.Data.ConnectionState.Open)
                    {
                       
                        String queryupdate = "UPDATE " + tablename + " SET voted_to ='" + label5.Text + "' WHERE reg_No ='"+label13.Text+"';";
                        SqlCommand cmd = new SqlCommand(queryupdate, con1);                       
                        cmd.ExecuteNonQuery();


                        alreadyvoted[voted] = textBox1.Text;
                        voted++;
                        label15.Text = "VOTE CASTED";
                        MessageBox.Show("Thankyou for voting " + label12.Text, "Message");

                    }

                    else
                    {
                        MessageBox.Show("No connection found !", "Connection details");
                    }
                }

                else if (bunifuCheckbox2.Checked == true)
                {
                    string tablename = mainmenu.pollname + "_Audience";

                    SqlConnection con2 = new SqlConnection(connection);
                    con2.Open();

                    if (con2.State == System.Data.ConnectionState.Open)
                    {
                        String queryupdate = "UPDATE " + tablename + " SET voted_to ='" + label8.Text + "' WHERE reg_No ='" + label13.Text + "';";
                        SqlCommand cmd = new SqlCommand(queryupdate, con2);
                        cmd.ExecuteNonQuery();

                        alreadyvoted[voted] = textBox1.Text;
                        voted++;

                        label15.Text = "VOTE CASTED";
                        MessageBox.Show("Thankyou for voting " + label12.Text, "Message");
                    }

                    else
                    {
                        MessageBox.Show("No connection found !", "Connection details");
                    }
                }

                else if (bunifuCheckbox3.Checked == true)
                {
                    string tablename = mainmenu.pollname + "_Audience";

                    SqlConnection con3 = new SqlConnection(connection);
                    con3.Open();

                    if (con3.State == System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show(tablename);
                        String queryupdate = "UPDATE " + tablename + " SET voted_to ='" + label10.Text + "' WHERE reg_No ='" + label13.Text + "';";
                        SqlCommand cmd = new SqlCommand(queryupdate, con3);
                        cmd.ExecuteNonQuery();

                        alreadyvoted[voted] = textBox1.Text;
                        voted++;

                        label15.Text = "VOTE CASTED";
                        MessageBox.Show("Thankyou for voting " + label12.Text, "Message");
                    }

                    else
                    {
                        MessageBox.Show("No connection found !", "Connection details");
                    }
                }

            }

            else if (label14.Text == "NOT EXIST")
            {
                MessageBox.Show("VOTE IS NOT REGISTERED", "Message");
            }

            else if (label14.Text == "ALREADY VOTED")
            {
                MessageBox.Show("You have already casted your vote");
            }

        }


        private void tick(object sender, EventArgs e)
        {
            label17.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        System.Windows.Forms.Timer t = null;

        private void starttimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(tick);
            t.Enabled = true;
        }
        private void votingmenu_Load(object sender, EventArgs e)
        {
            starttimer();
            label16.Text = DateTime.Now.ToShortDateString();

            string tablename = mainmenu.pollname;

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {

                String querygetdata = "SELECT candidate1_name,candidate2_name,candidate3_name,candidate1_regno,candidate2_regno,candidate3_regno,candidate1_pic,candidate2_pic,candidate3_pic FROM " + tablename + ";";
                SqlCommand cmd = new SqlCommand(querygetdata, con);
                cmd.ExecuteNonQuery();

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                if (dr.HasRows)
                {
                    label5.Text = dr["candidate1_name"].ToString();
                    label8.Text = dr["candidate2_name"].ToString();
                    label10.Text = dr["candidate3_name"].ToString();

                    label6.Text = dr["candidate1_regno"].ToString();
                    label7.Text = dr["candidate2_regno"].ToString();
                    label9.Text = dr["candidate3_regno"].ToString();

                    /*   byte[] img = (byte[])dr[6];
                       if(img==null)
                       {
                           pictureBox1.Image = null;
                       }

                       else
                       {

                           MemoryStream ms = new MemoryStream(img);
                           pictureBox1.Image = Image.FromStream(ms);

                       }

                       byte[] img2 = (byte[])dr[7];
                       if (img == null)
                       {
                           pictureBox2.Image = null;
                       }

                       else
                       {
                           MemoryStream ms = new MemoryStream(img2);
                           pictureBox2.Image = Image.FromStream(ms);
                       }

                       byte[] img3 = (byte[])dr[8];
                       if (img == null)
                       {
                           pictureBox3.Image = null;
                       }

                       else
                       {
                           MemoryStream ms = new MemoryStream(img3);
                           pictureBox3.Image = Image.FromStream(ms);
                       }
                       */
                    con.Close();
                }

                else
                {
                    MessageBox.Show("No data avalibe in database", "Data info");
                }


            }

            else
            {
                MessageBox.Show("NO CONNECTION ESTABLISHED", "Connection Info", MessageBoxButtons.OK);
            }

        }




        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked == true)
            {
                bunifuCheckbox2.Checked = false;
                bunifuCheckbox3.Checked = false;
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked == true)
            {
                bunifuCheckbox1.Checked = false;
                bunifuCheckbox3.Checked = false;
            }

        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked == true)
            {
                bunifuCheckbox2.Checked = false;
                bunifuCheckbox1.Checked = false;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            label12.Text = "Name:";
            label13.Text = "Reg:";
            label14.Text = "VERIFY RESULT";
            textBox1.Text = null;

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            string tablename1 = mainmenu.pollname+"_Audience";
            SqlConnection conx = new SqlConnection(connection);
            conx.Open();

            if (conx.State == System.Data.ConnectionState.Open)
            {

                String queryverify = "SELECT Name,reg_No FROM " + tablename1 + " WHERE Fingerprint='"+textBox1.Text+"';" ;
                SqlCommand cmd4 = new SqlCommand(queryverify, conx);
                cmd4.ExecuteNonQuery();

                SqlDataReader drv = cmd4.ExecuteReader();

                drv.Read();
                if (drv.HasRows)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        if (alreadyvoted[i] == textBox1.Text)
                        {
                            label14.Text = "ALREADY VOTED";
                        }

                    }


                    label12.Text = drv["Name"].ToString();
                    label13.Text = drv["reg_No"].ToString();
                    label14.Text = "VERIFIED";

                }
                else
                {
                    MessageBox.Show("NO details found related to this ID !", "Error");
                    label14.Text = "NOT EXIST";
                }
            }
        }
    }
}
