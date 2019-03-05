using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    public class BaseContext : DbContext, IQueryableUnitOfWork
    {
        #region Constructors
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions options)
            : base(options)
        {
        }
        #endregion

        #region IQueryableUnitOfWork Members
        public virtual DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public new virtual void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            //attach and set as unchanged

            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }
        public virtual void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            //this operation also attach item in object state manager
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }
        public virtual void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            //if it is not attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }
        public virtual bool Commit()
        {
            var retData = this.SaveChanges() > 0;
            return retData;
        }
        public virtual async Task<int> CommitAsync()
        {
            return await this.SaveChangesAsync();
        }
        public virtual void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    this.Commit();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }
        public virtual async Task<int> CommitAndRefreshChangesAsync()
        {
            bool saveFailed = false;
            int i = 0;
            do
            {
                try
                {
                    i = await this.CommitAsync();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

            return i;

        }
        public virtual void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }
        public virtual IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            //Not implemented yet
            throw new NotImplementedException();
        }
        public virtual int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            //Not implemented yet
            throw new NotImplementedException();
        }
        public virtual void Refresh(object entity)
        {
            base.Entry(entity).Reload();
        }
        #endregion
    }
}
