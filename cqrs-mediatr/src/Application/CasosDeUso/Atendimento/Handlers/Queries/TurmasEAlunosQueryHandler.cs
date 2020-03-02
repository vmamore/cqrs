using Application.CasosDeUso.Atendimento.Commands;
using Dados.Queries.Matriculas.ModeloDeLeitura;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Handlers.Queries
{
    public class TurmasEAlunosQueryHandler : IRequestHandler<TurmasEAlunosQuery, AlunosPorTurmaListItem>
    {
        public Task<AlunosPorTurmaListItem> Handle(TurmasEAlunosQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
