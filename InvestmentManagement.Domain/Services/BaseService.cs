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

            return entity is null
                ? throw new InformationException(Enums.EStatusExceptionEnum.NotFound, $"No data found for the Id {id}.")
                : entity;
        }

        public async Task AddAsync(T entity)
        {
            await _baseRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _baseRepository.FindAsync(id);

            if (entity is null)
                throw new InformationException(Enums.EStatusExceptionEnum.NotFound, $"No data found for the Id {entity.Id}.");

            entity.Active = false;

            await _baseRepository.EditAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            var find = await _baseRepository.FindAsNoTrackingAsync(x => x.Id == entity.Id && x.Active);

            if (find is null)
                throw new InformationException(Enums.EStatusExceptionEnum.NotFound, $"No data found for the Id {entity.Id}.");

            await _baseRepository.EditAsync(entity);
        }
    }
}
