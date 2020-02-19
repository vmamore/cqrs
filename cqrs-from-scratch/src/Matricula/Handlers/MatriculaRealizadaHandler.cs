using Core.Commands;
using Matricula.Comandos;
using System;
using System.Threading.Tasks;

namespace Matricula.Handlers
{
    public class MatriculaRealizadaHandler : ICommandHandler<MatriculaRealizada>
    {
        public Task<bool> ExecuteAsync(MatriculaRealizada command)
        {
            throw new NotImplementedException();
        }
    }
}
