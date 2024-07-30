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
    public partial class Payment_Selection : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        int UserID1;
        int MoveID;
        int TicketNUmber;
        int User_numberTickets;
        int MovieTotalSeats;

        public Payment_Selection(int UserID,int MID,int TiketID,int numbertickets)
        {
            InitializeComponent();

            UserID1 = UserID;
            MoveID = MID;
            TicketNUmber = TiketID;
            User_numberTickets = numbertickets;
        }


        private void PaymentSelectionCODE(string methodtype)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string billpayed = "Yes";
            string Method = methodtype;

            String Query = "UPDATE TicketBooking SET BillPayed=@BillPayment,PaymentMethod=@Method WHERE MID=@MovieID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@BillPayment", billpayed);
            command.Parameters.AddWithValue("@Method", Method);

            command.Parameters.AddWithValue("@MovieID", MoveID);

            command.ExecuteNonQuery();

            connection.Close();

            connection.Open();

            string query = "SELECT LTRIM(RTRIM(Seats)) from Movies WHERE MID=@MovieID";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MovieID", MoveID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MovieTotalSeats = int.Parse(reader[0].ToString());
            }

            connection.Close();

            connection.Open();

            Query = "UPDATE Movies SET Seats=@updatedSeats WHERE MID=@MovieID";
            command = new SqlCommand(Query, connection);

            int updatedseats = MovieTotalSeats - User_numberTickets;

            command.Parameters.AddWithValue("@updatedSeats", updatedseats);
            command.Parameters.AddWithValue("@MovieID", MoveID);


            command.ExecuteNonQuery();

            connection.Close();

            LoadingScreen_Gif obj = new LoadingScreen_Gif(UserID1, MoveID, TicketNUmber);
            
            obj.Show();
            this.Hide();

            }


        private void payment_selection_click(object sender, EventArgs e)
        {

        }

        private void CreditCardButton_Click(object sender, EventArgs e)
        {
            string Method = "Credit/Debit Card";
            PaymentSelectionCODE(Method);
          
        }

        private void EasyPaisaButton_Click(object sender, EventArgs e)
        {
           
            
            string Method = "EasyPaisa";
            PaymentSelectionCODE(Method);
            
        }

        private void Nayapaybutton_Click(object sender, EventArgs e)
        {
          
            string Method = "NayaPay";
            PaymentSelectionCODE(Method);
            
        }

        private void CNICButton_Click(object sender, EventArgs e)
        {
            string Method = "CNIC";
            PaymentSelectionCODE(Method);
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
            Proceed_Form pf = new Proceed_Form( UserID1, MoveID ,TicketNUmber);
            pf.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
