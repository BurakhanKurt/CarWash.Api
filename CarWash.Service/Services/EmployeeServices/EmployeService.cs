using CarWash.Core.Dtos;
using CarWash.Entity.Dtos.Employee;
using CarWash.Entity.Entities;
using CarWash.Entity.Enums;
using CarWash.Repository.Repositories.EmployeeAttendances;
using CarWash.Repository.Repositories.Employees;
using CarWash.Repository.UnitOfWork;
using CarWash.Service.Mapping;
using CarWash.Service.ServiceExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarWash.Service.Services.EmployeeServices
{
    public class EmployeService : IEmployeeService
    {
        private readonly ILogger<EmployeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeService(ILogger<EmployeService> logger, IEmployeeRepository employeeRepository, IEmployeeAttendanceRepository employeeAttendanceRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _employeeAttendanceRepository = employeeAttendanceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<NoContent>> UpdateEmployeeAttendance(CreateEmployeeAttandaceDto request)
        {
            _logger.SendInformation(nameof(UpdateEmployeeAttendance), "Started");
            try
            {
                var isAvailable = await _employeeRepository.AnyAsync(e => e.UserId == request.EmployeeId);
                if (isAvailable == false)
                {
                    _logger.SendWarning("Employee not found",nameof(UpdateEmployeeAttendance));
                    return Response<NoContent>.Fail("Çalışan bulunamadı!", 400);
                }

                var updatedAttendance = await _employeeAttendanceRepository.FindByCondition(ea=> ea.EmployeeId == request.EmployeeId).FirstOrDefaultAsync();
                updatedAttendance = ObjectMapper.Mapper.Map(request,updatedAttendance);

                _employeeAttendanceRepository.Update(updatedAttendance);
                await _unitOfWork.SaveChangesAsync();

                _logger.SendInformation(nameof(UpdateEmployeeAttendance), "Update successful");
                return Response<NoContent>.Success(204);
            }
            catch (Exception ex)
            {
                _logger.SendWarning(nameof(UpdateEmployeeAttendance), ex.Message);
                return Response<NoContent>.Fail("Bilinmedik bir hata oluştu", 500);
            }
        }

        public async Task<Response<IEnumerable<EmployeeListDto>>> GetAllEmployee()
        {
            var employees = await _employeeRepository
                .FindAll()
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.EmployeeAttendance)
                .ToListAsync();

            var employeesDto = ObjectMapper.Mapper.Map<List<EmployeeListDto>>(employees);
            
            return Response<IEnumerable<EmployeeListDto>>.Success(employeesDto,200);
        }
        //public async Task<List<EmployeeDto>> GetAvailableWorkers(DateTime startDateTime, DateTime endDateTime)
        //{
        //    _logger.SendInformation(nameof(GetAvailableWorkers), "Started");
        //    try
        //    {
        //        var availableWorkers = await _employeeRepository
        //            .FindByCondition(e => e.RoleId == EmployeeRoles.Worker)
        //            .Include(e => e.EmployeeAttendance)
        //            .Where(e => e.EmployeeAttendance.All(ea => !IsTimeOverlap(startDateTime, endDateTime, ea.StartTime, ea.EndTime)))
        //            .Select(e => ObjectMapper.Mapper.Map<EmployeeDto>(e))
        //            .ToListAsync();

        //        _logger.SendInformation(nameof(GetAvailableWorkers), "Retrieve successful");
        //        return availableWorkers;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.SendWarning(nameof(GetAvailableWorkers), ex.Message);
        //        // Handle the exception according to your application's needs
        //        return new List<EmployeeDto>();
        //    }
        //}

        //private bool IsTimeOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        //{
        //    return start1 < end2 && end1 > start2;
        //}

    }
}
