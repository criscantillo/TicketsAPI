using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TicketsAPI.Models.Data;

namespace TicketsAPI.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDBContext _dbContext;
        public UserRepository(ApplicationDBContext dbContext) => _dbContext = dbContext;
        public async Task<User> CreateAsync(User user)
        {
            await _dbContext.Set<User>().AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(User user)
        {
            if (user is null)
                return false;

            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<User> GetAsync()
        {
            return _dbContext.Users.ToList();
        }

        public User GetByIdAsync(int id)
        {
            return _dbContext.Users.Find(id);
        }
    }
}
