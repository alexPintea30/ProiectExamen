using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Alien> Alien { get; set; }

        public DbSet<Project.Models.Planet> Planet { get; set; }

        public DbSet<Project.Models.Team> Team { get; set; }

        public DbSet<Project.Models.AlienTeam> AlienTeam { get; set; }
    }
}
