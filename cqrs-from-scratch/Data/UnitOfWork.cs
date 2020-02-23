using Application.Servicos;
using System.Threading.Tasks;

namespace Dados
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public async Task<int> Salvar()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
