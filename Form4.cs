using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do Really want to Quit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "")
            {
                textBox1.Cut();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.CanUndo == true /*|| textBox2.CanUndo == true*/)
            {
                textBox1.Undo();
                redoToolStripMenuItem.Enabled = true;
                //textBox1.ClearUndo();
                //textBox2.Undo();
                //textBox2.ClearUndo();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                textBox2.Paste();
                Clipboard.Clear();
            }
        }

        private void viewTextboxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewTextboxesToolStripMenuItem.Checked = !viewTextboxesToolStripMenuItem.Checked;
            if (viewTextboxesToolStripMenuItem.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void viewImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pickedImage = "";
            openFileDialog1.Title = "Insert an Image";
            openFileDialog1.InitialDirectory = @"D:\Images\Test Image";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp|TIFF Images|*.tif|PNG Images|*.png|All Files|*.*";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pickedImage = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(pickedImage);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string myFile = "";

            openFileDialog1.InitialDirectory = @"D:\";
            openFileDialog1.Title = "Open a Text File";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                myFile = openFileDialog1.FileName;
                richTextBox1.LoadFile(myFile, RichTextBoxStreamType.PlainText);                
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string saveFile = "";
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Title = "Save a Text file";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                saveFile = saveFileDialog1.FileName;
                richTextBox1.SaveFile(saveFile, RichTextBoxStreamType.PlainText);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
            //label1.Text = DateTime.Now.ToShortTimeString();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
            redoToolStripMenuItem.Enabled = false;
        }
    }
}
