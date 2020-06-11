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
    public partial class CtrlR : Form
    {
        public CtrlR()
        {
            InitializeComponent();
        }
        
        int b = 0;
       
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
            Coordinator Coordinator = new Coordinator();
            Coordinator.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void CtrlR_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT RegistrationStatus FROM RegistrationStatus";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["RegistrationStatus"]);
                }
                conn.Close();
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "SELECT EventTypeName FROM EventType";
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox2.Items.Add(reader1["EventTypeName"]);
                }
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.Clear();
            string con = WSR123.Properties.Settings.Default.WSR123ConnectionString;
            using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT[User].FirstName AS Имя, [User].LastName AS Фамилия, [User].Email,[RegistrationStatus].RegistrationStatus AS Статус FROM Event INNER JOIN EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN RegistrationEvent ON Event.EventId = RegistrationEvent.EventId INNER JOIN Runner INNER JOIN[User] ON Runner.Email = [User].Email INNER JOIN Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN RegistrationStatus ON Registration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId ON RegistrationEvent.RegistrationId = Registration.RegistrationId WHERE([User].RoleId = N'R') AND(RegistrationStatus.RegistrationStatus = N'" + comboBox1.Text + "') AND(EventType.EventTypeName = N'" + comboBox2.Text + "')", con))//используя SqlDataAdapter с командой query и строкой соединения con
            {
                da.Fill(ds, "table");
                dataGridView1.DataSource = ds.Tables["table"];
                if (b == 0)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Add(btn);
                    btn.Text = "Редактировать";
                    btn.UseColumnTextForButtonValue = true;
                }
            }
            label8.Text = dataGridView1.RowCount.ToString();
            b++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                var csv = new StringBuilder();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [User].FirstName, [User].LastName, [User].Email, Gender.Gender, Country.CountryName, Runner.DateOfBirth, year(getdate())-year(Runner.DateOfBirth) AS Возраст, RegistrationStatus.RegistrationStatus, RaceKitOption.RaceKitOption, EventType.EventTypeName FROM RegistrationStatus INNER JOIN EventType INNER JOIN Event ON EventType.EventTypeId = Event.EventTypeId INNER JOIN Marathon ON Event.MarathonId = Marathon.MarathonId INNER JOIN Country ON Marathon.CountryCode = Country.CountryCode INNER JOIN Registration INNER JOIN RaceKitOption ON Registration.RaceKitOptionId = RaceKitOption.RaceKitOptionId INNER JOIN RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId ON Event.EventId = RegistrationEvent.EventId ON RegistrationStatus.RegistrationStatusId = Registration.RegistrationStatusId INNER JOIN Runner ON Country.CountryCode = Runner.CountryCode AND Registration.RunnerId = Runner.RunnerId INNER JOIN Gender ON Runner.Gender = Gender.Gender INNER JOIN [User] ON Runner.Email = [User].Email  WHERE([User].RoleId = N'R') AND(RegistrationStatus.RegistrationStatus = N'" + comboBox1.Text + "') AND(EventType.EventTypeName = N'" + comboBox2.Text + "')";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    var one = reader["FirstName"].ToString();
                    var two = reader["LastName"].ToString();
                    var three = reader["Email"].ToString();
                    var four = reader["Gender"].ToString();
                    var five = reader["CountryName"].ToString();
                    var six = reader["DateOfBirth"].ToString();
                    var seven = reader["Возраст"].ToString();
                    var eight = reader["RegistrationStatus"].ToString();
                    var nine = reader["RaceKitOption"].ToString();
                    var ten = reader["EventTypeName"].ToString();
                    var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", one, two, three, four, five, six, seven, eight, nine, ten);
                    csv.AppendLine(newLine);
                }
                conn.Close();
                string tempPath = "";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    tempPath = folderBrowserDialog1.SelectedPath; // prints path
                }
                File.WriteAllText(tempPath + "\\runner.csv", csv.ToString());
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Email Email = new Email();
            using (SqlConnection conn = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [User].FirstName, [User].LastName, [User].Email FROM Event INNER JOIN EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN Marathon ON Event.MarathonId = Marathon.MarathonId INNER JOIN RegistrationEvent ON Event.EventId = RegistrationEvent.EventId INNER JOIN Registration ON RegistrationEvent.RegistrationId = Registration.RegistrationId INNER JOIN RegistrationStatus ON Registration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId INNER JOIN Runner ON Registration.RunnerId = Runner.RunnerId INNER JOIN [User] ON Runner.Email = [User].Email WHERE([User].RoleId = N'R') AND(RegistrationStatus.RegistrationStatus = N'" + comboBox1.Text + "') AND(EventType.EventTypeName = N'" + comboBox2.Text + "')";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    var one = reader["FirstName"].ToString();
                    var two = reader["LastName"].ToString();
                    var three = reader["Email"].ToString();
                    var newLine = string.Format("'{0} {1}' <{2}>; ", one, two, three);
                    Email.textBox1.Text += newLine;
                }
                conn.Close();
                Email.ShowDialog();
            }

        }
    }
}
