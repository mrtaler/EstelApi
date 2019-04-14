namespace EstelApi.IntegrationTests.Base.Settings
{
    using Microsoft.Extensions.Options;

    internal class TestMssqlDatabaseOptions : IOptionsSnapshot<MssqlDatabaseSettings>
    {
        public TestMssqlDatabaseOptions(MssqlDatabaseSettings settings)
        {
            this.Value = settings;
        }

        public MssqlDatabaseSettings Value { get; }

        public MssqlDatabaseSettings Get(string name)
        {
            return this.Value;
        }
    }
}