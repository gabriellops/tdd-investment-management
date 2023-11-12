using AutoFixture;
using AutoMapper;
using Azure.Core;
using FluentAssertions;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Domain.Services;
using InvestmentManagement.Domain.Settings;
using InvestmentManagement.Tests.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;

namespace InvestmentManagement.Tests.API.Controllers
{
    [Trait("Controller", "User Controller")]
    public class UserControllerTest
    {
        private readonly Fixture _fixture;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserControllerTest()
        {
            _fixture = FixtureConfig.Get();
            _userService = Substitute.For<IUserService>();
            _mapper = MapConfig.Get();
        }

        [Fact]
        public async Task GetAsync()
        {
            var entities = _fixture.Create<List<UserEntity>>();

            _userService.GetAllAsync()
                        .Returns(entities);

            var controller = new UserController(_userService, _mapper);

            var actionResult = await controller.GetAsync();

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<List<UserResponse>>().Subject;

            response.Should().NotBeNull();
            response.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetById()
        {
            var entity = _fixture.Create<UserEntity>();

            _userService.GetByIdUserAsync(Arg.Any<int>())
                        .Returns(entity);

            var controller = new UserController(_userService, _mapper);

            var actionResult = await controller.GetByIdAsync(entity.Id);

            var response = (actionResult.Result as OkObjectResult)?.Value.Should().BeAssignableTo<UserResponse>().Subject;

            response.Should().NotBeNull();
            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post()
        {
            var request = _fixture.Create<UserRequest>();

            _userService.AddAsync(Arg.Any<UserEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new UserController(_userService, _mapper);

            var actionResult = await controller.PostAsync(request);

            actionResult.Should().BeOfType<CreatedResult>().Which.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task Put()
        {
            var id = _fixture.Create<int>();
            var request = _fixture.Create<UserRequest>();

            _userService.UpdateAsync(Arg.Any<UserEntity>())
                        .Returns(Task.CompletedTask);

            var controller = new UserController(_userService, _mapper);

            var actionResult = await controller.PutAsync(id, request);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _userService.DeleteAsync(Arg.Any<int>())
                        .Returns(Task.CompletedTask);

            var controller = new UserController(_userService, _mapper);

            var actionResult = await controller.DeleteAsync(id);

            actionResult.Should().BeOfType<NoContentResult>().Which.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }
    }
}
