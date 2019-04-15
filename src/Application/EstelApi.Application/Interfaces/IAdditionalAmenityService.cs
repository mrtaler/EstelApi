namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public interface IAdditionalAmenityService
    {
        Task<AdditionalAmenity> CreateAdditionalAmenity(CreateNewAdditionalAmenityDto processingEntity);

        Task<bool> DeleteAdditionalAmenity(RemoveEntityCommand<AdditionalAmenity> processingEntity);

        Task<AdditionalAmenity> UpdateAdditionalAmenity(UpdateAdditionalAmenityDto processingEntity);

        Task<AdditionalAmenity> GetAdditionalAmenity(ISpecification<AdditionalAmenity> criteria = null);

        Task<IEnumerable<AdditionalAmenity>> GetAdditionalAmenities(ISpecification<AdditionalAmenity> criteria = null);
    }
}