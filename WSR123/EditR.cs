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
    public partial class EditR : Form
    {
        public BindingSource BindingSource { get; private set; }

        public EditR()
        {
            InitializeComponent();
            SqlDataAdapter adapter;
            DataSet dataSet = new DataSet();
            string strings = "Фонд";
            BindingSource BindingSource = new BindingSource();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("30.05.2020 10:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
            check();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Runner Runner = new Runner();
            Runner.Show();
            this.Hide();
        }
        private void check()
        {
            if (textBox4.Text == "" | textBox2.Text == "" | textBox3.Text == "" | comboBox2.Text == "" | comboBox1.Text == "")
                button3.Enabled = false;
            else
                button3.Enabled = true;
        }
        private void EditR_Load(object sender, EventArgs e)
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox4.Text = openFileDialog1.SafeFileName;
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string expresion = @"(?=.*[\d])(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*[!@#$%^]).{6,}";
            if (Regex.IsMatch(textBox2.Text, expresion))
                textBox5.BackColor = Color.White;
            else
                textBox5.BackColor = Color.Red;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != textBox5.Text)
            {
                textBox6.BackColor = Color.Red;
                button3.Enabled = false;
            }
            else
            {
                textBox6.BackColor = Color.White;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
            if (textBox5.Text == "" && textBox6.Text == "")
            {
                SqlConnection con = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString);
                SqlDataAdapter
                                // Выборка
                adapter = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Runner ON [User].Email = Runner.Email", con);
                // Запрос на вставку
                adapter.InsertCommand = new SqlCommand("Update [User] set FirstName='" + textBox4.Text + "',LastName='" + textBox5.Text + "' where Email='" + label16.Text + "'" + "Update Runner set Gender = '" + comboBox1.Text + "', DateOfBirth = '" + dateTimePicker1.Value + "', CountryCode = '" + code + "', Image='" + textBox6.Text + "' where Email = '" + label16.Text + "'", con);
                DataSet
                                // Создание набора таблиц
                                dataSet = new DataSet();
                string strings = null;
                // Заполнение таблицы
                adapter.Fill(dataSet, strings);
                // Привязка к таблице
                BindingSource = new BindingSource(dataSet, strings);
                con.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
                Runner Runner = new Runner();
                Runner.Show();
                this.Hide();
            }
            else if (textBox5.Text == textBox6.Text && textBox5.Text != "" && textBox6.Text != "")
            {
                SqlConnection con = new SqlConnection(WSR123.Properties.Settings.Default.WSR123ConnectionString);
                SqlDataAdapter
                                // Выборка
                                adapter = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Runner ON [User].Email = Runner.Email", con);
                // Запрос на вставку
                adapter.InsertCommand = new SqlCommand("Update [User] set [Password]='" + textBox2.Text + "',FirstName='" + textBox4.Text + "',LastName='" + textBox5.Text + "' where Email='" + label16.Text + "'" + "Update Runner set Gender = '" + comboBox1.Text + "', DateOfBirth = '" + dateTimePicker1.Value + "', CountryCode = '" + code + "', Image='" + textBox6.Text + "' where Email = '" + label16.Text + "'", con);
                DataSet
                                // Создание набора таблиц
                                dataSet = new DataSet();
                string strings = null;
                // Заполнение таблицы
                adapter.Fill(dataSet, strings);
                // Привязка к таблице
                BindingSource = new BindingSource(dataSet, strings);
                con.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
                Runner Runner = new Runner();
                Runner.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пароли не совпадают.");

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {

        }
    }
}
