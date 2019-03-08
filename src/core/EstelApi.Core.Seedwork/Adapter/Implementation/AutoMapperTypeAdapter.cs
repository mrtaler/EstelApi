namespace EstelApi.Core.Seedwork.Adapter.Implementation
{
    using AutoMapper;

    /// <summary>
    /// AutoMapper type adapter implementation
    /// </summary>
    public class AutoMapperTypeAdapter
        : ITypeAdapter
    {
        #region ITypeAdapter Members

        /// <inheritdoc />
        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="source">
        /// The <paramref name="source" />.
        /// </param>
        /// <typeparam name="TSource">t Source
        /// </typeparam>
        /// <typeparam name="TTarget">T Target
        /// </typeparam>
        /// <returns>
        /// The <see cref="!:TTarget" />.
        /// </returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <inheritdoc />
        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="source">
        /// The <paramref name="source" />.
        /// </param>
        /// <typeparam name="TTarget">d d 
        /// </typeparam>
        /// <returns>
        /// The <see cref="!:TTarget" />.
        /// </returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        #endregion
    }
}