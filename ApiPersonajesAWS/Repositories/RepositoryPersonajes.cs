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

        public async Task<Personaje> GetPersonaje(int id)
        {
            Personaje perso = await this.context.Personajes.Where(x => x.IdPersonaje == id).FirstOrDefaultAsync();
            return perso;
        }

        public async Task UpdatePersonaje(Personaje perso)
        {
            Personaje personaje = await this.GetPersonaje(perso.IdPersonaje);
            personaje.Nombre = perso.Nombre;
            personaje.Imagen = perso.Imagen;
            await this.context.AddAsync(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
