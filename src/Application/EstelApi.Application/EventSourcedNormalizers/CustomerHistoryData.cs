﻿namespace EstelApi.Application.EventSourcedNormalizers
{
    using System;

    /// <summary>
    /// The customer history data.
    /// </summary>
    public class CustomerHistoryData
    {
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        public string Action { get; set; }
        
        /// <summary>
        /// The customer identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The customer first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The customer lastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the telephone 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Get or set the company name
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// The asociated credit limit
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// The country identifier
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// The address city
        /// </summary>
        public string AddressCity { get; set; }

        /// <summary>
        /// The address zip code
        /// </summary>
        public string AddressZipCode { get; set; }

        /// <summary>
        /// The address line 1
        /// </summary>
        public string AddressAddressLine1 { get; set; }

        /// <summary>
        /// The address line 2
        /// </summary>
        public string AddressAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the when.
        /// </summary>
        public string When { get; set; }

        /// <summary>
        /// Gets or sets the who.
        /// </summary>
        public string Who { get; set; }
    }
}