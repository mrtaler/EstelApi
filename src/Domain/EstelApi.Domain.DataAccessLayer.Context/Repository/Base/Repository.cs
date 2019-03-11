namespace EstelApi.Domain.DataAccessLayer.Context.Repository.Base
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Serilog;

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
        public Repository(EstelContext unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            DbSet = unitOfWork.Set<TEntity>();
        }
        public virtual void Add(TEntity item)
        {
            if (item != (TEntity)null)
            {
                GetSet().Add(item); // add new item in this set
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
                //attach item if not exist
                unitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
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
            if (item != (TEntity)null)
                unitOfWork.Attach<TEntity>(item);
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
                return GetSet().Find(id);
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
                return await GetSet().FindAsync(id);
            }
            else
            {
                return null;
            }
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetSet().ToListAsync();
        }
        public virtual void Merge(TEntity persisted, TEntity current)
        {
          //  unitOfWork.ApplyCurrentValues(persisted, current);
            this.unitOfWork.Entry<TEntity>(persisted).CurrentValues.SetValues(current);
        }
        public virtual void Refresh(TEntity entity)
        {
            unitOfWork.Entry(entity).Reload(); ;
        }
        public void Dispose()
        {
            if (unitOfWork != null)
                unitOfWork.Dispose();
        }
        DbSet<TEntity> GetSet()
        {
            return unitOfWork.Set<TEntity>();
        }
    }
}