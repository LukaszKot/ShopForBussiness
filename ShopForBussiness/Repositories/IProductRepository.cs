using ShopForBussiness.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopForBussiness.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(string category=null);
        Task<Product> GetProduct(int id);
        Task Add(Product product);
        Task Remove(int id);
        Task Update(Product product);
    }
}
