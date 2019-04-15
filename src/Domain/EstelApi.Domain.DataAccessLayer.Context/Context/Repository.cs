namespace EstelApi.Domain.DataAccessLayer.Context.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Core.Seedwork.Specifications.OrderSpecification;
    using EstelApi.Core.Seedwork.Specifications.Specifications;

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
        /// <summary>
        /// The unit of work.
        /// </summary>
        protected readonly EstelContext UnitOfWork;

        /// <summary>
        /// The db set.
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        /// <inheritdoc />
        public Repository(EstelContext unitOfWork)
        {
            this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            this.DbSet = unitOfWork.Set<TEntity>();
        }

        /// <inheritdoc />
        public virtual void Add(TEntity item)
        {
            if (item != null)
            {
                this.DbSet.Add(item); // add new item in this set
            }

            /*  else
              {
                  _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotAddNullEntity), typeof(TEntity).ToString());
              }*/
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public virtual void Remove(TEntity item)
        {
            if (item != null)
            {
                // attach item if not exist
                this.UnitOfWork.Attach(item);

                // set as "removed"
                this.DbSet.Remove(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotRemoveNullEntity), typeof(TEntity).ToString());");
            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public virtual void TrackItem(TEntity item)
        {
            if (item != null)
            {
                this.UnitOfWork.Attach(item);
            }

            /*  else
                          {
                              _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotTrackNullEntity), typeof(TEntity).ToString());
                          }*/
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public virtual void Modify(TEntity item)
        {
            if (item != null)
            {
                this.DbSet.Update(item);
            }

            /*else
            {
                _logger.LogInformation(LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotModifyNullEntity), typeof(TEntity).ToString());
            }*/
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public virtual TEntity Get(object id)
        {
            if (id == null)
            {
                return null;
            }

            var ret = this.DbSet.Find(id);
            return ret;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(object id)
        {
            if (id != null)
            {
                return await this.DbSet.FindAsync(id);
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> GetAll()
        {
            var retEnumerable = this.AllMatching().ToList();
            return retEnumerable;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.DbSet.ToListAsync();
        }

        /// <inheritdoc />
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            // unitOfWork.ApplyCurrentValues(persisted, current);
            this.UnitOfWork.Entry(persisted).CurrentValues.SetValues(current);
        }

        /// <inheritdoc />
        public virtual void Refresh(TEntity entity)
        {
            this.UnitOfWork.Entry(entity).Reload();
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> AllMatching(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null)
        {
            var ret = this.GetQueryable(
                filter: filter,
                sort: orderBy,
                includeSpecification: includes);
            return ret.ToList();
        }

        /// <inheritdoc />
        public TEntity OneMatching(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null)
        {
            var ret = this.GetQueryable(
                filter,
                orderBy,
                includeSpecification: includes);
            return ret.SingleOrDefault();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.UnitOfWork?.Dispose();
        }

        /// <summary>
        /// The get queryable.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <param name="sort">
        /// The sort.
        /// </param>
        /// <param name="includeSpecification">
        /// The include specification.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        protected virtual IQueryable<TEntity> GetQueryable(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> sort = null,
            IIncludeSpecification<TEntity> includeSpecification = null)
        {
            IQueryable<TEntity> query = this.DbSet;

            if (includeSpecification != null)
            {
                foreach (var includeItem in includeSpecification.Includes)
                {
                    query = includeItem(query);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (sort != null)
            {
                query = query.OrderBy(sort);
            }

            return query;
        }
    }
}