using Administrativo.Pessoas.Interfaces;
using Atendimento.Matriculas.Interfaces;
using Dados.Factories;
using Dados.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Dados
{
    public static class RegistroDeDepenciasInfra
    {
        public static IServiceCollection RegistrarDependenciasDeDados(this IServiceCollection services)
        {
            services.AddSingleton<IPessoaFisicaRepositorio, PessoaFisicaRepositorio>();
            services.AddSingleton<IMatriculaRepositorio, MatriculaRepositorio>();
            services.AddSingleton<IPessoaFisicaFactory, PessoaFisicaFactory>();
            services.AddSingleton<IMatriculaFactory, MatriculaFactory>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
