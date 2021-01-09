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
    public class DetailsModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public DetailsModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public AlienTeam AlienTeam { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AlienTeam = await _context.AlienTeam
                .Include(a => a.Alien)
                .Include(a => a.Team).FirstOrDefaultAsync(m => m.ID == id);

            if (AlienTeam == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
