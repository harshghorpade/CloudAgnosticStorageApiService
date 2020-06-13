// ==================================================
// Upload and Download API Controller
// ==================================================

using Microsoft.AspNetCore.Mvc;
using CloudAgnosticStorageAPI.Models;
using CloudAgnosticStorageAPI.Interface;

namespace CloudAgnosticStorageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CloudStorageController : ControllerBase
    {
        IStorageService _service;

        public CloudStorageController(IStorageService service)
        {
            _service = service;
        }

        [HttpPost("download")]
        public void Download([FromBody] uploadDownloadInput input)
        {
            if (ModelState.IsValid)
            {
                _service.DownloadObject(input);
            }
        }

        [HttpPost("upload")]
        public void Upload([FromBody] uploadDownloadInput input)
        {
            if (ModelState.IsValid)
            {
                _service.UploadObject(input);
            }
        }
    }
}
