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
    public partial class Admin_Registered_users : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";
        
        public Admin_Registered_users()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(ConnectionString);
            DataSet set = new DataSet();
            DataTable datatable = new DataTable();
            connection.Open();

            string query = "SELECT CMTS_ID,Name,Age,Gender,Phone,Email,FavGenre FROM UserPage";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            command = adapter.SelectCommand;

            adapter.Fill(datatable);

            dataGridView1.DataSource = datatable;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 118;
            connection.Close();

        }

        

        private void Add_Movie_AP_Click(object sender, EventArgs e)
        {

            DataSet set = new DataSet();
            DataTable datatable = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "DELETE FROM UserPage WHERE CMTS_ID=@ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

            command.ExecuteNonQuery();

           

            MessageBox.Show("User Successfully Deleted !", "User Deleted");

            textBox1.Clear();

            connection.Close();

            if (this.dataGridView1.DataSource != null)
            {
                this.dataGridView1.DataSource = null;
            }
            else
            {
                this.dataGridView1.Rows.Clear();
            }

            connection.Open();

            query = "SELECT CMTS_ID,Name,Age,Gender,Phone,Email,FavGenre FROM UserPage";

             command = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            command = adapter.SelectCommand;

            adapter.Fill(datatable);

            dataGridView1.DataSource = datatable;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 118;
            connection.Close();
 

        }

        private void Home_btn_UP_Click(object sender, EventArgs e)
        {
            Form1 from = new Form1();
            from.Show();
            this.Hide();
        }

        private void Back_btn_UP_Click(object sender, EventArgs e)
        {
            Admin_Page ap = new Admin_Page();
            ap.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
