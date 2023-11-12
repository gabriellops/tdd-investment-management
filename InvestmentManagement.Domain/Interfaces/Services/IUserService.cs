using InvestmentManagement.Domain.Contracts.Response;
using InvestmentManagement.Domain.Entities;

namespace InvestmentManagement.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task CreateUserAsync(UserEntity usuario);
        Task UpdateUserAsync(UserEntity usuario);
        Task<AuthenticateResponse> AuthResponse(string email, string senha);
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> GetByIdUserAsync(int id);
    }
}
