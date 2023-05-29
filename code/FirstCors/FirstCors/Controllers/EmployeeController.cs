using FirstCors.Application.ViewModel;
using FirstCors.Domain.Model;
using FirstCors.Infrestutura.Repository.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCors.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployee employee, ILogger<EmployeeController> logger)
        {
            _employee =  employee ?? throw new ArgumentNullException(nameof(employee));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{pageNumber}/{pageQuantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync([FromRoute]int pageNumber = 0, [FromRoute] int pageQuantity = 5)
        {
            _logger.Log(LogLevel.Error, "Teve um erro");

            // throw new Exception("teste");

            var emplyoee = await _employee.GeatAllAsync(pageNumber,pageQuantity);

            _logger.LogInformation("Teste");

            return emplyoee == null ? NotFound() : Ok(emplyoee);
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchAsync([FromRoute] int id)
        {
            var employeeDTO = await _employee.GetByIdAsync(id);

            if (employeeDTO == null) return NotFound();

            return Ok(employeeDTO);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromForm] EmployeeView employeeView)
        {
            if (!ModelState.IsValid) return BadRequest();

            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new EmployeeModel(employeeView.Name, employeeView.Age, filePath);
            await _employee.AddAsync(employee);
            return Created("https://localhost:7181/api/v1/Employee", new
            {
                success = true,
                name = employeeView.Name
            });
        }

        [HttpPost("/download/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DownloadPhoto([FromRoute] int id)
        {
            var employee = await _employee.GetByIdAsync(id);

            if(employee == null) return NotFound("Employee not found");

            if (employee.Photo == null) return NotFound("employee does not have a photo");

            var dataBase = await System.IO.File.ReadAllBytesAsync(employee.Photo);

            return File(dataBase, "image/jpeg");
        }
    }
}
