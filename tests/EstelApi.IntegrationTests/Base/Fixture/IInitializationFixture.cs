namespace EstelApi.IntegrationTests.Base.Fixture
{
    using System;

    using Autofac;

    public interface IInitializationFixture : IDisposable
    {
        IContainer Container { get; }
    }
}