namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The stored event map.
    /// </summary>
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}