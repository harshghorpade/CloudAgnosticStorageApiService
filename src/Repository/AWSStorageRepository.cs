﻿// ==================================================
// Storage Repository Implementation For AWS
// ==================================================

using System;
using System.IO;
using System.Net;
using CloudAgnosticStorageAPI.Interface;
using CloudAgnosticStorageAPI.Models;

namespace CloudAgnosticStorageAPI.Repository
{
    public class AWSStorageRepository : IStorageRepository
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
                    // TBD : input file name should be correct file path where we downloaded the file
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

            using (Stream dataStream = httpRequest.GetRequestStream())
            {
                // TBD : input file name should be correct file path where we downloaded the fiel
                using (Stream fileStream = new FileStream(path + "Shaft.jt", FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(dataStream);
                }
            }
            HttpWebResponse response = httpRequest.GetResponse() as HttpWebResponse;
            
            if(response.StatusCode == HttpStatusCode.OK)
            {
                result = true;
            }
            return result;
        }
    }
}