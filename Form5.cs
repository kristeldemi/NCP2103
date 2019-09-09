using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using LiveCharts;
using LiveCharts.Wpf;

namespace WindowsFormsApplication3 {
    public partial class Form5 : Form {
        public Form5() {
            InitializeComponent();
            Initialize();
        }

        //Database connection variables
        MySqlConnection conn;
        string myConnectionString;

        //Image variables
        string pickedImage = "";
        string location = @"C:\\Users\\MERCURIO\\Documents\\images\\";
        string fileName = "";

        public string id, Sname, Sage, Scourse;
        double value, count1, count2, count3, count4, count5;

        //Database connection initialization
        private void Initialize() {
            //myConnectionString = "server=localhost;user id=adminAlex;password=12345678;persistsecurityinfo=True;" +
            //    "port=3306;database=test;SslMode=none;";
            myConnectionString = "server=localhost;user id=root;password=;database=testss";
            conn = new MySqlConnection(myConnectionString);
        }

        //Opening connection to database
        private bool OpenConnection() {
            try {
                conn.Open();
                return true;
            } catch (MySqlException ex) {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //closing connection to database
        private bool CloseConnection() {
            try {
                conn.Close();
                return true;
            } catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Clearing system contents
        private void Clear() {
            nameTxtBox.Text = "";
            idCmbBox.SelectedIndex = -1;
            ageCmbBox.SelectedIndex = -1;
            courseCmbBox.SelectedIndex = -1;
            yearCmbBox.SelectedIndex = -1;
            pictureBox1.Image = null;
            Pie_Chart();
        }

        //loading ID's into combobox
        public void Load_Data() {
            idCmbBox.Items.Clear();
            string query = "SELECT * from myTable";
            if (OpenConnection()) {
                try {
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        idCmbBox.Items.Add(reader.GetString("ID"));
                    }
                } catch (MySqlException ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    CloseConnection();
                }
            }
        }

        //Insert into database
        public void Insert() {
            string query = "INSERT INTO mytable (S_Name, Age, Course, YearLevel, UserImage) VALUES ('" + nameTxtBox.Text +
                "'," + ageCmbBox.SelectedItem + ",'" + courseCmbBox.SelectedItem + "', + '" + yearCmbBox.SelectedItem + "','" + location + fileName + "')";
            if (OpenConnection()) {
                try {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted!", "Insert Successful!");
                    idCmbBox.Items.Clear();
                } catch (MySqlException ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    CloseConnection();
                    Clear();
                }
            }
        }

        //Update database 
        public void Updated() {
            string query = "UPDATE myTable SET S_Name = '" + nameTxtBox.Text + "', Age = "
                + ageCmbBox.SelectedItem + ", Course = '" + courseCmbBox.SelectedItem + "', YearLevel = '" + yearCmbBox.SelectedItem
                + "', UserImage = '" + location + fileName + "' WHERE ID = " + idCmbBox.SelectedItem + ";";
            if (this.OpenConnection()) {
                try {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated!", "Update Successful!");
                    idCmbBox.Items.Clear();
                } catch (MySqlException ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    this.CloseConnection();
                    Clear();
                }
            }
        }

        //delete from database
        public void Deleted() {
            string query = "DELETE from myTable WHERE ID = " + idCmbBox.SelectedItem + ";";
            if (this.OpenConnection()) {
                try {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted!", "Delete Successful!");
                    idCmbBox.Items.Clear();
                } catch (MySqlException ex) {
                    MessageBox.Show("Select an ID to Delete", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } finally {
                    this.CloseConnection();
                    Clear();
                }
            }
        }

        //populate listview with database contents
        public void Populate_ListView(string myquery) {
            listView1.Items.Clear();
            ListViewItem iItem;
            string query = myquery;
            if (OpenConnection()) {
                try {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read()) {
                        iItem = new ListViewItem(dataReader.GetString("ID"));
                        iItem.SubItems.Add(dataReader[1].ToString());
                        iItem.SubItems.Add(dataReader[2].ToString());
                        iItem.SubItems.Add(dataReader[3].ToString());
                        iItem.SubItems.Add(dataReader[4].ToString());
                        listView1.Items.Add(iItem);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    CloseConnection();
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        //Insert button code
        private void button1_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Do you really want to Insert Data?", "Data Insert", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Insert();
                Load_Data();
                Populate_ListView("SELECT * FROM myTable");
            }

        }

        //Load event for populating listview and ID combobox
        private void Form5_Load(object sender, EventArgs e) {
            Populate_ListView("SELECT * FROM myTable");
            Load_Data();
            Clear();
        }

        //close event to end program
        private void Form5_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        //combobox manipulation for database access
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string query = "SELECT * from myTable where ID = " + idCmbBox.SelectedItem + ";";
            if (this.OpenConnection() && idCmbBox.SelectedIndex != -1) {
                try {
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        nameTxtBox.Text = reader.GetString("S_Name");
                        ageCmbBox.Text = reader.GetString("Age");
                        courseCmbBox.Text = reader.GetString("Course");
                        yearCmbBox.Text = reader.GetString("YearLevel");
                        if (reader.GetString("UserImage") == @"C:\Users\MERCURIO\Documents\images\") {
                            pictureBox1.Image = Image.FromFile(@"C:\Users\MERCURIO\Documents\images\no image.jpg");
                        } else {
                            try {
                                pictureBox1.Image = Image.FromFile(reader.GetString("UserImage"));
                            } catch (Exception ex) {
                                MessageBox.Show(ex.Message);
                            }

                        }

                    }
                } catch (MySqlException ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    this.CloseConnection();
                }
            }
            this.CloseConnection();
        }

        //Update button
        private void button2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Do you really want to Update data?", "Data Update", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Updated();
                Load_Data();
                Populate_ListView("SELECT * FROM myTable");
            }

        }

        //delete button
        private void button3_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Do you really want to Delete data?", "Data Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Deleted();
                Load_Data();
                Populate_ListView("SELECT * FROM myTable");
            }
        }

        private void nameTxtBox_TextChanged(object sender, EventArgs e) {

        }

        //search button
        private void button4_Click(object sender, EventArgs e) {
            string query;
            query = "SELECT * FROM myTable WHERE ID = '" + searchTxtBox.Text + "' OR S_Name LIKE '%"
                + searchTxtBox.Text + "%' OR Age = '" + searchTxtBox.Text + "' OR course LIKE '%"
                + searchTxtBox.Text + "%';";
            Populate_ListView(query);
            searchTxtBox.Text = "";

        }

        //listview code
        private void listView1_DoubleClick(object sender, EventArgs e) {
            idCmbBox.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            Form frm = new Form9();
            frm.Show();
        }

        //clear button
        private void button6_Click(object sender, EventArgs e) {
            Clear();
        }

        //upload button
        private void button5_Click(object sender, EventArgs e) {
            openFileDialog1.Title = "Insert an Image";
            openFileDialog1.InitialDirectory = location;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp|TIFF Images|*.tif|PNG Images|*.png|All Files|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel) {
                fileName = openFileDialog1.SafeFileName;
                pickedImage = openFileDialog1.FileName;
                if (File.Exists(pickedImage))
                {
                    if(!File.Exists(location + fileName))
                    {
                        File.Copy(pickedImage, location + fileName);
                    }
                }
                pictureBox1.Image = Image.FromFile(pickedImage);
            }
        }

        //print button
        private void button7_Click(object sender, EventArgs e) {
            Form7 form = new Form7();
            form.Show();
        }

        private double myQuery(string course) {
            string query = "SELECT COUNT(*) as count from myTable where course = '" + course + "'";
            if (this.OpenConnection()) {
                try {
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        value = Convert.ToDouble(reader[0]);
                    }
                } catch (MySqlException ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    this.CloseConnection();
                }
            }
            return value;
        }

        private void Pie_Chart() {
            count1 = myQuery("BSCpE");
            count2 = myQuery("BSCE");
            count3 = myQuery("BSECE");
            count4 = myQuery("BSEE");
            count5 = myQuery("BSME");
            //Func<ChartPoint, string> labelPoint = chartPoint =>
            //string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "BSCpE",
                    Values = new ChartValues<double> {count1},
                    DataLabels = true,
                    //LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "BSCE",
                    Values = new ChartValues<double> {count2},
                    DataLabels = true,
                    //LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "BSECE",
                    Values = new ChartValues<double> {count3},
                    DataLabels = true,
                    //LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "BSEE",
                    Values = new ChartValues<double> {count4},
                    DataLabels = true,
                    //LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "BSME",
                    Values = new ChartValues<double> {count5},
                    DataLabels = true,
                    //LabelPoint = labelPoint
                }
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }
    }
}
