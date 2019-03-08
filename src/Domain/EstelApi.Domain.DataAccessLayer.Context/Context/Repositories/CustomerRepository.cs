namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    /// <inheritdoc cref="ICustomerRepository" />
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public CustomerRepository(IQueryableUnitOfWork context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public Customer GetByFirstName(string email)
        {
            var ret = this.GetAll().FirstOrDefault(c => c.FirstName == email);
            return ret;
        }

        /// <inheritdoc />
        public IEnumerable<Customer> GetEnabled()
        {
            var currentUnitOfWork = this.UnitOfWork as EstelContext;

            return currentUnitOfWork?.Customers.Where(c => c.IsEnabled).OrderBy(c => c.FullName);
        }

        /// <inheritdoc />
        public override void Merge(Customer persisted, Customer current)
        {
            // merge customer and customer picture
            if (this.UnitOfWork is EstelContext currentUnitOfWork)
            {
                currentUnitOfWork.ApplyCurrentValues(persisted, current);
                currentUnitOfWork.ApplyCurrentValues(persisted.Picture, current.Picture);
            }
        }
    }
}
