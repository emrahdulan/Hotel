using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.RoomDto;

namespace Hotel.WebAPI.Interfaces
{
    public interface IRoomService
    {
        PagedResult<RoomDto> GetListOfRooms(RoomSearchDto searchDto);
        RoomDto GetRoomById(int id);
        RoomDto InsertRoom(RoomInsertDto insertDto);
        RoomDto UpdateRoom(int id, RoomUpdateDto updateDto);
        bool DeleteRoom(int id);
    }
}
