﻿using System.Linq;
using EstelApi.Core.Entities;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;
using EstelApi.Domain.DataAccessLayer.Interfaces;

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
            var ret = GetAll().FirstOrDefault(c => c.Email == email);
            return ret;
        }
    }
}
