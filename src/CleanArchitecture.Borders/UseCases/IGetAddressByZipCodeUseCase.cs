using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.HttpResponse;

namespace CleanArchitecture.Borders.UseCases
{
    public interface IGetAddressByZipCodeUseCase
    {
        Task<UseCaseResponse<AddressResponse>> Execute(string zipCode);
    }
}
