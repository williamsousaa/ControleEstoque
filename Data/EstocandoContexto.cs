using System.Threading.Tasks;
using Estocando.Models;
using Microsoft.EntityFrameworkCore;

namespace Estocando.Data
{
    public class EstocandoContexto : DbContext
    {
        public EstocandoContexto(DbContextOptions<EstocandoContexto> options)
        : base(options){ }

        public DbSet<Produto> Produtos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstocandoContexto).Assembly);  
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}