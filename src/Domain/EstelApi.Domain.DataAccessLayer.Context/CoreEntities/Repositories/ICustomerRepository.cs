namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories
{
    using System.Collections.Generic;

    using EstelApi.Core.Seedwork.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    /// <inheritdoc />
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// The get by email.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        Customer GetByFirstName(string email);

        /// <summary>
        /// The get enabled.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1"/>.
        /// </returns>
        IEnumerable<Customer> GetEnabled();
    }

}