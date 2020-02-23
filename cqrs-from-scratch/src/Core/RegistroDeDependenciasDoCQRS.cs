using CQRS.Commands;
using CQRS.Events;
using CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS
{
    public static class RegistroDeDependenciasDoCQRS
    {
        public static IServiceCollection RegistrarDependenciasDoCQRS(this IServiceCollection services)
        {
            services.AddSingleton<DependencyResolver>();

            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddSingleton<IQueryProcessor, QueryProcessor>();
            services.AddSingleton<IEventPublisher, EventPublisher>();

            return services;
        }
    }
}
