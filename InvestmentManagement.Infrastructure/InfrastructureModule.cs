using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Infrastructure.Contexts;
using InvestmentManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentManagement.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInvestmentAccountRepository, InvestmentAccountRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();

            return services;
        }
    }
}
