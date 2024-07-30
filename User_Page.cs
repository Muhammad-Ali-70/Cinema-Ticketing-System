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
    public partial class User_Page : Form
    {

        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";
        int userID;    
        int ticketNum;
        int MID;

        public User_Page(string email)
        {
            
            InitializeComponent();
            string username = "";

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT CMTS_ID,LTRIM(RTRIM(Name)) FROM UserPage WHERE Email=@id_email";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id_email", email);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                userID = int.Parse(reader[0].ToString());
                username = reader[1].ToString();
            }
            connection.Close();

            user_label.Text = "Welcome " + username+" !";
        }

       
        private void Download_ticket_UP_Click(object sender, EventArgs e)
        {
            try
            {

          SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT TOP 1 TicketNumber,MID FROM TicketBooking WHERE CMTS_ID=@userId ORDER BY TicketNumber DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userId", userID);

             SqlDataAdapter Adapter = new SqlDataAdapter(command);

             DataTable dataTable = new DataTable();

              Adapter.Fill(dataTable);
            
            if (dataTable.Rows.Count == 1)
            {

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ticketNum = int.Parse(reader[0].ToString());
                    MID = int.Parse(reader[1].ToString());
                }
                
                connection.Close();

                LoadingScreen_Gif check = new LoadingScreen_Gif(userID,MID,ticketNum);
                check.Show();
                this.Hide();
            }
            else{
                    string message = "No Ticket has been Booked !\nBook A Ticket First.";
                    string title = "Error !";
                    MessageBox.Show(message, title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               

        }

        private void WatchNow_UP_Click(object sender, EventArgs e)
        {
            Watch_NOW watch = new Watch_NOW(userID);
            watch.Show();
            this.Hide();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string message = "Are You Sure You Want to Proceed?\nThis Action will Redirect You to Login Page!";
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

        private void TicketHistory_Click(object sender, EventArgs e)
        {
            Ticket_History ticket = new Ticket_History(userID);
            ticket.Show();
            this.Hide();
        }


    }
}
