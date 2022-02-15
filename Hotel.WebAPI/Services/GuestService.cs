using AutoMapper;
using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.HotelDto;
using Hotel.WebAPI.Exceptions;
using Hotel.WebAPI.Infrastructure.Database;
using Hotel.WebAPI.Interfaces;

namespace Hotel.WebAPI.Services
{
    public class GuestService : IGuestService
    {
        protected readonly HotelDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<GuestService> _logger;

        public GuestService(HotelDbContext context, IMapper mapper, ILogger<GuestService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public bool DeleteGuest(int id)
        {
            var dbGuest = _context.Guests.FirstOrDefault(x => x.Id == id);

            if (dbGuest == null)
            {
                throw new NoGuestException("Gost ne postoji");
            }

            _context.Guests.Remove(dbHotel);

            return _context.SaveChanges() > 0;
        }

        public GuestDto GetGuestById(int id)
        {
            var dbGuest = _context.Guests.FirstOrDefault(x => x.Id == id);

            if (dbGuest == null)
            {
                throw new NoGuestException("Gost ne postoji");
            }

            return _mapper.Map<GuestDto>(dbGuest);
        }

        public PagedResult<GuestDto> GetListOfGuests(GuestSearchDto searchDto)
        {
            var query = _context.Guests.AsQueryable();

            if (!string.IsNullOrEmpty(searchDto.Name))
            {
                query = query.Where(x => x.Name.ToLower() == searchDto.Name.ToLower());
            }

            PagedResult<GuestDto> result = new();
            result.TotalCount = query.LongCount();

            query = query.Skip(searchDto.Page * searchDto.PageSize)
                .Take(searchDto.PageSize);

            List<Guest> res = query.ToList();
            result.Data = _mapper.Map<List<GuestDto>>(res);
            return result;
        }

        public GuestDto InsertHotel(GuestInsertDto insertDto)
        {
            var dbGuest = _mapper.Map<Guest>(insertDto);
            _context.Guests.Add(dbGuest);
            _context.SaveChanges();
            return _mapper.Map<HotelDto>(dbGuest);
        }

        public GuestDto UpdateHotel(int id, GuestUpdateDto updateDto)
        {
            _logger.LogInformation($"Izmjena gosta sa id {id}");

            var dbGuest = _context.Guests.FirstOrDefault(x => x.Id == id);

            if (dbGuest == null)
            {
                throw new NoHotelException("Gost ne postoji");
            }

            _mapper.Map(updateDto, dbGuest);
            _context.SaveChanges();

            return _mapper.Map<GuestDto>(dbGuest);
        }
    }
}
