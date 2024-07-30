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
    public partial class Registeration : Form
    {

        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        String User_Name;
        int User_Age;
        String User_Gender;
        String User_Phone;
        String User_Email;
        String User_Password;
        String User_FavGenre;

        public Registeration()
        {
            InitializeComponent();

        }

        private void Back_btn_RU_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void Home_btn_RU_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        
        public void gender_FavGenre()
        {
            if (radioButton1.Checked)
            {
                User_Gender = "Male";
            }
            else if (radioButton2.Checked)
            {
                User_Gender = "Female";
            }
            else
            {
                User_Gender = "None";
            }

           

            if (listBox1.SelectedItem == "Action")
            {
                User_FavGenre = "Action";
            }
            else if (listBox1.SelectedItem == "Horror")
            {
                User_FavGenre = "Horror";
            }
            else if (listBox1.SelectedItem == "Drama")
            {
                User_FavGenre = "Drama";
            }
            else if (listBox1.SelectedItem == "Comedy")
            {
                User_FavGenre = "Comedy";
            }
            else if (listBox1.SelectedItem == "Crime")
            {
                User_FavGenre = "Crime";
            }
            else if (listBox1.SelectedItem == "Adventure")
            {
                User_FavGenre = "Adventure";
            }
            else if (listBox1.SelectedItem == "Animation")
            {
                User_FavGenre = "Animation";
            }
            else
            {
                User_FavGenre = "None Selected";
            }

        }


        private void Register_btn_Click(object sender, EventArgs e)
        {
            
            String User_Name = textBox1.Text;
            int User_Age = int.Parse(textBox2.Text);
            String User_Phone = textBox3.Text;
            String User_Email = textBox4.Text;
            String User_Password = textBox5.Text;
            gender_FavGenre();


            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            String Query = "INSERT INTO UserPage(Name,Age,Gender,Phone,Email,Password,FavGenre) VALUES(@Name,@Age,@Gender,@Phone,@Email,@Password,@FavGenre)";

            SqlCommand command = new SqlCommand(Query,connection);

            command.Parameters.AddWithValue("@Name" , User_Name);
            command.Parameters.AddWithValue("@Age", User_Age);
            command.Parameters.AddWithValue("@Gender", User_Gender);
            command.Parameters.AddWithValue("@Phone", User_Phone);
            command.Parameters.AddWithValue("@Email", User_Email);
            command.Parameters.AddWithValue("@Password", User_Password);
            command.Parameters.AddWithValue("@FavGenre", User_FavGenre);


            command.ExecuteNonQuery();

            connection.Close();

            string message = "Successfully Registered !";
            string title = "Congrats !";
            MessageBox.Show(message, title);

            Customer_Login CL = new Customer_Login();
            CL.Show();
            this.Hide();

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

        
    }
}
