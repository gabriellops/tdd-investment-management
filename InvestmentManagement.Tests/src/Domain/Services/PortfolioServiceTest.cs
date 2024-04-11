using AutoFixture;
using FluentAssertions;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Services;
using InvestmentManagement.Tests.Configs;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;

namespace InvestmentManagement.Tests.src.Domain.Services
{
    [Trait("Service", "Portfolio Service")]
    public class PortfolioServiceTest
    {
        private readonly Fixture _fixture;
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioServiceTest()
        {
            _fixture = FixtureConfig.Get();
            _portfolioRepository = Substitute.For<IPortfolioRepository>();
        }

        [Fact]
        public async Task Get_Portfolio_ReturnsAllPortfolios()
        {
            var entities = _fixture.Create<List<PortfolioEntity>>();

            _portfolioRepository.ListAsync(Arg.Any<Expression<Func<PortfolioEntity, bool>>>())
                                .Returns(entities);

            var service = new PortfolioService(_portfolioRepository);
            var response = await service.GetAllAsync();

            response.ToList().Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task Get_PortfolioById_ReturnsPortfolio()
        {
            var entity = _fixture.Create<PortfolioEntity>();

            _portfolioRepository.FindAsync(Arg.Any<Expression<Func<PortfolioEntity, bool>>>())
                                .Returns(entity);

            var service = new PortfolioService(_portfolioRepository);
            var response = await service.GetByIdAsync(entity.Id);

            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post_Portfolio_ShouldBeRegisteredPortfolio()
        {
            var entity = _fixture.Create<PortfolioEntity>();

            _portfolioRepository.AddAsync(Arg.Any<PortfolioEntity>())
                                .Returns(Task.CompletedTask);

            var service = new PortfolioService(_portfolioRepository);

            try
            {
                await service.AddAsync(entity);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async Task Put_Portfolio_ShouldBeEditedPortfolio()
        {
            var entity = _fixture.Create<PortfolioEntity>();

            _portfolioRepository.FindAsNoTrackingAsync(Arg.Any<Expression<Func<PortfolioEntity, bool>>>())
                                .Returns(entity);

            _portfolioRepository.EditAsync(Arg.Any<PortfolioEntity>())
                                .Returns(Task.CompletedTask);

            var service = new PortfolioService(_portfolioRepository);

            try
            {
                await service.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async Task Delete_Portfolio_ShouldBeDeletedPortfolio()
        {
            var entity = _fixture.Create<PortfolioEntity>();

            _portfolioRepository.FindAsync(Arg.Any<int>())
                                .Returns(entity);

            _portfolioRepository.RemoveAsync(Arg.Any<PortfolioEntity>())
                                .Returns(Task.CompletedTask);

            var service = new PortfolioService(_portfolioRepository);

            try
            {
                await service.DeleteAsync(entity.Id);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }
}
