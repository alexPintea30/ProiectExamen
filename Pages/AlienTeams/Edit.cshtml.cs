using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.AlienTeams
{
    public class EditModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public EditModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            ViewData["AlienID"] = new SelectList(_context.Set<Alien>(), "ID", "Name");
            ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "TeamName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AlienTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlienTeamExists(AlienTeam.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AlienTeamExists(int id)
        {
            return _context.AlienTeam.Any(e => e.ID == id);
        }
    }
}
