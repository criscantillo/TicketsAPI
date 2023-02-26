namespace TicketsAPI.Models.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Ticket> GetTickets([Service] ApplicationDBContext dbcontext) =>
            dbcontext.Tickets;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] ApplicationDBContext dbcontext) =>
            dbcontext.Users;
    }
}
