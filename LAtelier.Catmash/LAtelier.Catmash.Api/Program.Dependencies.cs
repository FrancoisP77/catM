using LAtelier.Catmash.Api.ExceptionFilters;
using LAtelier.Catmash.Infrastructure;
using LAtelier.Catmash.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LAtelier.Catmash.Api
{
    public static partial class Program
    {
        /// <summary>
        /// This is just for the purpose of the poc.
        /// We may want to use a persistant db system and store the actual connection string in a config file or aby other kind of storage.
        /// </summary>
        private static readonly string _dbName = "catmash";

        public static IServiceCollection ConfigureAllServices(this IServiceCollection services)
        {
            return services
                .ConfigureAllDependencies()
                .ConfigureCors()
                .ConfigureFilterExceptions()
                .AddOpenApiDocument();
        }

        private static IServiceCollection ConfigureAllDependencies(this IServiceCollection services)
        {
            /* We're using an in memory db here for the purpose of this example.
               All data will be wiped out upon application recycle.
               We keep the initial setup as lightweight as possible so anyone can run this project easly.
            */
            services.AddDbContext<CatmashDbContext>(o => o.UseInMemoryDatabase(_dbName));

            services.AddScoped<ICatsRepository, CatsRepository>();

            return services;
        }

        private static IServiceCollection ConfigureFilterExceptions(this IServiceCollection services)
        {
			services.AddMvc(options =>
			{
				options.Filters.Add(new GlobalExceptionFilter());
			});

            return services;
		}

        private static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                /* This is just for the purpose of this exercice. We may want to be more specific here. */
                options.AddPolicy(name: "AllOriginsAllowed",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                  });
            });

            return services;
        }
    }
}
