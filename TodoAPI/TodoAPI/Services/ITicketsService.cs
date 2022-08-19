using TodoAPI.Models;
using TodoAPI.Dto;
namespace TodoAPI.Services
{
    public interface ITicketsService
    {
        public List<Tickets> GetTickets();
        public int CreateTicket(TicketsDto ticket);
        public void DeleteTicket(int ticketId);
        public Tickets GetTicket(int ticketId);
    }
}
