using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using ShopForBussiness.Domain;
using ShopForBussiness.MySQL;

namespace ShopForBussiness.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopForBusinessContext _dbContext;

        public OrderRepository(ShopForBusinessContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Order order)
        {
            _dbContext.Order.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await _dbContext.Order.SingleOrDefaultAsync(x => x.ID==id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Order.Where(x => true).ToListAsync();
        }

        public async Task Update(Order order)
        {
            _dbContext.Order.AddOrUpdate(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}