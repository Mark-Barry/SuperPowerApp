using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPowerApp.Classes
{
    public class Superhero
    {
        public int SuperheroID { get; set; }
        public int AffinityID { get; set; }
        public string Name { get; set; }

        public Superhero() { 
        }

        public Superhero(string name)
        {
            this.Name = name;
        }
    }
}
