namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
    using EstelApi.Application.Dto;
    using EstelApi.Application.Services;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    public class PersonService : BaseService, IPersonService
    {
        private readonly IUserRepository userRepository;

        private readonly IWorkerRepository workerRepository;

        public PersonService(
            IQueryableUnitOfWork uow,
            IUserRepository userRepository,
            IWorkerRepository workerRepository)
            : base(uow)
        {
            this.userRepository = userRepository;
            this.workerRepository = workerRepository;
        }

        public async Task<IEnumerable<User>> GetUsers(ISpecification<User> criteria = null)
        {
            var ret = this.userRepository.AllMatching(includes: new UserInclude());
            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<Worker>> GetWorkers(ISpecification<Worker> criteria = null)
        {
            var ret = this.workerRepository.AllMatching(includes: new WorkerInclude());
            return await Task.FromResult(ret);
        }

        public async Task<User> GetUser(ISpecification<User> criteria = null)
        {
            var ret = this.userRepository.OneMatching(
                filter: criteria,
                includes: new UserInclude());

            return await Task.FromResult(ret);
        }

        public async Task<Worker> GetWorker(ISpecification<Worker> criteria = null)
        {
            var ret = this.workerRepository.OneMatching(
                filter: criteria,
                includes: new WorkerInclude());

            return await Task.FromResult(ret);
        }

        public async Task<User> CreateNewUser(CreateNewUserDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);
            var entity = processingEntity.ProjectedAs<User>();
            this.userRepository.Add(entity);
            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<Worker> CreateNewWorker(CreateNewWorkerDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);
            var entity = processingEntity.ProjectedAs<Worker>();
            this.workerRepository.Add(entity);
            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<bool> DeleteUser(RemoveEntityCommand<User> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.userRepository.OneMatching(new FindUserById().SetId(processingEntity.Id));
            this.userRepository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        public async Task<bool> DeleteWorker(RemoveEntityCommand<Worker> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.workerRepository.OneMatching(new FindWorkerById().SetId(processingEntity.Id));
            this.workerRepository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        public async Task<User> UpdateUser(UpdateUserDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<User>();
            this.userRepository.Modify(entity);
            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<Worker> UpdateWorker(UpdateWorkerDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<Worker>();
            this.workerRepository.Modify(entity);
            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }
    }
}