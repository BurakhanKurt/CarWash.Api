using CarWash.Core.Dtos;
using CarWash.Entity.Dtos.Employee;
using CarWash.Entity.Entities;
using CarWash.Repository.Repositories.EmployeeAttendances;
using CarWash.Repository.Repositories.Employees;
using CarWash.Service.Mapping;
using CarWash.Service.ServiceExtensions;
using CarWash.Service.Services.Auth;
using Microsoft.Extensions.Logging;

namespace CarWash.Service.Services.EmployeeServices
{
    public class EmployeService : IEmployeeService
    {
        private readonly ILogger<EmployeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;
        public EmployeService(ILogger<EmployeService> logger, IEmployeeRepository employeeRepository, IEmployeeAttendanceRepository employeeAttendanceRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _employeeAttendanceRepository = employeeAttendanceRepository;
        }

        public async Task<Response<NoContent>> CreateEmployeeAttendance(CreateEmployeeAttandaceDto request)
        {
            _logger.SendInformation(nameof(CreateEmployeeAttendance), "Started");
            try
            {
                var isAvailable = await _employeeRepository.AnyAsync(e => e.Id == request.EmployeeId);
                if (isAvailable == false)
                {
                    _logger.SendWarning("Employee not found",nameof(CreateEmployeeAttendance));
                    return Response<NoContent>.Fail("Çalışan bulunamadı!", 400);
                }
                var empAttendance = ObjectMapper.Mapper.Map<EmployeeAttendance>(request);

                await _employeeAttendanceRepository.CreateAsync(empAttendance);
                await _employeeAttendanceRepository.SaveChangesAsync();

                _logger.SendInformation(nameof(CreateEmployeeAttendance), "Create successful");
                return Response<NoContent>.Success(204);
            }
            catch (Exception ex)
            {
                _logger.SendWarning(nameof(CreateEmployeeAttendance), ex.Message);
                return Response<NoContent>.Fail("Bilinmedik bir hata oluştu", 500);
            }
        }



    }
}
