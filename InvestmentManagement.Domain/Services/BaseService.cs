using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Exceptions;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace InvestmentManagement.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _baseRepository.ListAsync(x => x.Active);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _baseRepository.FindAsync(x => x.Id == id && x.Active);

            if (entity is null)
                throw new InformationException(Enums.EStatusExceptionEnum.NotFound, $"No data found for the Id {id}.");

            return entity;
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
