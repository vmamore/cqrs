using Administrativo.Pessoas.ObjetosDeValor;
using System;
using System.Threading.Tasks;

namespace Administrativo.Pessoas.Interfaces
{
    public interface IPessoaFisicaRepositorio
    {
        Task<PessoaFisica> ObterPorId(Guid id);
        Task<PessoaFisica> ObterPorCPF(CPF cpf);
        Task CriarAsync(PessoaFisica pessoaFisica);
    }
}
