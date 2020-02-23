using Atendimento.Matriculas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dados.Mapeamentos
{
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.AlunoId)
                .IsRequired();

            builder.Property(m => m.TurmaId)
                .IsRequired();
        }
    }
}
