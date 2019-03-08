namespace EstelApi.Domain.DataAccessLayer.Context.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

    /// <summary>
    /// The FileSystemService interface.
    /// </summary>
    public interface IFileSystemService
    {
        /// <summary>
        /// The download.
        /// </summary>
        /// <param name="remoteFileUrl">
        /// The remote file url.
        /// </param>
        /// <param name="localFileFullPath">
        /// The local file full path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<DownloadedFile> Download(string remoteFileUrl, string localFileFullPath);

        /// <summary>
        /// The download.
        /// </summary>
        /// <param name="remoteFileUrl">
        /// The remote file url.
        /// </param>
        /// <param name="localFileFullPath">
        /// The local file full path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<DownloadedFile> Download(Uri remoteFileUrl, string localFileFullPath);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="localFileFullPath">
        /// The local file full path.
        /// </param>
        void Delete(string localFileFullPath);

        /// <summary>
        /// The rename.
        /// </summary>
        /// <param name="oldNameFullPath">
        /// The old name full path.
        /// </param>
        /// <param name="newNameFullPath">
        /// The new name full path.
        /// </param>
        void Rename(string oldNameFullPath, string newNameFullPath);

        /// <summary>
        /// The get files.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="searchPattern">
        /// The search pattern.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string[] GetFiles(string path, string searchPattern);

        /// <summary>
        /// The exists.
        /// </summary>
        /// <param name="localFileFullPath">
        /// The local file full path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Exists(string localFileFullPath);
    }
}
