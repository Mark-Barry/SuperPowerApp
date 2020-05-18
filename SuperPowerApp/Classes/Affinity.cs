using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPowerApp.Classes
{
    public class Affinity
    {
        public int AffinityID { get; set; }
        public string Type { get; set; }

        public Affinity() { }

        public Affinity(int id, string type) {
            this.AffinityID = id;
            this.Type = type;
        }
    }
}
