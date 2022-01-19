using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.ReservationDto;

namespace Hotel.WebAPI.Interfaces
{
    public interface IReservationService
    {
        PagedResult<ReservationDto> GetListOfReservations(ReservationSearchDto searchDto);
        ReservationDto GetReservationById(int id);
        ReservationDto InsertReservation(ReservationInsertDto insertDto);
        ReservationDto UpdateReservation(int id, ReservationUpdateDto updateDto);
        bool DeleteReservation(int id);
    }
}
