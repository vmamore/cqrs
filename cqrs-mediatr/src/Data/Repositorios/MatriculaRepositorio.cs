using Atendimento.Matriculas;
using Atendimento.Matriculas.Interfaces;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Dados.Repositorios
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly Context _context;
        private readonly IMediator _mediatr;

        public MatriculaRepositorio(
            Context context,
            IMediator mediatr)
        {
            _context = context;
            _mediatr = mediatr;
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
                await _mediatr.Publish(evento);
            }
        }
    }
}
