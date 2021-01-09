using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Aliens
{
    public class IndexModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public IndexModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<Alien> Alien { get;set; }
        public AlienData AlienD { get; set; }
        public int AlienID { get; set; }
        public int TeamID { get; set; }

        public async Task OnGetAsync(int? id, int? teamID)
        {
            
                AlienD = new AlienData();
                AlienD.Aliens = await _context.Alien.Include(b => b.Planet)
                .Include(b => b.AlienTeams)
                .ThenInclude(b => b.Team)
                 .AsNoTracking()
                .ToListAsync();
            if (id != null)
            {
                AlienID = id.Value;
                Alien alien = AlienD.Aliens
                .Where(i => i.ID == id.Value).Single();
                AlienD.Teams = alien.AlienTeams.Select(s => s.Team);
            }
        }
    }
}
