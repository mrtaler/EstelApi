namespace EstelApi.IntegrationTests.Base
{
    using System;
    using System.Collections.Concurrent;
    using System.Reflection;

    using Serilog.Context;

    using Xunit.Sdk;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal sealed class LogTestNameAttribute : BeforeAfterTestAttribute
    {
        private static readonly ConcurrentDictionary<string, IDisposable> Disposables =
            new ConcurrentDictionary<string, IDisposable>();

        public override void Before(MethodInfo methodUnderTest)
        {
            Disposables.TryAdd(methodUnderTest.Name, LogContext.PushProperty("Test", methodUnderTest.Name));
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Disposables.TryGetValue(methodUnderTest.Name, out var value);
            value.Dispose();
        }
    }
}