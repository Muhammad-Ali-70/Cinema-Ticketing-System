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

namespace Movie_Ticketing_System
{
    public partial class Edit_MovieDetails_Admin : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";
        int movieid_updation;
        public Image Recent_Upload_Pic = null;


       

        public Edit_MovieDetails_Admin(int Movie_ID)
        {
            movieid_updation = Movie_ID;

            InitializeComponent();

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT Name,Genre,Category,ReleaseDate,Year,Director,Cast,IMDBRating,RottenTomatos,Description,Timing,Seats,MovieImage FROM Movies WHERE MID=@MovieID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MovieID", Movie_ID);

            SqlDataReader reader = command.ExecuteReader();

            string timming="";

            while (reader.Read())
            {
                Movie_Name_textbox.Text = reader[0].ToString();
                genre_comboBox.Text = reader[1].ToString();
                Category_comboBox.Text = reader[2].ToString();
                dateTimePicker1.Text = reader[3].ToString();
                year_textbox.Text = reader[4].ToString();
                textBox2.Text = reader[5].ToString();
                richTextBox2.Text = reader[6].ToString();
                textBox1.Text = reader[7].ToString();
                textBox3.Text = reader[8].ToString();
                
                richTextBox1.Text = reader[9].ToString();
                timming = (reader[10].ToString()).Trim();               
                seat_comobox.Text = reader[11].ToString();
                add_movie_picturebox.Image = byteArrayToImage((byte[])reader[12]);
            }

            if (timming.Equals(radioButton1.Text))
            {
                radioButton1.Checked = true;
            }
            else if (timming.Equals(radioButton2.Text))
            {
                radioButton2.Checked = true;
            }
            else if (timming.Equals(radioButton3.Text))
            {
                radioButton3.Checked = true;
            }
            else
            {

            }

            connection.Close();

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        private void Upload_btn_AM_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                add_movie_picturebox.Image = new Bitmap(opnfd.FileName);
            }

            Recent_Upload_Pic = add_movie_picturebox.Image;
        }

        private void confirm_edit_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                String Movie_Name = Movie_Name_textbox.Text;
                String Movie_Genre = genre_comboBox.Text;
                String Movie_Category = Category_comboBox.Text;
                String RealeaseDate = dateTimePicker1.Text;
                int Year = int.Parse(year_textbox.Text);
                String MovieDirector = textBox2.Text;
                String MovieCast = richTextBox2.Text;
                String MovieIMDB = textBox1.Text;
                String Movie_Rotten = textBox3.Text;
                String Description = richTextBox1.Text;
                String Show_Timing = "";

                if (radioButton1.Checked)
                {
                    Show_Timing = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    Show_Timing = radioButton2.Text;
                }
                else if (radioButton3.Checked)
                {
                    Show_Timing = radioButton3.Text;
                }
                else
                {
                    Show_Timing = "In Queue";
                }

                int seats = int.Parse(seat_comobox.Text);



                

                String Query = "UPDATE Movies SET Name=@Name,Genre=@Genre,Category=@Category,ReleaseDate=@ReleaseDate,Year=@Year,Director=@Director,Cast=@Cast,IMDBRating=@IMDBRating,RottenTomatos=@RottenTomatos,Description=@Description,Timing=@Timing,Seats=@Seats,MovieImage=@Movie_Image WHERE MID=@MovieID";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@MovieID", movieid_updation);
                command.Parameters.AddWithValue("@Name", Movie_Name);
                command.Parameters.AddWithValue("@Genre", Movie_Genre);
                command.Parameters.AddWithValue("@Category", Movie_Category);
                command.Parameters.AddWithValue("@ReleaseDate", RealeaseDate);
                command.Parameters.AddWithValue("@Year", Year);
                command.Parameters.AddWithValue("@Director", MovieDirector);
                command.Parameters.AddWithValue("@Cast", MovieCast);
                command.Parameters.AddWithValue("@IMDBRating", MovieIMDB);
                command.Parameters.AddWithValue("@RottenTomatos", Movie_Rotten);
                command.Parameters.AddWithValue("@Description", Description);
                command.Parameters.AddWithValue("@Timing", Show_Timing);
                command.Parameters.AddWithValue("@Seats", seats);
                command.Parameters.AddWithValue("@Movie_Image", imageToByteArray(Recent_Upload_Pic));

                command.ExecuteNonQuery();

                connection.Close();

                string message = "Movie Edited Successfully !";
                string title = "Congrats !";
                MessageBox.Show(message, title);

                Movie_Name_textbox.Text= string.Empty;
                 genre_comboBox.Text  = string.Empty;
                Category_comboBox.Text= string.Empty;
                dateTimePicker1.Text= string.Empty;
                year_textbox.Text = string.Empty;
                textBox2.Text = string.Empty;
                richTextBox2.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox3.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                add_movie_picturebox.Image = null;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Values Cannot Be Null\nEnter Valid Values", "Error");
            }
            
            


        }


        public byte[] imageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EditDetails_ID edit = new EditDetails_ID();
            edit.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string message = "Are You Sure You Want to Logout?";
            string title = "Log Out";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Admin_Login login = new Admin_Login();
                login.Show();
                this.Hide();
            }
            else
            {

            }  
        }




    }
}
