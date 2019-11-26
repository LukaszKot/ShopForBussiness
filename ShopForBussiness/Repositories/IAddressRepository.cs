using ShopForBussiness.Domain;
using System.Threading.Tasks;

namespace ShopForBussiness.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> Get(int id);
        Task Add(Address address);
        Task Update(Address address);
    }
}
