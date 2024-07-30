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
    public partial class Ticket_Booking : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        int UserID1;
        int MovieID1;
        int TicketNumber;
        static string moviename;


        public Ticket_Booking(int UserID,int MovieID,string MOVNAME)
        {

            InitializeComponent();

            UserID1 = UserID;
            MovieID1 = MovieID;
            moviename = MOVNAME;

            radioButton1.Checked = true;

            dated_label.Text = "Dated: "+DateTime.Now.ToString("dd-MM-yyyy");

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT LTRIM(RTRIM(Name)),LTRIM(RTRIM(Seats)),Timing,MovieImage from Movies WHERE MID=@MovieID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MovieID",MovieID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                showName_Label.Text = reader[0].ToString();
                Seats_label.Text = reader[1].ToString();
                time_combox.Items.Add (reader[2].ToString());
                TicketBook_pic.Image = byteArrayToImage((byte[])reader[3]);
            }
            connection.Close();

            connection.Open();


             query = "SELECT ChildTicket,StandardMember,SilverMember,PlatinumMember,DiamondMember from TicketPricing";

             command = new SqlCommand(query, connection);

             reader = command.ExecuteReader();

            while (reader.Read())
            {
                ChildLabel.Text = reader[0].ToString();
                StandardLabel.Text = reader[1].ToString();
                SilverLabel.Text = reader[2].ToString();
                PlatinumLabel.Text = reader[3].ToString();
                DiamondLabel.Text = reader[4].ToString();

            }
            connection.Close();

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        



        private void Home_btn_TB_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void Next_button_Click(object sender, EventArgs e)
        {
            string showname = showName_Label.Text;
            string selectCinema = Cinema_Combo.Text;
            string city = City_Combo.Text;

            string familytype;
            int num_tickets;

            if (radioButton1.Checked){

                familytype = radioButton1.Text;
                num_tickets = int.Parse(TicketsCombo.Text);

            }
            else
            {
                familytype = radioButton2.Text;
                num_tickets = 1;
            }

            string ticketType = Ticket_type_combo.Text;
            string time = time_combox.Text;
            string BookingData = DateTime.Now.ToString("dd-MM-yyyy");

            int TotallBill;

            if (ticketType == "Child Member"){

                TotallBill = num_tickets * int.Parse(ChildLabel.Text);
            }
            else if (ticketType == "Standard Member"){

                TotallBill = num_tickets * int.Parse(StandardLabel.Text);
            }
            else if (ticketType == "Silver Member"){

                TotallBill = num_tickets * int.Parse(SilverLabel.Text);
            }
            else if (ticketType == "Platinum Member"){

                TotallBill = num_tickets * int.Parse(PlatinumLabel.Text);
            }
            else if (ticketType == "Diamond Member"){

                TotallBill = num_tickets * int.Parse(DiamondLabel.Text);
            }
            else
            {
                TotallBill = 0;
            }

            string Billpayed = "No";
            

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "INSERT INTO TicketBooking(ShowName,CinemaName,CinemaCity,FamilyType,Num_Tickets,TicketType,TimeSelected,BookingDate,TotalBill,BillPayed,CMTS_ID,MID) VALUES (@ShowName,@Cinema,@City,@Familytype,@NumTickets,@tickettype,@time,@bookingdate,@TotalBill,@BillPayed,@CMts,@MovieID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ShowName",showname);
            command.Parameters.AddWithValue("@Cinema",selectCinema);
            command.Parameters.AddWithValue("@City",city);
            command.Parameters.AddWithValue("@Familytype",familytype);
            command.Parameters.AddWithValue("@NumTickets",num_tickets);
            command.Parameters.AddWithValue("@tickettype",ticketType);
            command.Parameters.AddWithValue("@time",time);
            command.Parameters.AddWithValue("@bookingdate",BookingData);
            command.Parameters.AddWithValue("@TotalBill", TotallBill);
            command.Parameters.AddWithValue("@BillPayed",Billpayed);         
            command.Parameters.AddWithValue("@CMts",UserID1);
            command.Parameters.AddWithValue("@MovieID", MovieID1);

            command.ExecuteNonQuery();

            connection.Close();
           
            connection.Open();

            query = "SELECT TicketNumber from TicketBooking Where CMTS_ID=@CMTS and MID=@MovieId";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CMTS", @UserID1);
            command.Parameters.AddWithValue("@MovieId", MovieID1);

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                TicketNumber = int.Parse(reader[0].ToString());
                
            }
            connection.Close();

           Proceed_Form PF = new Proceed_Form(UserID1, MovieID1, TicketNumber);

            PF.Show();

            this.Hide();


        }

        private void Back_btn_TB_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                TicketsCombo.Enabled = false;
            }
            else
            {
                TicketsCombo.Enabled = true;
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
            Movie_Details detail = new Movie_Details( moviename,UserID1);
            detail.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
 
      
    }
}
