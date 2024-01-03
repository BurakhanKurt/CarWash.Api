using CarWash.Repository.Repositories.Customers;
using CarWash.Repository.Repositories.Employees;
using CarWash.Repository.Repositories.Roles;
using CarWash.Repository.Repositories.Token;
using CarWash.Repository.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace CarWash.Repository.ConfigureRepositories
{
    public static class ConfigureRepositoryExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
        }
    }
}