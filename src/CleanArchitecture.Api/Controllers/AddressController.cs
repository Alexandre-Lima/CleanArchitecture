using CleanArchitecture.Borders.Entities.External;
using CleanArchitecture.Borders.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/address")]
    [ApiController]    
    public class AddressController : Controller
    {
        private readonly IGetAddressByZipCodeUseCase _getAddressesByZipCodeUseCase;

        public AddressController
        (
            IGetAddressByZipCodeUseCase getAddressesByZipCodeUseCase
        )
        {
            _getAddressesByZipCodeUseCase = getAddressesByZipCodeUseCase;
        }

        [HttpGet("zip-code/{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        public async Task<IActionResult> GetAddressByZipCode([FromRoute] string zipCode)
        {
            return Ok(await _getAddressesByZipCodeUseCase.Execute(zipCode));
        }
    }
}
