using System.Threading.Tasks;

namespace Administrativo.Pessoas.Interfaces
{
    public interface IPessoaFisicaEscritaRepositorio
    {
        Task CriarAsync(PessoaFisica pessoaFisica);
    }
}
