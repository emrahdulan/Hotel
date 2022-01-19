using AutoMapper;
using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.InvoiceDto;
using Hotel.WebAPI.Entities;
using Hotel.WebAPI.Exceptions;
using Hotel.WebAPI.Infrastructure.Database;
using Hotel.WebAPI.Interfaces;

namespace Hotel.WebAPI.Services
{
    public class InvoiceService : IInvoiceService
    {
        protected readonly HotelDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<InvoiceService> _logger;

        public InvoiceService(HotelDbContext context, IMapper mapper, ILogger<InvoiceService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public bool DeleteInvoice(int id)
        {
            var dbInvoice = _context.Invoices.FirstOrDefault(x => x.Id == id);

            if (dbInvoice == null)
            {
                throw new NoInvoiceException("Invoice ne postoji");
            }

            _context.Invoices.Remove(dbInvoice);

            return _context.SaveChanges() > 0;
        }

        public InvoiceDto GetInvoiceById(int id)
        {
            var dbInvoice = _context.Invoices.FirstOrDefault(x => x.Id == id);

            if (dbInvoice == null)
            {
                throw new NoInvoiceException("Invoice ne postoji");
            }

            return _mapper.Map<InvoiceDto>(dbInvoice);
        }

        public PagedResult<InvoiceDto> GetListOfInvoices(InvoiceSearchDto searchDto)
        {
            var query = _context.Invoices.AsQueryable();

            if (!string.IsNullOrEmpty(searchDto.Name))
            {
                query = query.Where(x => x.Name.ToLower() == searchDto.Name.ToLower());
            }

            PagedResult<InvoiceDto> result = new();
            result.TotalCount = query.LongCount();

            query = query.Skip(searchDto.Page * searchDto.PageSize)
                .Take(searchDto.PageSize);

            List<Invoice> res = query.ToList();
            result.Data = _mapper.Map<List<InvoiceDto>>(res);
            return result;
        }

        public InvoiceDto InsertInvoice(InvoiceInsertDto insertDto)
        {
            var dbInvoice = _mapper.Map<Invoice>(insertDto);
            _context.Invoices.Add(dbInvoice);
            _context.SaveChanges();
            return _mapper.Map<InvoiceDto>(dbInvoice);
        }

        public InvoiceDto UpdateInvoice(int id, InvoiceUpdateDto updateDto)
        {
            _logger.LogInformation($"Izmjena invoice sa id {id}");

            var dbInvoice = _context.Invoices.FirstOrDefault(x => x.Id == id);

            if (dbInvoice == null)
            {
                throw new NoInvoiceException("Invoice ne postoji");
            }

            _mapper.Map(updateDto, dbInvoice);
            _context.SaveChanges();

            return _mapper.Map<InvoiceDto>(dbInvoice);
        }
    }
}
