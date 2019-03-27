namespace EstelApi.IntegrationTests.Base.Help
{
    using System;
    using System.Linq.Expressions;
    using System.Net.Http;

    using FluentAssertions.Execution;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal static class ResponseContentAssertions
    {
        public static void ShouldContainObject<T>(this HttpResponseMessage responseMessage, T expectedValue)
        {
            var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            var responseObject = JObject.Parse(responseContent);
            var expectedObject = JsonConverter.ConvertObject(expectedValue);
            var equals = JToken.DeepEquals(responseObject, expectedObject);
            Execute.Assertion.ForCondition(equals)
                .FailWith(
                    "Repsonse object was not equal to the expected one.\n"
                    + "Response object:\n{0}\n"
                    + "Expected object:\n{1}",
                    responseObject.ToString(Formatting.None),
                    expectedObject.ToString(Formatting.None));
        }

        public static void ShouldContainCorrectObject<T>(
            this HttpResponseMessage responseMessage,
            Expression<Func<T, bool>> checkObject)
        {
            var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            var expectedObject = JsonConverter.Deserialize<T>(responseContent);
            var condintion = checkObject.Compile()(expectedObject);
            Execute.Assertion.ForCondition(condintion)
                .FailWith(
                    "Repsonse object was not correct.\n" + "Response object:\n{0}\n" + "Expected condition: {1}",
                    responseContent,
                    checkObject.ToString());
        }
    }
}