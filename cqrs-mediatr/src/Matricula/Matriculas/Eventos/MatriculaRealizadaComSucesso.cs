using MediatR;
using System;

namespace Atendimento.Matriculas.Eventos
{
    public class MatriculaRealizadaComSucesso : INotification
    {
        public Guid AlunoId { get; set; }
        public Guid MatriculaId { get; set; }
        public Guid TurmaId { get; set; }
        public MatriculaRealizadaComSucesso(
            Guid alunoId,
            Guid turmaId,
            Guid matriculaId)
        {
            AlunoId = alunoId;
            MatriculaId = matriculaId;
            TurmaId = turmaId;
        }
    }
}
