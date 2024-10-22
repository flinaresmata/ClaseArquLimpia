using Biblioteca.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservacionesRESTFULL.Bussiness.Services;
using ReservacionesRESTFULL.Data.DTO;

namespace ReservacionesRESTFULL.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBookService _bibliotecaService;

        public BibliotecaController(IBookService reservationService)
        {
            _bibliotecaService = reservationService;
        }

        [HttpPost]
        public IActionResult Create(BookDTO dto)
        {
            try
            {
                var result = _bibliotecaService.Insert(dto);

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
            return Ok(_bibliotecaService.GetAll());
        }

        [HttpGet("Books")]
        public IActionResult FindBook(BookDTO book)
        {
            return Ok(_bibliotecaService.FindBooks(book));
        }
    }
}
