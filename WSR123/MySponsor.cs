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
    public partial class MySponsor : Form
    {
        public MySponsor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Runner Runner = new Runner();
            Runner.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void MySposor_Load(object sender, EventArgs e)
        {
            string email = File.ReadAllText("Resources/login.txt");
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Charity.CharityName, Charity.CharityDescription, Charity.CharityLogo, Sponsorship.SponsorName, Replace(Sponsorship.Amount,'.00','') as Amount, Runner.Email FROM Charity INNER JOIN Registration ON Charity.CharityId = Registration.CharityId INNER JOIN Sponsorship ON Registration.RegistrationId = Sponsorship.RegistrationId INNER JOIN Runner ON Registration.RunnerId = Runner.RunnerId WHERE (Runner.Email = N'" + email + "')"; SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label4.Text = reader["CharityName"].ToString();
                    pictureBox2.Image = Image.FromFile("Resources/" + reader["CharityLogo"].ToString()); textBox1.Text = reader["CharityDescription"].ToString(); dataGridView1.Rows.Add(reader["SponsorName"].ToString(), reader["Amount"].ToString());
                }
                conn.Close();
            }
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = sum + Convert.ToInt32(dataGridView1[1, i].Value);
            }
            label7.Text = sum.ToString();
        }
    }
}
