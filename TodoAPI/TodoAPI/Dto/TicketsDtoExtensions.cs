using TodoAPI.Models;
namespace TodoAPI.Dto
{
    public static class TicketsDtoExtensions
    {
        public static Tickets ConvertToTickets(this TicketsDto ticket)
        {
            return new Tickets
            {
                Id = ticket.Id,
                Number = ticket.Number,
                SeanceNumber = ticket.SeanceNumber,
                Place = ticket.Place,
                Cost = ticket.Cost,
                SeanceId = ticket.SeanceId
            };
        }

        public static TicketsDto ConvertToTicketsDto(this Tickets ticketDto)
        {
            return new TicketsDto
            {
                Id = ticketDto.Id,
                Number = ticketDto.Number,
                SeanceNumber = ticketDto.SeanceNumber,
                Place = ticketDto.Place,
                Cost = ticketDto.Cost,
                SeanceId = ticketDto.SeanceId
            };
        }
    }
}
