namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using EstelApi.Core.Seedwork;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AvailableDates : EntityInt
    {
        public string Month { get; set; }
        public string Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { set; get; }
    }
    public class AvailableDatesConfiguration : IEntityTypeConfiguration<AvailableDates>
    {
        public void Configure(EntityTypeBuilder<AvailableDates> builder)
        {
            builder.HasOne(x => x.Course)
                .WithMany(y => y.AvailableDates)
                .HasForeignKey(y => y.CourseId);
            builder.HasData(
                new AvailableDates { Id = 1, CourseId = 1, Month = "Сентябрь", Date = "12", StartHour = "11", EndHour = "18" },
                new AvailableDates { Id = 2, CourseId = 1, Month = "Октябрь", Date = "4", StartHour = "11", EndHour = "18" },
                new AvailableDates { Id = 3, CourseId = 2, Month = "Ноябрь", Date = "1", StartHour = "11", EndHour = "18" },
                new AvailableDates { Id = 4, CourseId = 2, Month = "Декабрь", Date = "30", StartHour = "11", EndHour = "18" });
        }
    }
}