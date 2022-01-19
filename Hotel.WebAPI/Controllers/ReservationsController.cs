using Hotel.WebAPI.Common;
using Hotel.WebAPI.Dto.ReservationDto;
using Hotel.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(IReservationService reservationService, ILogger<ReservationsController> logger)
        {
            _reservationService = reservationService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ReservationDto GetReservationById(int id)
        {
            return _reservationService.GetReservationById(id);
        }

        [HttpGet("")]
        public PagedResult<ReservationDto> GetReservations([FromQuery] ReservationSearchDto search)
        {
            _logger.LogInformation("Sve rezervacije");
            return _reservationService.GetListOfReservations(search);
        }

        [HttpPost]
        public ReservationDto CreateReservation(ReservationInsertDto insertReservationRequest)
        {
            return _reservationService.InsertReservation(insertReservationRequest);
        }

        [HttpPut("{id}")]
        public ReservationDto UpdateReservation(int id, ReservationUpdateDto updateRequest)
        {
            return _reservationService.UpdateReservation(id, updateRequest);
        }

        [HttpDelete]
        public bool DeleteReservation(int id)
        {
            return _reservationService.DeleteReservation(id);
        }
    }
}
