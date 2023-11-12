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

            _userRepository.ListAsync(Arg.Any<Expression<Func<UserEntity, bool>>>())
                          .ReturnsForAnyArgs(entities);

            var service = new UserService(_userRepository, _appSetting);
            var response = await service.GetAllAsync();

            response.ToList().Count().Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task Get_UserById_ReturnsUser()
        {
            var entity = _fixture.Create<UserEntity>();

            _userRepository.FindAsync(Arg.Any<Expression<Func<UserEntity, bool>>>())
                           .ReturnsForAnyArgs(entity);

            var service = new UserService(_userRepository, _appSetting);
            var response = await service.GetByIdAsync(entity.Id);

            response.Id.Should().Be(entity.Id);
        }
    }
}
