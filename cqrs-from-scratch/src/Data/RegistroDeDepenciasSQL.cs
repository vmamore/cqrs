using Administrativo.Pessoas.Interfaces;
using Dados.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Dados
{
    public static class RegistroDeDepenciasSQL
    {
        public static IServiceCollection RegistrarDependenciasDoSQLServer(this IServiceCollection services)
        {
            services.AddScoped<IPessoaFisicaEscritaRepositorio, PessoaFisicaRepositorio>();
            services.AddScoped<IPessoaFisicaLeituraRepositorio, PessoaFisicaRepositorio>();

            return services;
        }
    }
}
