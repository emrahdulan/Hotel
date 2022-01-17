using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.HotelDto;

namespace Hotel.WebAPI.Interfaces
{
    public interface IHotelService
    {
        PagedResult<HotelDto> GetListOfHotels(HotelSearchDto searchDto);
        HotelDto GetHotelById(int id);
        HotelDto InsertHotel(HotelInsertDto insertDto);
        HotelDto UpdateHotel(int id, HotelUpdateDto updateDto);
        bool DeleteHotel(int id);
    }
}
