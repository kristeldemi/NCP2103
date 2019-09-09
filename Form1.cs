using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int choice = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            choice = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            choice = 3;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                toolStripProgressBar1.Value = 0;
            }
            for (int i = 0; i < 100; i++)
            {
                toolStripProgressBar1.PerformStep();
                System.Threading.Thread.Sleep(50);
                toolStripStatusLabel1.Text = toolStripProgressBar1.Value.ToString() + "%";
                statusStrip1.Refresh();         
            }
                      
            if (toolStripProgressBar1.Value == 100 && choice == 3)
            {
                timer1.Enabled = false;
                Form4 form = new Form4();
                form.Show();
                this.Hide();
            }
            if (toolStripProgressBar1.Value == 100 && choice == 1)
            {
                timer1.Enabled = false;
                Form2 form = new Form2();
                form.Show();
                this.Hide();
            }
 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            this.Hide();
        }
    }
}
