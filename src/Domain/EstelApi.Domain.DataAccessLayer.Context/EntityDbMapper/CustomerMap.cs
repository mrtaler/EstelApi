using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstelApi.Domain.DataAccessLayer.Context.EntityDbMapper
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id).HasName("Id");
            builder.OwnsOne(c => c.Address);

            /* builder.Property(c => c.Id)
                                         .HasColumnName("Id");*/
            /*  builder.Property(c => c.Name).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
  
              builder.Property(c => c.Email).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();*/
        }
    }
}