using AutoMapper;
using InvestmentManagement.Domain.Contracts.Requests;
using InvestmentManagement.Domain.Contracts.Responses;
using InvestmentManagement.Domain.Entities;

namespace InvestmentManagement.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region Entity to Request

            CreateMap<UserRequest, UserEntity>();
            CreateMap<InvestmentAccountRequest, InvestmentAccountEntity>();
            CreateMap<PortfolioRequest, PortfolioEntity>();
            CreateMap<OperationRequest, OperationEntity>();
            CreateMap<AssetRequest, AssetEntity>();

            #endregion

            #region Response to Entity

            CreateMap<UserEntity, UserResponse>();
            CreateMap<InvestmentAccountEntity, InvestmentAccountResponse>();
            CreateMap<PortfolioEntity, PortfolioResponse>();
            CreateMap<OperationEntity, OperationResponse>();
            CreateMap<AssetEntity, AssetResponse>();

            #endregion
        }
    }
}
