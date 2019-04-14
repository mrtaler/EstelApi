namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using EstelApi.Core.Seedwork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    /// <inheritdoc />
    public class Customer : EntityInt
    {
        /// <summary>
        /// The is enabled.
        /// </summary>
        private bool isEnabled;


        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
        }

        /// <summary>
        /// Gets or sets the identity id.
        /// </summary>
        public int IdentityId { get; set; }

        /// <summary>
        /// Gets or sets the Given name of this customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname of this customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets the full name of this customer
        /// </summary>
        public string FullName => $"{this.LastName} {this.FirstName} {this.MiddleName}";

        /// <summary>
        /// Gets or sets the telephone 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTimeOffset BirthDate { get; set; }

        /*
        /// <summary>
        /// Gets or sets the address of this customer
        /// </summary>
        public virtual Address Address { get; set; }
        */

        /// <summary>
        /// Gets a value indicating whether is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.isEnabled = value;
        }

        /// <summary>
        /// Gets associated photo for this customer
        /// </summary>
        public string LogoPath { get; set; }

        //  public string Discriminator { get; set; }
        public ICollection<CourseAttendance> CourseAttendances { get; set; }



        /// <summary>
        /// Disable customer
        /// </summary>
        public void Disable()
        {
            if (this.IsEnabled)
            {
                this.isEnabled = false;
            }
        }

        /// <summary>
        /// Enable customer
        /// </summary>
        public void Enable()
        {
            if (!this.IsEnabled)
            {
                this.isEnabled = true;
            }
        }

        /// <summary>
        /// change the picture for this customer
        /// </summary>
        /// <param name="picturePath">the new picture for this customer</param>
        public void ChangePicture(string picturePath)
        {
            if (string.IsNullOrEmpty(picturePath))
            {
                this.LogoPath = picturePath;
            }
        }
    }

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
            /*   builder.HasData(
                   new Customer
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
                   new Customer
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
                   new Customer
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
                   new Customer
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
                   new Customer
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
                   */


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