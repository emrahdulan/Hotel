using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.GuestDto;

namespace Hotel.WebAPI.Interfaces
{
    public interface IGuestService
    {
        PagedResult<GuestDto> GetListOfGuest(GuestSearchDto searchDto);
        GuestDto GetGuestById(int id);
        GuestDto InsertGuest(GuestInsertDto insertDto);
        GuestDto UpdateGuest(int id, HotelUpdateDto updateDto);
        bool DeleteGuest(int id);
    }
}
