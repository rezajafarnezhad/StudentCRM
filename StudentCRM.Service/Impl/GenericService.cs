using Microsoft.EntityFrameworkCore;
using StudentCRM.Service.Contracts;
using StudentCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCRM.Data.ApplicationDataBaseContext;
using StudentCRM.ViewModel.term;

namespace StudentCRM.Service.Impl
{
    public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class,new()
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<TEntity> _entities;

        protected GenericService(IUnitOfWork uow)
        {
            _uow = uow;
            _entities = uow.Set<TEntity>();
        }

        public void Remove(TEntity entity)
            => _entities.Remove(entity);

       
        public async Task<TEntity> FindByIdAsync(long id)
            => await _entities.FindAsync(id);

        public async Task<bool> AnyAsync() => await _entities.AnyAsync();

        public async Task<TEntity> FindAsync(params object[] ids)
        {
            return await _entities.FindAsync(ids);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

       
        public void RemoveRange(List<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }


        public async Task<PaginationResultViewModel<T>> GenericPagination<T>(IQueryable<T> items, PaginationViewModel pagination)
        {
            if (pagination.CurrentPage < 1)
                pagination.CurrentPage = 1;

            var take = pagination.PageCount switch
            {
                PageCount.TwentyFive => 25,
                PageCount.Fifty => 50,
                PageCount.Hundred => 100,
                _ => 10,
            };

            
            var itemsCount = await items.LongCountAsync();
            var pagesCount = (int)Math.Ceiling(
                (decimal)itemsCount / take
            );
            if (pagesCount <= 0)
                pagesCount = 1;
            if (pagination.CurrentPage > pagesCount)
                pagination.CurrentPage = pagesCount;
            var skip = (pagination.CurrentPage - 1) * take;
            pagination.PagesCount = pagesCount;
            return new PaginationResultViewModel<T>
            {
                Pagination = pagination,
                Query = items.Skip(skip).Take(take)
            };
        }

        public virtual async Task<DuplicateColumns> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            return new DuplicateColumns();
        }


        public virtual async Task<DuplicateColumns> Update(TEntity entity)
        {
            _entities.Update(entity);
            return new DuplicateColumns();
        }

       
    }
}
