using Atendimento.Matriculas;
using Atendimento.Matriculas.Interfaces;
using CQRS.Events;
using System;
using System.Threading.Tasks;

namespace Dados.Repositorios
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly Context _context;
        private readonly IEventPublisher _eventPublisher;

        public MatriculaRepositorio(
            Context context,
            IEventPublisher eventPublisher)
        {
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public void AtualizarTurma(Turma turma)
        {
            _context.Turmas.Update(turma);
        }

        public async Task<Turma> ObterTurmaPorId(Guid turmaId)
        {
            return await _context.Turmas.FindAsync(turmaId);
        }

        public async Task Salvar(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);

            foreach(var evento in matricula.Eventos)
            {
                await _eventPublisher.PublishAsync((dynamic)evento);
            }
        }
    }
}
