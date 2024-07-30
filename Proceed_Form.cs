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
    public partial class Proceed_Form : Form
    {

        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        int UserID;
        int MoveID;
        int TicketNUmber;
        int NumberTickets;


        public Proceed_Form(int CMTSID,int MID,int tickerNum)
        {
            InitializeComponent();

            UserID = CMTSID;
            MoveID = MID;
            TicketNUmber = tickerNum;

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT LTRIM(RTRIM(Name)),MovieImage from Movies WHERE MID=@MovieID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MovieID", MID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ShowName_Label.Text = reader[0].ToString();
                ProceedfromPIC.Image = byteArrayToImage((byte[])reader[1]);
            }

            reader.Close();

            query = "SELECT LTRIM(RTRIM(Name)) from UserPage WHERE CMTS_ID=@CMTS";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CMTS", UserID);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Username_Label.Text = reader[0].ToString();
            }

            reader.Close();

            query = "SELECT FamilyType,Num_Tickets,TimeSelected,BookingDate,TotalBill from TicketBooking WHERE TicketNumber=@tickerNum";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@tickerNum", TicketNUmber);
            
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                FamilyTypeLabel.Text = reader[0].ToString();
                NumberTickets = int.Parse(reader[1].ToString());
                ShowTImeLabel.Text = reader[2].ToString();
                ShowDateLabel.Text = reader[3].ToString();
                TotalPaymentLabel.Text = reader[4].ToString();
            }
            NumberTicketsLabel.Text = NumberTickets.ToString();
            connection.Close();

            

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        private void Back_btn_Confirm_Click(object sender, EventArgs e)
        {
            
        }

        private void Home_btn_Confirm_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void Proceed_PaymentButton_Click(object sender, EventArgs e)
        {
            Payment_Selection payment = new Payment_Selection(UserID, MoveID,TicketNUmber,NumberTickets);
            payment.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Something Went Wrong!", "Error");

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
