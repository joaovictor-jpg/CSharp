using FirstCors.Data;
using FirstCors.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstCors.Repository.Employee
{
    public class EmployeeRepository : IEmployee
    {
        private readonly CorsContext _corsContext;

        public EmployeeRepository(CorsContext corsContext)
        {
            _corsContext = corsContext;
        }
        public async Task<List<EmployeeModel>> GeatAllAsync()
        {
            return await _corsContext.employee
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EmployeeModel?> GetByIdAsync(int id)
        {
            return await _corsContext.employee.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(EmployeeModel model)
        {
            await _corsContext.employee.AddAsync(model);
            await _corsContext.SaveChangesAsync();
        }
    }
}
