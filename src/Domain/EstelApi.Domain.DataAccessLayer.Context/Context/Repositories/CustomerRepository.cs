namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
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

            return currentUnitOfWork?.Customers.Where(c => c.IsEnabled == true).OrderBy(c => c.FullName);
        }

        /// <inheritdoc />
        public override void Merge(Customer persisted, Customer current)
        {
            //merge customer and customer picture
            var currentUnitOfWork = this.UnitOfWork as EstelContext;

            if (currentUnitOfWork != null)
            {
                currentUnitOfWork.ApplyCurrentValues(persisted, current);
                currentUnitOfWork.ApplyCurrentValues(persisted.Picture, current.Picture);
            }
        }
    }
}
