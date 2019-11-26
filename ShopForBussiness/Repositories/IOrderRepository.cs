using ShopForBussiness.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopForBussiness.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> Get(int id);
        Task Add(Order order);
        Task Update(Order order);

    }
}
