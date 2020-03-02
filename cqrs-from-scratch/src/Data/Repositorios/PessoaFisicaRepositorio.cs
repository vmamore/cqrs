using Administrativo.Pessoas;
using Administrativo.Pessoas.Interfaces;
using Administrativo.Pessoas.ObjetosDeValor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dados.Repositorios
{
    public class PessoaFisicaRepositorio : IPessoaFisicaRepositorio
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

        public async Task<PessoaFisica> ObterPorCPF(CPF cpf)
        {
            return await _context.PessoasFisicas
                .SingleOrDefaultAsync(pf => pf.CPF.Equals(cpf));
        }

        public async Task<PessoaFisica> ObterPorId(Guid id)
        {
            return await _context.PessoasFisicas
                .SingleOrDefaultAsync(pf => pf.Id == id);
        }
    }
}
