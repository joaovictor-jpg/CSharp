using FirstCors.Model;

namespace FirstCors.Repository.Employee
{
    public interface IEmployee
    {
        Task<List<EmployeeModel>> GeatAllAsync(int pageNumber, int pageQuantity);
        Task AddAsync(EmployeeModel model);
        Task<EmployeeModel?> GetByIdAsync(int id);
    }
}
