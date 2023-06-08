using AWSConciertos.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSConciertos.Data
{
    public class ConciertosContext:DbContext
    {
        public ConciertosContext(DbContextOptions<ConciertosContext> options): base(options) { }

        public DbSet<CategoriaEvento> CategoriaEventos { get; set; }

        public DbSet<Evento> Eventos { get; set; }
    }
}
