using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Alien
    {
        public int ID { get; set; }

        [Required, StringLength(70, MinimumLength = 4)]
        [Display(Name = "Alien Name")]
        public string Name { get; set; }

        [Range(1, 150)]
        [Display(Name = "Alien Age")]
        public int Age { get; set; }

        [Display(Name = "Alien Color")]
       [Required,StringLength(50,MinimumLength=3)]
        public string Color { get; set;}


        [DataType(DataType.Date)]
        public DateTime ArrivedOnEarth { get; set; }

       public int PlanetID { get; set; }
       public Planet Planet { get; set; }

        public ICollection<AlienTeam> AlienTeams { get; set; }
    }
}
