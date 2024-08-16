using Microsoft.EntityFrameworkCore;
using projet_web_atrio.Models;

namespace projet_web_atrio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Emploi> Emplois { get; set; }

    }
}
