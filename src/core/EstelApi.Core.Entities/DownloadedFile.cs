using System;

namespace EstelApi.Core.Entities
{
    public class DownloadedFile
    {
        public Uri Source { get; set; }
        public string Destination { get; set; }
        public string ContentType { get; set; }
    }
}
