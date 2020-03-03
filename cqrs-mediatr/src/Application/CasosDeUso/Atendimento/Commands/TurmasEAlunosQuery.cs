using Dados.Queries.Matriculas.ModeloDeLeitura;
using MediatR;
using System.Collections.Generic;

namespace Application.CasosDeUso.Atendimento.Commands
{
    public class TurmasEAlunosQuery : IRequest<IEnumerable<AlunosPorTurmaListItem>>
    {
    }
}
