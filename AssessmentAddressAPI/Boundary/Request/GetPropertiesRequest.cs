using Microsoft.AspNetCore.Mvc;

namespace AssessmentAddressAPI.Boundary.Request
{
    public class GetPropertiesRequest
    {
        [FromQuery(Name = "post_code")]
        public string PostCode { get; set; }
    }
}
