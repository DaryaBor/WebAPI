using Microsoft.AspNetCore.Mvc;
using TodoAPI.Dto;
using TodoAPI.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetFilms()
        {
            try
            {
                return Ok(_filmService.GetFilms()
                    .ConvertAll(t => t.ConvertToFilmDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{filmId}")]
        public IActionResult GetFilm(int filmId)
        {
            try
            {
                return Ok(_filmService.GetFilm(filmId).ConvertToFilmDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateFilm([FromBody] FilmDto film)
        {
            try
            {
                return Ok(_filmService.CreateFilm(film));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{filmId}")]
        public IActionResult DeleteTodo(int filmId)
        {
            try
            {
                _filmService.DeleteFilm(filmId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}

