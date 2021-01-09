using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;

namespace Project.Pages.AlienTeams
{
    public class CreateModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public CreateModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AlienID"] = new SelectList(_context.Set<Alien>(), "ID", "Name");
        ViewData["TeamID"] = new SelectList(_context.Set<Team>(), "ID", "TeamName");
            return Page();
        }

        [BindProperty]
        public AlienTeam AlienTeam { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AlienTeam.Add(AlienTeam);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
