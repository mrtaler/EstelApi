namespace EstelApi.Domain.DataAccessLayer.Context.Repository.Base
{
    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc />
    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        protected readonly IQueryableUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        /// <exception cref="ArgumentNullException">if unitOfWork is null
        /// </exception>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        public IUnitOfWork UnitOfWork => this.unitOfWork;

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void Add(TEntity item)
        {
            if (item == null)
            {
                Log.Information("error in add method");
            }
            else
            {
                this.GetSet().Add(item); // add new item in this set
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
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
        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void Remove(TEntity item)
        {
            if (item != null)
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

        /// <inheritdoc />
        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
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
        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Remove(object id)
        {
            var item = this.GetSet().Find(id);
            this.Remove(item);
        }

        /// <inheritdoc />
        /// <summary>
        /// The track item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void TrackItem(TEntity item)
        {
            if (item != null)
            {
                this.unitOfWork.Attach(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotTrackNullEntity), typeof(TEntity).ToString());");
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The track item.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public virtual void TrackItem(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.TrackItem(item);
                }
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotTrackNullEntity), typeof(TEntity).ToString());");
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void Update(TEntity item)
        {
            if (item != null)
            {
                this.unitOfWork.SetModified(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotModifyNullEntity), typeof(TEntity).ToString());");
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public virtual void Update(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    this.Update(item);
                }
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotModifyNullEntity), typeof(TEntity).ToString());");
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The merge.
        /// </summary>
        /// <param name="persisted">
        /// The persisted.
        /// </param>
        /// <param name="current">
        /// The current.
        /// </param>
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            this.unitOfWork.ApplyCurrentValues(persisted, current);
        }

        /// <inheritdoc />
        /// <summary>
        /// The refresh.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Refresh(TEntity entity)
        {
            this.unitOfWork.Refresh(entity);
        }

        /// <inheritdoc />
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<TEntity> GetAll()
        {
            // var ret = GetQueryable(null, null, null).ToList();
            return this.GetSet().ToList();
        }

        /// <inheritdoc />
        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="!:TEntity" />.
        /// </returns>
        public virtual TEntity GetById(object id)
        {
            var ret = this.GetSet().Find(id);
            return ret;
        }

        /*   public IEnumerable<TEntity> AllMatching(ISpecification<TEntity> filter = null, IOrderSpecification<TEntity> orderBy = null, IIncludeSpecification<TEntity> includes = null)
           {
               var ret = GetQueryable(filter, orderBy, includes).ToList();
               return ret;
           }

           public TEntity OneMatching(ISpecification<TEntity> filter = null, IOrderSpecification<TEntity> orderBy = null, IIncludeSpecification<TEntity> includes = null)
           {
               var ret = GetQueryable(filter, orderBy, includes);
               return ret.FirstOrDefault();
           }*/

        /// <inheritdoc />
        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.unitOfWork?.Dispose();
        }

        /// <summary>
        /// The get set.
        /// </summary>
        /// <returns>
        /// The <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1"/>.
        /// </returns>
        protected DbSet<TEntity> GetSet()
        {
            return this.unitOfWork.CreateSet<TEntity>();
        }

        /*  /// <summary>
          /// The get queryable.
          /// </summary>
          /// <param name="filter">
          /// The filter. 
          /// </param>
          /// <param name="sort">
          /// The order by. 
          /// </param>
          /// <param name="includeSpecification">
          /// The include Specification.
          /// </param>
          /// <param name="skip">
          /// The skip. 
          /// </param>
          /// <param name="take">
          /// The take. 
          /// </param>
          /// <returns>
          /// The <see cref="IQueryable"/>.
          /// </returns>
          protected virtual IQueryable<TEntity> GetQueryable(
              ISpecification<TEntity> filter = null,
              IOrderSpecification<TEntity> sort = null,
              IIncludeSpecification<TEntity> includeSpecification = null)
          {
              IQueryable<TEntity> query = GetSet();

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
          }*/
    }
}