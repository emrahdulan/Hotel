using AutoMapper;
using Hotel.WebAPI.Dto.HotelDto;

namespace Hotel.WebAPI.Mappings
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<Entities.Hotel, HotelDto>();
            CreateMap<HotelInsertDto, Entities.Hotel>();
            CreateMap<HotelUpdateDto, Entities.Hotel>();
        }
    }
}
