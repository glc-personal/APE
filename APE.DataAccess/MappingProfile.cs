using APE.DataAccess.Entities;
using AutoMapper;

namespace APE.DataAccess
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserEntity>().ReverseMap();
            CreateMap<ProtocolEntity, ProtocolEntity>().ReverseMap();
        }
    }
}
