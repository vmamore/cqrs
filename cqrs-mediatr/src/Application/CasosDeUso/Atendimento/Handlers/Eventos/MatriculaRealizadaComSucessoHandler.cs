using Atendimento.Matriculas.Eventos;
using Atendimento.Matriculas.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Handlers.Eventos
{
    public class MatriculaRealizadaComSucessoHandler : INotificationHandler<MatriculaRealizadaComSucesso>
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;

        public MatriculaRealizadaComSucessoHandler(
            IMatriculaRepositorio matriculaRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
        }

        public async Task Handle(MatriculaRealizadaComSucesso notification, CancellationToken cancellationToken)
        {
            var turma = await _matriculaRepositorio.ObterTurmaPorId(notification.TurmaId);

            turma.ContabilizarMatricula(notification.MatriculaId);

            _matriculaRepositorio.AtualizarTurma(turma);
        }
    }
}
