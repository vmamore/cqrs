using Atendimento.Matriculas;
using Atendimento.Matriculas.Interfaces;
using System;

namespace Infra.Dados.SqlStorage
{
    public class MatriculaFactory : IMatriculaFactory
    {
        public Matricula Criar(Guid alunoId, Guid turmaId)
        {
            return new Matricula(alunoId, turmaId);
        }
    }
}
