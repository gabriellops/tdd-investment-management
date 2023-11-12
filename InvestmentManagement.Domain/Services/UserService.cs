using InvestmentManagement.Domain.Contracts.Response;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Domain.Settings;
using System.Linq.Expressions;

namespace InvestmentManagement.Domain.Services
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSetting _appSettings;

        public UserService(IUserRepository userRepository, AppSetting appSettings) : base(userRepository)
        {
            _userRepository = userRepository;
            _appSettings = appSettings;
        }

        public Task CreateUserAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserEntity>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetByIdUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticateResponse> AuthResponse(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
