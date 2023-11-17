namespace AssessmentAddressAPI.Domain
{
    public class Address
    {
        public long Uprn { get; set; }


        public string Street { get; set; }
        public string BuildingNumber { get; set; }

        public string Locality { get; set; }
        public string Ward { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
    }
}
