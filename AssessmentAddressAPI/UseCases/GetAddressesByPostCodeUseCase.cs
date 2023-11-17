using AssessmentAddressAPI.Boundary.Request;
using AssessmentAddressAPI.Domain;
using AssessmentAddressAPI.UseCases.Interfaces;

namespace AssessmentAddressAPI.UseCases
{
    public class GetAddressesByPostCodeUseCase : IGetAddressesByPostCodeUseCase
    {
        public Task<IEnumerable<Address>> ExecuteAsync(GetPropertiesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
