using System;
using System.Threading.Tasks;

namespace EstelApi.Domain.DataAccessLayer.Context.Interfaces
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

    public interface IFileSystemService
    {
        Task<DownloadedFile> Download(string remoteFileUrl, string localFileFullPath);
        Task<DownloadedFile> Download(Uri remoteFileUrl, string localFileFullPath);
        void Delete(string localFileFullPath);
        void Rename(string oldNameFullPath, string newNameFullPath);
        string[] GetFiles(string path, string searchPattern);
        bool Exists(string localFileFullPath);
    }
}
