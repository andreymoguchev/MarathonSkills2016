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

namespace WSR123
{
    public partial class Sponsor : Form
    {
        public Sponsor()
        {
            InitializeComponent();
        }
        private void check()
        {
            if (textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "" | textBox7.Text == "" | comboBox1.Text == "") button5.Enabled = false; else button5.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("30.05.2020 10:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0) textBox1.Text = "0";
            label14.Text = textBox1.Text;
            if (Convert.ToInt32(textBox1.Text) <= 0)
            {
                MessageBox.Show("Вы должны пожертвовать хотя бы 1$");
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt32(textBox1.Text) + 10).ToString();
            label14.Text = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT        [User].FirstName + ' ' + [User].LastName + ' - ' + CONVERT(varchar(20),RegistrationEvent.BibNumber) + ' (' + Runner.CountryCode +')' AS Runner FROM Runner INNER JOIN              [User] ON Runner.Email = [User].Email INNER JOIN                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId WHERE([User].RoleId = N'R')"; SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName  FROM Charity";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                }
                conn.Close();
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength != 16)
                textBox4.BackColor = Color.Red;
            else
                textBox4.BackColor = Color.White;
            textBox4.MaxLength = 16;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
       
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox5.Text) > DateTime.Today.Month)
            {
                textBox5.BackColor = Color.Red;
            }
            else
            {
                textBox5.BackColor = Color.White;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox6.Text) < DateTime.Today.Year)
            {
                textBox6.BackColor = Color.Red;
            }
            else
            {
                textBox6.BackColor = Color.White;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.TextLength != 3)
                textBox7.BackColor = Color.Red;
            else
                textBox7.BackColor = Color.White;
            textBox7.MaxLength = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void Sponsor_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT        [User].FirstName + ' ' + [User].LastName + ' - ' + CONVERT(varchar(20),RegistrationEvent.BibNumber) + ' (' + Runner.CountryCode +')' AS Runner FROM Runner INNER JOIN              [User] ON Runner.Email = [User].Email INNER JOIN                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId WHERE([User].RoleId = N'R')"; SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName  FROM Charity";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) >= 10)
            {
                textBox1.Text = (Convert.ToInt32(textBox1.Text) - 10).ToString();
                label14.Text = textBox1.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("30.05.2020 10:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Fond Fond = new Fond();
            using (SqlConnection conn = new
            SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName,CharityDescription,CharityLogo FROM Charity WHERE CharityName = '" + comboBox1.Text + "'";
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

    }

}
