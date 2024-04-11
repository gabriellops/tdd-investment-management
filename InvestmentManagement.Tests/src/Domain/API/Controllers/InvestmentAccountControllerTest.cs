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
    [Trait("Controller", "InvestmentAccount Controller")]
    public class InvestmentAccountControllerTest
    {
        private readonly Fixture _fixture;
        private readonly IInvestmentAccountService _investmentAccountService;
        private readonly IMapper _mapper;

        public InvestmentAccountControllerTest()
        {
            _fixture = FixtureConfig.Get();
            _investmentAccountService = Substitute.For<IInvestmentAccountService>();
            _mapper = MapConfig.Get();
        }

        [Fact]
        public async Task GetAsync()
        {
            var entities = _fixture.Create<List<InvestmentAccountEntity>>();

            _investmentAccountService.GetAllAsync()
                        .Returns(entities);

            var controller = new InvestmentAccountController(_investmentAccountService, _mapper);

            var actionResult = await controller.GetAsync();

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<List<InvestmentAccountResponse>>().Subject;

            response.Should().NotBeNull();
            response.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetById()
        {
            var entity = _fixture.Create<InvestmentAccountEntity>();

            _investmentAccountService.GetByIdAsync(Arg.Any<int>())
                        .Returns(entity);

            var controller = new InvestmentAccountController(_investmentAccountService, _mapper);

            var actionResult = await controller.GetByIdAsync(entity.Id);

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<InvestmentAccountResponse>().Subject;

            response.Should().NotBeNull();
            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post()
        {
            var request = _fixture.Create<InvestmentAccountRequest>();

            _investmentAccountService.AddAsync(Arg.Any<InvestmentAccountEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new InvestmentAccountController(_investmentAccountService, _mapper);

            var actionResult = await controller.PostAsync(request);

            actionResult.Should().BeOfType<CreatedResult>().Which.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task Put()
        {
            var id = _fixture.Create<int>();
            var request = _fixture.Create<InvestmentAccountRequest>();

            _investmentAccountService.UpdateAsync(Arg.Any<InvestmentAccountEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new InvestmentAccountController(_investmentAccountService, _mapper);

            var actionResult = await controller.PutAsync(id, request);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _investmentAccountService.DeleteAsync(Arg.Any<int>())
                        .Returns(Task.CompletedTask);

            var controller = new InvestmentAccountController(_investmentAccountService, _mapper);

            var actionResult = await controller.DeleteAsync(id);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }
    }
}
