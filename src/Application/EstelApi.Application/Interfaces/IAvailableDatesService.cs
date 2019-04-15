namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public interface IAvailableDatesService
    {
        Task<AvailableDates> CreateAvailableDates(CreateNewAvailableDatesDto processingEntity);

        Task<bool> DeleteAvailableDate(RemoveEntityCommand<AvailableDates> processingEntity);

        Task<AvailableDates> UpdateAvailableDate(UpdateAvailableDatesDto processingEntity);

        Task<AvailableDates> GetAvailableDate(ISpecification<AvailableDates> criteria = null);

        Task<IEnumerable<AvailableDates>> GetAvailableDates(ISpecification<AvailableDates> criteria = null);
    }
}