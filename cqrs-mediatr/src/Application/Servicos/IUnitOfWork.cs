using System.Threading.Tasks;

namespace Application.Servicos
{
    public interface IUnitOfWork
    {
        Task<int> Salvar();
    }
}
