namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg;

    /// <summary>
    /// This is the factory for Customer creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class CustomerFactory
    {
        /// <summary>
        /// Create a new transient customer
        /// </summary>
        /// <param name="firstName">
        /// The customer firstName
        /// </param>
        /// <param name="lastName">
        /// The customer lastName
        /// </param>
        /// <param name="telephone">
        /// The telephone.
        /// </param>
        /// <returns>
        /// A valid customer
        /// </returns>
        public static Customer CreateCustomer(
            string firstName,
            string lastName,
            string telephone)
        {
            // create new instance and set identity
            var customer = new Customer();

            // set data
            customer.FirstName = firstName;
            customer.LastName = lastName;

            customer.Telephone = telephone;

            // customer is enabled by default
            customer.Enable();
            
            // todo set Default logo path
            customer.ChangePicture("picture");

            return customer;
        }
    }
}