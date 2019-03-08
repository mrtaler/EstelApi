namespace EstelApi.Core.Seedwork.Adapter
{
    /// <summary>
    /// The type adapter factory.
    /// </summary>
    public static class TypeAdapterFactory
    {
        /// <summary>
        /// The _current type adapter factory.
        /// </summary>
        private static ITypeAdapterFactory currentTypeAdapterFactory;

        /// <summary>
        /// Set the current type adapter factory
        /// </summary>
        /// <param name="adapterFactory">The adapter factory to set</param>
        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            currentTypeAdapterFactory = adapterFactory;
        }

        /// <summary>
        /// Create a new type adapter from current factory
        /// </summary>
        /// <returns>Created type adapter</returns>
        public static ITypeAdapter CreateAdapter()
        {
            return currentTypeAdapterFactory.Create();
        }
    }
}
