namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using System;

    using EstelApi.Core.Seedwork;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg;

    /// <inheritdoc />
    public class Customer : EntityGuid
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
        /// Gets or sets the Given name of this customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname of this customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name of this customer
        /// </summary>
        public string FullName => $"{this.LastName}, {this.FirstName}";

        /// <summary>
        /// Gets or sets the telephone 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the address of this customer
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or set the current credit limit for this customer
        /// </summary>
        public decimal CreditLimit { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get => this.isEnabled;
            private set => this.isEnabled = value;
        }


        /// <summary>
        /// Gets or set associated country identifier
        /// </summary>
        public Guid CountryId { get; private set; }

        /// <summary>
        /// Gets the current country for this customer
        /// </summary>
        public virtual Country Country { get; private set; }

        /// <summary>
        /// Gets associated photo for this customer
        /// </summary>
        public virtual Picture Picture { get; private set; }

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
        /// Associate existing country to this customer
        /// </summary>
        /// <param name="country"></param>
        public void SetTheCountryForThisCustomer(Country country)
        {
            if (country == null
                ||
                country.IsTransient())
            {
                throw new ArgumentException("messages.GetStringResource(LocalizationKeys.Domain.exception_CannotAssociateTransientOrNullCountry)");
            }

           // this.CountryId = country.Id;
            this.Country = country;
        }

        /// <summary>
        /// Set the country reference for this customer
        /// </summary>
        /// <param name="countryId"></param>
        public void SetTheCountryReference(Guid countryId)
        {
            if (countryId == Guid.Empty)
            {
                return;
            }
            
            this.CountryId = countryId;
            this.Country = null;
        }

        /// <summary>
        /// Change the customer credit limit
        /// </summary>
        /// <param name="newCredit">the new credit limit</param>
        public void ChangeTheCurrentCredit(decimal newCredit)
        {
            if (this.IsEnabled)
            {
                this.CreditLimit = newCredit;
            }
        }

        /// <summary>
        /// change the picture for this customer
        /// </summary>
        /// <param name="picture">the new picture for this customer</param>
        public void ChangePicture(Picture picture)
        {
            if (picture != null &&
                !picture.IsTransient())
            {
                this.Picture = picture;
            }
        }
    }
}