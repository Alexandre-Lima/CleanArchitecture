using CleanArchitecture.Borders.Entities.External;
using CleanArchitecture.UnitTests.Utils;

namespace CleanArchitecture.UnitTests.Builders
{
    public class AddressBuilder
    {
        private readonly Address _instance;

        public AddressBuilder()
        {
            var faker = FakerPtBr.CreateFaker();

            _instance = new Address
            {
                Localidade = faker.Address.City(),
                Complemento = faker.Address.StreetSuffix(),
                Bairro = faker.Address.CitySuffix(),
                Uf = faker.Address.State(),
                Logradouro = faker.Address.StreetName(),
                Cep = new ZipCodeBuilder().Build(),
                Ibge = faker.Address.CityPrefix(),
            };
        }

        public Address Build()
        {
            return _instance;
        }
    }
}
