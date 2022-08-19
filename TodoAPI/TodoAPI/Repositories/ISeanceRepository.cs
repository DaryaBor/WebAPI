using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface ISeanceRepository
    {
        public List<Seance> GetSeances();
        public int Create(Seance seance);
        public void Delete(Seance seance);
        public Seance Get(int id);
        public int Update(Seance seance);
    }
}
