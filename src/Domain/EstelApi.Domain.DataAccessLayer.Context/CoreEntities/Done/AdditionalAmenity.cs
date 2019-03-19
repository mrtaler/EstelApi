namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using System.Collections.Generic;

    using EstelApi.Core.Seedwork;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AdditionalAmenity : EntityInt
    {
        public string AdditionalAmenityName { get; set; }
        public ICollection<AdditionalAmenityCourse> AdditionalAmenityCourses { get; set; }
    }

    public class AdditionalAmenityConfiguration : IEntityTypeConfiguration<AdditionalAmenity>
    {
        public void Configure(EntityTypeBuilder<AdditionalAmenity> builder)
        {
            builder.HasData(
                new AdditionalAmenity { Id = 1, AdditionalAmenityName = "Практическая обработка" },
                new AdditionalAmenity { Id = 2, AdditionalAmenityName = "Кофе брейк" },
                new AdditionalAmenity { Id = 3, AdditionalAmenityName = "Сертификат" });
        }
    }
}