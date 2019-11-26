using ShopForBussiness.Domain;
using System.Threading.Tasks;

namespace ShopForBussiness.Services
{
    public interface IAddressService
    {
        Task<Address> Get(int id);
        Task Add(int userId, string name, string surname, string streetName,
            int propertyName, int? numberOfPremises, string zipCode,
            string city);
        Task Update(int userId, string name, string surname, string streetName,
            int propertyName, int? numberOfPremises, string zipCode,
            string city);
    }
}
