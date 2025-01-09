using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.GenericRepos
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();

        Task<T?> GetByIdAsync(Guid id);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);

        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);

        Task SaveChangesAsync();

        void Commit();
        void RollBack();

        IDbContextTransaction BeginTransaction();

    }
}
