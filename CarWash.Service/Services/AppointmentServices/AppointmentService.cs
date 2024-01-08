using CarWash.Core.Dtos;
using CarWash.Entity.Dtos.Appointment;
using CarWash.Entity.Entities;
using CarWash.Entity.Enums;
using CarWash.Repository.Repositories.AppointmentRepo;
using CarWash.Repository.Repositories.Employees;
using CarWash.Repository.Repositories.EwpRepo;
using CarWash.Repository.Repositories.WashPackages;
using CarWash.Repository.UnitOfWork;
using CarWash.Service.Mapping;
using CarWash.Service.ServiceExtensions;
using CarWash.Service.Services.EmployeeServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace CarWash.Service.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWashPackageRepository _workPackageRepository;
        private readonly IEwbRepo _ewbRepo;

        public AppointmentService(IUnitOfWork unitOfWork, ILogger<AppointmentService> logger, IAppointmentRepository appointmentRepository, IEmployeeRepository employeeRepository, IWashPackageRepository workPackageRepository, IEwbRepo ewbRepo)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _appointmentRepository = appointmentRepository;
            _employeeRepository = employeeRepository;
            _workPackageRepository = workPackageRepository;
            _ewbRepo = ewbRepo;
        }



        public async Task<Response<NoContent>> CreateAppointment(CreateAppointmentDto request)
        {
            _logger.SendInformation(nameof(CreateAppointment), "Started");

            try
            {
                var package = await _workPackageRepository.FindByCondition(p => p.Id == request.PackageId, true).FirstOrDefaultAsync();
                var duration = request.AppointmentDate.AddMinutes(package.Duration);
                var availableWorkers = await _employeeRepository.GetWorkersWithAvailableTimeSlots(request.AppointmentDate, duration);

                // Check employee availability
                if (!availableWorkers.Any())
                {
                    _logger.SendWarning(nameof(CreateAppointment), "Employee not available at the specified time");
                    return Response<NoContent>.Fail("Employee not available at the specified time", 400);
                }
                var empId = 0;
                // Check for overlapping wash processes
                foreach (var worker in availableWorkers)
                {

                    var emp = await _appointmentRepository.FindAll()
                        .Include(a => a.WashProcess)
                        .ThenInclude(a => a.Employees)
                        .Include(a => a.WashPackage)
                        .Where(wp => wp.WashProcess.CarWashStatus != CarWashStatus.Completed &&
                        (request.AppointmentDate < wp.AppointmentDate.AddMinutes(wp.WashPackage.Duration) &&
                            duration > wp.WashProcess.Appointment.AppointmentDate)).Select(a=> a.WashProcess.Employees.Select(a=> a.Employee).FirstOrDefault())
                            .Where(a=> a.UserId == worker.UserId)
                            .FirstOrDefaultAsync();

                    
                    if (emp is null)
                    {
                        empId = worker.UserId;
                        break;

                    }
                }

                if(empId == 0)
                {
                    _logger.SendWarning(nameof(CreateAppointment), "Appointment overlaps with existing wash process");
                    return Response<NoContent>.Fail("Appointment overlaps with existing wash process", 400);
                }

                var appointment = ObjectMapper.Mapper.Map<Appointment>(request);
                appointment.WashProcess = new WashProcess()
                {
                    CarWashStatus = CarWashStatus.Waiting,
                    WashPackageId = package.Id,
                };

                // Additional checks for employee availability can be added here if needed

                await _appointmentRepository.CreateAsync(appointment);
                var varable = new EmployeeWashProcess()
                {
                    EmployeeId = empId,
                    WashProcess = appointment.WashProcess 
                };

                await _ewbRepo.CreateAsync(varable);
                await _unitOfWork.SaveChangesAsync();
                _logger.SendInformation(nameof(CreateAppointment), "Create successful");
                return Response<NoContent>.Success(201);
            }
            catch (Exception ex)
            {
                _logger.SendWarning(nameof(CreateAppointment), ex.Message);
                return Response<NoContent>.Fail(ex.Message, 500);
            }
        }

        public async Task<Response<NoContent>> DeleteAppointment(int id)
        {
            _logger.SendInformation(nameof(DeleteAppointment), "Started");
            try
            {
                var appointmentToDelete = await _appointmentRepository.GetByIdAsync(id);

                if (appointmentToDelete == null)
                {
                    _logger.SendWarning(nameof(DeleteAppointment), "Appointment not found");
                    return Response<NoContent>.Fail("Appointment not found", 404);
                }

                _appointmentRepository.Delete(appointmentToDelete);
                await _unitOfWork.SaveChangesAsync();

                _logger.SendInformation(nameof(DeleteAppointment), "Delete successful");
                return Response<NoContent>.Success(204);
            }
            catch (Exception ex)
            {
                _logger.SendWarning(nameof(DeleteAppointment), ex.Message);
                return Response<NoContent>.Fail("Bilinmedik bir hata oluştu", 500);
            }
        }

        public async Task<Response<List<AppointmentDto>>> GetAppointments()
        {
            _logger.SendInformation(nameof(GetAppointments), "Started");
            try
            {
                var appointments = await _appointmentRepository.GetAllAsync();
                var appointmentDtos = ObjectMapper.Mapper.Map<List<AppointmentDto>>(appointments);

                _logger.SendInformation(nameof(GetAppointments), "Retrieve successful");
                return Response<List<AppointmentDto>>.Success(appointmentDtos);
            }
            catch (Exception ex)
            {
                _logger.SendWarning(nameof(GetAppointments), ex.Message);
                return Response<List<AppointmentDto>>.Fail("Bilinmedik bir hata oluştu", 500);
            }
        }
    }
}
