using System;

namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg
{
    using EstelApi.Core.Seedwork;

    /// <summary>
    /// The country entity
    /// </summary>
    public class Country
        : EntityGuid
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Country"/> class from being created. Required by EF
        /// </summary>
        public Country()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class.
        /// </summary>
        /// <param name="countryName">
        /// The country name.
        /// </param>
        /// <param name="countryIsoCode">
        /// The country iso code.
        /// </param>
        /// <exception cref="ArgumentNullException">if Arguments is null
        /// </exception>
        public Country(string countryName, string countryIsoCode)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentNullException("countryName");
            }

            if (string.IsNullOrWhiteSpace(countryIsoCode))
            {
                throw new ArgumentNullException("countryIsoCode");
            }

            this.CountryName = countryName;
            this.CountryIsoCode = countryIsoCode;
        }

        /// <summary>
        /// Gets the Country Name
        /// </summary>
        public string CountryName { get; private set; }

        /// <summary>
        /// Gets the Country ISO Code
        /// </summary>
        public string CountryIsoCode { get; private set; }
    }
}
