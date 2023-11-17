using AssessmentAddressAPI.Boundary.Request;
using AssessmentAddressAPI.Boundary.Response;
using AssessmentAddressAPI.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentAddressAPI.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IGetAddressesByPostCodeUseCase _getAddressesUseCase;

        public AddressController(IGetAddressesByPostCodeUseCase getAddressesUseCase)
        {
            _getAddressesUseCase = getAddressesUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses([FromQuery] GetAddressesRequest request)
        {
            var addresses = await _getAddressesUseCase.ExecuteAsync(request);

            var response = new GetAddressesResponse
            {
                Addresses = addresses
            };

            return Ok(response);
        }
    }
}
