using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.ReservationDto;

namespace Hotel.WebAPI.Interfaces
{
    public interface IReservationService
    {
        PagedResult<ReservationDto> GetListOfReservation(RservationSearchDto searchDto);
        ReservationDto GetHotelById(int id);
        ReservationDto InsertHotel(ReservationInsertDto insertDto);
        ReservationDto UpdateHotel(int id, ReservationUpdateDto updateDto);
        bool DeleteReservation(int id);
    }
}
