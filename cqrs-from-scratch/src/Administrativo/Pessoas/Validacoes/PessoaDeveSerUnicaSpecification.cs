using Administrativo.Pessoas.Interfaces;
using CQRS.Dominio;
using System.Threading.Tasks;

namespace Administrativo.Pessoas.Validacoes
{
    public class PessoaDeveSerUnicaSpecification : SpecificationAsync
    {
        private readonly IPessoaFisicaLeituraRepositorio _pessoaFisicaLeituraRepositorio;
        private string CPF { get; }

        public PessoaDeveSerUnicaSpecification(IPessoaFisicaLeituraRepositorio pessoaFisicaLeituraRepositorio, string cpf)
        {
            CPF = cpf;
            _pessoaFisicaLeituraRepositorio = pessoaFisicaLeituraRepositorio;
        }

        public override async Task<bool> EstaValido()
        {
            var pessoa = await _pessoaFisicaLeituraRepositorio.ObterPorCPF(CPF);
            return pessoa == null;
        }

        public new string Mensagem = "Pessoa Física com CPF já esta cadastraca na base de dados!";
    }
}
