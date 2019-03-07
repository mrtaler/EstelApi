namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    /// <inheritdoc cref="ICountryRepository" />
    public class CountryRepository
        : Repository<Country>, ICountryRepository
    {
        /// <inheritdoc />
        public CountryRepository(IQueryableUnitOfWork context)
             : base(context)
        {
        }
    }
}