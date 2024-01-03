using CarWash.Repository.Repositories.Customers;
using CarWash.Repository.Repositories.Employees;
using CarWash.Repository.Repositories.Roles;
using CarWash.Repository.Repositories.Token;
using CarWash.Repository.Repositories.Users;
using CarWash.Service.Providers;
using CarWash.Service.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace CarWash.Service.ConfigureServices
{
    public static class ConfigureServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<JwtGenerator>();
            services.AddScoped<PasswordHasher>();
            services.AddScoped<IEmployeeRepository, EmployeRepository>();
            services.AddScoped<IAuthService, AuthService>();

           
        }
    }
}
