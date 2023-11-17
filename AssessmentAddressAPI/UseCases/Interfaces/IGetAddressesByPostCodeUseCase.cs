using AssessmentAddressAPI.Boundary.Request;
using AssessmentAddressAPI.Domain;

namespace AssessmentAddressAPI.UseCases.Interfaces
{
    public interface IGetAddressesByPostCodeUseCase
    {
        public Task<IEnumerable<Address>> ExecuteAsync(GetPropertiesRequest request);
    }
}
