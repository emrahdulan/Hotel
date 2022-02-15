using AutoMapper;
using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.RoomDto;
using Hotel.WebAPI.Exceptions;
using Hotel.WebAPI.Infrastructure.Database;
using Hotel.WebAPI.Interfaces;

namespace Hotel.WebAPI.Services
{
    public class RoomService : IRoomService
    {
        protected readonly HotelDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<HotelService> _logger;

        public RoomService(HotelDbContext context, IMapper mapper, ILogger<RoomService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = (ILogger<HotelService>?)logger;
        }

        public bool DeleteRoom(int id)
        {
            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoRoomException("Soba ne postoji");
            }

            _context.Hotels.Remove(dbHotel);

            return _context.SaveChanges() > 0;
        }

        public RoomDto GetRoomById(int id)
        {
            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoRoomException("Soba ne postoji");
            }

            return _mapper.Map<RoomDto>(dbHotel);
        }

        public PagedResult<RoomDto> GetListOfRooms(RoomSearchDto searchDto)
        {
            var query = _context.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(searchDto.Name))
            {
                query = query.Where(x => x.Name.ToLower() == searchDto.Name.ToLower());
            }

            PagedResult<RoomDto> result = new();
            result.TotalCount = query.LongCount();

            query = query.Skip(searchDto.Page * searchDto.PageSize)
                .Take(searchDto.PageSize);

            List<Entities.Hotel> res = query.ToList();
            result.Data = _mapper.Map<List<RoomDto>>(res);
            return result;
        }

        public RoomDto InsertRoom(RoomInsertDto insertDto)
        {
            var dbHotel = _mapper.Map<Entities.Hotel>(insertDto);
            _context.Hotels.Add(dbHotel);
            _context.SaveChanges();
            return _mapper.Map<RoomDto>(dbHotel);
        }

        public RoomDto UpdateRoom(int id, RoomUpdateDto updateDto)
        {
            _logger.LogInformation($"Izmjena sobe sa id {id}");

            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoHotelException("Soba ne postoji");
            }

            _mapper.Map(updateDto, dbHotel);
            _context.SaveChanges();

            return _mapper.Map<RoomDto>(dbHotel);
        }
    }
}
