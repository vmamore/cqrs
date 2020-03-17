using Administrativo.Pessoas;
using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.ObjetosDeValor;
using Dapper;
using Infra.Dados.SqlStorage;
using System;
using System.Threading.Tasks;

namespace Infra.Dados.Queries.Repositorios
{
    public class PessoaFisicaLeituraRepositorio : IPessoaFisicaLeituraRepositorio
    {
        private readonly ISqlServerConfigurations _sqlServer;
        private readonly IPessoaFisicaFactory _pessoaFisicaFactory;
        public PessoaFisicaLeituraRepositorio(ISqlServerConfigurations sqlServer,
            IPessoaFisicaFactory pessoaFisicaFactory)
        {
            _sqlServer = sqlServer;
            _pessoaFisicaFactory = pessoaFisicaFactory;
        }

        public async Task<PessoaFisica> ObterPorCPF(CPF cpfVo)
        {
            using (var connection = _sqlServer.DbConnection)
            {
                var cpf = cpfVo.Numero;
                connection.Open();

                var pessoaFisicaDto = await connection.QueryFirstOrDefaultAsync<Modelos.PessoaFisica>("SELECT * FROM [dbo].[pessoa_fisica] Where CPF = @cpf", new { cpf });

                if (pessoaFisicaDto == null) return null;

                return _pessoaFisicaFactory.CriarNovaPessoa(
                    pessoaFisicaDto.Nome,
                    pessoaFisicaDto.CPF,
                    pessoaFisicaDto.Email,
                    pessoaFisicaDto.DataDeNascimento,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            }
        }

        public async Task<PessoaFisica> ObterPorId(Guid id)
        {
            using (var connection = _sqlServer.DbConnection)
            {
                connection.Open();

                var pessoaFisicaDto = await connection.QueryFirstOrDefaultAsync<Modelos.PessoaFisica>("SELECT * FROM [dbo].[pessoa_fisica] Where Id = @id", new { id });

                return _pessoaFisicaFactory.CriarNovaPessoa(
                    pessoaFisicaDto.Nome,
                    pessoaFisicaDto.CPF,
                    pessoaFisicaDto.Email,
                    pessoaFisicaDto.DataDeNascimento,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            }
        }
    }
}
