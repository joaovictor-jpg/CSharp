using System.ComponentModel.DataAnnotations;

namespace FirstCors.Application.ViewModel
{
    public class EmployeeView
    {
        [Required(ErrorMessage = "Name is Mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Mandatory")]
        public int Age { get; set; }
        public IFormFile Photo { get; set; }
    }
}
