using AutoFixture;
using FluentAssertions;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Services;
using InvestmentManagement.Domain.Settings;
using InvestmentManagement.Tests.Configs;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;

namespace InvestmentManagement.Tests.src.Domain.Services
{
    [Trait("Service", "User Service")]
    public class UserServiceTest
    {
        private readonly Fixture _fixture;
        private readonly IUserRepository _userRepository;
        private readonly AppSetting _appSetting;

        public UserServiceTest()
        {
            _fixture = FixtureConfig.Get();
            _userRepository = Substitute.For<IUserRepository>();
            _appSetting = Substitute.For<AppSetting>();
        }

        [Fact]
        public async Task Get_Users_ReturnsAllUsers()
        {
            var entities = _fixture.Create<List<UserEntity>>();

            var userRepository = Substitute.For<IUserRepository>();
            userRepository.ListAsync(Arg.Any<Expression<Func<UserEntity, bool>>>())
                          .ReturnsForAnyArgs(entities);

            var mockAppSetting = Substitute.For<AppSetting>();

            var service = new UserService(userRepository, mockAppSetting);
            var response = await service.GetAllAsync();

            response.ToList().Count().Should().BeGreaterThan(0);
        }
    }
}
