using AssessmentAddressAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace AssessmentAddressAPITests
{
    public static class MockDbContext
    {
        private static AddressDbContext _context;

        public static AddressDbContext Instance
        {
            get
            {
                if (_context == null)
                {
                    var builder = new DbContextOptionsBuilder<AddressDbContext>();

                    builder.UseInMemoryDatabase(Guid.NewGuid().ToString(), db => db.EnableNullChecks(false));

                    _context = new AddressDbContext(builder.Options);
                    _context.Database.EnsureCreated();
                }
                return _context;
            }
        }

        public static void Teardown()
        {
            _context = null;
        }
    }
}
