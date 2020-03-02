using Atendimento.Matriculas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Dados.Mapeamentos
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .HasMaxLength(150);

            builder.Property(t => t.Codigo)
                .HasMaxLength(150);

            builder.HasData(
                new List<object>
                {
                    new
                    {
                        Id = new Guid("1CD96EF4-16A6-49D8-9999-67CA67533BEE"),
                        Nome = "Curso .NET",
                        Codigo = "2020.1.1",
                        QuantidadeDeVagas = 30
                    },
                    new
                    {
                        Id = new Guid("62FB99CD-E73E-4797-917B-1C1E1B256E26"),
                        Nome = "Curso Javacript",
                        Codigo = "2020.1.2",
                        QuantidadeDeVagas = 30
                    },
                });
        }
    }
}
