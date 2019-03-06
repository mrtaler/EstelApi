﻿using System;
using System.Collections.Generic;
using System.Linq;
using EstelApi.Core.Seedwork.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository.Base
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private IQueryableUnitOfWork _unitOfWork;

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork) null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public virtual void Add(TEntity item)
        {
            if (item != (TEntity) null)
                GetSet().Add(item); // add new item in this set
            else
            {
                Log.Information("error in add method");
            }

        }

        public virtual void Add(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items) this.Add(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotAddNullEntity), typeof(TEntity).ToString())");
            }
        }

        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity) null)
            {
                //attach item if not exist
                _unitOfWork.Attach(item);

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
                foreach (var item in items) this.Remove(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotRemoveNullEntity), typeof(TEntity).ToString());");
            }
        }

        public void Remove(object id)
        {
            var item = GetSet().Find(id);
            Remove(item);
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity) null)
                _unitOfWork.Attach<TEntity>(item);
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotTrackNullEntity), typeof(TEntity).ToString());");
            }
        }

        public virtual void TrackItem(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items) this.TrackItem(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotTrackNullEntity), typeof(TEntity).ToString());");
            }
        }

        public virtual void Update(TEntity item)
        {
            if (item != (TEntity) null)
                _unitOfWork.SetModified(item);
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotModifyNullEntity), typeof(TEntity).ToString());");
            }
        }

        public virtual void Update(IEnumerable<TEntity> items)
        {
            if (items != null)
            {
                foreach (var item in items) this.Update(item);
            }
            else
            {
                Log.Information(
                    "LocalizationFactory.CreateLocalResources().GetStringResource(LocalizationKeys.Infrastructure.info_CannotModifyNullEntity), typeof(TEntity).ToString());");
            }
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _unitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual void Refresh(TEntity entity)
        {
            _unitOfWork.Refresh(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            //var ret = GetQueryable(null, null, null).ToList();
            return GetSet().ToList();
        }

        public TEntity GetById(object id)
        {
            var ret = GetSet().Find(id);
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
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        DbSet<TEntity> GetSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
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