namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using EstelApi.Core.Seedwork;

    /// <inheritdoc />
    /// <summary>
    /// Picture of customer
    /// </summary>
    public class Picture
        : EntityGuid
    {
        /// <summary>
        /// Gets or sets the raw photo.
        /// </summary>
        public byte[] RawPhoto { get; set; }
    }
}