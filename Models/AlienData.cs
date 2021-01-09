using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class AlienData
    {
        public IEnumerable<Alien> Aliens { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<AlienTeam> AlienTeams { get; set; }
    }
}
