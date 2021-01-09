using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string TeamName { get; set; }

        public ICollection<AlienTeam> AlienTeams { get; set; }

    }
}
