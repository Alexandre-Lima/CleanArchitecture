using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.UnitTests.Utils;

namespace CleanArchitecture.UnitTests.Builders
{
    public class AddressBuilder
    {
        private readonly AddressResponse _instance;

        public AddressBuilder()
        {
            var faker = FakerPtBr.CreateFaker();

            _instance = new AddressResponse
            {
                City = faker.Address.City(),
                Complement = faker.Address.StreetSuffix(),
                Neighborhood = faker.Address.CitySuffix(),
                State = faker.Address.State(),
                Address = faker.Address.StreetName(),
                ZipCode = new ZipCodeBuilder().Build()
            };
        }

        public AddressResponse Build()
        {
            return _instance;
        }
    }
}
