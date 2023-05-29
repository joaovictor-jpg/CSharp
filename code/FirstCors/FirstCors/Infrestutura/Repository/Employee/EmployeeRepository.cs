using AutoMapper;
using FirstCors.Domain.DTOs;
using FirstCors.Domain.Model;
using FirstCors.Infrestutura.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstCors.Infrestutura.Repository.Employee
{
    public class EmployeeRepository : IEmployee
    {
        private readonly CorsContext _corsContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(CorsContext corsContext, IMapper mapper)
        {
            _corsContext = corsContext;
            _mapper = mapper;
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
                    NameEmployee = e.Name,
                    Photo = e.Photo
                })
                .ToListAsync();
        }

        public async Task<EmployeeDTO?> GetByIdAsync(int id)
        {
            var employee = await _corsContext.employee.Where(x => x.Id == id).FirstOrDefaultAsync();

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;
        }

        public async Task AddAsync(EmployeeModel model)
        {
            await _corsContext.employee.AddAsync(model);
            await _corsContext.SaveChangesAsync();
        }
    }
}
