using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projet_web_atrio.Data;
using projet_web_atrio.Models;

namespace projet_web_atrio.Pages.Admin.Personnes
{
    public class DeleteModel : PageModel
    {
        private readonly projet_web_atrio.Data.DataContext _context;

        public DeleteModel(projet_web_atrio.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Personne Personne { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personne = await _context.Personnes.FirstOrDefaultAsync(m => m.Id == id);

            if (Personne == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personne = await _context.Personnes.FindAsync(id);

            if (Personne != null)
            {
                _context.Personnes.Remove(Personne);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
