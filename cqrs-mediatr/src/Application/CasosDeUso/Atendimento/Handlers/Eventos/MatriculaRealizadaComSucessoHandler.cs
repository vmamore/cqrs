using Application.Servicos;
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
        private readonly IUnitOfWork _uow;

        public MatriculaRealizadaComSucessoHandler(
            IMatriculaRepositorio matriculaRepositorio,
            IUnitOfWork uow)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _uow = uow;
        }

        public async Task Handle(MatriculaRealizadaComSucesso notification, CancellationToken cancellationToken)
        {
            var turma = await _matriculaRepositorio.ObterTurmaPorId(notification.TurmaId);

            turma.ContabilizarMatricula(notification.MatriculaId);

            _matriculaRepositorio.AtualizarTurma(turma);

            await _uow.Salvar();
        }
    }
}
