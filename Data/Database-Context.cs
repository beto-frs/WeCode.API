using Microsoft.EntityFrameworkCore;
using WeCode.API.Model;
using WeCode.API.ViewModel;

namespace WeCode.API.Data
{
    public class Database_Context : DbContext
    {
        public Database_Context(DbContextOptions<Database_Context> options) : base(options)
        {

        }

        public DbSet<Espectador> Espectadores { get; set; }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Visualizado> Visualizados { get; set; }

        
        
    }
}
