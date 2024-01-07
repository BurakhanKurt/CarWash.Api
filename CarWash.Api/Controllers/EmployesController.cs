using CarWash.Api.Controllers.BaseController;
using CarWash.Entity.Dtos.Auth;
using CarWash.Entity.Dtos.Employee;
using CarWash.Service.Services.EmployeeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : CustomControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("createEmpAttendance")]
        public async Task<IActionResult> CustLogin([FromBody] CreateEmployeeAttandaceDto request)
        {
            var response = await _employeeService.CreateEmployeeAttendance(request);
            return CreateActionResultInstance(response);
        }
    }
}
