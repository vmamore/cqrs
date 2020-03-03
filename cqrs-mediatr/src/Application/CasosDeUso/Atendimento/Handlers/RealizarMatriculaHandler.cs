using Administrativo.Pessoas.Interfaces;
using Atendimento.Matriculas.Interfaces;
using CQRS.Dominio;
using Dados;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Commands
{
    public class RealizarMatriculaHandler : IRequestHandler<RealizarMatricula, Resultado>
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

        public async Task<Resultado> Handle(RealizarMatricula request, CancellationToken cancellationToken)
        {
            var aluno = await _pessoaFisicaRepositorio.ObterPorId(request.AlunoId);

            if (aluno == null)
                return Resultado.Erro("Aluno não encontrado.");

            var turma = await _matriculaRepositorio.ObterTurmaPorId(request.TurmaId);

            if (turma == null)
                return Resultado.Erro("Turma não encontrada.");

            var matricula = _matriculaFactory.Criar(
                request.AlunoId,
                request.TurmaId);

            await _matriculaRepositorio.Salvar(matricula);

            await _uow.Salvar();

            return Resultado.OK();
        }
    }
}
