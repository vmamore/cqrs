using Application.CasosDeUso.Atendimento.Commands;
using CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Input.Atendimento;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public MatriculaController(
            ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Matricular(MatriculaDto dto)
        {
            var resultado = await _commandDispatcher.ExecuteAsync(
                new RealizarMatricula(
                    dto.AlunoId,
                    dto.TurmaId));

            if (resultado.Falhou)
            {
                return UnprocessableEntity(resultado);
            }

            return Created("", resultado);
        }
    }
}
