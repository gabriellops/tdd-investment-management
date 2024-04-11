using AutoFixture;
using AutoMapper;
using FluentAssertions;
using InvestmentManagement.API.Controllers;
using InvestmentManagement.Domain.Contracts.Requests;
using InvestmentManagement.Domain.Contracts.Responses;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Tests.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace InvestmentManagement.Tests.API.Controllers
{
    [Trait("Controller", "Portfolio Controller")]
    public class PortfolioControllerTest
    {
        private readonly Fixture _fixture;
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public PortfolioControllerTest()
        {
            _fixture = FixtureConfig.Get();
            _portfolioService = Substitute.For<IPortfolioService>();
            _mapper = MapConfig.Get();
        }

        [Fact]
        public async Task GetAsync()
        {
            var entities = _fixture.Create<List<PortfolioEntity>>();

            _portfolioService.GetAllAsync()
                        .Returns(entities);

            var controller = new PortfolioController(_portfolioService, _mapper);

            var actionResult = await controller.GetAsync();

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<List<PortfolioResponse>>().Subject;

            response.Should().NotBeNull();
            response.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetById()
        {
            var entity = _fixture.Create<PortfolioEntity>();

            _portfolioService.GetByIdAsync(Arg.Any<int>())
                        .Returns(entity);

            var controller = new PortfolioController(_portfolioService, _mapper);

            var actionResult = await controller.GetByIdAsync(entity.Id);

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<PortfolioResponse>().Subject;

            response.Should().NotBeNull();
            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post()
        {
            var request = _fixture.Create<PortfolioRequest>();

            _portfolioService.AddAsync(Arg.Any<PortfolioEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new PortfolioController(_portfolioService, _mapper);

            var actionResult = await controller.PostAsync(request);

            actionResult.Should().BeOfType<CreatedResult>().Which.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task Put()
        {
            var id = _fixture.Create<int>();
            var request = _fixture.Create<PortfolioRequest>();

            _portfolioService.UpdateAsync(Arg.Any<PortfolioEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new PortfolioController(_portfolioService, _mapper);

            var actionResult = await controller.PutAsync(id, request);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _portfolioService.DeleteAsync(Arg.Any<int>())
                        .Returns(Task.CompletedTask);

            var controller = new PortfolioController(_portfolioService, _mapper);

            var actionResult = await controller.DeleteAsync(id);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }
    }
}
