// ==================================================
// Service Interface
// ==================================================

using CloudAgnosticStorageAPI.Models;

namespace CloudAgnosticStorageAPI.Interface
{
    public interface IStorageService
    {
        void DownloadObject(uploadDownloadInput input);
        void UploadObject(uploadDownloadInput input);
    }
}
