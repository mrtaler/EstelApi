namespace EstelApi.IntegrationTests.Base.Settings
{
    using Microsoft.Extensions.Options;

    internal class DataAccessOptionsOptions : IOptionsSnapshot<DataAccessOptions>
    {
        public DataAccessOptionsOptions(DataAccessOptions settings)
        {
            this.Value = settings;
        }

        public DataAccessOptions Value { get; }

        public DataAccessOptions Get(string name)
        {
            return this.Value;
        }
    }
}
