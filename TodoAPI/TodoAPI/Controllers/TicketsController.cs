using Microsoft.AspNetCore.Mvc;
using TodoAPI.Dto;
using TodoAPI.Services;
namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetTickets()
        {
            try
            {
                return Ok(_ticketsService.GetTickets()
                    .ConvertAll(t => t.ConvertToTicketsDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{groupId}")]
        public IActionResult GetTicket(int ticketId)
        {
            try
            {
                return Ok(_ticketsService.GetTicket(ticketId).ConvertToTicketsDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateTicket([FromBody] TicketsDto ticket)
        {
            try
            {
                return Ok(_ticketsService.CreateTicket(ticket));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{ticketId}")]
        public IActionResult DeleteTicket(int ticketId)
        {
            try
            {
                _ticketsService.DeleteTicket(ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
