using TodoAPI.Models;
namespace TodoAPI.Dto
{
    public static class FilmDtoExtensions
    {
        public static Film ConvertToFilm(this FilmDto film)
        {
            return new Film
            {
                Id = film.Id,
                Denomination = film.Denomination,
                DateStart = film.DateStart,
                Company = film.Company
            };
        }

        public static  FilmDto ConvertToFilmDto(this Film filmDto)
        {
            return new FilmDto
            {
                Id = filmDto.Id,
                Denomination = filmDto.Denomination,
                DateStart = filmDto.DateStart,
                Company = filmDto.Company
            };
        }
    }
}
