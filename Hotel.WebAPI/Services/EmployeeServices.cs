using AutoMapper;
using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.EmployeeDto;
using Hotel.WebAPI.Dto.HotelDto;
using Hotel.WebAPI.Exceptions;
using Hotel.WebAPI.Infrastructure.Database;
using Hotel.WebAPI.Interfaces;

namespace Hotel.WebAPI.Services
{
    public class EmployeeService : IEmpoloyeeService
    {
        protected readonly HotelDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<EmployeeService> _logger;

        public EmployeeService(HotelDbContext context, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public bool DeleteEmployee(int id)
        {
            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoEmployeeException("Zaposlenik ne postoji");
            }

            _context.Hotels.Remove(dbHotel);

            return _context.SaveChanges() > 0;
        }

        public bool DeleteEmployeer(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoEmployeeException("Zaposlenik ne postoji");
            }

            return _mapper.Map<EmployeeDto>(dbHotel);
        }

        public EmployeeSearchDto GetemployeerById(int id)
        {
            throw new NotImplementedException();
        }

        public PagedResult<EmployeeSearchDto> GetListOfEmployeers(EmployeeSearchDto searchDto)
        {
            throw new NotImplementedException();
        }

        public PagedResult<EmployeeDto> GetListOfHotels(EmployeeSearchDto searchDto)
        {
            var query = _context.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(searchDto.Name))
            {
                query = query.Where(x => x.Name.ToLower() == searchDto.Name.ToLower());
            }

            PagedResult<EmployeeDto> result = new();
            result.TotalCount = query.LongCount();

            query = query.Skip(searchDto.Page * searchDto.PageSize)
                .Take(searchDto.PageSize);

            List<Entities.Hotel> res = query.ToList();
            result.Data = _mapper.Map<List<EmployeeDto>>(res);
            return result;
        }

        public EmployeeDto InsertEmployee(EmployeeInsertDto insertDto)
        {
            var dbHotel = _mapper.Map<Entities.Hotel>(insertDto);
            _context.Hotels.Add(dbHotel);
            _context.SaveChanges();
            return _mapper.Map<EmployeeDto>(dbHotel);
        }

        public EmployeeSearchDto InsertEmployeer(EmployeeInsertDto insertDto)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto UpdateEmployee(int id, EmployeeUpdateDto updateDto)
        {
            _logger.LogInformation($"Izmjena zaposlenika sa id {id}");

            var dbHotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (dbHotel == null)
            {
                throw new NoEmployeeException("Hotel ne postoji");
            }

            _mapper.Map(updateDto, dbHotel);
            _context.SaveChanges();

            return _mapper.Map<EmployeeDto>(dbHotel);
        }

        public EmployeeSearchDto UpdateEmployeer(int id, EmployeeUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        EmployeeDto IEmpoloyeeService.GetemployeerById(int id)
        {
            throw new NotImplementedException();
        }

        PagedResult<EmployeeDto> IEmpoloyeeService.GetListOfEmployeers(EmployeeSearchDto searchDto)
        {
            throw new NotImplementedException();
        }

        EmployeeDto IEmpoloyeeService.InsertEmployeer(EmployeeInsertDto insertDto)
        {
            throw new NotImplementedException();
        }

        EmployeeDto IEmpoloyeeService.UpdateEmployeer(int id, EmployeeUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }

}
