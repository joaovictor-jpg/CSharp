using AutoMapper;
using IntegraBrasil.DTOs;
using IntegraBrasil.Model;

namespace IntegraBrasil.Mapper
{
    public class BancoMapping : Profile
    {
        public BancoMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<BancoResponse, BancoModel>();
            CreateMap<BancoModel, BancoResponse>();
        }
    }
}
