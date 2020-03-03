using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.ObjetosDeValor;
using CQRS.Dominio;
using System.Threading.Tasks;

namespace Administrativo.Pessoas.Validacoes
{
    public class PessoaDeveSerUnicaSpecification : SpecificationAsync
    {
        private readonly IPessoaFisicaLeituraRepositorio _pessoaFisicaRepositorio;
        private CPF CPF { get; }

        public PessoaDeveSerUnicaSpecification(IPessoaFisicaLeituraRepositorio pessoaFisicaRepositorio, CPF cpf)
        {
            CPF = cpf;
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
        }

        public override async Task<bool> EstaValido()
        {
            var pessoa = await _pessoaFisicaRepositorio.ObterPorCPF(CPF);
            return pessoa == null;
        }

        public new string Mensagem = "Pessoa Física com CPF já esta cadastrada na base de dados!";
    }
}
