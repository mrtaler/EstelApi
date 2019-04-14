namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using System.Collections.Generic;

    using EstelApi.Core.Seedwork;

    public class AdditionalAmenity : EntityInt
    {
        public string AdditionalAmenityName { get; set; }
        public ICollection<AdditionalAmenityCourse> AdditionalAmenityCourses { get; set; }
    }
}