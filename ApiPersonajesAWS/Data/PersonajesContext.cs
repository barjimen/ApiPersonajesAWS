using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Data
{
    public class PersonajesContext : DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base()
        { }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
