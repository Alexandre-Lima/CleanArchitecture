using CleanArchitecture.Borders.Entities;
using CleanArchitecture.Borders.Repositories;

namespace CleanArchitecture.Repositories
{
    public class ZipCodeRepository : ApiRepository, IZipCodeRepository
    {
        public ZipCodeRepository(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public Task<Address> GetAddress(string zipCode)
        {
            return GetAsync<Address>($"{zipCode}/json");
        }
    }
}
