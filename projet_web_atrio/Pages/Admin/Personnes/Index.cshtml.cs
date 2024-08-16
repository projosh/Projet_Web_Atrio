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
    public class IndexModel : PageModel
    {
        private readonly projet_web_atrio.Data.DataContext _context;

        public IndexModel(projet_web_atrio.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Personne> Personne { get;set; }

        public async Task OnGetAsync()
        {
            Personne = await _context.Personnes.ToListAsync();
        }
    }
}
