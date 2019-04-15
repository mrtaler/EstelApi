namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;

    public class AvailableDatesRepository : Repository<AvailableDates>, IAvailableDatesRepository
    {
        public AvailableDatesRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}