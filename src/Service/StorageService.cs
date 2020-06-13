// ==================================================
// Service Implementation
// ==================================================

using System;
using CloudAgnosticStorageAPI.Interface;
using CloudAgnosticStorageAPI.Models;

namespace CloudAgnosticStorageAPI.Service
{
    public class StorageService : IStorageService
    {
        private IStorageRepositoryFactory _factory;

        public StorageService(IStorageRepositoryFactory factory)
        {
            _factory = factory;
        }
        public void DownloadObject(uploadDownloadInput input)
        {
            IStorageRepository storageRepo = _factory.GetStorgeRepository(input.storageServiceType);

            bool result = storageRepo.downloadFileUsingToken(input);
            if (!result)
            {
                Console.WriteLine($"ERROR : File download failed : {input.fileName}");
            }
            else
            {
                Console.WriteLine($"File download completed : {input.fileName}");
            }
        }
        public void UploadObject(uploadDownloadInput input)
        {
            IStorageRepository storageRepo = _factory.GetStorgeRepository(input.storageServiceType);
            bool result = storageRepo.uploadFileUsingToken(input);
            if (!result)
            {
                Console.WriteLine($"ERROR : File upload failed : {input.fileName}");
            }
            else
            {
                Console.WriteLine($"File upload completed : {input.fileName}");
            }
        }
    }
}
