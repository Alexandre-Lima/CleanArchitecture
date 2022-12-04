using CleanArchitecture.Borders.Adapters;
using CleanArchitecture.Borders.Entities;
using CleanArchitecture.UnitTests.Builders;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.UnitTests.Borders.Adapters
{
    public class AddressResponseAdapterTest
    {
        private readonly AddressResponseAdapter _adapter;

        public AddressResponseAdapterTest()
        {
            _adapter = new AddressResponseAdapter();
        }

        [Fact]
        public void ToResponse_Return_GetResponse()
        {
            var response = new AddressBuilder().Build();

            var address = new Address
            {
                Cep = response.ZipCode,
                Logradouro = response.Address,
                Complemento = response.Complement,
                Bairro = response.Neighborhood,
                Uf = response.State,
                Localidade = response.City
            };

            // Act
            var actual = _adapter.ToResponse(address);

            // Assert
            actual.Should().BeEquivalentTo(response);
        }
    }
}
