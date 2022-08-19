using TodoAPI.Models;
using TodoAPI.Dto;
using TodoAPI.Repositories;
namespace TodoAPI.Services
{
    
        public class FilmService : IFilmService
        {
            private readonly IFilmRepository _filmRepository;

            public FilmService (IFilmRepository filmRepository)
            {
                _filmRepository = filmRepository;
            }

            public List<Film> GetFilms()
            {
                return _filmRepository.GetFilms();
            }

            public int CreateFilm(FilmDto film)
            {
                if (film == null)
                {
                    throw new Exception($"{nameof(film)} not found");
                }

                Film filmEntity = film.ConvertToFilm();

                return _filmRepository.Create(filmEntity);
            }

            public void DeleteFilm(int filmId)
            {
                Film film = _filmRepository.Get(filmId);
                if (film == null)
                {
                    throw new Exception($"{nameof(film)} not found, #Id - {filmId}");
                }

                _filmRepository.Delete(film);
            }

            public Film GetFilm(int filmId)
            {
                Film film = _filmRepository.Get(filmId);
                if (film == null)
                {
                    throw new Exception($"{nameof(film)} not found, #Id - {filmId}");
                }

                return film;
            }
        }
}
