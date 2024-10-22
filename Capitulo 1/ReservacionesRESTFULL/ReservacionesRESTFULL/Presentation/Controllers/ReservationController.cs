using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservacionesRESTFULL.Bussiness.Services;
using ReservacionesRESTFULL.Data.DTO;

namespace ReservacionesRESTFULL.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Create(ReservationDTO dto)
        {
            try
            {
                var result = _reservationService.Insert(dto);

                return result > 0 ? Created() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_reservationService.GetAll());
        }

        [HttpGet("Rooms")]
        public IActionResult GetAvailableRooms()
        {
            return Ok(_reservationService.GetAvailableRooms());
        }
    }
}
