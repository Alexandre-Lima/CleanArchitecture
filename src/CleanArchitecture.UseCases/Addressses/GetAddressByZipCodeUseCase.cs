using CleanArchitecture.Borders.Adapters.Interfaces;
using CleanArchitecture.Borders.Constants;
using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.Entities;
using CleanArchitecture.Borders.HttpResponse;
using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.Borders.UseCases;

namespace CleanArchitecture.UseCases.Addressses
{
    public class GetAddressByZipCodeUseCase : IGetAddressByZipCodeUseCase
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IAddressResponseAdapter _adapter;

        public GetAddressByZipCodeUseCase(
            IZipCodeRepository zipCodeRepository,
            IAddressResponseAdapter adapter)
        {
            _zipCodeRepository = zipCodeRepository;
            _adapter = adapter;
        }

        public async Task<UseCaseResponse<AddressResponse>> Execute(string zipCode)
        {
            var response = new UseCaseResponse<AddressResponse>();
            try
            {            
                var address = await _zipCodeRepository.GetAddress(zipCode);
                if (address == null)
                    return response.SetNotFound(MessageConstant.NotFoundAddress);

                return response.SetResult(_adapter.ToResponse(address));
            }
            catch (ArgumentException ex)
            {
                return response.SetBadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return response.SetInternalServerError(ex.Message);
            }
        }
    }
}
