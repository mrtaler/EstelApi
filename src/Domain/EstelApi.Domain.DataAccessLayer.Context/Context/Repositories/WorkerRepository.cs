namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;

    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}