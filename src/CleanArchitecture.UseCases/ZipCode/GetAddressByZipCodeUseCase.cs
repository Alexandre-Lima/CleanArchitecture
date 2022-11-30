using CleanArchitecture.Borders.Entities.External;
using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.Borders.UseCases;

namespace CleanArchitecture.UseCases.ZipCode
{
    public class GetAddressByZipCodeUseCase: IGetAddressByZipCodeUseCase
    {
        private readonly IZipCodeRepository  _zipCodeRepository;

        public GetAddressByZipCodeUseCase(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public async Task<Address> Execute(string reques)
        {
            return await _zipCodeRepository.GetAnddress(reques);
        }
    }
}
