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
    public partial class BMI : Form
    {
        public BMI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            More More = new More();
            More.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("30.05.2020 10:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            time.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            More More = new More();
            More.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
            pictureBox3.BackColor = Color.White;
            button1.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Red;
            pictureBox2.BackColor = Color.White;
            button1.Enabled = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value < 19)
            {
                pictureBox4.Image = WSR123.Properties.Resources.bmi_underweight_icon;
                label7.Text = trackBar1.Value.ToString();
            }
            else if (trackBar1.Value >= 19 && trackBar1.Value < 25)
            {
                pictureBox4.Image = WSR123.Properties.Resources.bmi_healthy_icon;
                label7.Text = trackBar1.Value.ToString();
            }
            else if (trackBar1.Value >= 25 && trackBar1.Value < 30)
            {
                pictureBox4.Image = WSR123.Properties.Resources.bmi_overweight_icon;
                label7.Text = trackBar1.Value.ToString();
            }
            else if (trackBar1.Value >= 30)
            {
                pictureBox4.Image = WSR123.Properties.Resources.bmi_obese_icon;
                label7.Text = trackBar1.Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double r = Convert.ToDouble(textBox1.Text) / 100;
            int w = Convert.ToInt32(textBox2.Text);
            double val = (w / (r * r));
            if (Convert.ToInt32(val) > 36)
                trackBar1.Value = 35;
            else if (Convert.ToInt32(val) < 36 && Convert.ToInt32(val) > 13)
                trackBar1.Value = Convert.ToInt32(val);
            else if (Convert.ToInt32(val) < 13)
                trackBar1.Value = 13;
        }

        private void time_Click(object sender, EventArgs e)
        {

        }
    }
}
