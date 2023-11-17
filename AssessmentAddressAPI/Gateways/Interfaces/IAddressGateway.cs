using AssessmentAddressAPI.Infrastructure;

namespace AssessmentAddressAPI.Gateways.Interfaces
{
    public interface IAddressGateway
    {
        public IEnumerable<HackneyAddress> GetAddressesByPostCode(string postCode);

    }
}
