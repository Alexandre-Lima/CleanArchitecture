using CleanArchitecture.Borders.Entities.External;
using CleanArchitecture.Borders.Repositories;

namespace CleanArchitecture.Repositories
{
    public class ZipCodeRepository : ApiRepository, IZipCodeRepository
    {
        public ZipCodeRepository(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public Task<Address> GetAnddress(string zipCode)
        {
            return GetAsync<Address>($"{zipCode}/json");
        }
    }
}
