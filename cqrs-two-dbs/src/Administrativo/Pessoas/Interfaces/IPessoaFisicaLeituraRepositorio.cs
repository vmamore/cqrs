using Administrativo.Pessoas.ObjetosDeValor;
using System;
using System.Threading.Tasks;

namespace Administrativo.Pessoas.Interfaces
{
    public interface IPessoaFisicaLeituraRepositorio
    {
        Task<PessoaFisica> ObterPorCPF(CPF cpf);
        Task<PessoaFisica> ObterPorId(Guid id);
    }
}
