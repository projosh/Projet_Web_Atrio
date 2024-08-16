using Microsoft.AspNetCore.Mvc;
using projet_web_atrio.Data;
using projet_web_atrio.Models;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet_web_atrio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // GET: api/<ApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ApiController]
        [Route("api/[controller]")]
        public class PersonnesController : ControllerBase
        {
            private readonly DataContext _context;

            public PersonnesController(DataContext context)
            {
                _context = context;
            }


            private bool EstValide(Personne personne)
            {
                var age = DateTime.Now.Year - personne.DateDeNaissance.Year;
                if (personne.DateDeNaissance > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                return age < 150;
            }


            [HttpPost]
            public IActionResult AjouterPersonne([FromBody] Personne personne)
            {
                if (!EstValide(personne))
                {
                    return BadRequest("La personne ne peut pas avoir plus de 150 ans.");
                }

                _context.Personnes.Add(personne);
                _context.SaveChanges();

                return Ok(personne);
            }
        }
    }


}

