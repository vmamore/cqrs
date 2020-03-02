using CQRS.Dominio;
using MediatR;
using System;

namespace Application.CasosDeUso.Atendimento.Commands
{
    public class RealizarMatricula : IRequest<Resultado>
    {
        public Guid AlunoId { get; }
        public Guid TurmaId { get; }

        public RealizarMatricula(
            Guid alunoId,
            Guid turmaId)
        {
            AlunoId = alunoId;
            TurmaId = turmaId;
        }
    }
}
