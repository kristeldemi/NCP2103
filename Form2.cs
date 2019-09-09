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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(comboBox1.SelectedItem);
            label1.Font = new Font(label1.Font.FontFamily, size, label1.Font.Style);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string val = radioButton1.Text;
                label1.Font = new Font(val, label1.Font.Size);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                string val = radioButton2.Text;
                label1.Font = new Font(val, label1.Font.Size);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true)
            {
                string val = radioButton3.Text;
                label1.Font = new Font(val, label1.Font.Size);
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.ForeColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            label7.Text = Convert.ToString(hScrollBar1.Value + 8);
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label1.ForeColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            label8.Text = Convert.ToString(hScrollBar2.Value + 8);
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label1.ForeColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            label9.Text = Convert.ToString(hScrollBar3.Value + 8);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                string val = radioButton4.Text;
                label1.Font = new Font(val, label1.Font.Size);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Font thisFont = new Font(label1.Font.FontFamily, label1.Font.Size);
            if (checkBox1.Checked == true)
            {
                thisFont = new Font(label1.Font, label1.Font.Style | FontStyle.Bold);
            }
            else
            {
                thisFont = new Font(label1.Font, label1.Font.Style & ~FontStyle.Bold);
            }
            label1.Font = thisFont;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Font thisFont = new Font(label1.Font.FontFamily, label1.Font.Size);
            if (checkBox2.Checked == true)
            {
                thisFont = new Font(label1.Font, label1.Font.Style | FontStyle.Italic);
            }
            else
            {
                thisFont = new Font(label1.Font, label1.Font.Style & ~FontStyle.Italic);
            }
            label1.Font = thisFont;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Font thisFont = new Font(label1.Font.FontFamily, label1.Font.Size);
            if (checkBox3.Checked == true)
            {
                thisFont = new Font(label1.Font, label1.Font.Style | FontStyle.Underline);
            }
            else
            {
                thisFont = new Font(label1.Font, label1.Font.Style & ~FontStyle.Underline);
            }
            label1.Font = thisFont;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                string val = radioButton5.Text;
                label1.Font = new Font(val, label1.Font.Size);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                string val = radioButton6.Text;
                label1.Font = new Font(val, label1.Font.Size);
            }
        }
    }
}
