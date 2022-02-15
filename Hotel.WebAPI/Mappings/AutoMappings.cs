using AutoMapper;
using Hotel.WebAPI.Dto.HotelDto;
using Hotel.WebAPI.Dto.InvoiceDto;
using Hotel.WebAPI.Dto.ReservationDto;
using Hotel.WebAPI.Entities;

namespace Hotel.WebAPI.Mappings
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<Entities.Hotel, HotelDto>();
            CreateMap<HotelInsertDto, Entities.Hotel>();
            CreateMap<HotelUpdateDto, Entities.Hotel>();

            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationInsertDto, Reservation>();
            CreateMap<ReservationUpdateDto, Reservation>();

            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceInsertDto, Invoice>();
            CreateMap<InvoiceUpdateDto, Invoice>();
            
            CreateMap<Room, RoomDto>();
            CreateMap<RoomInsertDto, Room>();
            CreateMap<RoomUpdateDto, Room>();
            
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeInsertDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            
            CreateMap<Guest, GuestDto>();
            CreateMap<GuestInsertDto, Guest>();
            CreateMap<GuestUpdateDto, Guest>();
        }
    }
}
