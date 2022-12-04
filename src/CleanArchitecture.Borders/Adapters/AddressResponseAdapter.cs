using CleanArchitecture.Borders.Adapters.Interfaces;
using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.Entities;

namespace CleanArchitecture.Borders.Adapters
{
    public class AddressResponseAdapter : IAddressResponseAdapter
    {
        public AddressResponse ToResponse(Address address)
        {

            return new AddressResponse
            {
                ZipCode = address.Cep,
                Address = address.Logradouro,
                Complement = address.Complemento,
                Neighborhood = address.Bairro,
                State = address.Uf,
                City = address.Localidade
            };
        }
    }
}
