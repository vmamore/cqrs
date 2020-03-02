using Atendimento.Matriculas.Eventos;
using Atendimento.Matriculas.Interfaces;
using CQRS.Events;
using Dados;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Handlers.Eventos
{
    public class MatriculaRealizadaComSucessoHandler : IEventHandler<MatriculaRealizadaComSucesso>
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IUnitOfWork _uow;

        public MatriculaRealizadaComSucessoHandler(
            IMatriculaRepositorio matriculaRepositorio,
            IUnitOfWork uow)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _uow = uow;
        }

        public async Task HandleAsync(MatriculaRealizadaComSucesso @event)
        {
            var turma = await _matriculaRepositorio.ObterTurmaPorId(@event.TurmaId);

            turma.ContabilizarMatricula(@event.MatriculaId);

            _matriculaRepositorio.AtualizarTurma(turma);

            await _uow.Salvar();
        }
    }
}
