using FirstCors.Domain.DTOs;
using FirstCors.Domain.Model;
using FirstCors.Infrestutura.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstCors.Infrestutura.Repository.Employee
{
    public class EmployeeRepository : IEmployee
    {
        private readonly CorsContext _corsContext;

        public EmployeeRepository(CorsContext corsContext)
        {
            _corsContext = corsContext;
        }
        public async Task<List<EmployeeDTO>> GeatAllAsync(int pageNumber, int pageQuantity)
        {
            return await _corsContext.employee
                .AsNoTracking()
                .Skip(pageNumber)
                .Take(pageQuantity)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Photo = e.Photo
                })
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
