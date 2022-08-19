using TodoAPI.Dto;
using TodoAPI.Models;
namespace TodoAPI.Services
{
    public interface IFilmService
    {
        public List<Film> GetFilms();
        public int CreateFilm(FilmDto film);
        public void DeleteFilm(int filmId);
        public Film GetFilm(int filmId);
    }
}
