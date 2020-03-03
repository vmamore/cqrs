using Dapper.Contrib.Extensions;
using System;

namespace Infra.Dados.SqlStorage.Modelos
{
    [Table("pessoasfisicas")]
    public class PessoaFisica
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
    }
}
