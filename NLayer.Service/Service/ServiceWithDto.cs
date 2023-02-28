using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Entity;
using NLayer.Core.Repository;
using NLayer.Core.UnitOfWork;

namespace NLayer.Service.Service
{
    public class ServiceWithDto<TEntity, TDto> : IServiceWithDto<TEntity, TDto>
        where TEntity : BaseEntity where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public ServiceWithDto(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();
            var dtoList = mapper.Map<IEnumerable<TDto>>(entities);
            return dtoList;
        }

        public async Task<TDto> FindByIdAsync(int id)
        {
            TEntity entity = await _repository.FindByIdAsync(id);
            TDto dto = mapper.Map<TDto>(entity);
            return dto;
        }

        public async Task<IEnumerable<TDto>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _repository.Where(expression).ToListAsync();
            var dtoList = mapper.Map<IEnumerable<TDto>>(entities);
            return dtoList;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            bool any = await _repository.AnyAsync(expression);
            return any;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            TEntity newEntity = mapper.Map<TEntity>(dto);
            await _repository.AddAsync(newEntity);
            await unitOfWork.CommitAsync();
            TDto newDto = mapper.Map<TDto>(newEntity);
            return newDto;
        }

        public async Task<IEnumerable<TDto>> AddRangeAsync(IEnumerable<TDto> dtoList)
        {
            IEnumerable<TEntity> newEntities = mapper.Map<IEnumerable<TEntity>>(dtoList);
            await _repository.AddRangeAsync(newEntities);
            await unitOfWork.CommitAsync();
            IEnumerable<TDto> newDtoList = mapper.Map<IEnumerable<TDto>>(newEntities);
            return newDtoList;
        }

        public async Task UpdateAsync(TDto dto)
        {
            TEntity entity = mapper.Map<TEntity>(dto);
            _repository.Update(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = await _repository.FindByIdAsync(id);
            _repository.Delete(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            var entities = await _repository.Where(x => ids.Contains(x.Id)).ToListAsync();
            _repository.DeleteRange(entities);
            await unitOfWork.CommitAsync();
        }
    }
}