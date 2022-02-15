using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.InvoiceDto;
using Hotel.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger<InvoicesController> _logger;

        public InvoicesController(IInvoiceService invoiceService, ILogger<InvoicesController> logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public InvoiceDto GetInvoiceById(int id)
        {
            return _invoiceService.GetInvoiceById(id);
        }

        [HttpGet("")]
        public PagedResult<InvoiceDto> GetInvoices([FromQuery] InvoiceSearchDto search)
        {
            _logger.LogInformation("Svi hoteli");
            return _invoiceService.GetListOfInvoices(search);
        }

        [HttpPost]
        public InvoiceDto CreateInvoice(InvoiceInsertDto insertInvoiceRequest)
        {
            return _invoiceService.InsertInvoice(insertInvoiceRequest);
        }

        [HttpPut("{id}")]
        public InvoiceDto UpdateInvoice(int id, InvoiceUpdateDto updateRequest)
        {
            return _invoiceService.UpdateInvoice(id, updateRequest);
        }

        [HttpDelete]
        public bool DeleteInvoice(int id)
        {
            return _invoiceService.DeleteInvoice(id);
        }
    }
}
