using CleanArchitecture.Borders.Entities.External;

namespace CleanArchitecture.Borders.Repositories
{
    public interface IZipCodeRepository
    {
        Task<Address> GetAnddress(string id);
    }
}
