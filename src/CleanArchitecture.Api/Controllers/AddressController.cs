using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.Borders.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/address")]
    [ApiController]    
    public class AddressController : Controller
    {
        private readonly IGetAddressByZipCodeUseCase _getAddressesByZipCodeUseCase;
        private readonly IStateRepository _stateRepository;

        public AddressController
        (
            IGetAddressByZipCodeUseCase getAddressesByZipCodeUseCase,
            IStateRepository stateRepository
        )
        {
            _getAddressesByZipCodeUseCase = getAddressesByZipCodeUseCase;
            _stateRepository = stateRepository;
        }

        [HttpGet("zip-code/{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressResponse))]
        public async Task<IActionResult> GetAddressByZipCode([FromRoute] string zipCode)
        {
            return Ok(await _getAddressesByZipCodeUseCase.Execute(zipCode));
        }

        [HttpGet("state/{uf}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StateResponse))]
        public async Task<IActionResult> GetStateByZipCode([FromRoute] string uf)
        {
            return Ok(await _stateRepository.GetState(uf));
        }

        [HttpGet("states")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StateResponse))]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await _stateRepository.GetStates());
        }
    }
}
