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
    [Trait("Service", "Operation Service")]
    public class OperationServiceTest
    {
        private readonly Fixture _fixture;
        private readonly IOperationRepository _operationRepository;

        public OperationServiceTest()
        {
            _fixture = FixtureConfig.Get();
            _operationRepository = Substitute.For<IOperationRepository>();
        }

        [Fact]
        public async Task Get_Operation_ReturnsAllOperations()
        {
            var entities = _fixture.Create<List<OperationEntity>>();

            _operationRepository.ListAsync(Arg.Any<Expression<Func<OperationEntity, bool>>>())
                           .Returns(entities);

            var service = new OperationService(_operationRepository);
            var response = await service.GetAllAsync();

            response.ToList().Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task Get_OperationById_ReturnsOperation()
        {
            var entity = _fixture.Create<OperationEntity>();

            _operationRepository.FindAsync(Arg.Any<Expression<Func<OperationEntity, bool>>>())
                           .Returns(entity);

            var service = new OperationService(_operationRepository);
            var response = await service.GetByIdAsync(entity.Id);

            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post_Operation_ShouldBeRegisteredOperation()
        {
            var entity = _fixture.Create<OperationEntity>();

            _operationRepository.AddAsync(Arg.Any<OperationEntity>())
                           .Returns(Task.CompletedTask);

            var service = new OperationService(_operationRepository);

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
        public async Task Put_Operation_ShouldBeEditedOperation()
        {
            var entity = _fixture.Create<OperationEntity>();

            _operationRepository.FindAsNoTrackingAsync(Arg.Any<Expression<Func<OperationEntity, bool>>>())
                           .Returns(entity);

            _operationRepository.EditAsync(Arg.Any<OperationEntity>())
                           .Returns(Task.CompletedTask);

            var service = new OperationService(_operationRepository);

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
        public async Task Delete_Operation_ShouldBeDeletedOperation()
        {
            var entity = _fixture.Create<OperationEntity>();

            _operationRepository.FindAsync(Arg.Any<int>())
                           .Returns(entity);

            _operationRepository.RemoveAsync(Arg.Any<OperationEntity>())
                           .Returns(Task.CompletedTask);

            var service = new OperationService(_operationRepository);

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
