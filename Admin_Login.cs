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
    public partial class Admin_Login : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";
        public Admin_Login()
        {
            InitializeComponent();

            label6.Visible = false;
            pincode.Visible = false;
            button1.Visible = false;

        }

        private void Sign_btn_AL_Click(object sender, EventArgs e)
        {
            String Admin_Email_Validate = textBox1.Text;
            String Admin_Password_Validate = textBox2.Text;

            if (Admin_Email_Validate == "" || Admin_Password_Validate == "")
            {

                string message = "Provide Username And Password First !";
                string title = "Error !";
                MessageBox.Show(message, title);
                return;
            }

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();

                string query = "SELECT * FROM AdminPage WHERE AdminEmail=@AEmail AND AdminPassword=@APassword";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@AEmail", Admin_Email_Validate);
                command.Parameters.AddWithValue("@APassword", Admin_Password_Validate);

                SqlDataAdapter Adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                Adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    Admin_Page AP = new Admin_Page();
                    AP.Show();
                    this.Hide();
                }
                else
                {
                    string message = "Invalid Login Details! \nTry Again";
                    string title = "Error !";
                    MessageBox.Show(message, title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Back_btn_CL_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void Home_btn_CL_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void forgot_password_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            pincode.Visible = true;
            button1.Visible = true;

        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Admin_Email_Validate = textBox1.Text;


            if (Admin_Email_Validate == "" || pincode.Text == "")
            {

                string message = "Provide Email And Pin First !";
                string title = "Error !";
                MessageBox.Show(message, title);
                return;
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(ConnectionString);

                    connection.Open();

                    string query = "SELECT * FROM AdminPage WHERE AdminEmail=@AEmail AND AdminPin=@Apin";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@AEmail", Admin_Email_Validate);
                    command.Parameters.AddWithValue("@Apin", pincode.Text);

                    SqlDataAdapter Adapter = new SqlDataAdapter(command);

                    DataTable dataTable = new DataTable();

                    Adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 1)
                    {
                        Admin_Page AP = new Admin_Page();
                        AP.Show();
                        this.Hide();
                    }
                    else
                    {
                        string message = "Invalid Login Details! \nTry Again";
                        string title = "Error !";
                        MessageBox.Show(message, title);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
