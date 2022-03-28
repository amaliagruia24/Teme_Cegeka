using CarDealership.Data;
using Moq;
using Xunit;
using WebCarDealership.Controllers;
using System.Threading.Tasks;
using CarDealership.Data.Models;
using WebCarDealership.Requests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace WebCarDealershipTests
{
    public class OrderControllerTests
    {

        private readonly Mock<IRepository> repoMock;
        private readonly OrderController controllerSut;

        public OrderControllerTests()
        {
            repoMock = new Mock<IRepository>();
            controllerSut = new OrderController(repoMock.Object);
        }

        [Fact]
        public async Task GivenInvalidCarOfferId_WhenCallingPost_ThenReturnsBadRequest()
        {
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
            var requestModel = new OrderRequestModel();

            var result = await controllerSut.Post(requestModel);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async Task GivenATooBigQuantity_WhenCallingPost_ThenReturnsBadRequest()
        {
            var offer = new CarOffer()
            {
                Id = 1,
                AvailableStock = 0
            };

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 2
            };

            repoMock.Setup(repo => repo.GetCarOfferById(1)).ReturnsAsync(offer);

            var result = await controllerSut.Post(requestModel);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task GivenAValidRequestModel_WhenCallingPost_ThenReturnOk()
        {
            var offer = new CarOffer()
            {
                Id = 1,
                AvailableStock = 1,
            };

            var requestModel = new OrderRequestModel();

            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var result = await controllerSut.Post(requestModel);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GivenInvalidRequestModel_WhenCallinPost_ThenReturnBadRequest()
        {
            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 102
            };

            controllerSut.ModelState.AddModelError("Quantity", "Range Error");

            var result = await controllerSut.Post(requestModel);
            
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}