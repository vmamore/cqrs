using Administrativo.Pessoas.Interfaces;
using Application.Servicos;
using Atendimento.Matriculas.Interfaces;
using CQRS.Commands;
using CQRS.Dominio;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Commands
{
    public class RealizarMatriculaHandler : ICommandHandler<RealizarMatricula>
    {
        private readonly IPessoaFisicaRepositorio _pessoaFisicaRepositorio;
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IMatriculaFactory _matriculaFactory;
        private readonly IUnitOfWork _uow;

        public RealizarMatriculaHandler(
            IPessoaFisicaRepositorio pessoaFisicaRepositorio,
            IMatriculaRepositorio matriculaRepositorio,
            IMatriculaFactory matriculaFactory,
            IUnitOfWork uow)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
            _matriculaRepositorio = matriculaRepositorio;
            _matriculaFactory = matriculaFactory;
            _uow = uow;
        }

        public async Task<Resultado> ExecuteAsync(RealizarMatricula command)
        {
            var aluno = await _pessoaFisicaRepositorio.ObterPorId(command.AlunoId);

            if (aluno == null)
                return Resultado.Erro("Aluno não encontrado.");

            var turma = await _matriculaRepositorio.ObterTurmaPorId(command.TurmaId);

            if (turma == null)
                return Resultado.Erro("Turma não encontrada.");

            var matricula = _matriculaFactory.Criar(
                command.AlunoId,
                command.TurmaId);

            await _matriculaRepositorio.Salvar(matricula);

            await _uow.Salvar();

            return Resultado.OK();
        }
    }
}
