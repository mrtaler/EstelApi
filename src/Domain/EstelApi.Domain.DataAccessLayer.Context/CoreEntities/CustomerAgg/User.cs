namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class User : Customer
    {

    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    MiddleName = "MiddleName1",
                    Telephone = "123456789",
                    BirthDate = DateTimeOffset.UtcNow.AddDays(-150),
                    IsEnabled = true,
                    LogoPath = @"c:\"
                },
                new User
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    MiddleName = "MiddleName2",
                    Telephone = "234567891",
                    BirthDate = DateTimeOffset.UtcNow.AddDays(-275),
                    IsEnabled = true,
                    LogoPath = @"c:\"
                },
                new User
                {
                    Id = 3,
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    MiddleName = "MiddleName3",
                    Telephone = "345678912",
                    BirthDate = DateTimeOffset.UtcNow.AddDays(-690),
                    IsEnabled = true,
                    LogoPath = @"c:\"
                },
                new User
                {
                    Id = 4,
                    FirstName = "FirstName4",
                    LastName = "LastName4",
                    MiddleName = "MiddleName4",
                    Telephone = "456789123",
                    BirthDate = DateTimeOffset.UtcNow.AddDays(-850),
                    IsEnabled = true,
                    LogoPath = @"c:\"
                },
                new User
                {
                    Id = 5,
                    FirstName = "FirstName5",
                    LastName = "LastName5",
                    MiddleName = "MiddleName5",
                    Telephone = "567891234",
                    BirthDate = DateTimeOffset.UtcNow.AddDays(-987),
                    IsEnabled = true,
                    LogoPath = @"c:\"
                });



            /*   builder.HasDiscriminator(person => person.Discriminator)
                   .HasValue<Customer>(nameof(Customer))
                   .HasValue<Worker>(nameof(Worker))*/


            //  builder.HasOne(x => x.Picture).WithOne(x => x.Customer).HasForeignKey<Customer>(x => x.Id);
            /* builder.Property(c => c.Id)
                                         .HasColumnName("Id");*/
            /*  builder.Property(c => c.Name).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
  
              builder.Property(c => c.Email).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();*/
        }
    }
}