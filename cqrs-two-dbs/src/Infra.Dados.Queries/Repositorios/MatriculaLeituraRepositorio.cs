using Atendimento.Matriculas;
using Atendimento.Matriculas.Interfaces;
using Dapper;
using Infra.Dados.SqlStorage;
using System;
using System.Threading.Tasks;

namespace Infra.Dados.Queries.Repositorios
{
    public class MatriculaLeituraRepositorio : IMatriculaLeituraRepositorio
    {
        private readonly ISqlServerConfigurations _sqlServer;

        public MatriculaLeituraRepositorio(
            ISqlServerConfigurations sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public async Task<Turma> ObterTurmaPorId(Guid id)
        {
            using (var connection = _sqlServer.DbConnection)
            {
                connection.Open();

                return await connection.QueryFirstOrDefaultAsync<Turma>("SELECT * FROM Turmas Where Id = @id", new { id });
            }
        }
    }
}
