using TicketsAPI.Models.Data;

namespace TicketsAPI.Models.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);
        IEnumerable<User> GetAsync();
        User GetByIdAsync(int id);
    }
}
