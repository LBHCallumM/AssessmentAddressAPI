using AssessmentAddressAPI.Boundary.Request;
using AssessmentAddressAPI.Domain;

namespace AssessmentAddressAPI.UseCases.Interfaces
{
    public interface IGetAddressesByPostCodeUseCase
    {
        public Task<List<Address>> ExecuteAsync(GetAddressesRequest request);
    }
}
