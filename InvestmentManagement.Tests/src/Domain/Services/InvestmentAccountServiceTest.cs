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
    [Trait("Service", "Investment Account Service")]
    public class InvestmentAccountServiceTest
    {
        private readonly Fixture _fixture;
        private readonly IInvestmentAccountRepository _investmentAccountRepository;
        private readonly AppSetting _appSetting;

        public InvestmentAccountServiceTest()
        {
            _fixture = FixtureConfig.Get();
            _investmentAccountRepository = Substitute.For<IInvestmentAccountRepository>();
            _appSetting = Substitute.For<AppSetting>();
        }

        [Fact]
        public async Task Get_InvestmentAccount_ReturnsAllInvestmentAccounts()
        {
            var entities = _fixture.Create<List<InvestmentAccountEntity>>();

            _investmentAccountRepository.ListAsync(Arg.Any<Expression<Func<InvestmentAccountEntity, bool>>>())
                           .Returns(entities);

            var service = new InvestmentAccountService(_investmentAccountRepository);
            var response = await service.GetAllAsync();

            response.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task Get_InvestmentAccountById_ReturnsInvestmentAccount()
        {
            var entity = _fixture.Create<InvestmentAccountEntity>();

            _investmentAccountRepository.FindAsync(Arg.Any<Expression<Func<InvestmentAccountEntity, bool>>>())
                           .Returns(entity);

            var service = new InvestmentAccountService(_investmentAccountRepository);
            var response = await service.GetByIdAsync(entity.Id);

            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post_InvestmentAccount_ShouldBeRegisteredInvestmentAccount()
        {
            var entity = _fixture.Create<InvestmentAccountEntity>();

            _investmentAccountRepository.AddAsync(Arg.Any<InvestmentAccountEntity>())
                           .Returns(Task.CompletedTask);

            var service = new InvestmentAccountService(_investmentAccountRepository);

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
        public async Task Put_InvestmentAccount_ShouldBeEditedInvestmentAccount()
        {
            var entity = _fixture.Create<InvestmentAccountEntity>();

            _investmentAccountRepository.FindAsNoTrackingAsync(Arg.Any<Expression<Func<InvestmentAccountEntity, bool>>>())
                           .Returns(entity);

            _investmentAccountRepository.EditAsync(Arg.Any<InvestmentAccountEntity>())
                           .Returns(Task.CompletedTask);

            var service = new InvestmentAccountService(_investmentAccountRepository);

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
        public async Task Delete_InvestmentAccount_ShouldBeDeletedInvestmentAccount()
        {
            var entity = _fixture.Create<InvestmentAccountEntity>();

            _investmentAccountRepository.FindAsync(Arg.Any<int>())
                           .Returns(entity);

            _investmentAccountRepository.RemoveAsync(Arg.Any<InvestmentAccountEntity>())
                           .Returns(Task.CompletedTask);

            var service = new InvestmentAccountService(_investmentAccountRepository);

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
