using Administrativo.Pessoas.Interfaces;
using Atendimento.Matriculas.Interfaces;
using Infra.Dados.Queries.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Dados.Queries
{
    public static class RegistroDependenciasQueries
    {
        public static IServiceCollection RegistrarDependenciasDeQueries(this IServiceCollection services)
        {
            services.AddScoped<IMatriculaLeituraRepositorio, MatriculaLeituraRepositorio>();
            services.AddScoped<IPessoaFisicaLeituraRepositorio, PessoaFisicaLeituraRepositorio>();

            return services;
        }
    }
}
