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
        //required by EF
        private Country() { }

        public Country(string countryName, string countryISOCode)
        {
            if (String.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentNullException("countryName");
            }

            if (String.IsNullOrWhiteSpace(countryISOCode))
            {
                throw new ArgumentNullException("countryISOCode");
            }

            this.CountryName = countryName;
            this.CountryISOCode = countryISOCode;
        }

        /// <summary>
        /// Gets the Country Name
        /// </summary>
        public string CountryName { get; private set; }

        /// <summary>
        /// Gets the Country ISO Code
        /// </summary>
        public string CountryISOCode { get; private set; }
    }
}
