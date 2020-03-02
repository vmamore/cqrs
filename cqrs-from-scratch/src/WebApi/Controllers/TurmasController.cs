using Application.CasosDeUso.Atendimento.Commands;
using CQRS.Queries;
using Dados.Queries.Atendimento.ModeloDeLeitura;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

        public TurmasController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet("turmas-com-alunos")]
        public async Task<IActionResult> ObterAlunosComTurma()
        {
            var queryParameter = new TurmasEAlunosQuery();

            var resultado = await _queryProcessor.ExecuteQueryAsync<TurmasEAlunosQuery, IEnumerable<AlunosPorTurmaListItem>>(queryParameter);

            return Ok(resultado);
        }
    }
}
