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
    public partial class ForgotPassword : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        public ForgotPassword()
        {
            InitializeComponent();
            label5.Visible = false;
            textBox2.Visible = false;
            SaveChanges.Visible = false;
            NextButton.Visible = true;

        }

        private void Sign_btn_CL_Click(object sender, EventArgs e)
        {
            String User_Email_Validate = textBox1.Text;           

            if (User_Email_Validate == "")
            {
                string message = "Provide Email First!";
                string title = "Error !";
                MessageBox.Show(message, title);
                return;
            }

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();

                string query = "SELECT * FROM UserPage WHERE Email=@Email";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Email", User_Email_Validate);

                SqlDataAdapter Adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                Adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    label5.Visible = true;
                    textBox2.Visible = true;
                    SaveChanges.Visible = true;
                    NextButton.Visible = false;
                }
                else
                {
                    string message = "Invalid Email! \nNo Email Exist.";
                    string title = "Error !";
                    MessageBox.Show(message, title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            string UserNewPassword = textBox2.Text;

            if (UserNewPassword == "")
            {
                string message = "Provide Email First!";
                string title = "Error !";
                MessageBox.Show(message, title);
                return;
            }
            else
            {
                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();

                string User_Email_Validate = textBox1.Text;


                string query = "UPDATE UserPage SET Password=@NewPassword WHERE Email=@Emaill";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@NewPassword", UserNewPassword);

                command.Parameters.AddWithValue("@Emaill", User_Email_Validate);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Password Changed Successfully", "Updated");

                textBox2.Text = string.Empty;
                textBox1.Text = string.Empty;
            }


            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Customer_Login login = new Customer_Login();
            login.Show();
            this.Hide();
        }

        
    }
}
