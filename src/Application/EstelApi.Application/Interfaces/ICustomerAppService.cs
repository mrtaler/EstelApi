﻿using System;
using System.Collections.Generic;
using System.Text;
using EstelApi.Application.EventSourcedNormalizers;
using EstelApi.Application.ViewModels;

namespace EstelApi.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
