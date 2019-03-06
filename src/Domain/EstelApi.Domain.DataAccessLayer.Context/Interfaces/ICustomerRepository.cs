using EstelApi.Core.Seedwork.CoreEntities;
using EstelApi.Core.Seedwork.Interfaces;

namespace EstelApi.Domain.DataAccessLayer.Context.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}