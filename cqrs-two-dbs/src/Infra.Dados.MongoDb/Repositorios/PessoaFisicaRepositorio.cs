using Administrativo.Pessoas;
using Administrativo.Pessoas.Interfaces;
using Infra.Dados.MongoDb.Extensions;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Infra.Dados.MongoDb.Repositorios
{
    public class PessoaFisicaEscritaRepositorio : IPessoaFisicaEscritaRepositorio
    {
        private readonly MongoDbContext _context;

        public PessoaFisicaEscritaRepositorio(IOptions<ConfigurationSettings> settings)
        {
            _context = new MongoDbContext(settings);
        }

        public async Task CriarAsync(PessoaFisica pessoaFisica)
        {
            var pessoaFisicaModel = pessoaFisica.Converter();

            await _context.PessoasFisicas.InsertOneAsync(pessoaFisicaModel);
        }
    }
}
