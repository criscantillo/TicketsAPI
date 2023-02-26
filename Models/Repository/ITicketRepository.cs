using TicketsAPI.Models.Data;

namespace TicketsAPI.Models.Repository
{
    public interface ITicketRepository
    {
        Task<Ticket> CreateAsync(Ticket ticket);
        Task<bool> UpdateAsync(Ticket ticket);
        Task<bool> DeleteAsync(Ticket ticket);
        IEnumerable<Ticket> GetAsync();
        Ticket GetByIdAsync(int id);
    }
}
