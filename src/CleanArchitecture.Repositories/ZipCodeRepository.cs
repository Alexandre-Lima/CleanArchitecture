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

        public async Task<Address> GetAddress(string zipCode)
        {
            var endereco = await GetAsync<Address>($"{zipCode}/json");
            if (endereco?.Localidade == null)
                return null;
            return endereco;
        }
    }
}
