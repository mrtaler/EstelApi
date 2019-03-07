namespace Estel.Services.Api.Configurations
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;

    /// <summary>
    /// The mvc options extensions.
    /// </summary>
    public static class MvcOptionsExtensions
    {
        /// <summary>
        /// The use central route prefix.
        /// </summary>
        /// <param name="opts">
        /// The opts.
        /// </param>
        /// <param name="routeAttribute">
        /// The route attribute.
        /// </param>
        public static void UseCentralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            opts.Conventions.Insert(0, new RouteConvention(routeAttribute));
        }
    }
}