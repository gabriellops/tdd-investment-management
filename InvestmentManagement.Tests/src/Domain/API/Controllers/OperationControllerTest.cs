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
    [Trait("Controller", "Operation Controller")]
    public class OperationControllerTest
    {
        private readonly Fixture _fixture;
        private readonly IOperationService _operationService;
        private readonly IMapper _mapper;

        public OperationControllerTest()
        {
            _fixture = FixtureConfig.Get();
            _operationService = Substitute.For<IOperationService>();
            _mapper = MapConfig.Get();
        }

        [Fact]
        public async Task GetAsync()
        {
            var entities = _fixture.Create<List<OperationEntity>>();

            _operationService.GetAllAsync()
                        .Returns(entities);

            var controller = new OperationController(_operationService, _mapper);

            var actionResult = await controller.GetAsync();

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<List<OperationResponse>>().Subject;

            response.Should().NotBeNull();
            response.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetById()
        {
            var entity = _fixture.Create<OperationEntity>();

            _operationService.GetByIdAsync(Arg.Any<int>())
                        .Returns(entity);

            var controller = new OperationController(_operationService, _mapper);

            var actionResult = await controller.GetByIdAsync(entity.Id);

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<OperationResponse>().Subject;

            response.Should().NotBeNull();
            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post()
        {
            var request = _fixture.Create<OperationRequest>();

            _operationService.AddAsync(Arg.Any<OperationEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new OperationController(_operationService, _mapper);

            var actionResult = await controller.PostAsync(request);

            actionResult.Should().BeOfType<CreatedResult>().Which.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task Put()
        {
            var id = _fixture.Create<int>();
            var request = _fixture.Create<OperationRequest>();

            _operationService.UpdateAsync(Arg.Any<OperationEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new OperationController(_operationService, _mapper);

            var actionResult = await controller.PutAsync(id, request);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _operationService.DeleteAsync(Arg.Any<int>())
                        .Returns(Task.CompletedTask);

            var controller = new OperationController(_operationService, _mapper);

            var actionResult = await controller.DeleteAsync(id);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }
    }
}
