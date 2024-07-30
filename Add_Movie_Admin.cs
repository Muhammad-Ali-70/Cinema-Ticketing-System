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
    public partial class Add_Movie_Admin : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";


        public Add_Movie_Admin()
        {
            InitializeComponent();
        }

        public Image Recent_Upload_Pic = null;
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
       
        private void Add_Movie_btn_AM_Click(object sender, EventArgs e)
        {

            try
            {
                String Movie_Name = Movie_Name_textbox.Text;
                String Movie_Genre = genre_comboBox.Text;
                String Movie_Category = Category_comboBox.Text;
                String RealeaseDate = dateTimePicker1.Text;
                int Year = int.Parse(year_textbox.Text);
                String MovieDirector = DirectorTextBox.Text;
                String MovieCast = richTextBox2.Text;
                String MovieIMDB = IMDB_ratingTextbox.Text;
                String Movie_Rotten = RottenTomatos_textbox.Text;
                String Description = Description_textbox.Text;
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



                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                String Query = "INSERT INTO Movies(Name,Genre,Category,ReleaseDate,Year,Director,Cast,IMDBRating,RottenTomatos,Description,Timing,Seats,MovieImage) VALUES (@Name,@Genre,@Category,@ReleaseDate,@Year,@Director,@Cast,@IMDBRating,@RottenTomatos,@Description,@Timing,@Seats,@Movie_Image)";

                SqlCommand command = new SqlCommand(Query, connection);

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

                string message = "Movie Added Successfully !";
                string title = "Congrats !";
                MessageBox.Show(message, title);

                Movie_Name_textbox.Text = String.Empty;
                genre_comboBox.Text = String.Empty;
                Category_comboBox.Text = String.Empty;
                dateTimePicker1.Text = String.Empty;
                year_textbox.Text = String.Empty;
                DirectorTextBox.Text = String.Empty;
                richTextBox2.Text = String.Empty;
                IMDB_ratingTextbox.Text = String.Empty;
                RottenTomatos_textbox.Text = String.Empty;
                Description_textbox.Text = String.Empty;
                Show_Timing = String.Empty;
                add_movie_picturebox.Image = null;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Values Cannot Be Null\nEnter Valid Values\nError Code"+ex.Message, "Error");
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

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Home_btn_MD_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin_Page admin = new Admin_Page();
            admin.Show();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
