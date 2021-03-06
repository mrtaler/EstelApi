﻿namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;

    public class AdditionalAmenityRepository : Repository<AdditionalAmenity>, IAdditionalAmenityRepository
    {
        public AdditionalAmenityRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}