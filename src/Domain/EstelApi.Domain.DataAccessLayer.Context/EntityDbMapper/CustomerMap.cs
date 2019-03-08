namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <inheritdoc />
    /// <summary>
    /// The customer map.
    /// </summary>
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        /// <inheritdoc />
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id).HasName("CustomerId");
            builder.OwnsOne(c => c.Address);

            /* builder.Property(c => c.Id)
                                         .HasColumnName("Id");*/
            /*  builder.Property(c => c.Name).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
  
              builder.Property(c => c.Email).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();*/
        }
    }
}