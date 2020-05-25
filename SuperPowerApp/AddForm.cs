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
    public partial class AddForm : Form
    {
        private SuperPowerHandler superPowerHandler = new SuperPowerHandler();
        public AddForm()
        {
            InitializeComponent();
        }

        private void btn_Add_Cliked(object sender, EventArgs e)
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
            if (superhero.Affinity == null)
            {
                superhero.Affinity = new Affinity();
                superhero.Affinity = this.superPowerHandler.CreateAffinity(txtBox_Affinity.Text);
            }
            superhero.Name = txtBox_HeroName.Text;
            this.superPowerHandler.CreateSuperHero(superhero);
            this.Close();
        }
    }
}
