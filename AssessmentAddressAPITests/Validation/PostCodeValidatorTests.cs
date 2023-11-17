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
        [TestCase("aw evI")]
        [TestCase("gI fto")]
        public void IsValidPostCode_WhenInvalid_ReturnsFalse(string postCode)
        {
            // Arrange

            // Act
            var result = PostCodeValidator.IsValidPostCode(postCode);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("m8 8EZ")]
        [TestCase("f3 8Tz")]
        [TestCase("G6 5JT")]
        [TestCase("V6 5Oh")]
        [TestCase("T4 7Xh")]
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
