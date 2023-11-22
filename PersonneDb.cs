using Microsoft.EntityFrameworkCore;

namespace Web_atrio
{
    public class PersonneContext: DbContext
    {
        public PersonneContext(DbContextOptions<PersonneContext> options)
            : base(options) { }
        public DbSet<Personne> Personnes => Set<Personne>();            
        public DbSet<Emploi> Emploies => Set<Emploi>();

    }
}
