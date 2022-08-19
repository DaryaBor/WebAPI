using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface ITicketsRepository
    {
        public List<Tickets> GetTickets();
        public int Create(Tickets ticket);
        public void Delete(Tickets ticket);
        public Tickets Get(int id);
        public int Update(Tickets ticket);
    }
}
