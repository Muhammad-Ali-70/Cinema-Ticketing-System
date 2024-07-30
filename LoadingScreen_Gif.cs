using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Ticketing_System
{
    public partial class LoadingScreen_Gif : Form
    {

        int UserID1;
        int MoveID;
        int TicketNUmber;
        public LoadingScreen_Gif(int userID,int MoveId,int tiketnum)
        {
            InitializeComponent();
            UserID1 = userID;
            MoveID = MoveId;
            TicketNUmber = tiketnum;
        }


        Timer t1;
        private void LoadingScreen_Gif_Shown(object sender, EventArgs e)
        {
            t1 = new Timer();
            t1.Interval = 2000;
            t1.Start();
            t1.Tick += tick_click;
        }
        private void tick_click(object sender, EventArgs e)
        {
            t1.Stop();
            this.Hide();

            Ticked_Confimed TC = new Ticked_Confimed(UserID1, MoveID, TicketNUmber);
            TC.Show();
            this.Hide();

        }
    }
}
