using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.HotelDto;
using Hotel.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelsController> _logger;

        public RoomController(IHotelService hotelService, ILogger<HotelsController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public HotelDto GetHotelById(int id)
        {
            return _hotelService.GetHotelById(id);
        }

        [HttpGet("")]
        public PagedResult<HotelDto> GetHotels([FromQuery] HotelSearchDto search)
        {
            _logger.LogInformation("Svi hoteli");
            return _hotelService.GetListOfHotels(search);
        }

        [HttpPost]
        public HotelDto CreateHotel(HotelInsertDto insertHotelRequest)
        {
            return _hotelService.InsertHotel(insertHotelRequest);
        }

        [HttpPut("{id}")]
        public HotelDto UpdateHotel(int id, HotelUpdateDto updateRequest)
        {
            return _hotelService.UpdateHotel(id, updateRequest);
        }

        [HttpDelete]
        public bool DeleteBook(int id)
        {
            return _hotelService.DeleteHotel(id);
        }
    }
}

