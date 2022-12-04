using CleanArchitecture.Borders.Adapters.Interfaces;
using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.Borders.UseCases;

namespace CleanArchitecture.UseCases.Addressses
{
    public class GetAddressByZipCodeUseCase: IGetAddressByZipCodeUseCase
    {
        private readonly IZipCodeRepository  _zipCodeRepository;
        private readonly IAddressResponseAdapter _adapter;

        public GetAddressByZipCodeUseCase(
            IZipCodeRepository zipCodeRepository,
            IAddressResponseAdapter adapter)
        {
            _zipCodeRepository = zipCodeRepository;
            _adapter = adapter;
        }

        public async Task<AddressResponse> Execute(string zipCode)
        {
            var address =  await _zipCodeRepository.GetAddress(zipCode);

            return _adapter.ToResponse(address);
        }
    }
}
