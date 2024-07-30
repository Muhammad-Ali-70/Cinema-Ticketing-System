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
    public partial class Movie_Details : Form
    {

        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        int M_UserID;
        int MovieID;
        string moviename;
        
        public Movie_Details(String MovieName,int userID)
        {
            InitializeComponent();

            M_UserID = userID;
            moviename = MovieName;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT MID,LTRIM(RTRIM(Name)),LTRIM(RTRIM(Genre)),LTRIM(RTRIM(Category)),LTRIM(RTRIM(ReleaseDate)),Year,LTRIM(RTRIM(Director)),LTRIM(RTRIM(Cast)),IMDBRating,RottenTomatos,LTRIM(RTRIM(Description)),Seats,MovieImage FROM Movies WHERE Name=@MName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MName", MovieName);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MovieID = int.Parse(reader[0].ToString());
                Name_Label.Text = reader[1].ToString();
                Genre_Label.Text = reader[2].ToString();
                Category_Label.Text = reader[3].ToString();
                RealeaseDate_Label.Text = reader[4].ToString();
                Year_Label.Text = reader[5].ToString();
                DirectorLabel.Text = reader[6].ToString();
                CastLabel.Text = reader[7].ToString();
                IMDB_Label.Text = reader[8].ToString();
                Rotten_label.Text = reader[9].ToString();
                DescriptionLabel.Text = reader[10].ToString();
                SeatsLabel.Text = reader[11].ToString();
                MD_PictureBox.Image = byteArrayToImage((byte[])reader[12]);
            }
            connection.Close();

            


        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void BookNow_MD_btn_Click(object sender, EventArgs e)
        {
            Ticket_Booking TB = new Ticket_Booking(M_UserID,MovieID,moviename);
            TB.Show();
            this.Hide();
        }

        private void Movie_Details_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Watch_NOW watch = new Watch_NOW(M_UserID);
            watch.Show();
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
                Customer_Login customer = new Customer_Login();
                customer.Show();
                this.Show();
            }
            else
            {

            }  
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
