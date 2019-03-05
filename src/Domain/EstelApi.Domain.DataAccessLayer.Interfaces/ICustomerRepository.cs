using EstelApi.Core.Entities;
using EstelApi.Core.Seedwork.Interfaces;

namespace EstelApi.Domain.DataAccessLayer.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}