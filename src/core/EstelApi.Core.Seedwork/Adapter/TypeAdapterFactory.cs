﻿namespace EstelApi.Core.Seedwork.Adapter
{
    /// <summary>
    /// The type adapter factory.
    /// </summary>
    public static class TypeAdapterFactory
    {
        #region Members

        /// <summary>
        /// The _current type adapter factory.
        /// </summary>
        private static ITypeAdapterFactory _currentTypeAdapterFactory;

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Set the current type adapter factory
        /// </summary>
        /// <param name="adapterFactory">The adapter factory to set</param>
        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            _currentTypeAdapterFactory = adapterFactory;
        }

        /// <summary>
        /// Create a new type adapter from current factory
        /// </summary>
        /// <returns>Created type adapter</returns>
        public static ITypeAdapter CreateAdapter()
        {
            return _currentTypeAdapterFactory.Create();
        }

        #endregion
    }
}