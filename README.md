# CloudAgnosticStorageApiService
Cloud Agnostic Upload/Download APIs using Pre-signed URLs (AWS, Azure, Google Cloud). This code demonstrates how to use Pre-signed URLs offered by majority of cloud providers, includes upload and download REST APIs which accepts pre-signed URLs and consume them to upload and download any file from local machine to cloud storage of our choice (AWS, Azure, GCP).
Note : Code is not production ready, there are lots of things needs to be consider for making use of it in production (mainly security).

## Prerequisite
1] Accounts created in AWS, Microsoft Azure and Google Cloud Platform. They all provide free evaluation period, so if you don't have one, then create quickly

2] Visual Studio 2019 with .NET Core 3.1 installed.

3] AWS Toolkit for Visual Studio 2019.

4] Google Cloud Platform Latest SDK

## Steps to setup for local debugging
1] Clone the repository and open the solution file in Visual Studio 2019.

2] For local debugging need to set the path where you would like to download or upload from files to cloud storage. That path can be set under /properties/launchSettings.json under ENV_BASE_PATH environment variable.

3] For local debugging start the debugger from Visual Studio (by hitting F5 key).

4] Before calling APIs need to have pre-signed URLs handy, check post in following link for how to generate Pre-signed URLs.
https://www.linkedin.com/pulse/cloud-agnostic-uploaddownload-apis-using-pre-signed-urls-ghorpade

5] Using Postman hit the following URL download [POST http://localhost:5000/api/cloudstorage/download] and for upload [POST http://localhost:5000/api/cloudstorage/upload], with supported storageServiceType values would be "AWS", "Azure", "GCP"

6] On successful upload/download request will get 200 ok response.
