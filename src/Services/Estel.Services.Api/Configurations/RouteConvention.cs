namespace Estel.Services.Api.Configurations
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.Routing;

    /// <inheritdoc />
    public class RouteConvention : IApplicationModelConvention
    {
        /// <summary>
        /// The central prefix.
        /// </summary>
        private readonly AttributeRouteModel centralPrefix;

        /// <inheritdoc />
        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            this.centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        /// <inheritdoc />
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                            this.centralPrefix,
                            selectorModel.AttributeRouteModel);
                    }
                }

                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();

                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = this.centralPrefix;
                    }
                }
            }
        }
    }
}