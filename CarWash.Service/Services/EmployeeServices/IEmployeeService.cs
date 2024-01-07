using CarWash.Core.Dtos;
using CarWash.Entity.Dtos.Employee;

namespace CarWash.Service.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<Response<NoContent>> CreateEmployeeAttendance(CreateEmployeeAttandaceDto request);
    }
}
