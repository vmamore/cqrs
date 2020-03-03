using System;

namespace Dados.Queries.Matriculas.ModeloDeLeitura
{
    public class AlunosPorTurmaListItem
    {
        public string AlunoNome { get; set; }
        public string NomeTurma { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
    }
}
