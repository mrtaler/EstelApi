namespace EstelApi.IntegrationTests.Base.Fixture
{
    using System.Threading;

    internal static class GlobalLock
    {
        public static SemaphoreSlim Database { get; } = new SemaphoreSlim(1);
    }
}
