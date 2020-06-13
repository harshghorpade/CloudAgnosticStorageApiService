// ==================================================
// Storage Repository Interface
// ==================================================

using CloudAgnosticStorageAPI.Models;

namespace CloudAgnosticStorageAPI.Interface
{
    public interface IStorageRepository
    {
        public bool downloadFileUsingToken(uploadDownloadInput input);
        public bool uploadFileUsingToken(uploadDownloadInput input);
    }
}
