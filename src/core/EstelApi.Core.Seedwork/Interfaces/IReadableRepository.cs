using System.Collections.Generic;

namespace EstelApi.Core.Seedwork.Interfaces
{
    public interface IReadableRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// <see cref="Get"/> all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity GetById(object id);

        /*/// <summary>
        /// The get all.
        /// </summary>
        /// <param name="filter">
        /// The <paramref name="filter"/>.
        /// </param>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <param name="includes">
        /// The include specification.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<TEntity> AllMatching(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null);

        /// <summary>
        /// <see cref="Get"/> the first element of type TEntity that matching a Specification 
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <param name="orderBy">
        /// The order By.
        /// </param>
        /// <param name="includes">
        /// The includes.
        /// </param>
        /// <returns>
        /// Db Entity
        /// </returns>
        TEntity OneMatching(
            ISpecification<TEntity> filter = null,
            IOrderSpecification<TEntity> orderBy = null,
            IIncludeSpecification<TEntity> includes = null);*/
    }
}
