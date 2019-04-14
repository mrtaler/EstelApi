namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using System.Collections.Generic;

    using EstelApi.Core.Seedwork;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AvailableDates : EntityInt
    {
        public string Month { get; set; }
        public string Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public ICollection<AvailableDatesCourse> Courses { set; get; }
    }

    /// <inheritdoc />
    public class AvailableDatesConfiguration : IEntityTypeConfiguration<AvailableDates>
    {
        public void Configure(EntityTypeBuilder<AvailableDates> builder)
        {
            builder.HasData(
                new AvailableDates { Id = 1,  Month = "Сентябрь", Date = "12", StartHour = "11", EndHour = "18" },
                new AvailableDates { Id = 2,  Month = "Октябрь", Date = "4", StartHour = "11", EndHour = "18" },
                new AvailableDates { Id = 3,  Month = "Ноябрь", Date = "1", StartHour = "11", EndHour = "18" },
                new AvailableDates { Id = 4,  Month = "Декабрь", Date = "30", StartHour = "11", EndHour = "18" });
        }
    }
}