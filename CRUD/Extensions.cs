using Repository.Repositories.CustomerRepo;
using Service.Servicees.CustomerService;

namespace CRUD
{
    public static class Extensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
