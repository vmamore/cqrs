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
                texto => new Nome(texto));

            builder.Property(pf => pf.CPF)
                .HasConversion(
                _ => _.Numero,
                cpf => new CPF(cpf));

            builder.OwnsOne(pf => pf.Endereco);
        }
    }
}
