using CleanArchitecture.Borders.Entities.External;

namespace CleanArchitecture.Borders.UseCases
{
    public interface IGetAddressByZipCodeUseCase
    {
        Task<Address> Execute(string reques);
    }
}
