using TodoAPI.Models;
using TodoAPI.Dto;
using TodoAPI.Repositories;

namespace TodoAPI.Services
{
    public class SeanceService : ISeanceService
    {
        private readonly ISeanceRepository _seanceRepository;

        public SeanceService(ISeanceRepository seanceRepository)
        {
            _seanceRepository = seanceRepository;
        }

        public List<Seance> GetSeancec()
        {
            return _seanceRepository.GetSeances();
        }

        public int CreateGroup(SeanceDto seance)
        {
            if (seance == null)
            {
                throw new Exception($"{nameof(seance)} not found");
            }

            Seance seanceEntity = seance.ConvertToSeance();

            return _seanceRepository.Create(seanceEntity);
        }

        public void DeleteSeance(int seanceId)
        {
            Seance seance = _seanceRepository.Get(seanceId);
            if (seance == null)
            {
                throw new Exception($"{nameof(seance)} not found, #Id - {seanceId}");
            }

            _seanceRepository.Delete(seance);
        }

        public Seance GetSeance(int seanceId)
        {
            Seance seance = _seanceRepository.Get(seanceId);
            if (seance == null)
            {
                throw new Exception($"{nameof(seance)} not found, #Id - {seanceId}");
            }

            return seance;
        }
    }
}
