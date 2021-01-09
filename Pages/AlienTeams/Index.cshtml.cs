using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.AlienTeams
{
    public class IndexModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public IndexModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<AlienTeam> AlienTeam { get;set; }

        public async Task OnGetAsync()
        {
            AlienTeam = await _context.AlienTeam
                .Include(a => a.Alien)
                .Include(a => a.Team).ToListAsync();
        }
    }
}
