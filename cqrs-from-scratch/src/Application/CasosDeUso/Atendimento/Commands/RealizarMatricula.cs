using System;

namespace Application.CasosDeUso.Atendimento.Commands
{
    public class RealizarMatricula
    {
        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }
    }
}
