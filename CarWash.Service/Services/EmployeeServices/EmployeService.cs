using CarWash.Repository.Repositories.Employees;
using CarWash.Service.Services.Auth;
using Microsoft.Extensions.Logging;

namespace CarWash.Service.Services.EmployeeServices
{
    public class EmployeService : IEmployeeService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeService(ILogger<AuthService> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }


    }
}
