
using TodoAPI.Models;
namespace TodoAPI.Dto
{
    public static class SeanceDtoExtesions
    {
        public static Seance ConvertToSeance(this SeanceDto seance)
        {
            return new Seance
            {
                Id = seance.Id,
                DateSeance = seance.DateSeance,
                Title = seance.Title,
                FilmId = seance.FilmId
            };
        }

        public static SeanceDto ConvertToSeanceDto(this Seance seanceDto)
        {
            return new SeanceDto
            {
                Id = seanceDto.Id,
                DateSeance = seanceDto.DateSeance,
                Title = seanceDto.Title,
                FilmId = seanceDto.FilmId
            };
        }
    }
}