using AssessmentAddressAPI.Boundary.Request;
using AssessmentAddressAPI.Domain;
using AssessmentAddressAPI.Factories;
using AssessmentAddressAPI.Gateways.Interfaces;
using AssessmentAddressAPI.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AssessmentAddressAPI.UseCases
{
    public class GetAddressesByPostCodeUseCase : IGetAddressesByPostCodeUseCase
    {
        private readonly IAddressGateway _gateway;

        public GetAddressesByPostCodeUseCase(IAddressGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<List<Address>> ExecuteAsync(GetAddressesRequest request)
        {
            var addresses = await _gateway.GetAddressesByPostCode(request.PostCode);

            return addresses.ToDomain();
        }
    }
}
