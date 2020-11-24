using Foosball.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.Extensions
{
    public static class RepositoryServiceExtention
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
        }
    }
}
