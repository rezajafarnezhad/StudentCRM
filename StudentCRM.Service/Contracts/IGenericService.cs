using StudentCRM.Service.Impl;
using StudentCRM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCRM.ViewModel.term;

namespace StudentCRM.Service.Contracts
{
    public interface IGenericService<TEntity> where TEntity :class, new()
    {
        Task<DuplicateColumns> AddAsync(TEntity entity);
        Task<DuplicateColumns> Update(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> FindByIdAsync(long id);
        Task<TEntity> FindAsync(params object[] ids);
      
        Task<bool> AnyAsync();
        void RemoveRange(List<TEntity> entities);
        Task<PaginationResultViewModel<T>> GenericPagination<T>(IQueryable<T> items, PaginationViewModel pagination);


       
    }
}
