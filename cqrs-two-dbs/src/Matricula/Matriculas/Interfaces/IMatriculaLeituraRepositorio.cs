using System;
using System.Threading.Tasks;

namespace Atendimento.Matriculas.Interfaces
{
    public interface IMatriculaLeituraRepositorio
    {
        Task<Turma> ObterTurmaPorId(Guid turmaId);
    }
}
