namespace EstelApi.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.EventSourcedNormalizers;

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
        Task<IList<CustomerHistoryData>> GetAllHistory(Guid id);

        /// <summary>
        /// Add new customer 
        /// </summary>
        /// <param name="customerDto">The customer information</param>
        /// <returns>Added customer representation</returns>
        Task<CustomerDto> AddNewCustomer(CustomerDto customerDto);

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <param name="customerDto">
        /// The customer dto with changes
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateCustomer(CustomerDto customerDto);

        /// <summary>
        /// Remove existing customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        Task RemoveCustomer(Guid customerId);

        /// <summary>
        /// Find paged customers
        /// </summary>
        /// <returns>
        /// A collection of customer representation
        /// </returns>
        List<CustomerDto> GetAllCustomers();

        /// <summary>
        /// Find customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <returns>Selected customer representation if exist or null if not exist</returns>
        CustomerDto FindCustomer(Guid customerId);
    }
}
