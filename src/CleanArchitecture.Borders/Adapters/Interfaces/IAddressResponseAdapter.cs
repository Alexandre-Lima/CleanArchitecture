using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.Entities;

namespace CleanArchitecture.Borders.Adapters.Interfaces
{
    public interface IAddressResponseAdapter
    {
        AddressResponse ToResponse(Address address);
    }
}
