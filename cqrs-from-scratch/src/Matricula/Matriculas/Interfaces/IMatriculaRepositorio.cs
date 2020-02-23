using System;
using System.Threading.Tasks;

namespace Atendimento.Matriculas.Interfaces
{
    public interface IMatriculaRepositorio
    {
        Task Salvar(Matricula matricula);
        Task<Turma> ObterTurmaPorId(Guid turmaId);
        void AtualizarTurma(Turma turma);
    }
}
