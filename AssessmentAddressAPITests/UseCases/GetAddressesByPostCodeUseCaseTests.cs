using AssessmentAddressAPI.Boundary.Request;
using AssessmentAddressAPI.Factories;
using AssessmentAddressAPI.Gateways.Interfaces;
using AssessmentAddressAPI.Infrastructure;
using AssessmentAddressAPI.UseCases;
using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentAddressAPITests.UseCases
{
    public class GetAddressesByPostCodeUseCaseTests
    {
        private GetAddressesByPostCodeUseCase _classUnderTest;
        private Mock<IAddressGateway> _addressGatewayMock;

        private readonly Fixture _fixture = new Fixture();
        private readonly Random _random = new Random();

        [SetUp]
        public void Setup()
        {
            _addressGatewayMock = new Mock<IAddressGateway>();

            _classUnderTest = new GetAddressesByPostCodeUseCase(
                _addressGatewayMock.Object
            );
        }

        [Test]
        public async Task ExecuteAsync_WhenCalled_ReturnsAddressesFromGateway()
        {
            // Arrange
            var request = new GetAddressesRequest
            {
                PostCode = _fixture.Create<string>()
            };

            var numberOfAddresses = _random.Next(5, 10);

            var gatewayResponse = _fixture.Build<HackneyAddress>()
                .CreateMany(numberOfAddresses);

            _addressGatewayMock
                .Setup(x => x.GetAddressesByPostCode(It.IsAny<string>()))
                .ReturnsAsync(gatewayResponse);

            // Act
            var response = await _classUnderTest.ExecuteAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.Should().HaveCount(numberOfAddresses);
            response.Should().BeEquivalentTo(gatewayResponse.ToDomain());

            _addressGatewayMock
                .Verify(x => x.GetAddressesByPostCode(request.PostCode), Times.Once);
        }
    }
}
