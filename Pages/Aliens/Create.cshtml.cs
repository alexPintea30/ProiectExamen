using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;

namespace Project.Pages.Aliens
{
    public class CreateModel : AlienTeamsPageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public CreateModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PlanetID"] = new SelectList(_context.Set<Planet>(), "ID", "PlanetName");
            var alien = new Alien();
            alien.AlienTeams = new List<AlienTeam>();
            PopulateAssignedTeamData(_context, alien);

            return Page();
        }

        [BindProperty]
        public Alien Alien { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedTeams)
        {
            var newAlien = new Alien();
            if (selectedTeams != null)
            {
                newAlien.AlienTeams = new List<AlienTeam>();
                foreach (var cat in selectedTeams)
                {
                    var catToAdd = new AlienTeam
                    {
                        TeamID = int.Parse(cat)
                    };
                    newAlien.AlienTeams.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Alien>(
            newAlien,
            "Alien",
            i => i.Name, i => i.Age,
            i => i.Color, i => i.ArrivedOnEarth, i => i.PlanetID))
            {
                _context.Alien.Add(newAlien);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedTeamData(_context, newAlien);
            return Page();
        }
    }
}
