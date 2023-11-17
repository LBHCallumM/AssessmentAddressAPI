using AssessmentAddressAPI.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentAddressAPITests.Validation
{
    public class PostCodeValidatorTests
    {


        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void IsValidPostCode_WhenEmptyString_ReturnsFalse(string postCode)
        {
            // Arrange

            // Act
            var result = PostCodeValidator.IsValidPostCode(postCode);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("wx 2iP")]
        [TestCase("u6 ug9")]
        [TestCase("b9 bwY")]
        [TestCase("awevI")]
        [TestCase("gIfto")]
        public void IsValidPostCode_WhenInvalid_ReturnsFalse(string postCode)
        {
            // Arrange

            // Act
            var result = PostCodeValidator.IsValidPostCode(postCode);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("N16PS")]
        [TestCase("  m88EZ  ")]
        [TestCase("f38Tz")]
        [TestCase("G65JT")]
        [TestCase("T47Xh")]
        public void IsValidPostCode_WhenValid_ReturnsTrue(string postCode)
        {
            // Arrange

            // Act
            var result = PostCodeValidator.IsValidPostCode(postCode);

            // Assert
            result.Should().BeTrue();
        }
    }
}
