namespace EstelApi.Core.Seedwork.Adapter
{
    /// <summary>
    /// Base contract for adapter factory
    /// </summary>
    public interface ITypeAdapterFactory
    {
        /// <summary>
        /// Create a type adapter
        /// </summary>
        /// <returns>The created <c>ITypeAdapter</c></returns>
        ITypeAdapter Create();
    }
}