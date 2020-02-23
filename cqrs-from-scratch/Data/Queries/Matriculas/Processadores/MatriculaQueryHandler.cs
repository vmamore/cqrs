using CQRS.Queries;
using Dados.Queries.Matriculas.Consultas;
using Dados.Queries.Matriculas.ModeloDeLeitura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dados.Queries.Matriculas.Processadores
{
    public class MatriculaQueryHandler : IQueryHandler<MatriculaQuery, IEnumerable<MatriculaListItem>>
    {
        public Task<IEnumerable<MatriculaListItem>> ExecuteQueryAsync(MatriculaQuery queryParameters)
        {
            throw new NotImplementedException();
        }
    }
}
