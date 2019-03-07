using System.Linq;
using EstelApi.Core.Seedwork.CoreEntities;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IQueryableUnitOfWork context)
            : base(context)
        {
        }

        public Customer GetByEmail(string email)
        {
            var ret = this.GetAll().FirstOrDefault(c => c.Email == email);
            return ret;
        }
    }
}
