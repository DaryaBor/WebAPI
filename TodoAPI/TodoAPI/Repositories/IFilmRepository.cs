using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface IFilmRepository
    {
        public List<Film> GetFilms();
        public int Create(Film film);
        public int Update(Film film);
        public void Delete(Film film);
        public Film Get(int id);
    }
}
