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
        // required by EF
        private Country() { }

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
