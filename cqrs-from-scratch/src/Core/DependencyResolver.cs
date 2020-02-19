using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Core
{
    public class DependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public DependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TDependencyType Resolve<TDependencyType>()
        {
            return _serviceProvider.GetRequiredService<TDependencyType>();
        }

        public IEnumerable<TDependencyType> ResolveAll<TDependencyType>()
        {
            return _serviceProvider.GetServices<TDependencyType>();
        }
    }
}
