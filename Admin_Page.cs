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
    public partial class Admin_Page : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";


        public Admin_Page()
        {
            InitializeComponent();

            DatedLabel.Text = "Dated: " + DateTime.Now.ToString("dd-MM-yyyy");

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT COUNT(*) from UserPage";

            SqlCommand command = new SqlCommand(query, connection);

            Int32 count = Convert.ToInt32(command.ExecuteScalar());

            User_label.Text = count.ToString();

            query = "SELECT COUNT(*) from Movies";

            command = new SqlCommand(query, connection);
       
            count = Convert.ToInt32(command.ExecuteScalar());

            movies_label.Text = count.ToString();


            query = "SELECT COUNT(*) from TicketBooking WHERE BillPayed='Yes'";

            command = new SqlCommand(query, connection);

            count = Convert.ToInt32(command.ExecuteScalar());

            confirmedtickets.Text = count.ToString();


            query = "SELECT ISNULL(SUM(TotalBill),0) from TicketBooking WHERE BillPayed='Yes'";

            command = new SqlCommand(query, connection);

            count = Convert.ToInt32(command.ExecuteScalar());

            totalblace.Text = count.ToString();

            connection.Close();
        }

        private void Edit_Movie_AP_Click(object sender, EventArgs e)
        {
            EditDetails_ID edit = new EditDetails_ID();
            edit.Show();
            this.Hide();
        }

        private void Add_Movie_AP_Click(object sender, EventArgs e)
        {
            Add_Movie_Admin add = new Add_Movie_Admin();
            add.Show();
            this.Hide();
        }

        private void Register_Users_AP_Click(object sender, EventArgs e)
        {
            Admin_Registered_users reg = new Admin_Registered_users();
            reg.Show();
            this.Hide();
        }

        private void Home_btn_UP_Click(object sender, EventArgs e)
        {
            Form1 from = new Form1();
            from.Show();
            this.Hide();
        }

        private void Back_btn_UP_Click(object sender, EventArgs e)
        {
            Admin_Login AL = new Admin_Login();
            AL.Show();
            this.Hide();
        }

        private void Manage_Movies_AP_Click(object sender, EventArgs e)
        {
            Admin_Manage_Movies admin_manage = new Admin_Manage_Movies();

            admin_manage.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string message = "Are You Sure You Want to Proceed?\nThis Action will Sign Out!";
            string title = "Log Out";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Admin_Login login = new Admin_Login();
                login.Show();
                this.Hide();
            }
            else
            {

            }  
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string message = "Are You Sure You Want to Logout?";
            string title = "Log Out";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Admin_Login login = new Admin_Login();
                login.Show();
                this.Hide();
            }
            else
            {

            }  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_UpdatePricing Update = new Admin_UpdatePricing();
            Update.Show();
            this.Hide();
        }

        private void ManageTickets_Click(object sender, EventArgs e)
        {
            Admin_Manage_Tickets Admin = new Admin_Manage_Tickets();
            Admin.Show();
            this.Hide();
        }

        
    }
}
