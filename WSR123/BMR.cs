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
    public partial class BMR : Form
    {
        public BMR()
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

        private void button3_Click(object sender, EventArgs e)
        {
            More More = new More();
            More.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
            pictureBox3.BackColor = Color.White;
            button7.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Red;
            pictureBox2.BackColor = Color.White;
            button7.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = 0;
            int w = 0;
            int o = 0;
            if (pictureBox2.BackColor == Color.Red)
            {
                r = Convert.ToInt32(textBox1.Text);
                w = Convert.ToInt32(textBox2.Text);
                o = Convert.ToInt32(textBox3.Text);
                ybmr.Text = Convert.ToInt32(66 + (13.7 * w) + (5 * r) - (6.8 * o)).ToString();
                sid.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.2).ToString();
                mal.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.375).ToString();
                sred.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.55).ToString();
                sil.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.725).ToString();
                maxi.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.9).ToString();
            }
            else
            if (pictureBox3.BackColor == Color.Red)
            {
                r = Convert.ToInt32(textBox1.Text);
                w = Convert.ToInt32(textBox2.Text); o = Convert.ToInt32(textBox3.Text);
                ybmr.Text = Convert.ToInt32(655 + (9.6 * w) + (1.8 * r) - (4.7 * o)).ToString();
                sid.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.2).ToString();
                mal.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.375).ToString();
                sred.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.55).ToString();
                sil.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.725).ToString();
                maxi.Text = Convert.ToInt32(Convert.ToInt32(ybmr.Text) * 1.9).ToString();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BMI BMI = new BMI();
            BMI.ShowDialog();
        }

        private void BMR_Load(object sender, EventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {

        }
    }
}