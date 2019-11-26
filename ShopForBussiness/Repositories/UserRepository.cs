using System.Data.Entity;
using System.Threading.Tasks;
using ShopForBussiness.Domain;
using ShopForBussiness.MySQL;

namespace ShopForBussiness.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopForBusinessContext _dbContext;

        public UserRepository(ShopForBusinessContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetAsync(string email)
            => await _dbContext.User.SingleOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetAsync(int id)
            => await _dbContext.User.SingleOrDefaultAsync(x => x.ID == id);
    }
}