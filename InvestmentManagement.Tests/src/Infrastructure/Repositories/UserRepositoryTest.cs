using AutoFixture;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Infrastructure.Contexts;
using InvestmentManagement.Infrastructure.Repositories;
using InvestmentManagement.Tests.Configs;
using Microsoft.EntityFrameworkCore;
using MockQueryable.NSubstitute;
using NSubstitute;
using Xunit;

namespace InvestmentManagement.Tests.src.Infrastructure.Repositories
{
    [Trait("Repository", "User Repository")]
    public class UserRepositoryTest
    {
        private readonly Fixture _fixture;
        public readonly InvestmentContext _context;

        public UserRepositoryTest()
        {
            _fixture = FixtureConfig.Get();
            _context = Substitute.For<InvestmentContext>();
        }

        [Fact]
        public async Task Get_Users_ReturnsListAllUsers()
        {
        }
    }
}
