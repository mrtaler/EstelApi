namespace EstelApi.Core.Seedwork.Adapter
{
    /// <summary>
    /// Base contract for map DTO to aggregate or aggregate to DTO.
    /// <remarks>
    /// This is a  contract for work with "auto" mappers ( <c>automapper</c>,<c>emitmapper</c>,<c>valueinjecter</c>...)
    /// or <c>adhoc</c> mappers
    /// </remarks>
    /// </summary>
    public interface ITypeAdapter
    {
        /// <summary>
        /// Adapt a <paramref name="source"/> object to an instance of type TTarget
        /// </summary>
        /// <typeparam name="TSource">Type of source item</typeparam>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns><paramref name="source"/> mapped to <typeparamref name="TTarget"/></returns>
        TTarget Adapt<TSource, TTarget>(TSource source)
            where TTarget : class, new()
            where TSource : class;

        /// <summary>
        /// Adapt a <paramref name="source"/> object to an instance of type TTarget"
        /// </summary>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns><paramref name="source"/> mapped to <typeparamref name="TTarget"/></returns>
        TTarget Adapt<TTarget>(object source)
            where TTarget : class, new();
    }
}