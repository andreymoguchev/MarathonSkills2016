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
using System.Text.RegularExpressions;

namespace WSR123
{
    public partial class RegistrR : Form
    {
        public RegistrR()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("30.06.2020 10:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }
        private void check()
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "" | comboBox2.Text == "" | comboBox1.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void RegistrR_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT Gender  FROM Gender";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = " SELECT CountryName  FROM Country";
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox2.Items.Add(reader1[0]);
                }
                conn.Close();
            }
            var y = DateTime.Today;
            y = y.AddYears(-10);
            dateTimePicker1.MaxDate = y;
            dateTimePicker1.Value = y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox6.Text = openFileDialog1.SafeFileName;
            pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string expresion = @".+@.+\..+";
            if (Regex.IsMatch(textBox1.Text, expresion))
                textBox1.BackColor = Color.White;
            else
                textBox1.BackColor = Color.Red;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string expresion = @"(?=.*[\d])(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*[!@#$%^]).{6,}";
            if (Regex.IsMatch(textBox2.Text, expresion))
                textBox2.BackColor = Color.White;
            else
                textBox2.BackColor = Color.Red;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox2.Text)
            {
                textBox3.BackColor = Color.Red;
                button1.Enabled = false;
            }
            else
            {
                textBox3.BackColor = Color.White;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = "";
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT CountryCode  FROM Country where CountryName='" + comboBox2.Text + "' OR CountryCode='" + comboBox2.Text + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    code = reader[0].ToString();
                }
                conn.Close();
            }
            if (textBox2.Text == textBox3.Text)
            {
                using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into [User] Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','R')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Open();
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "Insert into Runner Values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value + "','" + code + "','" + textBox6.Text + "')";
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                File.WriteAllText("Resources/run.txt", textBox1.Text);
                RegistrM RegistrM = new RegistrM();
                RegistrM.Show();
                this.Hide();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
