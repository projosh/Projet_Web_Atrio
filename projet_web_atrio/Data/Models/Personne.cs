using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;

namespace projet_web_atrio.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom {  get; set; }

        public string Prenom { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public ICollection<Emploi> Emplois { get; set; } = new List<Emploi>();


    }

    public class Emploi
    {
        public int Id { get; set; }

        public string NomEntreprise { get; set; }

        public string PosteOccupe { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public int PersonneId { get; set; }
        public Personne Personne { get; set; }

    } 


}
