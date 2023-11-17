using AssessmentAddressAPI.Infrastructure;

namespace AssessmentAddressAPI.Gateways.Interfaces
{
    public interface IAddressGateway
    {
        public Task<IEnumerable<HackneyAddress>> GetAddressesByPostCode(string postCode);

    }
}
