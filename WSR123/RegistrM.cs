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

namespace WSR123
{
    public partial class RegistrM : Form
    {
        public RegistrM()
        {
            InitializeComponent();
        }
        string kit = "";
        int cost = 0;
        int b = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Runner Runner = new Runner();
            Runner.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("30.05.2020 10:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void RegistrM_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName  FROM Charity";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                label17.Text = (Convert.ToInt32(label17.Text) + 145).ToString();
            else
                label17.Text = (Convert.ToInt32(label17.Text) - 145).ToString();
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                label17.Text = (Convert.ToInt32(label17.Text) + 75).ToString();
            else
                label17.Text = (Convert.ToInt32(label17.Text) - 75).ToString();
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                label17.Text = (Convert.ToInt32(label17.Text) + 20).ToString();
            else
                label17.Text = (Convert.ToInt32(label17.Text) - 20).ToString();
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                kit = "A";
                cost = 0;
                label17.Text = (Convert.ToInt32(label17.Text) + 0).ToString();
            }
            else
                label17.Text = (Convert.ToInt32(label17.Text) - 0).ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                kit = "B";
                cost = 20;
                label17.Text = (Convert.ToInt32(label17.Text) + 20).ToString();
            }
            else
                label17.Text = (Convert.ToInt32(label17.Text) - 20).ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                kit = "C";
                cost = 45;
                label17.Text = (Convert.ToInt32(label17.Text) + 45).ToString();
            }
            else
                label17.Text = (Convert.ToInt32(label17.Text) - 45).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                textBox1.Text = "0";
                label17.Text = (Convert.ToInt32(label17.Text) - b).ToString();
            }
            label17.Text = (b + Convert.ToInt32(textBox1.Text)).ToString();
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            b = Convert.ToInt32(label17.Text);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Fond Fond = new Fond();
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName,CharityDescription,CharityLogo  FROM Charity WHERE CharityName='" + comboBox1.Text + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Fond.label1.Text = reader["CharityName"].ToString();
                    Fond.textBox1.Text = reader["CharityDescription"].ToString();
                    Fond.pictureBox1.Image = Image.FromFile("Resources/" + reader["CharityLogo"].ToString());
                }
                conn.Close();
            }
            Fond.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string charity = "";
            string rid = "";
            string email = File.ReadAllText("Resources/run.txt");
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT RunnerID  FROM Runner where Email='" + email + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rid = reader[0].ToString();
                }
                conn.Close();
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "SELECT CharityId  FROM Charity where CharityName='" + comboBox1.Text + "'";
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    charity = reader1[0].ToString();
                }
                conn.Close();
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into Registration Values ('" + rid + "','" + DateTime.Today + "','" + kit + "','4','" + cost + "','" + charity + "','" + textBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                CompleteRunner CompleteRunner = new CompleteRunner();
                CompleteRunner.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы не выбрали марафон.");
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
