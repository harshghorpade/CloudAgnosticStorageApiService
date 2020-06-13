// ==================================================
// Service Interface
// ==================================================

namespace CloudAgnosticStorageAPI.Models
{
    public class uploadDownloadInput
    {
        public string fileName { get; set; }
        public string storageServiceType { get; set; }
        public string signedUrl { get; set; }
    }
}
