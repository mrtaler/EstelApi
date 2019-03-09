namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc cref="DbContext" />
    /// <summary>
    /// The base context.
    /// </summary>
    public class BaseContext : DbContext, IQueryableUnitOfWork
    {
        /// <inheritdoc />
        public BaseContext()
        {
        }

        /// <inheritdoc />
        public BaseContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <inheritdoc />
        public virtual DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return this.Set<TEntity>();
        }

        /// <inheritdoc />
        public new virtual void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            // attach and set as unchanged
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        /// <inheritdoc />
        public virtual void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            // this operation also attach item in object state manager
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }

        /// <inheritdoc />
        public virtual void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            // if it is not attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
     //       this.Entry(original).CurrentValues.SetValues(current);
        }

        /// <inheritdoc />
        public virtual bool Commit()
        {
            var retData = this.SaveChanges() > 0;
            return retData;
        }

        /// <inheritdoc />
        public virtual async Task<int> CommitAsync()
        {
            return await this.SaveChangesAsync();
        }

        /// <inheritdoc />
        public virtual void CommitAndRefreshChanges()
        {
            bool saveFailed;
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
            }
            while (saveFailed);
        }

        /// <inheritdoc />
        public virtual async Task<int> CommitAndRefreshChangesAsync()
        {
            bool saveFailed;
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
            }
            while (saveFailed);

            return i;
        }

        /// <inheritdoc />
        public virtual void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            this.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            // Not implemented yet
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            // Not implemented yet
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual void Refresh(object entity)
        {
            this.Entry(entity).Reload();
        }
    }
}
