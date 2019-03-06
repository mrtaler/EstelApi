using System;

namespace EstelApi.Core.Seedwork.CoreEntities
{
    public class DownloadedFile
    {
        public Uri Source { get; set; }
        public string Destination { get; set; }
        public string ContentType { get; set; }
    }
}
