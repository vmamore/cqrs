using System;

namespace WebApi.Input.Atendimento
{
    public class MatriculaDto
    {
        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }
    }
}
