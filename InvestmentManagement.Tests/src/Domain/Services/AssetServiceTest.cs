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
    [Trait("Service", "Asset Service")]
    public class AssetServiceTest
    {
        private readonly Fixture _fixture;
        private readonly IAssetRepository _assetRepository;

        public AssetServiceTest()
        {
            _fixture = FixtureConfig.Get();
            _assetRepository = Substitute.For<IAssetRepository>();
        }

        [Fact]
        public async Task Get_Asset_ReturnsAllAssets()
        {
            var entities = _fixture.Create<List<AssetEntity>>();

            _assetRepository.ListAsync(Arg.Any<Expression<Func<AssetEntity, bool>>>())
                           .Returns(entities);

            var service = new AssetService(_assetRepository);
            var response = await service.GetAllAsync();

            response.ToList().Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task Get_AssetById_ReturnsAsset()
        {
            var entity = _fixture.Create<AssetEntity>();

            _assetRepository.FindAsync(Arg.Any<Expression<Func<AssetEntity, bool>>>())
                           .Returns(entity);

            var service = new AssetService(_assetRepository);
            var response = await service.GetByIdAsync(entity.Id);

            response.Id.Should().Be(entity.Id);
        }

        [Fact]
        public async Task Post_Asset_ShouldBeRegisteredAsset()
        {
            var entity = _fixture.Create<AssetEntity>();

            _assetRepository.AddAsync(Arg.Any<AssetEntity>())
                           .Returns(Task.CompletedTask);

            var service = new AssetService(_assetRepository);

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
        public async Task Put_Asset_ShouldBeEditedAsset()
        {
            var entity = _fixture.Create<AssetEntity>();

            _assetRepository.FindAsNoTrackingAsync(Arg.Any<Expression<Func<AssetEntity, bool>>>())
                           .Returns(entity);

            _assetRepository.EditAsync(Arg.Any<AssetEntity>())
                           .Returns(Task.CompletedTask);

            var service = new AssetService(_assetRepository);

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
        public async Task Delete_Asset_ShouldBeDeletedAsset()
        {
            var entity = _fixture.Create<AssetEntity>();

            _assetRepository.FindAsync(Arg.Any<int>())
                           .Returns(entity);

            _assetRepository.RemoveAsync(Arg.Any<AssetEntity>())
                           .Returns(Task.CompletedTask);

            var service = new AssetService(_assetRepository);

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
