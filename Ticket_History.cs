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
    public partial class Ticket_History : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";
        int userID;
        string email;
        public Ticket_History(int UserID)
        {
            InitializeComponent();
            userID = UserID;

            SqlConnection connection = new SqlConnection(ConnectionString);
            DataSet set = new DataSet();
            DataTable datatable = new DataTable();
            connection.Open();

            string query = "SELECT * FROM Ticketbooking WHERE CMTS_ID=@userID ORDER BY TicketNumber DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", userID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            command = adapter.SelectCommand;

            adapter.Fill(datatable);

            dataGridView1.DataSource = datatable;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {            
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT Email from UserPage Where CMTS_ID=@userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", userID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                email = reader[0].ToString();
            }

            User_Page user = new User_Page(email);
            user.Show();
            this.Hide();
        }
    }
}
