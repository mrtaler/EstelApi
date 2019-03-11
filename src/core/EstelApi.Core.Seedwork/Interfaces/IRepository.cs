namespace EstelApi.Core.Seedwork.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc cref="T:IReadableRepository" />
    /// <summary>
    /// The Repository <see langword="interface" />.
    /// </summary>
    /// <typeparam name="TEntity">db Entities
    /// </typeparam>
    public interface IRepository<TEntity> : /*IReadableRepository<TEntity> , IAsyncRepository<TEntity>,*/ IDisposable
        where TEntity : Entity
    {
       /* /// <summary>
        /// Gets the unit of work in this repository
        /// </summary>
        IUnitOfWork UnitOfWork { get; }*/

        /// <summary>
        /// Add <paramref name="item"/> into repository
        /// </summary>
        /// <param name="item">
        /// Item to add to repository
        /// </param>
        void Add(TEntity item);

        /// <summary>
        /// Add <c>items</c> into repository
        /// </summary>
        /// <param name="items">Items to add to repository</param>
        void Add(IEnumerable<TEntity> items);

        /// <summary>
        /// Delete <c>item</c> 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TEntity item);

        /// <summary>
        /// Delete <c>items</c>
        /// </summary>
        /// <param name="items">Items to delete</param>
        void Remove(IEnumerable<TEntity> items);

        /// <summary>
        /// Set <paramref name="item"/> as modified
        /// </summary>
        /// <param name="item">Item to modify</param>
        void Modify(TEntity item);

        /// <summary>
        /// Set <paramref name="items"/> as modified
        /// </summary>
        /// <param name="items">Items to modify</param>
        void Modify(IEnumerable<TEntity> items);

        /// <summary>
        /// Track entity into this repository, really in UnitOfWork. 
        /// In EF this can be done with Attach and with Update in NH
        /// </summary>
        /// <param name="item">Item to attach</param>
        void TrackItem(TEntity item);

        /// <summary>
        /// Track entity into this repository, really in UnitOfWork. 
        /// In EF this can be done with Attach and with Update in NH
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void TrackItem(IEnumerable<TEntity> item);

        /// <summary>
        /// Sets modified entity into the repository. 
        /// When calling Commit() method in UnitOfWork 
        /// these changes will be saved into the storage
        /// </summary>
        /// <param name="persisted">The persisted item</param>
        /// <param name="current">The current item</param>
        void Merge(TEntity persisted, TEntity current);

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        TEntity Get(object id);

        /// <summary>
        /// Get element by entity key - Async
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(object id);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get all elements of type TEntity in repository - Async
        /// </summary>
        /// <returns>List of selected elements</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Refresh entity. Note. This generates adhoc queries.
        /// </summary>
        /// <param name="entity"></param>
        void Refresh(TEntity entity);
    }
}