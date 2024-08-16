using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet_web_atrio.Data;
using projet_web_atrio.Models;

namespace projet_web_atrio.Pages.Admin.Personnes
{
    public class EditModel : PageModel
    {
        private readonly projet_web_atrio.Data.DataContext _context;

        public EditModel(projet_web_atrio.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Personne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonneExists(Personne.Id))
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

        private bool PersonneExists(int id)
        {
            return _context.Personnes.Any(e => e.Id == id);
        }
    }
}
