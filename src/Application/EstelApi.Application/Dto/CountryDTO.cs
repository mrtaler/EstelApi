using System;
using System.Collections.Generic;
using System.Text;

namespace EstelApi.Application.Dto
{
    public class CountryDTO
    {
        /// <summary>
        /// The country identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The country name
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// The country ISO Code
        /// </summary>
        public string CountryISOCode { get; set; }
    }
}
