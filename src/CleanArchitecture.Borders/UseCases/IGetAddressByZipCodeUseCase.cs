using CleanArchitecture.Borders.Dtos.Addressses;

namespace CleanArchitecture.Borders.UseCases
{
    public interface IGetAddressByZipCodeUseCase
    {
        Task<AddressResponse> Execute(string zipCode);
    }
}
