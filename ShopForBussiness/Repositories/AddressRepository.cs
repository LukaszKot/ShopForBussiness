using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using ShopForBussiness.Domain;
using ShopForBussiness.MySQL;

namespace ShopForBussiness.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShopForBusinessContext _dbContext;
        public AddressRepository(ShopForBusinessContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Address address)
        {
            _dbContext.Address.Add(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Address> Get(int id)
        {
            return await _dbContext.Address.SingleOrDefaultAsync(x => x.UserID == id);
        }

        public async Task Update(Address address)
        {
            _dbContext.Address.AddOrUpdate(address);
            await _dbContext.SaveChangesAsync();
        }
    }
}
