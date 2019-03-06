using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstelApi.Application.EventSourcedNormalizers;
using EstelApi.Application.ViewModels.Customer;

namespace EstelApi.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<CustomerViewModelApp> Register(CreateCustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModelApp> GetAll();
        CustomerViewModelApp GetById(Guid id);
        void Update(UpdateCustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
