using AssessmentAddressAPI.Boundary.Response;
using AssessmentAddressAPI.Factories;
using AssessmentAddressAPI.Infrastructure;
using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;

namespace AssessmentAddressAPITests.E2E
{
    public class GetAddressesE2ETests : MockWebApplicationFactory
    {
        public HttpClient Client => CreateClient();

        private readonly Fixture _fixture = new Fixture();
        private readonly Random _random = new Random();

        [Test]
        public async Task GetAddresses_WhenInvalidPostCode_ReturnsBadRequest()
        {
            // Arrange
            var url = new Uri($"/api/addresses?post_code=abcd", UriKind.Relative);

            // Act
            var response = await Client.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task GetAddresses_WhenNoResultsFound_Returns200()
        {
            // Arrange
            var url = new Uri($"/api/addresses?post_code=N16PS", UriKind.Relative);

            // Act
            var response = await Client.GetAsync(url);

            var stringResult = await response.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<GetAddressesResponse>(stringResult);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseContent.Should().NotBeNull();
            responseContent.Addresses.Should().BeEmpty();
        }

        [Test]
        public async Task GetAddresses_WhenResultsFound_Returns200()
        {
            // Arrange
            var postCode = "N16PS";
            var postCodeInDatabaseFormat = "N1 6PS";

            var numberOfAddresses = _random.Next(5, 10);

            var addresses = _fixture.Build<HackneyAddress>()
                .With(x => x.Postcode, postCodeInDatabaseFormat)
                .CreateMany(numberOfAddresses);

            using var dbContext = CreateDbContext();

            dbContext.HackneyAddresses.AddRange(addresses);
            await dbContext.SaveChangesAsync();


            var url = new Uri($"/api/addresses?post_code={postCode}", UriKind.Relative);

            // Act

            var response = await Client.GetAsync(url);

            var stringResult = await response.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<GetAddressesResponse>(stringResult);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseContent.Should().NotBeNull();
            responseContent.Addresses.Should().HaveCount(numberOfAddresses);

            responseContent.Addresses.Should().BeEquivalentTo(addresses.ToDomain());
        }
    }
}
