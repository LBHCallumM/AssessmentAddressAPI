using AssessmentAddressAPI.Boundary.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AssessmentAddressAPI.Boundary.Request
{
    public class GetAddressesRequest
    {
        [FromQuery(Name = "post_code")]
        [Required]
        [PostcodeValidation]
        public string PostCode { get; set; }
    }
}
