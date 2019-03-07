using System;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using TupleExtensions;

namespace Estel.Services.Api.Extension.Swagger
{
    internal class VersionFilter : IDocumentFilter, IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths = swaggerDoc.Paths
                .Select(
                    kvp =>
                    {
                        (var path, var pathItem) = kvp;
                        path = path.Replace("{api-version}", swaggerDoc.Info.Version, StringComparison.Ordinal);
                        return (path, pathItem);
                    }

                )
                .ToDictionary();
        }

        /// <inheritdoc />
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.First(p => p.Name == "version" || p.Name == "api-version");
            operation.Parameters.Remove(versionParameter);
        }
    }
}