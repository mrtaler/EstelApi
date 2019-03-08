namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using System;

    /// <summary>
    /// The downloaded file.
    /// </summary>
    public class DownloadedFile
    {
        public Uri Source { get; set; }
        public string Destination { get; set; }
        public string ContentType { get; set; }
    }
}
