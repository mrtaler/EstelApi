namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <inheritdoc />
    /// <summary>
    /// The customer map.
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
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
            builder.ToTable("Customer");
        }
    }
}