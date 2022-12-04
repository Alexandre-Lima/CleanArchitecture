using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.Entities;

namespace CleanArchitecture.Borders.Repositories
{
    public interface IZipCodeRepository
    {
        Task<Address> GetAddress(string zipCode);
    }
}
