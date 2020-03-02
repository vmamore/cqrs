using Atendimento.Matriculas;
using Atendimento.Matriculas.Interfaces;
using System;

namespace Dados.Factories
{
    public class MatriculaFactory : IMatriculaFactory
    {
        public Matricula Criar(Guid alunoId, Guid turmaId)
        {
            return new Matricula(alunoId, turmaId);
        }
    }
}
