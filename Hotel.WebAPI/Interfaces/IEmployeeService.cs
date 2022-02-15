using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.EmployeeDto;
using Hotel.WebAPI.Dto.HotelDto;

namespace Hotel.WebAPI.Interfaces
{
    public interface IEmpoloyeeService
    {
        PagedResult<EmployeeDto> GetListOfEmployeers(EmployeeSearchDto searchDto);
        EmployeeDto GetemployeerById(int id);
        EmployeeDto InsertEmployeer(EmployeeInsertDto insertDto);
        EmployeeDto UpdateEmployeer(int id, EmployeeUpdateDto updateDto);
        bool DeleteEmployeer(int id);
    }
}
