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
    public class DetailsModel : PageModel
    {
        private readonly projet_web_atrio.Data.DataContext _context;

        public DetailsModel(projet_web_atrio.Data.DataContext context)
        {
            _context = context;
        }

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
    }
}
