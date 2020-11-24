using Foosball.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.Extensions
{
    public static class LiteDbServiceExtention
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddSingleton<LiteDbContext, LiteDbContext>();
            services.Configure<LiteDbConfig>(options => options.Path = databasePath);
        }
    }
}
