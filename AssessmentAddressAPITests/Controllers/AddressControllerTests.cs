using AssessmentAddressAPI.Boundary.Request;
using AssessmentAddressAPI.Controllers;
using AssessmentAddressAPI.UseCases.Interfaces;
using AutoFixture;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentAddressAPI.Boundary.Response;
using System.Net;
using FluentAssertions;
using AssessmentAddressAPI.Domain;

namespace AssessmentAddressAPITests.Controllers
{
    public abstract class ControllerTests
    {
        protected static T GetResultData<T>(IActionResult result)
        {
            return (T)(result as ObjectResult)?.Value;
        }

        protected static int? GetStatusCode(IActionResult result)
        {
            return (result as IStatusCodeActionResult).StatusCode;
        }
    }

    public class AddressControllerTests : ControllerTests
    {
        private AddressController _classUnderTest;
        private Mock<IGetAddressesByPostCodeUseCase> _getAddressesByPostCodeUseCaseMock;

        private readonly Fixture _fixture = new Fixture();
        private readonly Random _random = new Random();


        [SetUp]
        public void Setup()
        {
            _getAddressesByPostCodeUseCaseMock = new Mock<IGetAddressesByPostCodeUseCase>();

            _classUnderTest = new AddressController(
                _getAddressesByPostCodeUseCaseMock.Object
            );
        }

        [Test]
        public async Task GetAddresses_WhenCalled_ReturnsAddresses()
        {
            // Arrange
            var request = _fixture.Create<GetAddressesRequest>();

            var numberOfResults = _random.Next(5, 10);
            var useCaseResponse = _fixture
                .Build<Address>()
                .CreateMany(numberOfResults).ToList();

            _getAddressesByPostCodeUseCaseMock
                .Setup(x => x.ExecuteAsync(It.IsAny<GetAddressesRequest>()))
                .ReturnsAsync(useCaseResponse);

            // Act
            var result = await _classUnderTest.GetAddresses(request);
            var addressResult = GetResultData<GetAddressesResponse>(result);
            var statusCode = GetStatusCode(result);

            // Assert
            statusCode.Should().Be((int)HttpStatusCode.OK);

            addressResult.Should().NotBeNull();
            addressResult.Addresses.Should().HaveCount(numberOfResults);

            addressResult.Addresses.Should().BeEquivalentTo(useCaseResponse);
        }
    }
}
