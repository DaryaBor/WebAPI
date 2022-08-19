using TodoAPI.Models;
using TodoAPI.Dto;
namespace TodoAPI.Services
{
    public interface ISeanceService
    {
        public List<Seance> GetSeances();
        public int CreateSeance(SeanceDto seance);
        public void DeleteSeance(int seanceId);
        public Seance GetSeance(int seanceId);
    }
}
