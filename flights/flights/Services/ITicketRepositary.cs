using flights.Context;
using flights.Entity;


namespace flightSystem.Services
{
    public interface ITicketRepositary
    {
        public List<ticket> GetAll();
        public ticket GetDetails(int id);
        public void Insert(ticket ticket);
        public void UpdateTicket(int id, ticket ticket);
        public void DeleteTicket(int id);
    }
}
