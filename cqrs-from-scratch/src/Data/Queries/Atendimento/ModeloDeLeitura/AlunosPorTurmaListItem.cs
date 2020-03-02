using System;

namespace Dados.Queries.Atendimento.ModeloDeLeitura
{
    public class AlunosPorTurmaListItem
    {
        public string NomeTurma { get; set; }
        public string AlunoNome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
    }
}
