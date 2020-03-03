using Administrativo.Pessoas;
using Atendimento.Matriculas;
using Dados.Queries.Matriculas.ModeloDeLeitura;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class Context : DbContext
    {
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<AlunosPorTurmaListItem> AlunosPorTurma { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunosPorTurmaListItem>().HasNoKey();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
