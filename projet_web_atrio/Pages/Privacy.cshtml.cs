using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projet_web_atrio.Data;
using projet_web_atrio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet_web_atrio.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        DataContext _dataContext;

        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            this._dataContext = dataContext;
        }

        public void OnGet()
        {
            var personne = new Personne() { Nom = "Toto", Prenom = "Tata", DateDeNaissance = new DateTime(1990, 5, 15) };
            _dataContext.Personnes.Add(personne);
            _dataContext.SaveChanges();

        }
    }
}
