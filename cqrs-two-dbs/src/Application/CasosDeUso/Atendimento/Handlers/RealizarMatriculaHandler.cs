using Administrativo.Pessoas.Interfaces;
using Atendimento.Matriculas.Interfaces;
using CQRS;
using CQRS.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Atendimento.Commands
{
    public class RealizarMatriculaHandler : ICommandHandler<RealizarMatricula>
    {
        private readonly IPessoaFisicaLeituraRepositorio _pessoaFisicaRepositorio;
        private readonly IMatriculaEscritaRepositorio _matriculaEscritaRepositorio;
        private readonly IMatriculaLeituraRepositorio _matriculaLeituraRepositorio;
        private readonly IMatriculaFactory _matriculaFactory;

        public RealizarMatriculaHandler(
            IPessoaFisicaLeituraRepositorio pessoaFisicaRepositorio,
            IMatriculaEscritaRepositorio matriculaEscritaRepositorio,
            IMatriculaLeituraRepositorio matriculaLeituraRepositorio,
            IMatriculaFactory matriculaFactory)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
            _matriculaEscritaRepositorio = matriculaEscritaRepositorio;
            _matriculaLeituraRepositorio = matriculaLeituraRepositorio;
            _matriculaFactory = matriculaFactory;
        }

        public async Task<Resultado> Handle(RealizarMatricula request, CancellationToken cancellationToken)
        {
            var aluno = await _pessoaFisicaRepositorio.ObterPorId(request.AlunoId);

            if (aluno == null)
                return Resultado.Erro("Aluno não encontrado.");

            var turma = await _matriculaLeituraRepositorio.ObterTurmaPorId(request.TurmaId);

            if (turma == null)
                return Resultado.Erro("Turma não encontrada.");

            var matricula = _matriculaFactory.Criar(
                request.AlunoId,
                request.TurmaId);

            await _matriculaEscritaRepositorio.Salvar(matricula);

            return Resultado.OK();
        }
    }
}
