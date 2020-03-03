using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.Validacoes;
using Application.CasosDeUso.Administrativo.Commands;
using CQRS;
using CQRS.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Administrativo.Handlers
{
    public class CadastrarPessoaFisicaHandler : ICommandHandler<CadastrarPessoaFisica>
    {
        private readonly IPessoaFisicaLeituraRepositorio _pessoaFisicaLeituraRepositorio;
        private readonly IPessoaFisicaEscritaRepositorio _pessoaFisicaEscritaRepositorio;
        private readonly IPessoaFisicaFactory _pessoaFisicaFactory;

        public CadastrarPessoaFisicaHandler(
            IPessoaFisicaLeituraRepositorio pessoaFisicaLeituraRepositorio,
            IPessoaFisicaEscritaRepositorio pessoaFisicaEscritaRepositorio,
            IPessoaFisicaFactory pessoaFisicaFactory)
        {
            _pessoaFisicaLeituraRepositorio = pessoaFisicaLeituraRepositorio;
            _pessoaFisicaEscritaRepositorio = pessoaFisicaEscritaRepositorio;
            _pessoaFisicaFactory = pessoaFisicaFactory;
        }

        public async Task<Resultado> Handle(CadastrarPessoaFisica command, CancellationToken cancellationToken)
        {
            var pessoaFisica = _pessoaFisicaFactory.CriarNovaPessoa(
                command.Nome,
                command.CPF,
                command.DataDeNascimento,
                command.Logradouro,
                command.CEP,
                command.Numero);

            var pessoaDeveSerUnica = new PessoaDeveSerUnicaSpecification(_pessoaFisicaLeituraRepositorio, pessoaFisica.CPF);

            if (!await pessoaDeveSerUnica.EstaValido())
                return Resultado.Erro(pessoaDeveSerUnica.Mensagem);

            await _pessoaFisicaEscritaRepositorio.CriarAsync(pessoaFisica);

            return Resultado.OK();
        }
    }
}
