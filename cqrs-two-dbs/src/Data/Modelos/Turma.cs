using Dapper.Contrib.Extensions;
using System;

namespace Infra.Dados.SqlStorage.Modelos
{
    [Table("turmas")]
    public class Turma
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int QuantidadeDeVagas { get; set; }
    }
}
