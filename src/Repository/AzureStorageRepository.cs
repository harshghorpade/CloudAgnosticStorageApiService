// ==================================================
// Storage Repository Implementation For Azure
// ==================================================

using System;
using System.IO;
using System.Net;
using CloudAgnosticStorageAPI.Interface;
using CloudAgnosticStorageAPI.Models;

namespace CloudAgnosticStorageAPI.Repository
{
    public class AzureStorageRepository : IStorageRepository
    {
        private string path = Environment.GetEnvironmentVariable("ENV_BASE_PATH");

        public bool downloadFileUsingToken(uploadDownloadInput input)
        {
            bool result = true;
            HttpWebRequest httpRequest = WebRequest.Create(input.signedUrl) as HttpWebRequest;
            httpRequest.Method = "GET";

            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    using (Stream fileStream = new FileStream(path + input.fileName, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }

            return result;
        }
        public bool uploadFileUsingToken(uploadDownloadInput input)
        {
            bool result = false;

            HttpWebRequest httpRequest = WebRequest.Create(input.signedUrl) as HttpWebRequest;
            httpRequest.Method = "PUT";
            httpRequest.Headers["Content-Type"] = "application/octet-stream";
            // This is Azure specific header which needs to be passed while PUT request
            httpRequest.Headers["x-ms-blob-type"] = "BlockBlob";

            using (Stream dataStream = httpRequest.GetRequestStream())
            {
                using (Stream fileStream = new FileStream(path + input.fileName, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(dataStream);
                }
            }
            HttpWebResponse response = httpRequest.GetResponse() as HttpWebResponse;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = true;
            }
            return result;
        }
    }
}
