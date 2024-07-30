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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        Timer t1;
        private void splash_form_shown(object sender, EventArgs e)
        {
           
            t1 = new Timer();
            t1.Interval = 8000;
            t1.Start();
            t1.Tick += tick_click;
        }

        private void tick_click(object sender, EventArgs e)
        {
            t1.Stop();
            this.Hide();

            Form1 first = new Form1();
            first.Show();       

        }
    }
}
