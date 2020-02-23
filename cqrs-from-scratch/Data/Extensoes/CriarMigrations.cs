using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Dados.Extensoes
{
    public static class CriarMigrations
    {
        public static void EnsureMigrations<T>(this IApplicationBuilder app) where T : Context
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<T>();
                context.Database.EnsureCreated();
            }
        }
    }
}
