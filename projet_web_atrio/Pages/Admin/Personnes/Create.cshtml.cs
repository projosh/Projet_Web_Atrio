using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projet_web_atrio.Data;
using projet_web_atrio.Models;

namespace projet_web_atrio.Pages.Admin.Personnes
{
    public class CreateModel : PageModel
    {
        private readonly projet_web_atrio.Data.DataContext _context;

        public CreateModel(projet_web_atrio.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Personne Personne { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Personnes.Add(Personne);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
