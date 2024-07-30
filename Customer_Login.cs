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

namespace Movie_Ticketing_System
{
    public partial class Customer_Login : Form
    {

        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        public Customer_Login()
        {
            InitializeComponent();
        }

        private int imageNumber = 1;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            loadNextImage();
        }

        private void loadNextImage()
        {       
            if (imageNumber == 13)
            {
                imageNumber = 1;
            }
            SlidePic.ImageLocation = string.Format(@"Images\{0}.jpg", imageNumber);
            imageNumber++;
        }


        private void back_click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void Sign_btn_CL_Click(object sender, EventArgs e)
        {
            String User_Email_Validate = textBox1.Text;
            String User_Password_Validate = textBox2.Text;

            if (User_Email_Validate == "" || User_Password_Validate == ""){

                string message = "Provide Username And Password First !";
                string title = "Error !";
                MessageBox.Show(message, title);

                return;
            }


            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();

                string query = "SELECT * FROM UserPage WHERE Email=@Email AND Password=@Password";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Email", User_Email_Validate);
                command.Parameters.AddWithValue("@Password", User_Password_Validate);

                SqlDataAdapter Adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                Adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    User_Page UP = new User_Page(User_Email_Validate);
                    UP.Show();
                    this.Hide();
                }
                else{
                     string message = "Invalid Login Details! \nTry Again";
                     string title = "Error !";
                     MessageBox.Show(message, title);
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }             
        }

        private void Home_btn_CL_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void Back_btn_CL_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void forgot_password_Click(object sender, EventArgs e)
        {
            ForgotPassword for1 = new ForgotPassword();
            for1.Show();
            this.Hide();
        }

        
        
        

        
    }
}
