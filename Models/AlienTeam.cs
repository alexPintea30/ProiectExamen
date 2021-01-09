using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class AlienTeam
    {
        public int ID { get; set; }
        public int AlienID { get; set; }
        public Alien Alien { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
