using Application.CasosDeUso.Atendimento.Commands;
using CQRS.Commands;
using CQRS.Queries;
using Dados.Queries.Matriculas.Consultas;
using Dados.Queries.Matriculas.ModeloDeLeitura;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Input.Atendimento;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;

        public MatriculaController(
            IQueryProcessor queryProcessor,
            ICommandDispatcher commandDispatcher)
        {
            _queryProcessor = queryProcessor;
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

        [HttpGet]
        [Route("obter-todas")]
        public async Task<IActionResult> GetMatriculas()
        {
            var matriculaQuery = new MatriculaQuery();

            var resultado = await
                _queryProcessor.ExecuteQueryAsync<MatriculaQuery, IEnumerable<MatriculaListItem>>(matriculaQuery);

            return Ok(resultado);
        }
    }
}
