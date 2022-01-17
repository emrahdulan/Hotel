using AutoMapper;
using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.HotelDto;
using Hotel.WebAPI.Exceptions;
using Hotel.WebAPI.Infrastructure.Database;
using Hotel.WebAPI.Interfaces;

namespace Hotel.WebAPI.Services
{
    public class HotelService : IHotelService
    {
        protected readonly HotelDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<HotelService> _logger;

        public HotelService(HotelDbContext context, IMapper mapper, ILogger<HotelService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public bool DeleteHotel(int id)
        {
            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoHotelException("Hotel ne postoji");
            }

            _context.Hotels.Remove(dbHotel);

            return _context.SaveChanges() > 0;
        }

        public HotelDto GetHotelById(int id)
        {
            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoHotelException("Hotel ne postoji");
            }

            return _mapper.Map<HotelDto>(dbHotel);
        }

        public PagedResult<HotelDto> GetListOfHotels(HotelSearchDto searchDto)
        {
            var query = _context.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(searchDto.Name))
            {
                query = query.Where(x => x.Name.ToLower() == searchDto.Name.ToLower());
            }

            PagedResult<HotelDto> result = new();
            result.TotalCount = query.LongCount();

            query = query.Skip(searchDto.Page * searchDto.PageSize)
                .Take(searchDto.PageSize);

            List<Entities.Hotel> res = query.ToList();
            result.Data = _mapper.Map<List<HotelDto>>(res);
            return result;
        }

        public HotelDto InsertHotel(HotelInsertDto insertDto)
        {
            var dbHotel = _mapper.Map<Entities.Hotel>(insertDto);
            _context.Hotels.Add(dbHotel);
            _context.SaveChanges();
            return _mapper.Map<HotelDto>(dbHotel);
        }

        public HotelDto UpdateHotel(int id, HotelUpdateDto updateDto)
        {
            _logger.LogInformation($"Izmjena hotela sa id {id}");

            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoHotelException("Hotel ne postoji");
            }

            _mapper.Map(updateDto, dbHotel);
            _context.SaveChanges();

            return _mapper.Map<HotelDto>(dbHotel);
        }
    }
}
