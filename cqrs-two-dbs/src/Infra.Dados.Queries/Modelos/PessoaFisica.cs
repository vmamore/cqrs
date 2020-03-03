using System;

namespace Infra.Dados.Queries.Modelos
{
    public class PessoaFisica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
