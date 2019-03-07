namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CountryAgg
{
    using EstelApi.Core.Seedwork.Interfaces;

    /// <summary>
    /// Base contract for country repository
    /// </summary>
    public interface ICountryRepository
        : IRepository<Country>
    {
    }
}