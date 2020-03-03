using System.Threading.Tasks;

namespace Atendimento.Matriculas.Interfaces
{
    public interface IMatriculaEscritaRepositorio
    {
        Task Salvar(Matricula matricula);
        void AtualizarTurma(Turma turma);
    }
}
