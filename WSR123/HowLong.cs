using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSR123
{
    public partial class HowLong : Form
    {
        public HowLong()
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

        private void button1_Click(object sender, EventArgs e)
        {
            More More = new More();
            More.Show();
            this.Hide();
        }

        private void HowLong_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label3.Text = label5.Text;
            pictureBox1.Image = pictureBox2.Image;
            label2.Text = "Максимальная скорость F1 Car 345km/h. Это займет 12 минут, чтобы завершить 42km марафон.";

        }

        private void label5_Click(object sender, EventArgs e)
        {
            label3.Text = label5.Text;
            pictureBox1.Image = pictureBox2.Image;
            label2.Text = "Максимальная скорость F1 Car 345km/h. Это займет 12 минут, чтобы завершить 42km марафон.";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label3.Text = label6.Text;
            pictureBox1.Image = pictureBox3.Image;
            label2.Text = "Максимальная скорость Slug 0.01km/h. Это займет 4200 часов, чтобы завершить 42km марафон.";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label3.Text = label6.Text;
            pictureBox1.Image = pictureBox3.Image;
            label2.Text = "Максимальная скорость Slug 0.01km/h. Это займет 4200 часов, чтобы завершить 42km марафон.";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label3.Text = label7.Text;
            pictureBox1.Image = pictureBox5.Image;
            label2.Text = "Максимальная скорость Horse 15km/h. Это займет 2,8 часа, чтобы завершить 42km марафон.";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label3.Text = label7.Text;
            pictureBox1.Image = pictureBox5.Image;
            label2.Text = "Максимальная скорость Horse 15km/h. Это займет 2,8 часа, чтобы завершить 42km марафон.";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            label3.Text = label8.Text;
            pictureBox1.Image = pictureBox7.Image;
            label2.Text = "Максимальная скорость Sloth 0.12km/h. Это займет 350 часов, чтобы завершить 42km марафон.";
        }

        private void label8_Click(object sender, EventArgs e)
        {
            label3.Text = label8.Text;
            pictureBox1.Image = pictureBox7.Image;
            label2.Text = "Максимальная скорость Sloth 0.12km/h. Это займет 350 часов, чтобы завершить 42km марафон.";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            label3.Text = label9.Text;
            pictureBox1.Image = pictureBox8.Image;
            label2.Text = "Максимальная скорость Capybara 35km/h. Это займет 1,2 часа, чтобы завершить 42km марафон.";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            label3.Text = label9.Text;
            pictureBox1.Image = pictureBox8.Image;
            label2.Text = "Максимальная скорость Capybara 35km/h. Это займет 1,2 часа, чтобы завершить 42km марафон.";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            label3.Text = label10.Text;
            pictureBox1.Image = pictureBox6.Image;
            label2.Text = "Максимальная скорость Jaguar 80km/h. Это займет 31,5 минут, чтобы завершить 42km марафон.";
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label3.Text = label10.Text;
            pictureBox1.Image = pictureBox6.Image;
            label2.Text = "Максимальная скорость Jaguar 80km/h. Это займет 31,5 минут, чтобы завершить 42km марафон.";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            label3.Text = label11.Text;
            pictureBox1.Image = pictureBox9.Image;
            label2.Text = "Максимальная скорость Worm 0.03km/h. Это займет 1400 часов, чтобы завершить 42km марафон.";
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label3.Text = label11.Text;
            pictureBox1.Image = pictureBox9.Image;
            label2.Text = "Максимальная скорость Worm 0.03km/h. Это займет 1400 часов, чтобы завершить 42km марафон.";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            label3.Text = label12.Text;
            pictureBox1.Image = pictureBox10.Image;
            label2.Text = "Длина Bus 10m. Это займет 4200 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void label12_Click(object sender, EventArgs e)
        {
            label3.Text = label12.Text;
            pictureBox1.Image = pictureBox12.Image;
            label2.Text = "Длина Bus 10m. Это займет 4200 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            label3.Text = label13.Text;
            pictureBox1.Image = pictureBox14.Image;
            label2.Text = "Длина Pair of Havaianas 0.245m. Это займет 171429 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label3.Text = label13.Text;
            pictureBox1.Image = pictureBox14.Image;
            label2.Text = "Длина Pair of Havaianas 0.245m. Это займет 171429 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            label3.Text = label14.Text;
            pictureBox1.Image = pictureBox12.Image;
            label2.Text = "Длина AirBus A380 73m. Это займет 576 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void label14_Click(object sender, EventArgs e)
        {
            label3.Text = label14.Text;
            pictureBox1.Image = pictureBox12.Image;
            label2.Text = "Длина AirBus A380 73m. Это займет 576 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            label3.Text = label15.Text;
            pictureBox1.Image = pictureBox11.Image;
            label2.Text = "Длина Football Field 105m. Это займет 400 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void label15_Click(object sender, EventArgs e)
        {
            label3.Text = label15.Text;
            pictureBox1.Image = pictureBox11.Image;
            label2.Text = "Длина Football Field 105m. Это займет 400 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            label3.Text = label16.Text;
            pictureBox1.Image = pictureBox13.Image;
            label2.Text = "Длина Ronaldinho 1.81m. Это займет 23205 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void label16_Click(object sender, EventArgs e)
        {
            label3.Text = label16.Text;
            pictureBox2.Image = pictureBox13.Image;
            label2.Text = "Длина Ronaldinho 1.81m. Это займет 23205 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
