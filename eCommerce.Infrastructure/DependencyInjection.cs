using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register infrastructure services here
            // e.g., services.AddScoped<IMyService, MyService>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddTransient<DapperDbContext>();
            
            return services;
        }
    }
}
