using AssessmentAddressAPI.Gateways;
using AssessmentAddressAPI.Infrastructure;
using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace AssessmentAddressAPITests.Gateways
{

    public class AddressGatewayTests
    {
        private AddressGateway _classUnderTest;

        private readonly Fixture _fixture = new Fixture();
        private readonly Random _random = new Random();

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new AddressGateway(MockDbContext.Instance);
        }

        [TearDown]
        public void Teardown()
        {
            MockDbContext.Teardown();
        }


        [Test]
        public async Task GetAddressesByPostCode_WhenNoAddressesFound_ReturnsEmptyArray()
        {
            // Arrange
            var postCode = _fixture.Create<string>();

            // Act
            var result = await _classUnderTest.GetAddressesByPostCode(postCode);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Test]
        public async Task GetAddressesByPostCode_WhenCalled_ReturnsMatchingAddresses()
        {
            // Arrange
            var postCode = _fixture.Create<string>();
            var numberOfAddresses = _random.Next(5, 10);

            var addresses = _fixture
                .Build<HackneyAddress>()
                .CreateMany(numberOfAddresses);

            // One address must match the postCode
            addresses.First().Postcode = postCode;

            // save mock data to db
            MockDbContext.Instance.HackneyAddresses.AddRange(addresses);
            await MockDbContext.Instance.SaveChangesAsync();

            // Act
            var result = await _classUnderTest.GetAddressesByPostCode(postCode);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result.First().Should().BeEquivalentTo(addresses.First());
        }

        [TestCase("N16 6PS")]
        [TestCase("N166PS")]
        [TestCase("n16 6ps")]
        [TestCase("n166ps")]
        [TestCase("   N16 6PS   ")]
        public async Task GetAddressesByPostCode_WhenFormatVariesFromPostCodeInDatabase_ReturnsMatchingAddresses(string postCodeFromRequest)
        {
            // Arrange
            var postCode = "N16 6PS";
            var numberOfAddresses = _random.Next(5, 10);

            var addresses = _fixture
                .Build<HackneyAddress>()
                .CreateMany(numberOfAddresses);

            // One address must match the postCode
            addresses.First().Postcode = postCode;

            // save mock data to db
            MockDbContext.Instance.HackneyAddresses.AddRange(addresses);
            await MockDbContext.Instance.SaveChangesAsync();

            // Act
            var result = await _classUnderTest.GetAddressesByPostCode(postCodeFromRequest);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result.First().Should().BeEquivalentTo(addresses.First());
        }

    }
}
