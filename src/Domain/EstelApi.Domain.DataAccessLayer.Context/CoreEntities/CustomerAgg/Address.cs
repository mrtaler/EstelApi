namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using EstelApi.Core.Seedwork;

    /// <summary>
    /// Address  information for existing customer
    /// For this Domain-Model, the Address is a Value-Object
    /// </summary>
    public class Address : ValueObject<Address>
    {
        // For this Domain-Model, the Address is a Value-Object
        // 'sets' are private as Value-Objects must be immutable, 
        // so the only way to set properties is using the constructor 

        /// <inheritdoc />
        public Address(string city, string zipCode, string addressLine1, string addressLine2)
        {
            this.City = city;
            this.ZipCode = zipCode;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// required for EF
        /// </summary>
        protected Address() { }  


        /// <summary>
        /// Gets the city of this address 
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Gets the zip code
        /// </summary>
        public string ZipCode { get; private set; }

        /// <summary>
        /// Gets address line 1
        /// </summary>
        public string AddressLine1 { get; private set; }

        /// <summary>
        /// Gets address line 2
        /// </summary>
        public string AddressLine2 { get; private set; }
     

    }
}