using Administrativo.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class Context : DbContext
    {
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("context");
        }
    }
}
