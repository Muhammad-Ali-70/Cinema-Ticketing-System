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
    public partial class Ticked_Confimed : Form
    {
        int UserID1;
        int MId;
        int TicketNumber1;
        string NumType;
        string NumTickets;
        string tickettype;
        string CinemaName;
        string CinemaCity;
        string email;

        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        public Ticked_Confimed(int UserID,int MID,int TicketNumber)
        {
            InitializeComponent();
            UserID1 = UserID;
            MId = MID;
            TicketNumber1 = TicketNumber;

            TicketNumberLabel.Text = TicketNumber.ToString();

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT LTRIM(RTRIM(Name)),MovieImage from Movies WHERE MID=@MovieID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MovieID", MId);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ShowNameLabel.Text = reader[0].ToString();
                ConfirmationPic.Image = byteArrayToImage((byte[])reader[1]);
            }

            reader.Close();

            query = "SELECT LTRIM(RTRIM(Name)) from UserPage WHERE CMTS_ID=@CMTS";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CMTS", UserID1);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                UserNameLabel.Text = reader[0].ToString();
            }

            reader.Close();

            query = "SELECT LTRIM(RTRIM(BookingDate)),LTRIM(RTRIM(TimeSelected)),Num_Tickets,LTRIM(RTRIM(CinemaName)),LTRIM(RTRIM(CinemaCity)),TotalBill,LTRIM(RTRIM(TicketType)) from TicketBooking WHERE TicketNumber=@tickerNum";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@tickerNum", TicketNumber);

            reader = command.ExecuteReader();

            
            while (reader.Read())
            {
                ShowDateLabel.Text = reader[0].ToString();
                ShowTimeLabel.Text = reader[1].ToString();
                NumTickets = reader[2].ToString();
                CinemaName= reader[3].ToString();
                CinemaCity = reader[4].ToString();
                TotalBillLabel.Text = reader[5].ToString();
                tickettype = reader[6].ToString();

            }
            CinemaCityLabel.Text = CinemaName + " - " + CinemaCity;

            NumType = NumTickets+ "  (" + tickettype + ")";

            NumberTicketsLabel.Text = NumType;


            connection.Close();


            string QRVALUES = "Ticket Number : " + TicketNumber
                + "\nUserName : " + UserNameLabel.Text
                + "\nShow Name : " + ShowNameLabel.Text
                + "\nShow Date : " + ShowDateLabel.Text
                + "\nShow Time : " + ShowTimeLabel.Text
                + "\nNo. of Tickets : " + NumType
                + "\nCinema & City : " + CinemaCityLabel.Text
                + "\nTotal Bill : "+ TotalBillLabel.Text;

            QRCoder.QRCodeGenerator obj = new QRCoder.QRCodeGenerator();

            var mydata = obj.CreateQrCode(QRVALUES, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(mydata);

            pictureBox2.Image = code.GetGraphic(100);

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string message = "Cannot Go Back!\nThis Action will Redirect you to User Home Page\nAre You Sure You Want to Proceed ?";
            string title = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();

                string query = "SELECT Email from UserPage Where CMTS_ID=@userID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@userID", UserID1);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    email = reader[0].ToString();
                }

                User_Page user = new User_Page(email);
                user.Show();
                this.Hide();
            }
            else
            {
                return;
            }
            
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
                this.Hide();
            }
            else
            {
                return;
            }  
        }

      int ticketname = 1;
      private void DownloadButton_Click(object sender, EventArgs e)
      {
          ticketname++;
          using (var bmp = new Bitmap(panel3.Width, panel3.Height))
          {

              panel3.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

              bmp.Save(@"Tickets/" + TicketNumber1+"-"+ticketname+ ".bmp");


              MessageBox.Show("Ticket Download!\nSaved in Project/Debug/Tickets","Downloaded");
          }
      }

      private void Ticked_Confimed_Load(object sender, EventArgs e)
      {

      }
    }
}
