using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validatiors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // Register core services here
            // e.g., services.AddScoped<IMyCoreService, MyCoreService>();

            services.AddScoped<IUserService, UserService>();

            //FluentValidation
            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();

            return services;
        }
    }
}
