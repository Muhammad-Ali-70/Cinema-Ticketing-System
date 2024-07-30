using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_Ticketing_System
{
    public partial class EditDetails_ID : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";

        public EditDetails_ID()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(ConnectionString);
            DataSet set = new DataSet();
            DataTable datatable = new DataTable();
            connection.Open();

          

            string query = "SELECT MID,Name,Genre,Category,ReleaseDate,Year,Director,Cast,IMDBRating,RottenTomatos,Timing,Seats FROM Movies";

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
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 80;
            connection.Close();

        }

        private void Proceed_btn_EDIT_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
       
            connection.Open();

            string query = "SELECT * FROM Movies WHERE MID=@MID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MID", int.Parse(textBox1.Text));

            int count = command.ExecuteNonQuery();

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            Adapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {                
                int id = int.Parse(textBox1.Text);
                Edit_MovieDetails_Admin obj = new Edit_MovieDetails_Admin(id);

                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Movie Found in DataBase!\nCheck MID and Try Again.", "Error!");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
