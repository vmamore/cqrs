using System.Threading.Tasks;

namespace Administrativo.Pessoas.Interfaces
{
    public interface IPessoaFisicaLeituraRepositorio
    {
        Task<PessoaFisica> ObterPorCPF(string cpf);
    }
}
