using FirstCors.Model;

namespace FirstCors.Repository.Employee
{
    public interface IEmployee
    {
        Task<List<EmployeeModel>> GeatAllAsync();

        Task AddAsync(EmployeeModel model);
    }
}
