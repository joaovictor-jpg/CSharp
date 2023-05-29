using AutoMapper;
using FirstCors.Domain.DTOs;
using FirstCors.Domain.Model;

namespace FirstCors.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<EmployeeModel, EmployeeDTO>().ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig =>  orig.Name));
        }
    }
}
