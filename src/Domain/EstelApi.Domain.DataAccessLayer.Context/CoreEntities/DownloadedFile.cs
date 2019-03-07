namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using System;

    public class DownloadedFile
    {
        public Uri Source { get; set; }
        public string Destination { get; set; }
        public string ContentType { get; set; }
    }
}
