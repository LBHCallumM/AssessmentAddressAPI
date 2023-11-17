using AssessmentAddressAPI.Domain;

namespace AssessmentAddressAPI.Boundary.Response
{
    public class GetAddressesResponse
    {
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
