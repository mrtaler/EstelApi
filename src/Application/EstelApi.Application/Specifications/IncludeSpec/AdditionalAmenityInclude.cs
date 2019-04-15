namespace EstelApi.Application.Specifications.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;

    public class AdditionalAmenityInclude : BaseIncludeSpecification<AdditionalAmenity>
    {
        public AdditionalAmenityInclude()
        {
            this.AddInclude(p => p.Include(x => x.AdditionalAmenityCourses));
        }
    }
}