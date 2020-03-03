using Application.CasosDeUso.Atendimento.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Input.Atendimento;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatriculaController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Matricular(MatriculaDto dto)
        {
            var resultado = await _mediator.Send(
                new RealizarMatricula(
                    dto.AlunoId,
                    dto.TurmaId));

            if (resultado.Falhou)
            {
                return UnprocessableEntity(resultado);
            }

            return Created("", resultado);
        }

        [HttpGet]
        [Route("obter-alunos-e-turmas")]
        public async Task<IActionResult> GetMatriculas()
        {
            var turmasEAlunosQuery = new TurmasEAlunosQuery();

            var resultado = await
                _mediator.Send(turmasEAlunosQuery);

            return Ok(resultado);
        }
    }
}
