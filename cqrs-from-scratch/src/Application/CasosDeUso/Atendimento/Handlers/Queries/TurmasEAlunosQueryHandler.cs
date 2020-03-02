using Application.CasosDeUso.Atendimento.Commands;
using CQRS.Queries;
using Dados;
using Dados.Queries.Atendimento.ModeloDeLeitura;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Handlers.Queries
{
    public class TurmasEAlunosQueryHandler : IQueryHandler<TurmasEAlunosQuery, IEnumerable<AlunosPorTurmaListItem>>
    {
        private readonly Context _context;

        public TurmasEAlunosQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlunosPorTurmaListItem>> ExecuteQueryAsync(TurmasEAlunosQuery queryParameters)
        {
            return _context.AlunosPorTurma.FromSqlRaw("select * from [dbo].[turmas_com_alunos]");
        }
    }
}
