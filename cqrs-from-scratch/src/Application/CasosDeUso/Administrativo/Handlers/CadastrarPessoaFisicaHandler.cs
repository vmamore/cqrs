using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.Validacoes;
using Application.CasosDeUso.Administrativo.Commands;
using Core.Commands;
using CQRS.Dominio;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Administrativo.Handlers
{
    public class CadastrarPessoaFisicaHandler : ICommandHandler<CadastrarPessoaFisica>
    {
        private readonly IPessoaFisicaEscritaRepositorio _pessoaFisicaEscritaRepositorio;
        private readonly IPessoaFisicaLeituraRepositorio _pessoaFisicaLeituraRepositorio;
        private readonly IPessoaFisicaFactory _pessoaFisicaFactory;
        public CadastrarPessoaFisicaHandler(
            IPessoaFisicaEscritaRepositorio pessoaFisicaEscritaRepositorio,
            IPessoaFisicaLeituraRepositorio pessoaFisicaLeituraRepositorio,
            IPessoaFisicaFactory pessoaFisicaFactory)
        {
            _pessoaFisicaEscritaRepositorio = pessoaFisicaEscritaRepositorio;
            _pessoaFisicaLeituraRepositorio = pessoaFisicaLeituraRepositorio;
            _pessoaFisicaFactory = pessoaFisicaFactory;
        }

        public async Task<Resultado> ExecuteAsync(CadastrarPessoaFisica command)
        {
            var pessoaFisica = _pessoaFisicaFactory.CriarNovaPessoa(
                command.Nome,
                command.CPF,
                command.DataDeNascimento,
                command.Logradouro,
                command.CEP,
                command.Numero);

            var pessoaDeveSerUnica = new PessoaDeveSerUnicaSpecification(_pessoaFisicaLeituraRepositorio, pessoaFisica.CPF.Numero);

            if (!await pessoaDeveSerUnica.EstaValido())
                return Resultado.Erro(pessoaDeveSerUnica.Mensagem);

            await _pessoaFisicaEscritaRepositorio.CriarAsync(pessoaFisica);

            return Resultado.OK();
        }
    }
}
