using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.Validacoes;
using Application.CasosDeUso.Administrativo.Commands;
using Application.Servicos;
using CQRS.Dominio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Administrativo.Handlers
{
    public class CadastrarPessoaFisicaHandler : IRequestHandler<CadastrarPessoaFisica, Resultado>
    {
        private readonly IPessoaFisicaRepositorio _pessoaFisicaRepositorio;
        private readonly IPessoaFisicaFactory _pessoaFisicaFactory;
        private readonly IUnitOfWork _uow;

        public CadastrarPessoaFisicaHandler(
            IPessoaFisicaRepositorio pessoaFisicaRepositorio,
            IPessoaFisicaFactory pessoaFisicaFactory,
            IUnitOfWork uow)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
            _pessoaFisicaFactory = pessoaFisicaFactory;
            _uow = uow;
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

            var pessoaDeveSerUnica = new PessoaDeveSerUnicaSpecification(_pessoaFisicaRepositorio, pessoaFisica.CPF);

            if (!await pessoaDeveSerUnica.EstaValido())
                return Resultado.Erro(pessoaDeveSerUnica.Mensagem);

            await _pessoaFisicaRepositorio.CriarAsync(pessoaFisica);

            await _uow.Salvar();

            return Resultado.OK();
        }
    }
}
