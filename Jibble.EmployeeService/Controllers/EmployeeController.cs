using Jibble.EmployeeService.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Jibble.EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IFileService fileService, IEmployeeService employeeService)
        {
            _fileService = fileService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var stream = file.OpenReadStream();
            var employeeRequests = _fileService.ReadEmployeeCsv(stream);
            await _employeeService.IntersectEmployeeFromSource(employeeRequests);
            return Ok();
        }
    }
}
