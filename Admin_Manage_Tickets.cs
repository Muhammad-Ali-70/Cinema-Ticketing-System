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
    public partial class Admin_Manage_Tickets : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        public Admin_Manage_Tickets()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(ConnectionString);
            DataSet set = new DataSet();
            DataTable datatable = new DataTable();
            connection.Open();

            string query = "SELECT * FROM Ticketbooking";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            command = adapter.SelectCommand;

            adapter.Fill(datatable);

            dataGridView1.DataSource = datatable;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 130;
            dataGridView1.Columns[8].Width = 80;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[11].Width = 110;
            dataGridView1.Columns[12].Width = 110;
            dataGridView1.Columns[13].Width = 90;

            connection.Close();

        }

        private void DeleteTicket_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet set = new DataSet();
                DataTable datatable = new DataTable();

                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();

                string query = "DELETE FROM TicketBooking WHERE TicketNumber=@Ticket";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Ticket", int.Parse(textBox1.Text));

                command.ExecuteNonQuery();


                query = "SELECT * FROM Ticketbooking";

                command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                command = adapter.SelectCommand;

                adapter.Fill(datatable);

                dataGridView1.DataSource = datatable;

                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 130;
                dataGridView1.Columns[8].Width = 80;
                dataGridView1.Columns[9].Width = 100;
                dataGridView1.Columns[10].Width = 80;
                dataGridView1.Columns[11].Width = 110;
                dataGridView1.Columns[12].Width = 110;
                dataGridView1.Columns[13].Width = 90;

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error- Cannot Delete " + ex.Message, "Error");
            }


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin_Page admin = new Admin_Page();
            admin.Show();
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
