using CarWash.Core.Dtos;
using CarWash.Entity.Dtos.Appointment;

namespace CarWash.Service.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<Response<NoContent>> CreateAppointment(CreateAppointmentDto request);
    }
}
