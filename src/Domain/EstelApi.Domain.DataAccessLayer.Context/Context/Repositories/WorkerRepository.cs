namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}