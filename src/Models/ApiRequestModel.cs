// ==================================================
// API Request Object Model
// ==================================================

namespace CloudAgnosticStorageAPI.Models
{
    public class uploadDownloadInput
    {
        // file name input for upload or download file
        public string fileName { get; set; }
        
        // storage service type option
        public string storageServiceType { get; set; }
        
        // GET or PUT Pre-signed URL
        public string signedUrl { get; set; }
    }
}
