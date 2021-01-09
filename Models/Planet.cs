using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Planet
    {
        public int ID { get; set; }
        public string PlanetName { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal PlanetArea { get; set; }
        public int NrOfSatellites { get; set; }
        public ICollection<Alien> Aliens { get; set; }
    }
}
