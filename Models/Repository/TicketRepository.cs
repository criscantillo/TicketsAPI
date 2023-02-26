using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TicketsAPI.Models.Data;

namespace TicketsAPI.Models.Repository
{
    public class TicketRepository : ITicketRepository
    {
        protected readonly ApplicationDBContext _dbContext;
        public TicketRepository(ApplicationDBContext dbContext) => _dbContext= dbContext;
        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            await _dbContext.Set<Ticket>().AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> UpdateAsync(Ticket ticket)
        {
            _dbContext.Entry(ticket).State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Ticket ticket)
        {
            if (ticket is null)
                return false;

            _dbContext.Set<Ticket>().Remove(ticket);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<Ticket> GetAsync()
        {
            return _dbContext.Tickets.ToList();
        }

        public Ticket GetByIdAsync(int id)
        {
            return _dbContext.Tickets.Find(id);
        }
    }
}
