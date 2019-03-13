namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc cref="DbContext" />
    /// <summary>
    /// The base context.
    /// </summary>
    public class UnitOfWork : IQueryableUnitOfWork
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly EstelContext context;

        /// <inheritdoc />
        public UnitOfWork(EstelContext context)
        {
            this.context = context;
        }

        /// <inheritdoc />
        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <inheritdoc />
        public virtual DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return this.context.Set<TEntity>();
        }

        /// <inheritdoc />
        public virtual void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            // attach and set as unchanged
            this.context.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        /// <inheritdoc />
        public virtual void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            // this operation also attach item in object state manager
            this.context.Entry<TEntity>(item).State = EntityState.Modified;
        }

        /// <inheritdoc />
        public virtual void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            // if it is not attached, attach original and set current values
            this.context.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        /// <inheritdoc />
        public virtual bool Commit()
        {
            var retData = this.SaveAndAuditChanges() > 0;
            return retData;
        }

        /// <inheritdoc />
        public virtual async Task<int> CommitAsync()
        {
            return await this.SaveAndAuditChangesAsync();
        }

        /// <inheritdoc />
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
            }
 while (saveFailed);

        }

        /// <inheritdoc />
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
            }
 while (saveFailed);

            return i;

        }

        /// <inheritdoc />
        public virtual void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            this.context.ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        /// <inheritdoc />
        public virtual Task<IEnumerable<TEntity>> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class
        {
            // Not implemented yet
          //  throw new NotImplementedException();
            var retVal = this.context.Set<TEntity>().FromSql(sqlQuery, parameters).ToListAsync();
            return retVal as Task<IEnumerable<TEntity>>;
        }

        /// <inheritdoc />
        public virtual Task<int> ExecuteCommand(string sqlCommand, params object[] parameters)
        {
          var retVal= this.context.Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
          return retVal;
        }

        /// <inheritdoc />
        public virtual void Refresh(object entity)
        {
            this.context.Entry(entity).Reload();
        }

        /// <summary>
        /// The audit.
        /// </summary>
        private void Audit()
        {
            // Get the authenticated user name 
            string userName = "Anonymous";

            var user = ClaimsPrincipal.Current;
            var identity = user?.Identity;
            if (identity != null)
            {
                userName = identity.Name;
            }

            foreach (var auditedEntity in this.context.ChangeTracker.Entries<IAuditableEntity>())
            {
                if (auditedEntity.State == EntityState.Added ||
                    auditedEntity.State == EntityState.Modified)
                {
                    auditedEntity.Entity.LastModifiedAt = DateTime.UtcNow;
                    auditedEntity.Entity.LastModifiedBy = userName;

                    if (auditedEntity.State == EntityState.Added)
                    {
                        auditedEntity.Entity.CreatedAt = DateTime.UtcNow;
                        auditedEntity.Entity.CreatedBy = userName;
                    }
                    else
                    {
                        auditedEntity.Property(p => p.CreatedAt).IsModified = false;
                        auditedEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }
            }
        }

        /// <summary>
        /// The save and audit changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int SaveAndAuditChanges()
        {
            this.Audit();
            return this.context.SaveChanges();
        }

        /// <summary>
        /// The save and audit changes async.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task<int> SaveAndAuditChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Audit();
            return await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
