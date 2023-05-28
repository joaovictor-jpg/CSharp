using FirstCors.Model;
using FirstCors.Repository.Employee;
using FirstCors.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCors.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee =  employee ?? throw new ArgumentNullException(nameof(employee));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var emplyoee = await _employee.GeatAllAsync();
            return emplyoee == null ? NotFound() : Ok(emplyoee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
