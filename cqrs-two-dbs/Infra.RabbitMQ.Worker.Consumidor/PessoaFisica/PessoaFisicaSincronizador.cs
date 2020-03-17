using Dapper;
using Infra.Dados.SqlStorage;
using System.Threading.Tasks;

namespace Infra.RabbitMQ.Worker.Consumidor.PessoaFisica
{
    public class PessoaFisicaSincronizador : ISincronizador<PessoaFisicaData>
    {
        private readonly ISqlServerConfigurations _sqlServerConfigurations;

        public PessoaFisicaSincronizador(ISqlServerConfigurations sqlServerConfigurations)
        {
            _sqlServerConfigurations = sqlServerConfigurations;
        }

        public async Task Sincronizar(PessoaFisicaData obj)
        {
            using (var connection = _sqlServerConfigurations.DbConnection)
            {
                await connection.ExecuteAsync("INSERT INTO [dbo].[pessoa_fisica] (Id, Nome, Email, DataDeNascimento, Logradouro, Numero, CEP) " +
                    "VALUES (@Id, @Nome, @Email, @DataDeNascimento, @Logradouro, @Numero, @Cep)", 
                    new {
                        @Id = obj.PessoaId,
                        @Nome = obj.Nome,
                        @Email = obj.Email,
                        @DataDeNascimento = obj.DataDeNascimento,
                        @Logradouro = obj.Logradouro,
                        @Numero = obj.Numero,
                        @Cep = obj.CEP
                    });
            }
        }
    }
}
