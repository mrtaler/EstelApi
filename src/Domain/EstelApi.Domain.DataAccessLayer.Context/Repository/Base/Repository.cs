namespace EstelApi.Domain.DataAccessLayer.Context.Repository.Base
{
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {

        protected readonly EstelContext unitOfWork;
        protected readonly DbSet<TEntity> DbSet;

        private bool useInclude = false;

        private List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> includes =
            new List<Func<IQueryable<TEntity>, IQueryable<TEntity>>>();
        public Repository(EstelContext unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            this.DbSet = unitOfWork.Set<TEntity>();
        }

        public virtual void Add(TEntity item)
        {
            if (item != (TEntity)null)
            {
                this.GetSet().Add(item); // add new item in this set
            }

            /*  else
              {
                  _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotAddNullEntity), typeof(TEntity).ToString());
              }*/
        }

        public virtual void Add(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.Add(item);
                }
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotAddNullEntity), typeof(TEntity).ToString())");
            }
        }

        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                // attach item if not exist
                this.unitOfWork.Attach(item);

                // set as "removed"
                this.GetSet().Remove(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotRemoveNullEntity), typeof(TEntity).ToString());");
            }
        }

        public virtual void Remove(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.Remove(item);
                }
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotRemoveNullEntity), typeof(TEntity).ToString());");
            }
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity)null) this.unitOfWork.Attach<TEntity>(item);

            /*  else
                          {
                              _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotTrackNullEntity), typeof(TEntity).ToString());
                          }*/
        }

        public virtual void TrackItem(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.TrackItem(item);
                }
            }

            /* else
                         {
                             _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotTrackNullEntity), typeof(TEntity).ToString());
                         }*/
        }

        public virtual void Modify(TEntity item)
        {
            if (item != (TEntity)null)
            {
                this.DbSet.Update(item);
            }

            /*else
            {
                _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotModifyNullEntity), typeof(TEntity).ToString());
            }*/
        }

        public virtual void Modify(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.Modify(item);
                }
            }

            /*else
            {
                _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotModifyNullEntity), typeof(TEntity).ToString());
            }*/
        }

        public virtual TEntity Get(object id)
        {
            if (id != null)
            {
                if (this.useInclude)
                {
                    var retEnumerable = this.GetSetAsQueryable(id).First();
                    return retEnumerable;
                }

                return this.GetSet().Find(id);
            }
            else
            {
                return null;
            }
        }

        public virtual async Task<TEntity> GetAsync(object id)
        {
            if (id != null)
            {
                return await this.GetSet().FindAsync(id);
            }
            else
            {
                return null;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            if (this.useInclude)
            {
                var retEnumerable = GetSetAsQueryable().ToList();
                return retEnumerable;
            }

            var ret = this.GetSet().ToList();
            return ret;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.GetSet().ToListAsync();
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            // unitOfWork.ApplyCurrentValues(persisted, current);
            this.unitOfWork.Entry<TEntity>(persisted).CurrentValues.SetValues(current);
        }

        public virtual void Refresh(TEntity entity)
        {
            this.unitOfWork.Entry(entity).Reload();
        }

        public void SetInclude(IEnumerable<Func<IQueryable<TEntity>, IQueryable<TEntity>>> Includes)
        {
            this.includes = Includes.ToList();
            this.useInclude = true;
        }

        public void Dispose()
        {
            if (this.unitOfWork != null) this.unitOfWork.Dispose();
        }

        public void SetUseInclude(bool useInclude = false)
        {
            this.useInclude = useInclude;
        }

        DbSet<TEntity> GetSet()
        {
            var retVAl = this.unitOfWork.Set<TEntity>();
            return retVAl;
        }

        IQueryable<TEntity> GetSetAsQueryable(object id = null)
        {
            var retVal = this.unitOfWork.Set<TEntity>();
            if (id != null)
            {
                retVal.Find(id);
            }

            var retValQ = retVal.AsQueryable();

            if (this.useInclude && this.includes.Any())
            {
                foreach (var includeItem in this.includes)
                {
                    retValQ = includeItem(retValQ);
                }
            }

            return retValQ;
        }
    }
}