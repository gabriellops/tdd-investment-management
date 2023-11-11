using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Settings;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;

namespace InvestmentManagement.Tests.src.Domain.Services
{
    [Trait("Service", "User Service")]
    public class UserServiceTest
    {
        [Fact]
        public async Task Get_Users_ReturnsAllUsers()
        {
            var entities = _fixture.Create<List<UserEntity>>();

            var userRepository = Substitute.For<IUserRepository>();
            userRepository.ListAsync(Arg.Any<Expression<Func<UserEntity, bool>>>())
                          .ReturnsForAnyArgsAsync(entities);

            var mockAppSetting = Substitute.For<AppSetting>;

            var service = new UserService(userRepository, mockAppSetting, mockAppSetting);
            var response = await service.ObterTodosAsync();

            response.Should().Be.True(response.ToList().Count() > 0);
        }
    }
}
