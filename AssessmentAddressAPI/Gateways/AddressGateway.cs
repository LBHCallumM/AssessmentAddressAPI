using AssessmentAddressAPI.Gateways.Interfaces;
using AssessmentAddressAPI.Infrastructure;

namespace AssessmentAddressAPI.Gateways
{
    public class AddressGateway : IAddressGateway
    {
        public IEnumerable<HackneyAddress> GetAddressesByPostCode(string postCode)
        {
            throw new NotImplementedException();
        }
    }
}
