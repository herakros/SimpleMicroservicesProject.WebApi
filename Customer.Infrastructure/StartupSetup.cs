using CustomerMicroservice.Contracts.Data;
using CustomerMicroservice.Infrastructure.Data;
using CustomerMicroservice.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerMicroservice.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CustomerDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
