using Application.CasosDeUso.Atendimento.Commands;
using Dados;
using Dados.Queries.Matriculas.ModeloDeLeitura;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Handlers.Queries
{
    public class TurmasEAlunosQueryHandler : IRequestHandler<TurmasEAlunosQuery, IEnumerable<AlunosPorTurmaListItem>>
    {
        private readonly Context _context;
        public TurmasEAlunosQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlunosPorTurmaListItem>> Handle(TurmasEAlunosQuery request, CancellationToken cancellationToken)
        {
            return _context.AlunosPorTurma.FromSqlRaw("select * from [dbo].[turmas_com_alunos]");
        }
    }
}
