using AutoMapper;
using Geolocation.Main.Models;

namespace Geolocation.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LocationModel, LocationViewModel>().ForMember(dest => dest.Network,
               opts => opts.MapFrom(src => src.Network.ToString()));
        }
    }
}
