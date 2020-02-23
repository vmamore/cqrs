using Administrativo.Pessoas;
using Administrativo.Pessoas.ObjetosDeValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dados.Mapeamentos
{
    public class PessoaFisicaMapping : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.HasKey(pf => pf.Id);

            builder.Property(pf => pf.Nome)
                .HasConversion(
                _ => _.Texto,
                texto => new Nome(texto))
                .IsRequired();

            builder.Property(pf => pf.CPF)
                .HasConversion(
                _ => _.Numero,
                numero => new CPF(numero))
                .IsRequired();

            builder.OwnsOne(pf => pf.Endereco);
        }
    }
}
