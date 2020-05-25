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

        private void on_Delete_Clicked(object sender, EventArgs e)
        {
            this.superPowerHandler.DeleteSuperhero(this.superPowerHandler.currentSuperheroID);
            this.DisplayHero();
        }

        private void on_Update_Clicked(object sender, EventArgs e)
        {
            Superhero superhero = new Superhero();
            var affinities = superPowerHandler.Affinities;
            foreach (var affinity in this.superPowerHandler.Affinities)
            {
                if (affinity.Type == txtBox_Affinity.Text)
                {
                    superhero.Affinity = new Affinity();
                    superhero.Affinity.AffinityID = affinity.AffinityID;
                    superhero.Affinity.Type = affinity.Type;
                    break;
                }
            }
            if (superhero.Affinity.AffinityID == 0)
            {
                superhero.Affinity = new Affinity();
                superhero.Affinity = this.superPowerHandler.CreateAffinity(txtBox_Affinity.Text);
            }
            superhero.Name = txtBox_Super_Hero_Name.Text;
            superhero.SuperheroID = this.superPowerHandler.currentSuperheroID;
            this.superPowerHandler.UpdateSuperhero(superhero);
        }

        private void on_Create_Clicked(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }
    }
}
