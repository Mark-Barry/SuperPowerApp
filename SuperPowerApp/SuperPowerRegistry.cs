using SuperPowerApp.Classes;
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

        private SuperPowerHandler superPowerHandler = new SuperPowerHandler();
        public form_SuperHeroRegistry()
        {
            //this.txtBox_Origin.BackColor.A.Equals(0);
            InitializeComponent();
            this.DisplayHero();
        }

        private void DisplayHero() {
            txtBox_Super_Hero_ID.Text = this.superPowerHandler.currentSuperhero.SuperheroID.ToString();
            txtBox_Super_Hero_Name.Text = this.superPowerHandler.currentSuperhero.Name;
            txtBox_Affinity.Text = this.superPowerHandler.currentSuperhero.Affinity.Type;
        }

        private void on_Exit_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void on_Previous_Clicked(object sender, EventArgs e)
        {
            int index;
            index = this.superPowerHandler.SetPreviousSuperheroID();
            if (index != -1)
            {
                this.DisplayHero();
            }
        }

        private void on_Next_Clicked(object sender, EventArgs e)
        {
            int index;
            index = this.superPowerHandler.SetNextSuperheroID();
            if (index != -1)
            {
                this.DisplayHero();
            }
        }
    }
}
