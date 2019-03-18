namespace EstelApi.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

   // using EstelApi.Application.Dto;
    using EstelApi.Application.EventSourcedNormalizers;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    /// <inheritdoc />
    /// <summary>
    /// The CustomerAppService interface.
    /// </summary>
    public interface ICustomerAppService : IDisposable
    {
        /// <summary>
        /// The get all history.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IList<CustomerHistoryData>> GetAllHistory(int id);

        /// <summary>
        /// Add new customer 
        /// </summary>
        /// <param name="customerDto">The customer information</param>
        /// <returns>Added customer representation</returns>
        Task<Customer> AddNewCustomer(Customer customerDto);

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <param name="customerDto">
        /// The customer dto with changes
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateCustomer(Customer customerDto);

        /// <summary>
        /// Remove existing customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        Task RemoveCustomer(int customerId);

        /// <summary>
        /// Find paged customers
        /// </summary>
        /// <returns>
        /// A collection of customer representation
        /// </returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Find customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <returns>Selected customer representation if exist or null if not exist</returns>
        Customer FindCustomer(int customerId);
    }
}
