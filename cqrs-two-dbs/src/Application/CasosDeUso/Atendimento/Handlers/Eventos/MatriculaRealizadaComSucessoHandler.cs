 using Atendimento.Matriculas.Eventos;
using Atendimento.Matriculas.Interfaces;
using CQRS;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Handlers.Eventos
{
    public class MatriculaRealizadaComSucessoHandler : IEventHandler<MatriculaRealizadaComSucesso>
    {
        private readonly IMatriculaEscritaRepositorio _matriculaEscritaRepositorio;
        private readonly IMatriculaLeituraRepositorio _matriculaLeituraRepositorio;

        public MatriculaRealizadaComSucessoHandler(
            IMatriculaEscritaRepositorio matriculaEscritaRepositorio,
            IMatriculaLeituraRepositorio matriculaLeituraRepositorio)
        {
            _matriculaEscritaRepositorio = matriculaEscritaRepositorio;
            _matriculaLeituraRepositorio = matriculaLeituraRepositorio;
        }

        public async Task Handle(MatriculaRealizadaComSucesso notification, CancellationToken cancellationToken)
        {
            var turma = await _matriculaLeituraRepositorio.ObterTurmaPorId(notification.TurmaId);

            turma.ContabilizarMatricula(notification.MatriculaId);

            _matriculaEscritaRepositorio.AtualizarTurma(turma);
        }
    }
}
