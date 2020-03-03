using System;

namespace Atendimento.Matriculas.Interfaces
{
    public interface IMatriculaFactory
    {
        Matricula Criar(Guid alunoId, Guid turmaId);
    }
}
