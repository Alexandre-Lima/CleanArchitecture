using CleanArchitecture.Api.Models;
using CleanArchitecture.Borders.Dtos.Addressses;
using CleanArchitecture.Borders.HttpResponse.Models;
using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.Borders.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/address")]
    [ApiController]    
    public class AddressController : ControllerBase
    {
        private readonly IGetAddressByZipCodeUseCase _getAddressesByZipCodeUseCase;
        private readonly IActionResultConverter _actionResultConverter;
        private readonly IStateRepository _stateRepository;

        public AddressController
        (
            IActionResultConverter actionResultConverter,
            IGetAddressByZipCodeUseCase getAddressesByZipCodeUseCase,
            IStateRepository stateRepository
        )
        {
            _actionResultConverter = actionResultConverter;
            _getAddressesByZipCodeUseCase = getAddressesByZipCodeUseCase;
            _stateRepository = stateRepository;
        }

        [HttpGet("zip-code/{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> GetAddressByZipCode([FromRoute] string zipCode)
        {
            return _actionResultConverter.Convert(await _getAddressesByZipCodeUseCase.Execute(zipCode));
        }

        [HttpGet("state/{uf}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StateResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> GetStateByZipCode([FromRoute] string uf)
        {
            return Ok(await _stateRepository.GetState(uf));
        }

        [HttpGet("states")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StateResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await _stateRepository.GetStates());
        }
    }
}
