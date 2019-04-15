namespace EstelApi.IntegrationTests.Base
{
    using System;

    /// <summary>
    /// The DatabaseManager interface.
    /// </summary>
    internal interface IDatabaseManager : IDisposable
    {
        /// <summary>
        /// The reset test database
        /// </summary>
        void Reset();
    }
}