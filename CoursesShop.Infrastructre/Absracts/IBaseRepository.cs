using CoursesShop.Data.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesShop.Infrastructure.Absracts
{
    public interface IBaseRepository<TModel>
    {
        Task<TModel> GetByIdAsync(string id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        Task<List<TModel>> GetTableNoTracking();
        Task<List<TModel>> GetTableAsTracking();
        Task<TModel> AddAsync(TModel entity);
        Task AddRangeAsync(ICollection<TModel> entities);
        Task UpdateAsync(TModel entity);
        Task UpdateRangeAsync(ICollection<TModel> entities);
        Task DeleteAsync(TModel entity);
    }
}
