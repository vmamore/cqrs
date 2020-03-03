using Dapper;
using Infra.Dados.Queries.Turmas.ModeloDeLeitura;
using Infra.Dados.SqlStorage;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Dados.Queries.Turmas.Query.Handler
{
    public class TurmasEAlunosQueryHandler : IRequestHandler<TurmasEAlunosQuery, IEnumerable<AlunosPorTurmaListItem>>
    {
        private readonly ISqlServerConfigurations _sqlServerConfiguration;
        public TurmasEAlunosQueryHandler(ISqlServerConfigurations sqlServerConfiguration)
        {
            _sqlServerConfiguration = sqlServerConfiguration;
        }

        public async Task<IEnumerable<AlunosPorTurmaListItem>> Handle(TurmasEAlunosQuery request, CancellationToken cancellationToken)
        {
            using(var connection = _sqlServerConfiguration.DbConnection)
            {
                connection.Open();

                return await connection.QueryAsync<AlunosPorTurmaListItem>("select * from [dbo].[turmas_com_alunos]");
            }
        }
    }
}
