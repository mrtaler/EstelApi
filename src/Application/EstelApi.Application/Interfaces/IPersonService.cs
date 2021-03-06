﻿namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public interface IPersonService
    {
        Task<IEnumerable<User>> GetUsers(ISpecification<User> criteria = null);
        Task<IEnumerable<Worker>> GetWorkers(ISpecification<Worker> criteria = null);

        Task<User> GetUser(ISpecification<User> criteria = null);
        Task<Worker> GetWorker(ISpecification<Worker> criteria = null);

        Task<User> CreateNewUser(CreateNewUserDto processingEntity);
        Task<Worker> CreateNewWorker(CreateNewWorkerDto processingEntity);

        Task<bool> DeleteUser(RemoveEntity<User> processingEntity);
        Task<bool> DeleteWorker(RemoveEntity<Worker> processingEntity);

        Task<User> UpdateUser(UpdateUserDto processingEntity);
        Task<Worker> UpdateWorker(UpdateWorkerDto processingEntity);
    }
}