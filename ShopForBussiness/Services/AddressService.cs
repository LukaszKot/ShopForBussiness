using System;
using System.Threading.Tasks;
using ShopForBussiness.Domain;
using ShopForBussiness.Repositories;

namespace ShopForBussiness.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Add(int userId, string name, string surname, string streetName,
            int propertyName, int? numberOfPremises, string zipCode,
            string city)
        {

            await _addressRepository.Add(new Address(userId, name, surname, streetName, propertyName, numberOfPremises, zipCode, city));
        }

        public async Task<Address> Get(int id)
        {
            return await _addressRepository.Get(id);
        }

        public async Task Update(int userId, string name, string surname, string streetName,
            int propertyName, int? numberOfPremises, string zipCode,
            string city)
        {
            await _addressRepository.Update(new Address(userId, name, surname, streetName, propertyName, numberOfPremises, zipCode, city));
        }
    }
}