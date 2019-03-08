namespace Estel.Services.Api.Extension.Swagger
{
    using System;
    using System.Collections.Generic;

    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <inheritdoc />
    internal class SecurityRequirementsDocumentFilter : IDocumentFilter
    {
        /// <inheritdoc />
        public void Apply(SwaggerDocument document, DocumentFilterContext context)
        {
            document.Security = new List<IDictionary<string, IEnumerable<string>>>()
            {
                new Dictionary<string, IEnumerable<string>>()
                {
                    { "ApiSecurity", Array.Empty<string>() },
                    { "CorrelationId", Array.Empty<string>() },
                }
            };
        }
    }
}