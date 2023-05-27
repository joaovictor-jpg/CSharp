using AutoMapper;
using IntegraBrasil.DTOs;
using IntegraBrasil.Model;

namespace IntegraBrasil.Mapper
{
    public class EnderecoMapping :Profile
    {
        public EnderecoMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<EnderecoResponse, EnderecoModel>();
            CreateMap<EnderecoModel, EnderecoResponse>();
        }
    }
}
