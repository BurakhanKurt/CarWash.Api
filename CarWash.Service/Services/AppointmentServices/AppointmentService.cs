using CarWash.Core.Dtos;
using CarWash.Entity.Entities;
using CarWash.Repository.Repositories.AppointmentRepo;
using CarWash.Repository.UnitOfWork;
using CarWash.Service.Mapping;
using CarWash.Service.ServiceExtensions;
using CarWash.Service.Services.EmployeeServices;
using Microsoft.Extensions.Logging;

namespace CarWash.Service.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmployeeService _employeeService;

        public AppointmentService(IUnitOfWork unitOfWork, ILogger<AppointmentService> logger, IAppointmentRepository appointmentRepository, IEmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _appointmentRepository = appointmentRepository;
            _employeeService = employeeService;
        }

        //private async Task<bool> IsEmployeeAvailable(DateTime startDateTime, DateTime endDateTime)
        //{
        //    // Get workers with available time slots
        //    var availableWorkers = await _employeeService.GetAvailableWorkers(startDateTime, endDateTime);

        //    return availableWorkers.Any();
        //}

        //public async Task<Response<NoContent>> CreateAppointment(CreateAppointmentDto request)
        //{
        //    _logger.SendInformation(nameof(CreateAppointment), "Started");

        //    try
        //    {
        //        // Check employee availability
        //        if (!await IsEmployeeAvailable(request.AppointmentDate, request.AppointmentDate.AddMinutes(request.Duration)))
        //        {
        //            _logger.SendWarning(nameof(CreateAppointment), "Employee not available at the specified time");
        //            return Response<NoContent>.Fail("Employee not available at the specified time", 400);
        //        }

        //        var appointment = ObjectMapper.Mapper.Map<Appointment>(request);

        //        // Additional checks for employee availability can be added here if needed

        //        await _appointmentRepository.CreateAsync(appointment);
        //        await _unitOfWork.SaveChangesAsync();
        //        _logger.SendInformation(nameof(CreateAppointment), "Create successful");
        //        return Response<NoContent>.Success(201);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.SendWarning(nameof(CreateAppointment), ex.Message);
        //        return Response<NoContent>.Fail("Bilinmedik bir hata oluştu", 500);
        //    }
        //}

        //public async Task<Response<NoContent>> UpdateAppointment(UpdateAppointmentDto request)
        //{
        //    _logger.SendInformation(nameof(UpdateAppointment), "Started");
        //    try
        //    {
        //        var existingAppointment = await _appointmentRepository.GetByIdAsync(request.Id);

        //        if (existingAppointment == null)
        //        {
        //            _logger.SendWarning(nameof(UpdateAppointment), "Appointment not found");
        //            return Response<NoContent>.Fail("Appointment not found", 404);
        //        }

        //        ObjectMapper.Mapper.Map(request, existingAppointment);

        //        _appointmentRepository.Update(existingAppointment);
        //        await _unitOfWork.SaveChangesAsync();

        //        _logger.SendInformation(nameof(UpdateAppointment), "Update successful");
        //        return Response<NoContent>.Success(204);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.SendWarning(nameof(UpdateAppointment), ex.Message);
        //        return Response<NoContent>.Fail("Bilinmedik bir hata oluştu", 500);
        //    }
        //}

        //public async Task<Response<NoContent>> DeleteAppointment(int id)
        //{
        //    _logger.SendInformation(nameof(DeleteAppointment), "Started");
        //    try
        //    {
        //        var appointmentToDelete = await _appointmentRepository.GetByIdAsync(id);

        //        if (appointmentToDelete == null)
        //        {
        //            _logger.SendWarning(nameof(DeleteAppointment), "Appointment not found");
        //            return Response<NoContent>.Fail("Appointment not found", 404);
        //        }

        //        _appointmentRepository.Delete(appointmentToDelete);
        //        await _unitOfWork.SaveChangesAsync();

        //        _logger.SendInformation(nameof(DeleteAppointment), "Delete successful");
        //        return Response<NoContent>.Success(204);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.SendWarning(nameof(DeleteAppointment), ex.Message);
        //        return Response<NoContent>.Fail("Bilinmedik bir hata oluştu", 500);
        //    }
        //}

        //public async Task<Response<List<AppointmentDto>>> GetAppointments()
        //{
        //    _logger.SendInformation(nameof(GetAppointments), "Started");
        //    try
        //    {
        //        var appointments = await _appointmentRepository.GetAllAsync();
        //        var appointmentDtos = ObjectMapper.Mapper.Map<List<AppointmentDto>>(appointments);

        //        _logger.SendInformation(nameof(GetAppointments), "Retrieve successful");
        //        return Response<List<AppointmentDto>>.Success(appointmentDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.SendWarning(nameof(GetAppointments), ex.Message);
        //        return Response<List<AppointmentDto>>.Fail("Bilinmedik bir hata oluştu", 500);
        //    }
        //}
    }
}
