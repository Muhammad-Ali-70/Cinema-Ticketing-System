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
    public partial class Watch_NOW : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\Documents\Visual Studio 2013\Projects\Movie Ticketing System\Movie Ticketing System\CinemaTicketing_DBS.mdf;Integrated Security=True";
        DataSet dataset = new DataSet();
        int WN_userID;
        string email;

        public Watch_NOW(int userID)
        {
            InitializeComponent();
            WN_userID = userID;
        }

        private void Watch_Now_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT LTRIM(RTRIM(Name)),MovieImage from Movies";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            command = Adapter.SelectCommand;

            Adapter.Fill(dataset);

            if (dataset.Tables[0].Rows.Count == 1)
            {
                Byte[] data ;
                W1_Label.Text = dataset.Tables[0].Rows[0][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[0]["MovieImage"]);
                MemoryStream mem = new MemoryStream(data);

                W1.Image = Image.FromStream(mem);


                W2.Visible = false;
                W3.Visible = false;
                W4.Visible = false;
                W5.Visible = false;
                W6.Visible = false;
                W7.Visible = false;
                W8.Visible = false;
                W9.Visible = false;
                W10.Visible = false;
                W11.Visible = false;
                W12.Visible = false;


            }


            else if (dataset.Tables[0].Rows.Count == 2)
            {
                Byte[] data;


                W1_Label.Text = dataset.Tables[0].Rows[0][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[0]["MovieImage"]);
                MemoryStream mem = new MemoryStream(data);

                W1.Image = Image.FromStream(mem);

                W2_Label.Text = dataset.Tables[0].Rows[1][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[1]["MovieImage"]);
                mem = new MemoryStream(data);
                W2.Image = Image.FromStream(mem);


                
                W3.Visible = false;
                W4.Visible = false;
                W5.Visible = false;
                W6.Visible = false;
                W7.Visible = false;
                W8.Visible = false;
                W9.Visible = false;
                W10.Visible = false;
                W11.Visible = false;
                W12.Visible = false;



            }

            else if (dataset.Tables[0].Rows.Count == 3)
            {
                Byte[] data;


                W1_Label.Text = dataset.Tables[0].Rows[0][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[0]["MovieImage"]);
                MemoryStream mem = new MemoryStream(data);

                W1.Image = Image.FromStream(mem);

                W2_Label.Text = dataset.Tables[0].Rows[1][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[1]["MovieImage"]);
                mem = new MemoryStream(data);
                W2.Image = Image.FromStream(mem);


                W3_Label.Text = dataset.Tables[0].Rows[2][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[2]["MovieImage"]);
                mem = new MemoryStream(data);
                W3.Image = Image.FromStream(mem);

               
                W4.Visible = false;
                W5.Visible = false;
                W6.Visible = false;
                W7.Visible = false;
                W8.Visible = false;
                W9.Visible = false;
                W10.Visible = false;
                W11.Visible = false;
                W12.Visible = false;

            }

            else if (dataset.Tables[0].Rows.Count == 4)
            {
                Byte[] data;


                W1_Label.Text = dataset.Tables[0].Rows[0][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[0]["MovieImage"]);
                MemoryStream mem = new MemoryStream(data);

                W1.Image = Image.FromStream(mem);

                W2_Label.Text = dataset.Tables[0].Rows[1][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[1]["MovieImage"]);
                mem = new MemoryStream(data);
                W2.Image = Image.FromStream(mem);


                W3_Label.Text = dataset.Tables[0].Rows[2][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[2]["MovieImage"]);
                mem = new MemoryStream(data);
                W3.Image = Image.FromStream(mem);

                W4_Label.Text = dataset.Tables[0].Rows[3][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[3]["MovieImage"]);
                mem = new MemoryStream(data);
                W4.Image = Image.FromStream(mem);


               
                W5.Visible = false;
                W6.Visible = false;
                W7.Visible = false;
                W8.Visible = false;
                W9.Visible = false;
                W10.Visible = false;
                W11.Visible = false;
                W12.Visible = false;

            }
            else if (dataset.Tables[0].Rows.Count == 5)
            {
                Byte[] data;


                W1_Label.Text = dataset.Tables[0].Rows[0][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[0]["MovieImage"]);
                MemoryStream mem = new MemoryStream(data);

                W1.Image = Image.FromStream(mem);

                W2_Label.Text = dataset.Tables[0].Rows[1][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[1]["MovieImage"]);
                mem = new MemoryStream(data);
                W2.Image = Image.FromStream(mem);


                W3_Label.Text = dataset.Tables[0].Rows[2][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[2]["MovieImage"]);
                mem = new MemoryStream(data);
                W3.Image = Image.FromStream(mem);

                W4_Label.Text = dataset.Tables[0].Rows[3][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[3]["MovieImage"]);
                mem = new MemoryStream(data);
                W4.Image = Image.FromStream(mem);

                W5_Label.Text = dataset.Tables[0].Rows[4][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[4]["MovieImage"]);
                mem = new MemoryStream(data);
                W5.Image = Image.FromStream(mem);


                W1.Visible = false;
                W2.Visible = false;
                W3.Visible = false;
                W4.Visible = false;
                W6.Visible = false;
                W7.Visible = false;
                W8.Visible = false;
                W9.Visible = false;
                W10.Visible = false;
                W11.Visible = false;
                W12.Visible = false;


            }
            else if (dataset.Tables[0].Rows.Count == 6)
            {
                Byte[] data;

                W1_Label.Text = dataset.Tables[0].Rows[0][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[0]["MovieImage"]);
                MemoryStream mem = new MemoryStream(data);

                W1.Image = Image.FromStream(mem);

                W2_Label.Text = dataset.Tables[0].Rows[1][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[1]["MovieImage"]);
                mem = new MemoryStream(data);
                W2.Image = Image.FromStream(mem);


                W3_Label.Text = dataset.Tables[0].Rows[2][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[2]["MovieImage"]);
                mem = new MemoryStream(data);
                W3.Image = Image.FromStream(mem);

                W4_Label.Text = dataset.Tables[0].Rows[3][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[3]["MovieImage"]);
                mem = new MemoryStream(data);
                W4.Image = Image.FromStream(mem);

                W5_Label.Text = dataset.Tables[0].Rows[4][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[4]["MovieImage"]);
                mem = new MemoryStream(data);
                W5.Image = Image.FromStream(mem);

                W6_Label.Text = dataset.Tables[0].Rows[5][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[5]["MovieImage"]);
                mem = new MemoryStream(data);
                W6.Image = Image.FromStream(mem);

                
                W7.Visible = false;
                W8.Visible = false;
                W9.Visible = false;
                W10.Visible = false;
                W11.Visible = false;
                W12.Visible = false;
            }
            else if (dataset.Tables[0].Rows.Count == 7)
            {
                Byte[] data;

                W1_Label.Text = dataset.Tables[0].Rows[0][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[0]["MovieImage"]);
                MemoryStream mem = new MemoryStream(data);

                W1.Image = Image.FromStream(mem);

                W2_Label.Text = dataset.Tables[0].Rows[1][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[1]["MovieImage"]);
                mem = new MemoryStream(data);
                W2.Image = Image.FromStream(mem);


                W3_Label.Text = dataset.Tables[0].Rows[2][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[2]["MovieImage"]);
                mem = new MemoryStream(data);
                W3.Image = Image.FromStream(mem);

                W4_Label.Text = dataset.Tables[0].Rows[3][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[3]["MovieImage"]);
                mem = new MemoryStream(data);
                W4.Image = Image.FromStream(mem);

                W5_Label.Text = dataset.Tables[0].Rows[4][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[4]["MovieImage"]);
                mem = new MemoryStream(data);
                W5.Image = Image.FromStream(mem);

                W6_Label.Text = dataset.Tables[0].Rows[5][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[5]["MovieImage"]);
                mem = new MemoryStream(data);
                W6.Image = Image.FromStream(mem);

                W7_Lable.Text = dataset.Tables[0].Rows[6][0].ToString();

                data = (Byte[])(dataset.Tables[0].Rows[6]["MovieImage"]);
                mem = new MemoryStream(data);
                W7.Image = Image.FromStream(mem);


               
                W8.Visible = false;
                W9.Visible = false;
                W10.Visible = false;
                W11.Visible = false;
                W12.Visible = false;

            }


        }

        private void Back_btn_WN_Click(object sender, EventArgs e)
        {
            
        }

        private void Home_btn_WN_Click(object sender, EventArgs e)
        {
            Form1 first = new Form1();
            first.Show();
            this.Hide();
        }

        private void W1_Click(object sender, EventArgs e)
        {

            Movie_Details MOV = new Movie_Details(W1_Label.Text,WN_userID);
            MOV.Show();
            this.Hide();

        }

        private void W2_Click(object sender, EventArgs e)
        {
            Movie_Details MOV = new Movie_Details(W2_Label.Text, WN_userID);
            MOV.Show();
            this.Hide();
        }

        private void W3_Click(object sender, EventArgs e)
        {
            Movie_Details MOV = new Movie_Details(W3_Label.Text, WN_userID);
            MOV.Show();
            this.Hide();
        }

        private void W4_Click(object sender, EventArgs e)
        {
            Movie_Details MOV = new Movie_Details(W4_Label.Text, WN_userID);
            MOV.Show();
            this.Hide();
        }


        private void W5_Click(object sender, EventArgs e)
        {
            Movie_Details MOV = new Movie_Details(W5_Label.Text, WN_userID);
            MOV.Show();
            this.Hide();

        }

        private void W6_Click(object sender, EventArgs e)
        {
            Movie_Details MOV = new Movie_Details(W6_Label.Text, WN_userID);
            MOV.Show();
            this.Hide();
        }

        private void W7_Click(object sender, EventArgs e)
        {
            Movie_Details MOV = new Movie_Details(W7_Lable.Text, WN_userID);
            MOV.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            string query = "SELECT Email from UserPage Where CMTS_ID=@userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", WN_userID);

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
