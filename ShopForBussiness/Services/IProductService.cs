using ShopForBussiness.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopForBussiness.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task Update(int id, string name, string category, float prize, string description, int amountInMagazine);
        Task Remove(int id);
        Task Add(string name, string category, float prize, string description, int amountInMagazine);
    }
}
