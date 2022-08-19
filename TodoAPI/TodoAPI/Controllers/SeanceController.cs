using Microsoft.AspNetCore.Mvc;
using TodoAPI.Dto;
using TodoAPI.Services;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
        private readonly ISeanceService _seanceService;

        public SeanceController(ISeanceService seanceService)
        {
            _seanceService = seanceService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetSeances()
        {
            try
            {
                return Ok(_seanceService.GetSeances()
                    .ConvertAll(t => t.ConvertToSeanceDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{seanceId}")]
        public IActionResult GetSeance(int seanceId)
        {
            try
            {
                return Ok(_seanceService.GetSeance(seanceId).ConvertToSeanceDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateSeance([FromBody] SeanceDto seance)
        {
            try
            {
                return Ok(_seanceService.CreateSeance(seance));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{seanceId}")]
        public IActionResult DeleteSeance(int seanceId)
        {
            try
            {
                _seanceService.DeleteSeance(seanceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
