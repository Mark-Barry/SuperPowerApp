using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperPowerApp
{
    public partial class form_SuperHeroRegistry : Form
    {
        
        public form_SuperHeroRegistry()
        {
            //this.txtBox_Origin.BackColor.A.Equals(0);
            InitializeComponent();
        }

        private void on_Exit_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void on_Previous_Clicked(object sender, EventArgs e)
        {

        }

        private void on_Next_Clicked(object sender, EventArgs e)
        {

        }
    }
}
