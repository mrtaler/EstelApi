namespace EstelApi.Application.AutoMapper
{
    //using EstelApi.Application.Dto;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using global::AutoMapper;

    using Serilog;

    /// <inheritdoc />
    /// <summary>
    /// The domain to dto mapping profile reverse.
    /// </summary>
    public class DomainToDtoMappingProfileReverse : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToDtoMappingProfileReverse"/> class.
        /// </summary>
        public DomainToDtoMappingProfileReverse()
        {
            Log.Debug($"AutoMapper profile {nameof(DomainToDtoMappingProfileReverse)} was launch");
         //   this.CreateMap<Customer, CustomerDto>().PreserveReferences();
        }
    }
}