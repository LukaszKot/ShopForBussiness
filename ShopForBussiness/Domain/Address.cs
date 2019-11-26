using ShopForBussiness.Extensions;
using System.Text.RegularExpressions;

namespace ShopForBussiness.Domain
{
    public class Address
    {
        private readonly Regex zipCodeRegex = new Regex(@"^[0-9]{2}\-[0-9]{3}$");
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string StreetName { get; private set; }
        public int PropertyNumber { get; private set; }
        public int? NumberOfPremises { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }

        protected Address()
        {

        }

        public Address(int userId, string name, string surname, string streetName, int propertyNumber, int? numberOfPremises, string zipCode, string city)
        {
            UserID = userId;
            SetName(name);
            SetSurname(surname);
            SetStreetName(streetName);
            SetPropertyNumber(propertyNumber);
            SetNumberOfPremises(numberOfPremises);
            SetZipCode(zipCode);
            SetCity(city);
        }

        private void SetName(string name)
        {
            if(!name.IsNotEmpty())
            {
                throw new DomainException(ErrorMessages.INVALID_NAME);
            }
            Name = name;
        }

        private void SetSurname(string surname)
        {
            if (!surname.IsNotEmpty())
            {
                throw new DomainException(ErrorMessages.INVALID_SURNAME);
            }
            Surname = surname;
        }
        private void SetStreetName(string streetName)
        {
            if (!streetName.IsNotEmpty())
            {
                throw new DomainException(ErrorMessages.INVALID_STREET_NAME);
            }
            StreetName = streetName;
        }

        private void SetPropertyNumber(int propertyNumber)
        {
            if(propertyNumber<=0)
            {
                throw new DomainException(ErrorMessages.INVALID_PROPERTY_NUMBER);
            }
            PropertyNumber = propertyNumber;
        }

        private void SetNumberOfPremises(int? number)
        {
            if (number == null)
            {
                NumberOfPremises = NumberOfPremises;
                return;
            }
            if (number <= 0)
            {
                throw new DomainException(ErrorMessages.INVALID_NUMBER_OF_PREMISES);
            }
            NumberOfPremises = number;
        }

        private void SetZipCode(string zipCode)
        {
            if (!zipCode.IsNotEmpty())
            {
                throw new DomainException(ErrorMessages.INVALID_ZIPCODE);
            }
            if(!zipCodeRegex.IsMatch(zipCode))
            {
                throw new DomainException(ErrorMessages.INVALID_ZIPCODE);
            }
            
            ZipCode = zipCode;
        }

        private void SetCity(string city)
        {
            if (!city.IsNotEmpty())
            {
                throw new DomainException(ErrorMessages.INVALID_CITY);
            }
            City = city;
        }

    }
}