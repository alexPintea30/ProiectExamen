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

namespace Project.Pages.Aliens
{
    public class EditModel : AlienTeamsPageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public EditModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Alien Alien { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alien = await _context.Alien
               .Include(b => b.Planet)
               .Include(b => b.AlienTeams).ThenInclude(b => b.Team)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);

            if (Alien == null)
            {
                return NotFound();
            }
            PopulateAssignedTeamData(_context, Alien);
            ViewData["PlanetID"] = new SelectList(_context.Set<Planet>(), "ID", "PlanetName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTeams)
        {
            if (id == null)
            {
                return NotFound();
            }
            var alienToUpdate = await _context.Alien
            .Include(i => i.Planet)
            .Include(i => i.AlienTeams)
                .ThenInclude(i => i.Team)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (alienToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Alien>(
            alienToUpdate,
            "Alien",
            i => i.Name, i => i.Age,
            i => i.Color, i => i.ArrivedOnEarth, i => i.PlanetID))
            {
                UpdateAlienTeams(_context, selectedTeams, alienToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
          
            UpdateAlienTeams(_context, selectedTeams, alienToUpdate);
            PopulateAssignedTeamData(_context, alienToUpdate);
            return Page();
        }

        private bool AlienExists(int id)
        {
            return _context.Alien.Any(e => e.ID == id);
        }
    }
}
