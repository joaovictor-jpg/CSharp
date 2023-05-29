using FirstCors.Domain.DTOs;
using FirstCors.Domain.Model;

namespace FirstCors.Infrestutura.Repository.Employee
{
    public interface IEmployee
    {
        Task<List<EmployeeDTO>> GeatAllAsync(int pageNumber, int pageQuantity);
        Task AddAsync(EmployeeModel model);
        Task<EmployeeModel?> GetByIdAsync(int id);
    }
}
