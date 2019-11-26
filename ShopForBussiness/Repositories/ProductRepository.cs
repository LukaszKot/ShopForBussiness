using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForBussiness.Domain;
using ShopForBussiness.MySQL;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ShopForBussiness.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopForBusinessContext _dbContext;
        public ProductRepository(ShopForBusinessContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Product product)
        {
            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll(string category = null)
        {
            return await _dbContext.Product.Where(x=>true).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _dbContext.Product.SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task Remove(int id)
        {
            _dbContext.Product.Remove(await _dbContext.Product.SingleOrDefaultAsync(x => x.ID == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _dbContext.Product.AddOrUpdate(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}