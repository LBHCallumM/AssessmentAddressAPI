using AssessmentAddressAPI.Domain;
using AssessmentAddressAPI.Infrastructure;
using System.Runtime.CompilerServices;

namespace AssessmentAddressAPI.Factories
{
    public static class DbToDomainFactory
    {
        public static List<Address> ToDomain(this IEnumerable<HackneyAddress> db)
        {
            return db.Select(ToDomain).ToList();
        }

        public static Address ToDomain(this HackneyAddress db)
        {
            return new Address
            {
                Uprn = db.Uprn,
                Street = db.StreetDescription ?? "",
                BuildingNumber = db.BuildingNumber ?? "",
                Locality = db.Locality ?? "",
                Ward = db.Ward ?? "",
                Town = db.Town ?? "",
                PostCode = db.Postcode ?? "",
                AddressLine1 = db.Line1 ?? "",
                AddressLine2 = db.Line2 ?? "",
                AddressLine3 = db.Line3 ?? "",
                AddressLine4 = db.Line4 ?? "",
            };
        }

    }
}
