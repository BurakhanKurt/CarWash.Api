using CarWash.Api.Controllers.BaseController;
using CarWash.Entity.Dtos.Appointment;
using CarWash.Entity.Dtos.Employee;
using CarWash.Service.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmetsController : CustomControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmetsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("createEmpAttendance")]
        public async Task<IActionResult> CustLogin([FromBody] CreateAppointmentDto request)
        {
            var response = await _appointmentService.CreateAppointment(request);
            return CreateActionResultInstance(response);
        }

        [HttpGet("getByCustId")]
        public async Task<IActionResult> GetByCustId([FromQuery] int custId)
        {
            var response = await _appointmentService.GetAppointmentsByCustId(custId);
            return CreateActionResultInstance(response);
        }
    }
}
