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
    public partial class Admin_UpdatePricing : Form
    {

        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";


        public Admin_UpdatePricing()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT ChildTicket,StandardMember,SilverMember,PlatinumMember,DiamondMember from TicketPricing";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

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

        private void Next_button_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string Query = "UPDATE TicketPricing SET ChildTicket=@Child,StandardMember=@Standard,SilverMember=@siler,PlatinumMember=@Plat,DiamondMember=@Diamond";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Child", textBox1.Text);
            command.Parameters.AddWithValue("@Standard", textBox2.Text);
            command.Parameters.AddWithValue("@siler", textBox3.Text);
            command.Parameters.AddWithValue("@Plat", textBox4.Text);
            command.Parameters.AddWithValue("@Diamond", textBox5.Text);

            command.ExecuteNonQuery();

            connection.Close();

            connection.Open();

            string query = "SELECT ChildTicket,StandardMember,SilverMember,PlatinumMember,DiamondMember from TicketPricing";

             command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ChildLabel.Text = reader[0].ToString();
                StandardLabel.Text = reader[1].ToString();
                SilverLabel.Text = reader[2].ToString();
                PlatinumLabel.Text = reader[3].ToString();
                DiamondLabel.Text = reader[4].ToString();

            }
            connection.Close();

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;


            MessageBox.Show("Prices Updated Successfully!", "Updated");

            


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Admin_Page admin = new Admin_Page();
            admin.Show();
            this.Hide();
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



       
    }
}
