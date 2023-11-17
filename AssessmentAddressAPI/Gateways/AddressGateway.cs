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
            return await _context.HackneyAddresses
                .Where(x => x.Postcode == postCode)
                .ToListAsync();
        }
    }
}
