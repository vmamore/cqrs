using Administrativo.Pessoas;
using Administrativo.Pessoas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dados.Repositorios
{
    public class PessoaFisicaRepositorio : IPessoaFisicaEscritaRepositorio, IPessoaFisicaLeituraRepositorio
    {
        private readonly Context _context;
        public PessoaFisicaRepositorio(Context context)
        {
            _context = context;
        }

        public async Task CriarAsync(PessoaFisica pessoaFisica)
        {
            await _context.PessoasFisicas.AddAsync(pessoaFisica);
        }

        public async Task<PessoaFisica> ObterPorCPF(string cpf)
        {
            return await _context.PessoasFisicas
                .SingleOrDefaultAsync(pf => pf.CPF.Numero.Equals(cpf));
        }
    }
}
