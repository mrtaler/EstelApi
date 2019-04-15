namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using EstelApi.Core.Seedwork;

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
}