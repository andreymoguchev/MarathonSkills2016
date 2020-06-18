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
    public partial class Runner : Form
    {
        public Runner()
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

        private void button7_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void Назад_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Contacts Contacts = new Contacts();
            Contacts.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = File.ReadAllText("Resources/login.txt");
            EditR EditR = new EditR();
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [User].Email, [User].Password, [User].FirstName, [User].LastName, Runner.Gender, Runner.DateOfBirth, Runner.CountryCode, [Image] FROM [User] INNER JOIN Runner ON [User].Email = Runner.Email where [User].Email='" + email + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EditR.label13.Text = reader["Email"].ToString();
                    EditR.textBox2.Text = reader["FirstName"].ToString();
                    EditR.textBox3.Text = reader["LastName"].ToString();
                    EditR.comboBox1.Text = reader["Gender"].ToString();
                    EditR.dateTimePicker1.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                    EditR.comboBox2.Text = reader["CountryCode"].ToString();
                    if (reader["Image"].ToString() != "")
                    {
                        EditR.pictureBox1.Image = Image.FromFile("Resources/" + reader["Image"]);
                    }
                    EditR.textBox4.Text = reader["Image"].ToString();
                }
                conn.Close();
            }
            EditR.Show();
            this.Hide();
        }

        private void Runner_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySponsor MySponsor = new MySponsor();
            MySponsor.Show();
            this.Hide();
        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
