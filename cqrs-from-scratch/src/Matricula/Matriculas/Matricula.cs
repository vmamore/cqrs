using Atendimento.Matriculas.Eventos;
using CQRS.Dominio;
using System;
using System.Collections.Generic;

namespace Atendimento.Matriculas
{
    public class Matricula : Agregado
    {
        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }

        public Matricula(Guid alunoId, Guid turmaId) : base(Guid.NewGuid())
        {
            AlunoId = alunoId;
            TurmaId = turmaId;

            AdicionarEvento(new MatriculaRealizadaComSucesso(
                alunoId,
                turmaId,
                this.Id.Value));
        }
    }
}
