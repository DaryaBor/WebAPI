using TodoAPI.Models;
using TodoAPI.Dto;
using TodoAPI.Repositories;
namespace TodoAPI.Services
{
    public  class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _ticketsRepository;

        public TicketsService(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public List<Tickets> GetTickets()
        {
            return _ticketsRepository.GetTickets();
        }

        public int CreateTicket(TicketsDto ticket)
        {
            if (ticket == null)
            {
                throw new Exception($"{nameof(ticket)} not found");
            }

            Tickets ticketEntity = ticket.ConvertToTickets();

            return _ticketsRepository.Create(ticketEntity);
        }

        public void DeleteTicket(int ticketId)
        {
            Tickets ticket = _ticketsRepository.Get(ticketId);
            if (ticket == null)
            {
                throw new Exception($"{nameof(ticket)} not found, #Id - {ticketId}");
            }

            _ticketsRepository.Delete(ticket);
        }

        public Tickets GetTicket(int ticketId)
        {
            Tickets ticket = _ticketsRepository.Get(ticketId);
            if (ticket == null)
            {
                throw new Exception($"{nameof(ticket)} not found, #Id - {ticketId}");
            }

            return ticket;
        }
    }
}
