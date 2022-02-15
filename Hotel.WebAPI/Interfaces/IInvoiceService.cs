using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.InvoiceDto;

namespace Hotel.WebAPI.Interfaces
{
    public interface IInvoiceService
    {
        PagedResult<InvoiceDto> GetListOfInvoices(InvoiceSearchDto searchDto);
        InvoiceDto GetInvoiceById(int id);
        InvoiceDto InsertInvoice(InvoiceInsertDto insertDto);
        InvoiceDto UpdateInvoice(int id, InvoiceUpdateDto updateDto);
        bool DeleteInvoice(int id);
    }
}
