using Dados.Queries.Matriculas.ModeloDeLeitura;
using MediatR;

namespace Application.CasosDeUso.Atendimento.Commands
{
    public class TurmasEAlunosQuery : IRequest<AlunosPorTurmaListItem>
    {
    }
}
