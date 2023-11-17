using AssessmentAddressAPI.Gateways.Interfaces;
using AssessmentAddressAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace AssessmentAddressAPI.Gateways
{
    public class AddressGateway : IAddressGateway
    {
        private readonly AddressDbContext _context;

        public AddressGateway(AddressDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HackneyAddress>> GetAddressesByPostCode(string postCode)
        {
            var normalisedPostCode = NormalisePostCode(postCode);

            return await _context.HackneyAddresses
                // Using helper method doesnt translate to database
                .Where(x => x.Postcode.Replace(" ", "").ToLower() == normalisedPostCode)
                .ToListAsync();
        }

        private static string NormalisePostCode(string postCode)
        {
            return postCode.Replace(" ", "").ToLower();
        }
    }
}
