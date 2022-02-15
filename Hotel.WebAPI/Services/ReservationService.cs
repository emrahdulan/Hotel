
using AutoMapper;
using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.HotelDto;
using Hotel.WebAPI.Exceptions;
using Hotel.WebAPI.Infrastructure.Database;
using Hotel.WebAPI.Interfaces;

namespace Hotel.WebAPI.Services
{
    public class ReservationService : IReservationService
    {
        protected readonly HotelDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<ReservationService> _logger;

        public ReservationService(HotelDbContext context, IMapper mapper, ILogger<ReservationService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public bool DeleteReservation(int id)
        {
            var dbReservation = _context.Reservations.FirstOrDefault(x => x.Id == id);

            if (dbReservation == null)
            {
                throw new NoReservationException("Rezervacija ne postoji");
            }

            _context.Reservations.Remove(dbReservation);

            return _context.SaveChanges() > 0;
        }

        public ReservationDto GetReservationById(int id)
        {
            var dbReservation = _context.Reservations.FirstOrDefault(x => x.Id == id);

            if (dbReservation == null)
            {
                throw new NoReservationException("Rezervacija ne postoji");
            }

            return _mapper.Map<ReservationDto>(dbReservation);
        }

        public PagedResult<ReservationDto> GetListOfReservations(ReservationSearchDto searchDto)
        {
            var query = _context.Reservations.AsQueryable();

            if (!string.IsNullOrEmpty(searchDto.Name))
            {
                query = query.Where(x => x.Name.ToLower() == searchDto.Name.ToLower());
            }

            PagedResult<ReservationDto> result = new();
            result.TotalCount = query.LongCount();

            query = query.Skip(searchDto.Page * searchDto.PageSize)
                .Take(searchDto.PageSize);

            List<Reservation> res = query.ToList();
            result.Data = _mapper.Map<List<ReservationDto>>(res);
            return result;
        }

        public ReservationDto GetReservationById(int id)
        {
            var dbReservation = _context.Reservations.FirstOrDefault(x => x.Id == id);

            if (dbReservation == null)
            {
                throw new NoReservationException("Rezervacija ne postoji");
            }

            return _mapper.Map<ReservationDto>(dbReservation);
        }

        public ReservationDto InsertReservation(ReservationInsertDto insertDto)
        {
            var dbReservation = _mapper.Map<Reservation>(insertDto);
            _context.Reservations.Add(dbReservation);
            _context.SaveChanges();

            return _mapper.Map<ReservationDto>(dbReservation);
        }

        public ReservationDto UpdateReservation(int id, ReservationUpdateDto updateDto)
        {
            return _mapper.Map<HotelDto>(dbReservation);
        }

        public ReservationDto UpdateHotel(int id, ReservationUpdateDto updateDto)
        {
            _logger.LogInformation($"Izmjena rezervacije sa id {id}");

            var dbReservation = _context.Reservations.FirstOrDefault(x => x.Id == id);

            if (dbReservation == null)
            {
                throw new NoReservationException("Rezervacija ne postoji");
            }

            _mapper.Map(updateDto, dbReservation);
            _context.SaveChanges();

            return _mapper.Map<ReservationDto>(dbReservation);
        }
    }
}
