using CQRS;
using Infra.Dados.Queries.Turmas.ModeloDeLeitura;
using System.Collections.Generic;

namespace Infra.Dados.Queries.Turmas.Query
{
    public class TurmasEAlunosQuery : IQuery<IEnumerable<AlunosPorTurmaListItem>>
    {
    }
}
