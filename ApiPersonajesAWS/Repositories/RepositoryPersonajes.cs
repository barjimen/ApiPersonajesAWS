using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        private async Task<int> GetMaxId ()
        {
            return await this.context.Personajes.MaxAsync(x => x.IdPersonaje) + 1;
        }

        public async Task CreatePersonaje(string nombre, string imagen)
        {
            Personaje p = new Personaje();
            p.IdPersonaje = await this.GetMaxId();
            p.Nombre = nombre;
            p.Imagen = imagen;
            await this.context.Personajes.AddAsync(p);
            await this.context.SaveChangesAsync();
        }
    }
}
