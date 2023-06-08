using AWSConciertos.Data;
using AWSConciertos.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSConciertos.Repositories
{
    public class RepositoryConciertos
    {
        private ConciertosContext context;

        public RepositoryConciertos(ConciertosContext context)
        {
            this.context = context;
        }

        public async Task<List<Evento>> Eventos()
        {
            return await this.context.Eventos.ToListAsync();
        }

        public async Task<List<Evento>> EventosCategoria(int id)
        {
            var response = from datos in this.context.Eventos
                           where datos.IdCategoria == id
                           select datos;
            return await response.ToListAsync();
        }

        public async Task<List<CategoriaEvento>> CategoriasEventos()
        {
            return await this.context.CategoriaEventos.ToListAsync();
        }

        private int MaxIdEvento()
        {
            if(this.context.Eventos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Eventos.Max(x => x.IdEvento) + 1;
            }
        }

        public async Task InsertEvento(string nombre, string artista, int idcategoria, string imagen)
        {
            Evento evento = new Evento
            {
                IdEvento = this.MaxIdEvento(),
                Nombre = nombre,
                Artista = artista,
                IdCategoria = idcategoria,
                Imagen = imagen
            };

            await this.context.Eventos.AddAsync(evento);
            await this.context.SaveChangesAsync();
        }
    }
}
