namespace EstelApi.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.EventSourcedNormalizers;

    public interface ICustomerAppService : IDisposable
    {
        Task<IList<CustomerHistoryData>> GetAllHistory(Guid id);

        /// <summary>
        /// Add new customer 
        /// </summary>
        /// <param name="customerDTO">The customer information</param>
        /// <returns>Added customer representation</returns>
        Task<CustomerDTO> AddNewCustomer(CustomerDTO customerDTO);

        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <param name="customerDTO">The customerdto with changes</param>
        void UpdateCustomer(CustomerDTO customerDTO);

        /// <summary>
        /// Remove existing customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        void RemoveCustomer(Guid customerId);

        /// <summary>
        /// Find paged customers
        /// </summary>
        /// <param name="pageIndex">The index of page</param>
        /// <param name="pageCount">The # of elements in each page</param>
        /// <returns>A collection of customer representation</returns>
        List<CustomerListDTO> GetAllCustomers();

        /// <summary>
        /// Find customers with contain specific text in
        /// firstname or lastname
        /// </summary>
        /// <param name="text">the text to seach</param>
        /// <returns>A collection of customer representation</returns>
        List<CustomerListDTO> FindCustomers(string text);

        /// <summary>
        /// Find customer
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <returns>Selected customer representation if exist or null if not exist</returns>
        CustomerDTO FindCustomer(Guid customerId);

        /// <summary>
        /// Find paged countries
        /// </summary>
        /// <param name="pageIndex">The index of page</param>
        /// <param name="pageCount">The # of elements in each page</param>
        /// <returns>A collection of countries dto</returns>
        List<CountryDTO> FindCountries(int pageIndex, int pageCount);

        /// <summary>
        /// Find countries with country name or iso code like <paramref name="text"/>
        /// </summary>
        /// <param name="text">The text to search in countries</param>
        /// <returns>A collection of country dto</returns>
        List<CountryDTO> FindCountries(string text);
    }
}
