using CustomerMicroservice.Contracts.Services;
using CustomerMicroservice.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerMicroservice.Core
{
    public static class StartupSetup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
