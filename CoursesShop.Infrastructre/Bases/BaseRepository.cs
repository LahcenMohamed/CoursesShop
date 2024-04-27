using CoursesShop.Infrastructure.Absracts;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceCourse.DataAccess.DbContexts;

namespace CoursesShop.Infrastructure.Bases
{
    public class BaseRepository<TModel>(CoursesShopDbContext context) : IBaseRepository<TModel> where TModel : class
    {
        #region Vars / Props

        protected readonly CoursesShopDbContext _dbContext = context;

        #endregion

        #region Methods

        #endregion

        #region Actions
        public virtual async Task<TModel> GetByIdAsync(string id)
        {
            return await _dbContext.Set<TModel>().FindAsync(id);
        }


        public IQueryable<TModel> GetTableNoTracking()
        {
            return _dbContext.Set<TModel>().AsNoTracking().AsQueryable();
        }


        public virtual async Task AddRangeAsync(ICollection<TModel> entities)
        {
            await _dbContext.Set<TModel>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

        }
        public virtual async Task<TModel> AddAsync(TModel entity)
        {
            _dbContext.Set<TModel>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(TModel entity)
        {
            _dbContext.Set<TModel>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }

        public virtual async Task DeleteAsync(TModel entity)
        {
            _dbContext.Set<TModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteRangeAsync(ICollection<TModel> entities)
        {
            _dbContext.Set<TModel>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }



        public IDbContextTransaction BeginTransaction()
        {


            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();

        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();

        }

        public async Task<List<TModel>> GetTableAsTracking()
        {
            return await _dbContext.Set<TModel>().ToListAsync();

        }

        public virtual async Task UpdateRangeAsync(ICollection<TModel> entities)
        {
            _dbContext.Set<TModel>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
