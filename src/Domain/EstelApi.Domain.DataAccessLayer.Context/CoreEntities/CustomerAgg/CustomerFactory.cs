﻿namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
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
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="country">
        /// The associated country to this customer
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// A valid customer
        /// </returns>
        public static Customer CreateCustomer(
            string firstName,
            string lastName,
            string telephone,
            string company,
            Country country,
            Address address)
        {
            // create new instance and set identity
            var customer = new Customer();

            customer.GenerateNewIdentity();

            // set data
            customer.FirstName = firstName;
            customer.LastName = lastName;

            customer.Company = company;
            customer.Telephone = telephone;

            // set address
            customer.Address = address;

            // customer is enabled by default
            customer.Enable();

            // TODO: By default this is the limit for customer credit, you can set this 
            // parameter customizable via configuration or other system
            customer.ChangeTheCurrentCredit(1000M);

            // set default picture
            var picture = new Picture();
           picture.GenerateNewIdentity();
            customer.ChangePicture(picture);

            // set the country for this customer
         //   set
        //    customer.SetTheCountryForThisCustomer(country);
           // customer.SetTheCountryReference(country.Id);
            customer.SetTheCountryForThisCustomer(country);
            return customer;
        }
    }
}