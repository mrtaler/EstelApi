namespace EstelApi.IntegrationTests.Base.Help
{
    using System.Net.Http.Headers;

    internal static class HttpRequestHeaderHelper
    {
        private const string ApiKey = "x-api-key";
        private const string CorrelationIdKey = "correlationId";
        private const string ValidApiKeyValue = "99e6e559-8b9e-4af7-b8a2-d3513d700049";
        private const string InvalidApiKeyValue = "99e6e559-8b9e-4af7-b8a2-000000000000";
        private const string CorrelationIdValue = "56fe8ce0-a02b-4ae0-b6d8-fe18d8bbff5d";

        public static void AddValidApiKey(this HttpRequestHeaders headers)
        {
            headers.Add(ApiKey, ValidApiKeyValue);
        }

        public static void AddInvalidApiKey(this HttpRequestHeaders headers)
        {
            headers.Add(ApiKey, InvalidApiKeyValue);
        }

        public static void AddCorrelationId(this HttpRequestHeaders headers)
        {
            headers.Add(CorrelationIdKey, CorrelationIdValue);
        }
    }
}
