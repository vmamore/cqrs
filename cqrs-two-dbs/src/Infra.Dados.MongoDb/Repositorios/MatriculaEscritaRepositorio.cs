using Atendimento.Matriculas;
using Atendimento.Matriculas.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Infra.Dados.MongoDb.Repositorios
{
    public class MatriculaEscritaRepositorio : IMatriculaEscritaRepositorio
    {
        private readonly MongoDbContext _context;

        public MatriculaEscritaRepositorio(IOptions<ConfigurationSettings> settings)
        {
            _context = new MongoDbContext(settings);
        }
        public void AtualizarTurma(Turma turma)
        {
            throw new NotImplementedException();
        }

        public async Task Salvar(Matricula matricula)
        {
            throw new NotImplementedException();
        }
    }
}
